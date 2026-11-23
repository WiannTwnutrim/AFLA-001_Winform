using TwinCAT.Ads;

namespace AFLA_001
{
    // 管理 PLC 連線、點位 handle 及 ADS 讀寫。
    public static class AdsService
    {
        // 背景 EC 輪詢與其他 ADS 讀寫共用同一把鎖，避免連線或 handle 在使用中被釋放。
        private static readonly object clientLock = new();
        private const int DefaultPort = 851;
        private const int WrLength = 1651;

        // PLC 的 GVL.EC 為 ARRAY[0..461] OF LREAL，CSV 的 Index 直接對應陣列索引。
        internal const int EcLength = 462;
        // 動作命令的 Index 對應 PLC 寫入點位名稱，設定在 ADS 重連時保留。
        private static Dictionary<int, string> actionWriteLabels = new();
        private static AdsClient? ads;
        // 整組 GVL.EC 共用一個 handle，其有效期與目前的 ADS 連線相同。
        private static uint diHandle, doHandle, wrHandle, ecHandle;

        // 保存最近一次讀回的 DI、DO 值，長度需符合 PLC 宣告。
        public static bool[] DI { get; private set; } = new bool[24];
        public static bool[] DO { get; private set; } = new bool[36];

        //volatile 關鍵字用於標示一個欄位（field）可能由多個同時執行的執行緒存取或修改
        public static volatile short[]? LatestWr;
        public static volatile bool[]? LatestMotionStates;
        //鋸齒狀陣列,一個陣列，裡面的每個元素又是一個陣列
        public static volatile bool[][]? LatestWrBits;

        //程式開啟時它是 false，關閉時把它改成 true，背景讀取就會停下來
        private static volatile bool stopWrPolling = false;

        // 載入 ActionCommands.csv 的動作寫入對應，供 WriteAction 使用。
        internal static void ConfigureActionWrites(IReadOnlyList<Motion> motions)
        {
            var labels = motions.ToDictionary(motion => motion.Index, motion => motion.Writelabel);
            lock (clientLock)
            {
                actionWriteLabels = labels;
            }
        }

        // 建立 ADS 連線，讀取所需的 handle 在首次使用時建立。
        public static void Connection()
        {
            lock (clientLock)
            {
                if (ads != null)
                    throw new InvalidOperationException("ADS 已初始化。");

                var client = new AdsClient();
                try
                {
                    string? netId = Environment.GetEnvironmentVariable("PLC_AMS_NET_ID");
                    int port = int.TryParse(Environment.GetEnvironmentVariable("PLC_ADS_PORT"), out int configuredPort)
                        ? configuredPort : DefaultPort;
                    if (string.IsNullOrWhiteSpace(netId))
                        client.Connect(port);
                    else
                        client.Connect(netId, port);
                    ads = client;
                }
                // 初始化中途失敗時，清理已建立的 handle 和連線。
                catch
                {
                    Release(client);
                    throw;
                }
            }
        }

        /// <summary>
        /// 整組讀取 WR。PLC INT 對應 C# short
        /// </summary>
        /// <returns></returns>
        public static short[] ReadAction()
        {
            lock (clientLock)
            {
                var client = GetClient();
                if (wrHandle == 0)
                    wrHandle = client.CreateVariableHandle("GVL.WR");

                return (short[])client.ReadAny(
                    wrHandle, typeof(short[]), new[] { WrLength });
            }
        }
        /// <summary>
        /// 讀回.1的bool陣列,所有動作中的狀態(750之前)
        /// </summary>
        /// <param name="wr"></param>
        /// <returns></returns>
        public static bool[] ReadMotionStates(short[] wr)
        {

            var states = new bool[750];//只處理0-749

            // 1 << 1 把 1 左移一位，得到二進位 0010
            //bit 1是1的回傳true
            for (int i = 0; i < states.Length; i++)
            {
                states[i] = (wr[i] & (1 << 1)) != 0;
            }


            return states;
        }

        /// <summary>
        /// 讀到後要拆成 16 個 bit 的 bool 陣列
        /// </summary>
        /// <param name="wr"></param>
        /// <param name="motionStates"></param>
        /// <returns></returns>
        private static bool[][] SplitWrBits(short[] wr, bool[] motionStates)
        {
            var bits = new bool[wr.Length][];

            for (int i = 0; i < wr.Length; i++)
            {
                //幫這一筆 WR 建立 16 格，分別放 .0 到 .15
                bits[i] = new bool[16];

                for (int bit = 0; bit < 16; bit++)
                {
                    //bit且這筆 WR 在前 750 筆內
                    if (bit == 1 && i < motionStates.Length)
                        //例如把 motionStates[142] 放進 bits[142][1]。
                        bits[i][bit] = motionStates[i];
                    else
                        bits[i][bit] = (wr[i] & (1 << bit)) != 0;
                }
            }

            return bits;
        }



        /// <summary>
        /// 讀一次 PLC，把最新的 WR 資料存起來
        /// </summary>
        private static void RefreshWr()
        {
            short[] wr = ReadAction();  // 每輪只向 PLC 讀一次
            bool[] states = ReadMotionStates(wr);

            //把值存到AdsService 的欄位
            LatestWrBits = SplitWrBits(wr, states);
            LatestMotionStates = states;
            LatestWr = wr;
        }



        /// <summary>
        /// 依 Index 找到「PC寫入」點位，每次按下都送出 TRUE。
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void WriteAction(int index)
        {
            lock (clientLock)
            {
                if (!actionWriteLabels.TryGetValue(index, out string? writeLabel))
                    throw new ArgumentOutOfRangeException(nameof(index), index, "找不到 CSV 命令索引。");

                //WriteValue:用名稱指定目標,原先使用WriteAny(handle, true) 是用 handle 指定目標
                GetClient().WriteValue(writeLabel, true);
            }
        }

        /// <summary>
        /// 先讀一次 WR，再等下一個 100 ms 的時間點，然後繼續讀
        /// </summary>
        /// <returns></returns>
        public static async Task PollWrAsync()
        {
            using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(100));

            while (!stopWrPolling)
            {
                try
                {
                    RefreshWr(); // 讀取並儲存這一輪的 WR
                }
                catch (Exception ex)
                {
                    Loghelper.Error($"WR 讀取失敗：{ex.Message}");
                }

                await timer.WaitForNextTickAsync();
            }
        }

        public static void StopWrPolling()
        {
            stopWrPolling = true;
        }

        /// <summary>
        /// 透過 ecHandle 一次讀取整組 GVL.EC。PLC 的 LREAL 對應 C# double。
        /// </summary>
        /// <returns>本次讀取的陣列快照，供 Manual 按 CSV Index 顯示。</returns>
        public static double[] ReadEc()
        {
            lock (clientLock)
            {
                var client = GetClient();
                if (ecHandle == 0)
                    ecHandle = client.CreateVariableHandle("GVL.EC");

                return (double[])client.ReadAny(
                    ecHandle, typeof(double[]), new[] { EcLength });
            }
        }


        // Manual 依 CSV Index 取得寫入符號。寫入目標是 PLC 參數符號，EC 畫面值來自啟動時的快照。
        internal static void WriteManualValue(ECclass point, int value)
        {
            lock (clientLock)
            {
                // 使用符號型別封送數值，EC 的 LREAL 型別只適用於讀取陣列。
                GetClient().WriteValue(point.WriteEC, (object)value);
            }
        }

        // 讀回 DI、DO 陣列供 I/O 畫面使用。
        public static void Read()
        {
            lock (clientLock)
            {
                var client = GetClient();
                if (diHandle == 0)
                    diHandle = client.CreateVariableHandle("GVL_IO.DI");
                if (doHandle == 0)
                    doHandle = client.CreateVariableHandle("GVL_IO.DOO");

                DI = (bool[])client.ReadAny(diHandle, typeof(bool[]), new[] { DI.Length });
                DO = (bool[])client.ReadAny(doHandle, typeof(bool[]), new[] { DO.Length });
            }
        }

        // 先讀整組 DO，修改指定元素後再整組寫回。
        public static void Write(int index, bool value)
        {
            lock (clientLock)
            {
                if (index < 0 || index >= DO.Length)
                    throw new ArgumentOutOfRangeException(nameof(index));

                var client = GetClient();
                if (doHandle == 0)
                    doHandle = client.CreateVariableHandle("GVL_IO.DOO");

                var outputs = (bool[])client.ReadAny(doHandle, typeof(bool[]), new[] { DO.Length });
                outputs[index] = value;
                client.WriteAny(doHandle, outputs);
                DO = outputs;
            }
        }

        // 程式結束時釋放本次連線的 ADS 資源。
        public static void Shutdown()
        {
            lock (clientLock)
            {
                if (ads is AdsClient client)
                {
                    ads = null;
                    Release(client);
                }
            }
        }

        // 讀寫前確認 ADS 已完成初始化。
        private static AdsClient GetClient()
        {
            return ads ?? throw new InvalidOperationException("請先初始化 ADS 連線。");
        }

        // 釋放已建立的 handle 並關閉 ADS client。
        private static void Release(AdsClient client)
        {
            try
            {
                // 先釋放 EC 的 PLC handle，再關閉 ADS 連線。
                if (ecHandle != 0) client.TryDeleteVariableHandle(ecHandle);
                if (wrHandle != 0) client.TryDeleteVariableHandle(wrHandle);
                if (doHandle != 0) client.TryDeleteVariableHandle(doHandle);
                if (diHandle != 0) client.TryDeleteVariableHandle(diHandle);
            }
            finally
            {
                // 下次連線須重新取得 EC handle
                //釋放handle
                diHandle = doHandle = wrHandle = ecHandle = 0;
                client.Dispose();
            }
        }
    }
}

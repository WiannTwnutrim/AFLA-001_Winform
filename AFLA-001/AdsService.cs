using TwinCAT.Ads;

namespace AFLA_001
{
    // 管理 PLC 連線、點位 handle 及 ADS 讀寫。
    public static class AdsService
    {
        // 背景 EC 輪詢與其他 ADS 讀寫共用同一把鎖，避免連線或 handle 在使用中被釋放。
        private static readonly object clientLock = new();
        private const int WrLength = 1651;

        // PLC 的 GVL.EC 為 ARRAY[0..460] OF LREAL，CSV 的 Index 直接對應陣列索引。
        internal const int EcLength = 461;
        // 動作命令的 Index 對應 PLC 寫入點位名稱，設定在 ADS 重連時保留。
        private static Dictionary<int, string> actionWriteLabels = new();
        private static AdsClient? ads;
        // 整組 GVL.EC 共用一個 handle，其有效期與目前的 ADS 連線相同。
        private static uint  wrHandle, ecHandle;

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


        /// <summary>
        /// 建立 ADS 連線，讀取所需的 handle 在首次使用時建立。
        /// ip跟port目前以UmRT_Default使用
        /// </summary>
        /// <param name="netId"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool Connection(string netId, int port)
        {
            lock (clientLock)
            {
                if (ads != null)
                {
                    Loghelper.Error("ADS 已初始化。");
                    return false;
                }

                AdsClient? client = null;
                try
                {
                    client = new AdsClient();
                    client.Connect(netId, port);
                    ads = client;
                    return true;
                }
                // 初始化中途失敗時，清理已建立的 handle 和連線。
                catch (Exception ex)
                {
                    Loghelper.Error($"無法連線 PLC ADS：{ex.ToString()}");
                    if (client != null)
                    {
                        try
                        {
                            Release(client);
                        }
                        catch (Exception cleanupError)
                        {
                            Loghelper.Error($"無法釋放 ADS 資源：{cleanupError.ToString()}");
                        }
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// 整組讀取 WR。PLC INT 對應 C# short
        /// </summary>
        /// <returns></returns>
        public static short[] ReadAction(string label)
        {
            lock (clientLock)
            {
                var client = ads;
  

                if (wrHandle == 0)
                    wrHandle = client.CreateVariableHandle(label);

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
        /// <param name="wr">讀回的整個wr</param>
        /// <param name="motionStates">wr[750]以前的</param>
        /// <returns></returns>
        private static bool[][] SplitWrBits(short[] wr, bool[] motionStates)
        {
            //建立外層陣列,每個 WR 元素各占一格
            var bits = new bool[wr.Length][];

            for (int i = 0; i < wr.Length; i++)
            {
                
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
            short[]? wr = ReadAction("GVL.WR");  // 每輪只向 PLC 讀一次
            if (wr == null)
                return;

            bool[] states = ReadMotionStates(wr);

            //把值存到AdsService 的欄位
            LatestWrBits = SplitWrBits(wr, states);
            LatestMotionStates = states;
            LatestWr = wr;
        }
        /// <summary>
        /// 兩個int組成double
        /// </summary>
        /// <param name="lowWord"></param>
        /// <param name="highWord"></param>
        /// <returns></returns>
        public static double WrIntToDouble(short lowWord, short highWord)
        {
            //lowWord & 0xFFFF 避免蓋掉高位元的
            int bits = (lowWord & 0xFFFF) | ((highWord ) << 16);
            return BitConverter.Int32BitsToSingle(bits);
        }

        /// <summary>
        /// 依 Index 找到「PC寫入」點位，每次按下都送出 TRUE。
        /// </summary>
        /// <param name="index"></param>
        public static void WriteAction(int index)
        {
            lock (clientLock)
            {
                if (!actionWriteLabels.TryGetValue(index, out string? writeLabel))
                {
                    Loghelper.Error($"找不到 CSV 命令索引：{index}");
                    return;
                }

                var client = ads;
                if (client == null)
                {
                    Loghelper.Error($"無法寫入動作點位 {index}：請先初始化 ADS 連線。");
                    return;
                }

                //WriteValue:用名稱指定目標,原先使用WriteAny(handle, true) 是用 handle 指定目標
                try
                {
                    client.WriteValue(writeLabel, true);
                }
                catch (Exception ex)
                {
                    Loghelper.Error($"ADS 寫入失敗：{ex.ToString()}");
                }
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
                    Loghelper.Error($"WR 讀取失敗：{ex.ToString()}");
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
        public static double[]? ReadEc()
        {
            lock (clientLock)
            {
                var client = ads;
                if (client == null)
                {
                    Loghelper.Error("無法讀取 PLC EC：請先初始化 ADS 連線。");
                    return null;
                }

                if (ecHandle == 0)
                    ecHandle = client.CreateVariableHandle("GVL.EC");

                return (double[])client.ReadAny(
                    ecHandle, typeof(double[]), new[] { EcLength });
            }
        }


        // Manual 依 CSV Index 取得寫入符號。寫入目標是 PLC 參數符號，EC 畫面值來自啟動時的快照。
        internal static void WriteManualValue(ECclass point, double value)
        {
            lock (clientLock)
            {
                var client = ads;
                if (client == null)
                {
                    Loghelper.Error($"無法寫入 Manual 點位 {point.WriteEC}：請先初始化 ADS 連線。");
                    return;
                }

                // 使用符號型別封送數值，EC 的 LREAL 型別只適用於讀取陣列。
                client.WriteValue(point.WriteEC, (object)value);
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

        // 釋放已建立的 handle 並關閉 ADS client。
        private static void Release(AdsClient client)
        {
            try
            {
                // 先釋放 EC 的 PLC handle，再關閉 ADS 連線。
                if (ecHandle != 0) client.TryDeleteVariableHandle(ecHandle);
                if (wrHandle != 0) client.TryDeleteVariableHandle(wrHandle);
            }
            finally
            {
                // 下次連線須重新取得 EC handle
                //釋放handle
                wrHandle = ecHandle = 0;
                client.Dispose();
            }
        }
    }
}

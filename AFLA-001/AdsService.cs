using Microsoft.VisualBasic.FileIO;
using TwinCAT.Ads;

namespace AFLA_001
{
    // 管理 PLC 連線、點位 handle 及 ADS 讀寫。
    public static class AdsService
    {
        // 以 AMS Net ID 和 ADS 埠指定目標 PLC Runtime。
        private const string AdsId = "199.4.42.250.1.1";
        private const int PortId = 851;
        // WR 的 PLC 宣告為 ARRAY[0..1650] OF INT，共 1651 筆。
        private const int WrLength = 1651;
        // 以 CSV 的 Index 對應命令點位的 handle。
        private static readonly Dictionary<int, uint> writeHandles = new();
        private static AdsClient? ads;
        // DI、DO 和 WR 各使用一個整組陣列的 handle。
        private static uint diHandle, doHandle, wrHandle;

        // 保存最近一次讀回的 DI、DO 值，長度需符合 PLC 宣告。
        public static bool[] DI { get; private set; } = new bool[24];
        public static bool[] DO { get; private set; } = new bool[36];

        // 啟動時載入命令設定並建立本次連線所需的 handle。
        public static void Connection(string? commandCsvPath = null)
        {
            if (ads != null)
                throw new InvalidOperationException("ADS 已初始化。");

            // 先驗證 CSV，再連線 PLC。
            var commands = commandCsvPath == null ? null : LoadCommands(commandCsvPath);
            var client = new AdsClient();
            try
            {
                client.Connect(AdsId, PortId);
                diHandle = client.CreateVariableHandle("GVL_IO.DI");
                doHandle = client.CreateVariableHandle("GVL_IO.DOO");
                wrHandle = client.CreateVariableHandle("GVL.WR");

                if (commands != null)
                {
                    foreach (var command in commands)
                    {
                        // 以「PC寫入」欄位建立單點 handle，供後續用 Index 查找。
                        uint handle = client.CreateVariableHandle(command.Value);
                        writeHandles.Add(command.Key, handle);
                    }
                }

                ads = client;
            }
            // 初始化中途失敗時，清理已建立的 handle 和連線。
            catch
            {
                Release(client);
                throw;
            }
        }

        // 整組讀取 WR。PLC INT 對應 C# short
        public static short[] ReadAction()
        {
            return (short[])GetClient().ReadAny(
                wrHandle, typeof(short[]), new[] { WrLength });
        }

        //讀回.1的陣列
        public static bool[] ReadMotionStates()
        {
            short[] wr = ReadAction(); // ADS 只讀一次，取得整組 WR
            var states = new bool[wr.Length];

            const int motionBit = 1 << 1; // PLC 的 .1

            for (int index = 0; index < wr.Length; index++)
            {
                states[index] = (wr[index] & motionBit) != 0;
            }

            return states;
        }
        // 依 Index 找到「PC寫入」點位，每次按下都送出 TRUE。
        public static void WriteAction(int index)
        {
            if (!writeHandles.TryGetValue(index, out uint handle))
                throw new ArgumentOutOfRangeException(nameof(index), index, "找不到 CSV 命令索引。");

            GetClient().WriteAny(handle, true);
        }

        // PC寫入是命令點位。PC讀保留 WR 狀態對應供查閱，狀態由 ReadMotionStates 讀取。
        private static Dictionary<int, string> LoadCommands(string path)
        {
            using var parser = new TextFieldParser(path);
            parser.SetDelimiters(",");

            string[]? header = parser.ReadFields();
            if (header == null || !header.SequenceEqual(
                    new[] { "Index", "PC寫入", "PC讀" }, StringComparer.OrdinalIgnoreCase))
            {
                throw new FormatException("功能 CSV 欄位須依序為 Index,PC寫入,PC讀。");
            }

            var commands = new Dictionary<int, string>();
            while (!parser.EndOfData)
            {
                long line = parser.LineNumber;
                string[]? fields = parser.ReadFields();
                if (fields == null || fields.Length != 3 ||
                    !int.TryParse(fields[0], out int index) || index < 0 ||
                    string.IsNullOrWhiteSpace(fields[1]))
                {
                    throw new FormatException($"功能 CSV 第 {line} 列的索引或命令點位無效。");
                }

                if (!commands.TryAdd(index, fields[1]))
                    throw new FormatException($"功能 CSV 第 {line} 列的 Index {index} 重複。");
            }

            return commands;
        }


        // 讀回 DI、DO 陣列供 I/O 畫面使用。
        public static void Read()
        {
            var client = GetClient();
            DI = (bool[])client.ReadAny(diHandle, typeof(bool[]), new[] { DI.Length });
            DO = (bool[])client.ReadAny(doHandle, typeof(bool[]), new[] { DO.Length });
        }

        // 先讀整組 DO，修改指定元素後再整組寫回。
        public static void Write(int index, bool value)
        {
            if (index < 0 || index >= DO.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            var client = GetClient();
            var outputs = (bool[])client.ReadAny(doHandle, typeof(bool[]), new[] { DO.Length });
            outputs[index] = value;
            client.WriteAny(doHandle, outputs);
            DO = outputs;
        }

        // 程式結束時釋放本次連線的 ADS 資源。
        public static void Shutdown()
        {
            if (ads is AdsClient client)
            {
                ads = null;
                Release(client);
            }
        }

        // 讀寫前確認 ADS 已完成初始化。
        private static AdsClient GetClient()
        {
            return ads ?? throw new InvalidOperationException("請先初始化 ADS 連線。");
        }

        // 釋放已建立的 handle，清除本機對應並關閉 ADS client。
        private static void Release(AdsClient client)
        {
            try
            {
                foreach (uint handle in writeHandles.Values)
                    client.TryDeleteVariableHandle(handle);
                if (wrHandle != 0) client.TryDeleteVariableHandle(wrHandle);
                if (doHandle != 0) client.TryDeleteVariableHandle(doHandle);
                if (diHandle != 0) client.TryDeleteVariableHandle(diHandle);
            }
            finally
            {
                writeHandles.Clear();
                diHandle = doHandle = wrHandle = 0;
                client.Dispose();
            }
        }
    }
}

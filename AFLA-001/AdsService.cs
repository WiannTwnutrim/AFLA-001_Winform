using System;
using TwinCAT.Ads;

namespace AFLA_001
{
    // 修改：只保留基本步驟：連線 → 建立 Handle → 讀寫 → 結束時釋放。
    public static class AdsService
    {
        private static AdsClient ads = new AdsClient();
        private static string adsId = "199.4.42.250.1.1";
        private static int portId = 851;
        private static uint diHandle, doHandle;
        private static uint toHmi6Handle;
        public static bool[] DI { get; private set; } = new bool[24];
        public static bool[] DO { get; private set; } = new bool[36];

        public static ushort readHmi;

        // 不要每次讀寫都重新連線、建立 Handle。
        public static void Connection()
        {
            ads.Connect(adsId, portId);
            //取得plc識別碼
            diHandle = ads.CreateVariableHandle("GVL_IO.DI");
            doHandle = ads.CreateVariableHandle("GVL_IO.DOO");
            toHmi6Handle = ads.CreateVariableHandle("GVL.toHMI[6]");
            //forHmi6Handle = ads.CreateVariableHandle("GVL.forHMI[6]");
        }

        public static void Read()
        {
            // 用陣列本身的長度讀取，避免宣告長度與讀取長度不同。
            DI = (bool[])ads.ReadAny(diHandle, typeof(bool[]), new int[] { DI.Length });
            DO = (bool[])ads.ReadAny(doHandle, typeof(bool[]), new int[] { DO.Length });
        }

        // 修改：指定要改的輸出，例如 Write(0, true)，索引從 0 開始。
        public static void Write(int index, bool value)
        {
            if (index < 0 || index >= DO.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            DO = (bool[])ads.ReadAny(doHandle, typeof(bool[]), new int[] { DO.Length });
            DO[index] = value;
            ads.WriteAny(doHandle, DO);
            // 這裡是整組寫回；若 PLC 也會改同一組 DO，需另設單點寫入。
        }

        public static void ReadAction()
        {
            readHmi = (ushort)ads.ReadAny(toHmi6Handle, typeof(ushort));

            bool reset = (readHmi & (1 << 0)) != 0; // GVL.toHMI[6].0
            bool buzzerOff = (readHmi & (1 << 1)) != 0; // GVL.toHMI[6].1
            bool doorBypass = (readHmi & (1 << 2)) != 0; // GVL.toHMI[6].2
            bool stop = (readHmi & (1 << 3)) != 0; // GVL.toHMI[6].3
            bool Start = (readHmi & (1 << 4)) != 0; // GVL.toHMI[6].4
            bool ManMov = (readHmi & (1 << 5)) != 0; // GVL.toHMI[6].5
            bool AutoMov = (readHmi & (1 << 6)) != 0; // GVL.toHMI[6].6
            bool InitMov = (readHmi & (1 << 7)) != 0; // GVL.toHMI[6].7
            bool ProcessMov = (readHmi & (1 << 8)) != 0; // GVL.toHMI[6].8
            bool VacuumOnMov = (readHmi & (1 << 9)) != 0; // GVL.toHMI[6].9
            bool VacuumOffMov = (readHmi & (1 << 10)) != 0; // GVL.toHMI[6].10
            bool InjectionIPAMon = (readHmi & (1 << 11)) != 0; // GVL.toHMI[6].11
            bool InjectionOILMon = (readHmi & (1 << 12)) != 0; // GVL.toHMI[6].12
            bool InjectionGlueMon = (readHmi & (1 << 13)) != 0; // GVL.toHMI[6].13
            bool BackOILMon = (readHmi & (1 << 14)) != 0; // GVL.toHMI[6].14
            bool BackAIRMon = (readHmi & (1 << 15)) != 0; // GVL.toHMI[6].15
        }

        public static void WriteAction()
        {
            ads.WriteAny(toHmi6Handle, readHmi);
        }

        // 程式結束時呼叫一次，不要在 Read、Write 裡釋放 Client。
        public static void Shutdown()
        {
            try
            {
                // TryDelete：PLC 已斷線時，也繼續嘗試清理另一個 Handle。
                if (diHandle != 0) ads.TryDeleteVariableHandle(diHandle);
                if (doHandle != 0) ads.TryDeleteVariableHandle(doHandle);
                if (toHmi6Handle != 0) ads.TryDeleteVariableHandle(toHmi6Handle);
            }
            finally
            {
                diHandle = 0;
                doHandle = 0;
                toHmi6Handle = 0;
                ads.Dispose();
            }
        }
    }
}

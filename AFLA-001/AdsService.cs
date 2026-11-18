using System;
using TwinCAT.Ads;

namespace AFLA_001
{
    // 修改：只保留基本步驟：連線 → 建立 Handle → 讀寫 → 結束時釋放。
    public class AdsService : IDisposable
    {
        private AdsClient ads = new AdsClient();
        private string adsId = "199.4.42.250.1.1";
        private int portId = 851;
        private uint diHandle, doHandle;

        public bool[] DI { get; private set; } = new bool[24];
        public bool[] DO { get; private set; } = new bool[36];

        // 不要每次讀寫都重新連線、建立 Handle。
        public void Connection()
        {
            ads.Connect(adsId, portId);
            //取得plc識別碼
            diHandle = ads.CreateVariableHandle("GVL_IO.DI");
            doHandle = ads.CreateVariableHandle("GVL_IO.DOO"); 
        }

        public void Read()
        {
            // 用陣列本身的長度讀取，避免宣告長度與讀取長度不同。
            DI = (bool[])ads.ReadAny(diHandle, typeof(bool[]), new int[] { DI.Length });
            DO = (bool[])ads.ReadAny(doHandle, typeof(bool[]), new int[] { DO.Length });
        }

        // 修改：指定要改的輸出，例如 Write(0, true)，索引從 0 開始。
        public void Write(int index, bool value)
        {
            if (index < 0 || index >= DO.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            DO = (bool[])ads.ReadAny(doHandle, typeof(bool[]), new int[] { DO.Length });
            DO[index] = value;
            ads.WriteAny(doHandle, DO);
            // 這裡是整組寫回；若 PLC 也會改同一組 DO，需另設單點寫入。
        }

        // 程式結束時呼叫一次，不要在 Read、Write 裡釋放 Client。
        public void Dispose()
        {
            try
            {
                // TryDelete：PLC 已斷線時，也繼續嘗試清理另一個 Handle。
                if (diHandle != 0) ads.TryDeleteVariableHandle(diHandle);
                if (doHandle != 0) ads.TryDeleteVariableHandle(doHandle);
            }
            finally
            {
                diHandle = 0;
                doHandle = 0;
                ads.Dispose();
            }
        }
    }
}

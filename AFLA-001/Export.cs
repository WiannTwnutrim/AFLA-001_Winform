using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFLA_001
{
    /// <summary>
    /// 輸出類別(傳入dataGridView)
    /// </summary>
    public static class Export
    {   
        /// <summary>
        /// 輸出excel
        /// </summary>
        /// <param name="dataGridView">哪個表</param>
        /// <param name="DataName">檔名</param>
        public static void ExportCSV(DataGridView dataGridView,string DataName)
        {
            //來讓使用者選擇檔案儲存的路徑與檔名。它只負責取得路徑與檔名
            SaveFileDialog data = new SaveFileDialog();

            //，決定對話框中「另存為檔案類型」或「類型檔案」欄位中出現的選項。
            data.Filter = "CSV 檔案 (*.csv)|*.csv";

            data.FileName =$"{DateTime.Now.ToString("yyyy/MM/dd")}  {DataName}" ;//檔名(stirng)
            if (data.ShowDialog() != DialogResult.OK)
                    //使用者在對話框要傳回ok
            {
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();

            //寫欄位
            for(int i = 0; i < dataGridView.Columns.Count; i++)
            {
                //Append:加入結尾,把欄位顯示在畫面上的標題加入
                //dataGridView.Columns[i].name是欄位在程式內使用的名稱，用來識別欄位
                stringBuilder.Append(dataGridView.Columns[i].HeaderText);
                //寫一個欄位後加,
                if (i < dataGridView.Columns.Count - 1)
                    stringBuilder.Append(",");
            }
                stringBuilder.AppendLine();//加完標題換行

            // 2. 寫入每一列資料
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // 跳過 DataGridView 最下面新增資料用的空白列
                if (row.IsNewRow)
                    continue;

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    string value = row.Cells[i].Value?.ToString() ?? "";

                    stringBuilder.Append(value);

                    if (i < dataGridView.Columns.Count - 1)
                        stringBuilder.Append(",");
                }

                stringBuilder.AppendLine();
            }

            // 3. 寫入 CSV
            //建立一個新檔案，使用指定的編碼寫入指定的字串，然後關閉該檔案。
            //如果目標檔案已經存在，則會遭到截斷並覆寫
            //參數:(路徑,內容,編碼)
            File.WriteAllText(
                data.FileName,
                stringBuilder.ToString(),
                Encoding.UTF8
            );

            MessageBox.Show("CSV 匯出完成");
        }
    }
}

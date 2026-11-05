using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFLA_001
{
    public partial class ManualForm : Form
    {
        // 從 bin\Debug 或 bin\Release 下的目標框架目錄往上三層，回到專案根目錄。
        private readonly string manualDataPath = Path.GetFullPath(
            // 以執行檔目錄為起點，往上三層再接上 CSV 檔名。
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "manual for winform.csv"));
        public ManualForm()
        {

            InitializeComponent();
            // 表單首次載入時讀取 CSV。
            Load += ManualForm_Load;

            // 固定資料列數，讓操作員編輯現有資料並手動儲存。

            // 隱藏新增列，讓操作員編輯現有資料。
            manualdata.AllowUserToAddRows = false;
            // 建立儲存按鈕。
            var saveButton = new Button
            {
                // 設定按鈕顯示文字。
                Text = "儲存",
                // 將按鈕放在表格左側上方 37 像素。
                Location = new Point(manualdata.Left, manualdata.Top - 37),
                // 設定按鈕寬 100、高 30 像素。
                Size = new Size(100, 30),
                // 載入完成前先停用儲存按鈕。
                Enabled = false
            };
            // 點擊時呼叫存檔方法。
            saveButton.Click += SaveManualData_Click;
            // 把按鈕加入表單。
            Controls.Add(saveButton);
            // 讀檔完成後，有成功綁定 DataTable 才啟用儲存。
            Load += (_, _) => saveButton.Enabled = manualdata.DataSource is DataTable;
            // 接收工具畫面的返回事件。

        }

        private void ManualForm_Load(object? sender, EventArgs e)
        {
            // 直接讀取專案根目錄的 CSV，與儲存功能共用同一路徑。
            try
            {
                //TextFieldParser 是 .NET 用來讀取和解析文字資料檔的類別
                // 使用 CSV 剖析器處理引號與欄位內的逗號。
                // 開啟 CSV，離開區塊時自動關閉檔案。
                using var parser = new TextFieldParser(manualDataPath);
                // 依逗號拆分欄位(csv檔各欄位會以,區分)
                parser.SetDelimiters(",");
                // 允許欄位以雙引號包住逗號與換行。
                parser.HasFieldsEnclosedInQuotes = true;
                // 保留欄位前後的空白(不做清除)
                parser.TrimWhiteSpace = false;

                // 第一列是欄名，後續各列是資料。
                var table = new DataTable();
                // 會讀取下一筆 CSV 資料，並把拆好的欄位回傳成字串陣列 string[]
                //假設有a,b,c欄位,讀到c後就結束了(ReadFields(從目前的讀取位置讀一行,當沒有,這行就結束了))
                string[] headers = parser.ReadFields()
                    // 空檔缺少欄名時停止載入。
                    ?? throw new InvalidDataException("CSV 缺少欄名。");


                foreach (string header in headers)
                    // 建立一個字串欄位。
                    table.Columns.Add(header);

                // 逐筆讀到 CSV 結尾
                while (!parser.EndOfData)
                {
                    // 記錄行號，供格式錯誤時顯示。
                    long lineNumber = parser.LineNumber;
                    // 再讀整行
                    string[] fields = parser.ReadFields()!;
                    // 確認資料欄位數與欄名數相同。
                    if (fields.Length != table.Columns.Count)
                        // 欄位數錯誤時停止載入，並指出行號。
                        throw new InvalidDataException($"CSV 第 {lineNumber} 行的欄位數不符。");

                    // 將這筆資料加入資料表(把整筆資料加在表格下方)
                    table.Rows.Add(fields);
                }

                // 解析成功後綁定資料表，由表格自動產生欄位。
                manualdata.DataSource = table;
            }
            // 依例外篩選條件處理預期的檔案或資料錯誤。
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException
                // 載入時也處理 CSV 格式錯誤與重複欄名。
                or MalformedLineException or DuplicateNameException)
            {
                // 顯示讀檔失敗的路徑與原因。
                MessageBox.Show(this, $"無法載入手動資料。\n{manualDataPath}\n{ex.Message}",
                    "載入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveManualData_Click(object? sender, EventArgs e)
        {
            // 確認有資料表可存，並提交目前儲存格的編輯。
            //EndEdit:結束目前這一格的編輯，提交剛輸入的值(如果輸入到一半游標在格子內就儲存,則會回傳fasle)
            if (manualdata.DataSource is not DataTable table || !manualdata.EndEdit())
                // 前一步條件不成立時結束存檔。
                return;

            //BindingContext 是 WinForms 用來查找「資料繫結管理員」的地方。這個管理員會追蹤表格目前在哪一列，以及那一列正在進行的編輯
            // 提交目前那一列的編輯，讓最後修改的儲存格也能寫入(程式在找不到 BindingContext 或管理員時，跳過這個呼叫)
            BindingContext?[table]?.EndCurrentEdit();

            // 先寫同一目錄的暫存檔，寫完才取代原 CSV
            // ToString("N")把它轉成 32 個十六進位字元的字串
            //Guid.NewGuid()會產生一個新的 GUID（全域唯一識別碼）。這裡用它讓每次儲存產生的暫存檔有不同的名字
            //簡單來說用 GUID 產生唯一檔名(tmp檔)，把暫存檔放在 CSV 同一目錄(路徑/檔名.csv+.新識識別碼.tmp)
            string temporaryPath = manualDataPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                // StreamWriter 是 C# 提供的文字寫入工具以 UTF-8 寫檔，離開區塊時關閉寫入器(using)
                using (var writer = new StreamWriter(temporaryPath, false, new UTF8Encoding(true)))
                {
                    // 先把欄名以逗號串接並寫入第一列(.Cast<DataColumn>() 是取得兩個欄位物件)
                    //假設欄位為a,b則為 "a","b"
                    writer.WriteLine(string.Join(",", table.Columns.Cast<DataColumn>()
                        // 逐一轉義欄名，以保留逗號或引號。
                        .Select(column => QuoteCsvField(column.ColumnName))));

                    // 依資料表的列順序逐筆寫入
                    foreach (DataRow row in table.Rows)
                    {
                        // 將目前這筆資料寫成一列
                        //row.ItemArray 會取出這一列的所有欄位值，依照資料表的欄位順序放進一個陣列
                        //假設欄位值為c,d則為 "c","d"
                        writer.WriteLine(string.Join(",", row.ItemArray
                            // 將欄位轉成文字並轉義，空值以空字串寫出(""是空字串)
                            .Select(value => QuoteCsvField(Convert.ToString(value) ?? ""))));
                    }
                }

                // 完整寫入並關閉暫存檔後，再取代原 CSV
                File.Move(temporaryPath, manualDataPath, overwrite: true);
                // 檔案取代成功後顯示儲存完成
                MessageBox.Show(this, "手動資料已儲存。", "儲存完成",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // 依例外篩選條件處理預期的檔案或資料錯誤
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // 顯示存檔失敗的路徑與原因
                MessageBox.Show(this, $"無法儲存手動資料。\n{manualDataPath}\n{ex.Message}",
                    "儲存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 不論儲存成功或失敗，都嘗試清理暫存檔
            finally
            {
                try
                {
                    // 清除可能殘留的暫存檔
                    File.Delete(temporaryPath);
                }
                // 依例外篩選條件處理預期的檔案或資料錯誤
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
                {
                    // 清除暫存檔失敗時，保留前面顯示的儲存結果
                }
            }
        }
        /// <summary>
        /// 欄位一律用雙引號包住，欄位內的雙引號則寫成兩個
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string QuoteCsvField(string value)
        {
            //Replace找第一個參數換成第二個,沒有則維持原樣
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        private void toolbtn_Click(object sender, EventArgs e)
        {
            //預設glueTestbtn可見狀態是false
            bool show = !glueTestbtn.Visible;
            //按下後show變為true,再按又變為false
            glueTestbtn.Visible = show;
            oiltestbtn.Visible = show;
            vaccumoffbtn.Visible = show;
            vaccumonbtm.Visible = show;
            ipatestbtn.Visible = show;
        }

        private void Checkbtn_Click(object sender, EventArgs e)
        {
            bool show = !Resetbtn.Visible;
            Resetbtn.Visible = show;
            Stopbtn.Visible = show;
            homebtn.Visible = show;
            jogbtn.Visible = show;
            spinbtn.Visible = show;
            powerbtn.Visible = show;

        }

        private void manualdata_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int rowIndex = e.RowIndex;       // 列索引，從 0 開始
            int columnIndex = e.ColumnIndex; // 欄索引，從 0 開始

            // 取得該儲存格
            DataGridViewCell cell =
                manualdata.Rows[rowIndex].Cells[columnIndex];
            foreach (DataGridViewColumn column in manualdata.Columns)
            {
                column.ReadOnly = true;
            }
            manualdata.Columns["Value"].ReadOnly = false;
            // 取得原本的值
            int value =Convert.ToInt32(cell.Value);
            int max = Convert.ToInt32(manualdata.Rows[rowIndex].Cells["Max"].Value);
            int min = Convert.ToInt32(manualdata.Rows[rowIndex].Cells["Min"].Value);
            e.Cancel = true;
            ManualValueForm form = new ManualValueForm(max,min);
            form.Show();
        }
    }
}

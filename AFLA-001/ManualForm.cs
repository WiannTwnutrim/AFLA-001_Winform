using System.Data;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace AFLA_001
{
    public partial class ManualForm : Form
    {
        private static readonly string ManualDataPath =
            Path.Combine(AppContext.BaseDirectory, "manual for winform.csv");

        private readonly Dictionary<int, (ECclass Point, DataRow Row, string CsvValue)> rowsByIndex = new();
        private double[]? ecValues;
        private bool editingValue;

        public ManualForm()
        {
            InitializeComponent();
            Load += ManualForm_Load;
            manualdata.AllowUserToAddRows = false;
        }

        private void ManualForm_Load(object? sender, EventArgs e)
        {
            try
            {
                using var parser = new TextFieldParser(ManualDataPath);
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                var table = new DataTable();
                foreach (string header in parser.ReadFields() ?? throw new InvalidDataException("CSV 缺少欄名。"))
                    table.Columns.Add(header);

                foreach (string column in new[] { "Index", "PC 寫變數", "Value", "Min", "Max" })
                {
                    if (!table.Columns.Contains(column))
                        throw new InvalidDataException($"CSV 缺少 {column} 欄位。");
                }

                while (!parser.EndOfData)
                {
                    long lineNumber = parser.LineNumber;
                    string[] fields = parser.ReadFields()!;
                    if (fields.Length != table.Columns.Count)
                        throw new InvalidDataException($"CSV 第 {lineNumber} 行的欄位數不符。");

                    DataRow row = table.Rows.Add(fields);
                    string csvValue = (string)row["Value"];
                    if (string.IsNullOrWhiteSpace(csvValue))
                    {
                        csvValue = "0";
                        row["Value"] = csvValue;
                    }

                    string indexText = ((string)row["Index"]).Trim();
                    if (indexText.Length == 0)
                        continue;

                    if (!int.TryParse(indexText, out int index) || (uint)index >= AdsService.EcLength)
                        throw new InvalidDataException($"CSV 第 {lineNumber} 行的 EC Index 無效。");

                    var point = new ECclass
                    {
                        Index = index,
                        WriteEC = ((string)row["PC 寫變數"]).Trim(),
                        ReadEC = table.Columns.Contains("PC讀") ? ((string)row["PC讀"]).Trim() : ""
                    };
                    if (!rowsByIndex.TryAdd(point.Index, (point, row, csvValue)))
                        throw new InvalidDataException($"CSV 第 {lineNumber} 行的 EC Index 重複。");
                }

                manualdata.DataSource = table;
                manualdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                if (manualdata.Columns["Difinition"] is DataGridViewColumn definition)
                    definition.Width = 200;

                foreach (DataGridViewColumn column in manualdata.Columns)
                    column.ReadOnly = column.Name != "Value";

                ApplyValues();
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidDataException or
                MalformedLineException or DuplicateNameException)
            {
                rowsByIndex.Clear();
                MessageBox.Show(this, $"無法載入手動資料。\n{ManualDataPath}\n{ex.Message}",
                    "載入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void RefreshEcValues(double[]? values)
        {
            ecValues = values;
            ApplyValues();
        }

        private void ApplyValues()
        {
            if (editingValue || manualdata.DataSource == null)
                return;

            // 沒有 PLC 快照時使用載入 CSV 時保存的原始值（空白已轉成 0）。
            foreach (var (point, row, csvValue) in rowsByIndex.Values)
            {
                string value = ecValues == null
                    ? csvValue
                    : ecValues[point.Index].ToString(CultureInfo.CurrentCulture);
                if ((string)row["Value"] != value)
                    row["Value"] = value;
            }

            loadUpData();
        }

        public void loadUpData()
        {
            Chuckrpmtxt.Text = rowsByIndex.TryGetValue(170, out var chuck) ? (string)chuck.Row["Value"] : "";
            cuplifttxt.Text = rowsByIndex.TryGetValue(163, out var cupLift) ? (string)cupLift.Row["Value"] : "";
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

        private async void manualdata_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
            if (editingValue || manualdata.Columns[e.ColumnIndex].Name != "Value" ||
                manualdata.Rows[e.RowIndex].DataBoundItem is not DataRowView rowView ||
                !int.TryParse((string)rowView["Index"], out int index) ||
                !rowsByIndex.TryGetValue(index, out var entry))
            {
                return;
            }

            DataRow row = entry.Row;
            string symbol = entry.Point.WriteEC;
            if (string.IsNullOrWhiteSpace(symbol))
                return;

            int max = int.TryParse((string)row["Max"], out int upperLimit) ? upperLimit : int.MaxValue;
            int min = int.TryParse((string)row["Min"], out int lowerLimit) ? lowerLimit : int.MinValue;

            editingValue = true;
            try
            {
                // 等表格完成取消編輯，再開啟輸入視窗。
                await Task.Yield();
                if (IsDisposed)
                    return;

                using var form = new ManualValueForm(max, min);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    int value = form._intput;
                    await Task.Run(() => AdsService.WriteManualValue(entry.Point, value));
                }
            }
            catch (Exception ex)
            {
                Loghelper.Error($"無法寫入 Manual Index {index}（{symbol}）：{ex.Message}");
                if (!IsDisposed)
                    MessageBox.Show(this, $"無法寫入 PLC 變數 {symbol}。\n{ex.Message}",
                        "寫入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                editingValue = false;
                if (!IsDisposed)
                    ApplyValues();
            }
        }
    }
}

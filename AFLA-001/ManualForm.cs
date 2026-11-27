using System.Data;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace AFLA_001
{
	public partial class ManualForm : Form
	{
		private static readonly string ManualDataPath =
			Path.Combine(AppContext.BaseDirectory, "manual for winform.csv");

		private double[]? ecValues;
		//標記「目前正在處理一次數值編輯」的 bool。
		//開啟輸入視窗前會設成 true，使用者輸入、確認後等待 PLC 寫入的期間，也會保持 true
		//不論使用者確認、取消，或 PLC 寫入失敗，`finally` 都會把 editingValue 設回 false
		private bool editingValue;

		public ManualForm()
		{
			InitializeComponent();
			Load += ManualForm_Load;
			manualdata.AllowUserToAddRows = false;
		}

		private void ManualForm_Load(object? sender, EventArgs e)
		{
			if (DesignMode)
				return;

			loadUpData();

			// 記住目前處理的 CSV 行號，方便在錯誤紀錄指出哪一行有問題。0 是初始值。
			long lineNumber = 0;
			// 在 try 中讀取 CSV 並設定畫面
			try
			{

				using var parser = new TextFieldParser(ManualDataPath);

				parser.SetDelimiters(",");
				// 允許欄位用雙引號包住。例如 CSV 的 "A,B" 會被讀成同一個欄位的 A,B。
				parser.HasFieldsEnclosedInQuotes = true;

				// 建立記憶體中的空表格，後面會依序加入欄位和資料列。
				var table = new DataTable();
				// 先記下下一筆要讀的資料所在行號，因為 ReadFields 讀完後會移到下一筆。
				lineNumber = parser.LineNumber;
				// 第一筆當作欄名。ReadFields 回傳的陣列每個元素代表一欄，讀不到資料時可能回傳 null。
				string[]? headers = parser.ReadFields();
				// 檔案沒有可讀的欄名時，無法建立表格。
				if (headers is null)
				{
					// 寫入錯誤紀錄，留下目前的行號和原因。
					LogManualLoadError($"CSV 第 {lineNumber} 行缺少欄名。");
					// 結束載入。表格尚未綁定，畫面不會顯示只讀到一半的資料。
					return;
				}

				// 依照 CSV 的欄位順序，逐一走訪第一筆讀到的欄名。
				foreach (string header in headers)
					// 用目前的欄名在 DataTable 建立一個文字欄位。
					table.Columns.Add(header);

				// 逐一檢查後續功能需要的欄位。Index 用來對應 EC，PC 寫變數用來寫入 PLC，Value 用來顯示，Min 和 Max 是輸入限制。
				foreach (string column in new[] { "Index", "PC 寫變數", "Value", "Min", "Max" })
				{
					// Contains 表示表格有這個欄位。前面的 ! 把結果反轉，所以缺少欄位才會進入此區塊。
					if (!table.Columns.Contains(column))
					{
						// 記下第一個缺少的必要欄名。
						LogManualLoadError($"CSV 第 {lineNumber} 行缺少 {column} 欄位。");
						// 結束載入。表格尚未綁定，畫面不會顯示只讀到一半的資料。
						return;
					}
				}

				//// 另外加一個欄位保存 CSV 的初始值。之後畫面上的 Value 被 PLC 數值覆蓋時，仍可用它還原。
				//table.Columns.Add(CsvValueColumn);
				// 建立整數集合，記住這次載入時已經看過哪些 EC Index，供檢查重複。
				var indices = new HashSet<int>();

				// 只要 CSV 還有資料，就繼續讀取。每次迴圈處理一筆資料。
				while (!parser.EndOfData)
				{
					// 先記下下一筆要讀的資料所在行號，因為 ReadFields 讀完後會移到下一筆。
					lineNumber = parser.LineNumber;
					// 讀取一筆資料並拆成欄位陣列。結尾的 ! 是告訴編譯器這裡預期有資料，前面已檢查尚未讀完。
					string[] fields = parser.ReadFields()!;
					// 資料的欄位數必須和 CSV 欄名數相同。額外加入的備用欄位不算 CSV 欄位。
					if (fields.Length != headers.Length)
					{
						// 記下欄位數不符的資料行。
						LogManualLoadError($"CSV 第 {lineNumber} 行的欄位數不符。");
						// 結束載入。表格尚未綁定，畫面不會顯示只讀到一半的資料。
						return;
					}

					// 將每個欄位值依順序放進表格的新資料列，並用 row 代表這一列。
					DataRow row = table.Rows.Add(fields);

					//預設讀取,沒有讀ec時使用
					// 用欄名 Value 讀取這列的值。DataRow 取出的資料型別是 object，這裡轉成字串。
					string csvValue = (string)row["Value"];
					// 檢查 Value 是否為 null、空字串或只有空白字元。
					if (string.IsNullOrWhiteSpace(csvValue))
					{
						// 缺少值時用字串 0 作為預設值。
						csvValue = "0";
						// 把預設值也寫到表格的 Value 欄，讓畫面能顯示 0。
						row["Value"] = csvValue;
					}


					// 取出 Index 欄位的文字，並用 Trim 去掉前後空白。
					string indexText = ((string)row["Index"]).Trim();
					// 允許 CSV 的 Index 留空。這種資料列照樣顯示在表格中。
					if (indexText.Length == 0)
						// 跳過本列剩下的 EC Index 檢查，繼續讀下一筆。
						continue;

					// TryParse 嘗試把文字轉成整數，成功時把結果放入 index。|| 表示任一條件成立就進入錯誤區塊。
					// 合法索引從 0 到 EcLength - 1。轉成 uint 比較時，負數會變成超出範圍的大數，因此也會被擋下。
					if (!int.TryParse(indexText, out int index) || (uint)index >= AdsService.EcLength)
					{
						// 記下無法轉成整數或超出 EC 陣列範圍的行。
						LogManualLoadError($"CSV 第 {lineNumber} 行的 EC Index 無效。");
						// 結束載入。表格尚未綁定，畫面不會顯示只讀到一半的資料。
						return;
					}

					// 第一次遇到此索引時，Add 會加入集合並回傳 true。已出現過的索引會回傳 false，此時 ! 讓程式進入錯誤區塊。
					if (!indices.Add(index))
					{
						// 記下再次出現相同 EC Index 的行。
						LogManualLoadError($"CSV 第 {lineNumber} 行的 EC Index 重複。");
						// 結束載入。表格尚未綁定，畫面不會顯示只讀到一半的資料。
						return;
					}
				}

				// CSV 已讀完，把行號重設為初始值。
				lineNumber = 0;
				// 把資料表綁定到畫面上的 manualdata，畫面就能顯示剛讀到的欄位和資料列。
				manualdata.DataSource = table;

				// 隱藏備用值欄位。程式仍可從 DataTable 讀取它。
				foreach (string name in new[] { "Index", "PC 寫變數", "PC讀" })
				{
					if (manualdata.Columns[name] is DataGridViewColumn column)
						column.Visible = false;
				}

				// 關閉全表自動調整欄寬，讓下方的固定欄寬設定生效。
				manualdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
				// 依 CSV 中的欄名 Difinition 尋找畫面欄位。找到時，is 會把欄位物件存進 definition。
				manualdata.Columns["ID"].Width = 50;
				manualdata.Columns["Module"].Width = 150;
				manualdata.Columns["Difinition"].Width = 480;
				manualdata.Columns["UNIT"].Width = 100;
				manualdata.Columns["Min"].Width = 80;
				manualdata.Columns["Max"].Width = 100;
				manualdata.Columns["Value"].Width = 78;

				// 逐一處理畫面上的欄位，設定哪些欄位可以編輯。
				foreach (DataGridViewColumn column in manualdata.Columns)
					// 欄名是 Value 時，!= 的結果為 false，因此此欄可編輯。其他欄位都設為唯讀。
					column.ReadOnly = column.Name != "Value";

				ApplyEcValues();
			}
			catch (Exception ex)
			{
				LogManualLoadError(ex.ToString());
			}
		}

		private static void LogManualLoadError(string message)
		{
			Loghelper.Error($"無法載入手動資料{message}");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="values">是整組的值</param>
		internal void RefreshEcValues(double[]? values)
		{
			ecValues = values;
			ApplyEcValues();
		}

		private void ApplyEcValues()
		{
			//DataSource is not DataTable table：EC 也可能先到，這時 Manual 的 CSV 還沒綁定
			//ecValues is not double[] values 沒讀EC則讀CSV
			if (IsDisposed || editingValue || ecValues is not double[] values ||
				manualdata.DataSource is not DataTable table)
				return;
			try
			{
				foreach (DataRow row in table.Rows)
				{
					if (!int.TryParse((string)row["Index"], out int index) ||
						index < 0 || index >= values.Length)
						continue;

					string value = values[index].ToString(CultureInfo.CurrentCulture);

					//只有新值和目前顯示的值不同時，才更新表格
					if ((string)row["Value"] != value)
						row["Value"] = value;
				}
			}
			catch (Exception ex)
			{
				LogManualLoadError(ex.ToString());
			}

		}

		/// <summary>
		/// 讀取上方6格,假設沒有plc連線就顯示100
		/// </summary>
		public void loadUpData()
		{
			var wr = AdsService.LatestWr;//ReadAction讀取整組wr的short[]
			if (wr == null || wr.Length <= 950)
			{
				//沒讀給值測試用
				Arm1Rotatetxt.Text = "40";
				Arm1Lifttxt.Text = "50";
				Arm2Rotatetxt.Text = "60";
				Arm2Lifttxt.Text = "90";
				Chuckrpmtxt.Text = "100";
				cuplifttxt.Text = "80";
				return;
			}

			double Arm1Rotate = AdsService.WrIntToDouble(wr[900], wr[901]) / 1000;
			double Arm2Rotate = AdsService.WrIntToDouble(wr[880], wr[881]) / 1000;
			double Arm1Lift = AdsService.WrIntToDouble(wr[870], wr[871]) / 1000;
			double Arm2Lift = AdsService.WrIntToDouble(wr[890], wr[891]) / 1000;
			double cuplift = AdsService.WrIntToDouble(wr[910], wr[911]) / 1000;
			double Chuckrpm = AdsService.WrIntToDouble(wr[920], wr[921]) / 10;//rpm /10
			var valuesByTextBox = new Dictionary<TextBox, double>
			{
				[Arm1Rotatetxt] = Arm1Rotate,
				[Arm2Rotatetxt] = Arm2Rotate,
				[Arm1Lifttxt] = Arm1Lift,
				[Arm2Lifttxt] = Arm2Lift,
				[Chuckrpmtxt] = Chuckrpm,
				[cuplifttxt] = cuplift,
			};

			foreach (var entry in valuesByTextBox)
			{
				entry.Key.Text = entry.Value.ToString(CultureInfo.CurrentCulture);
			}
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

		/// <summary>
		/// 判斷欄位名稱的方法
		/// </summary>
		/// <param name="row"></param>
		/// <param name="Modulename"></param>
		/// <param name="Difinitionname"></param>
		/// <returns></returns>
		private static bool Judgebool(DataRow row, string Modulename, string Difinitionname)
		{
			if (row != null)
			{
				return
					(row["Module"].ToString()).Contains(Modulename) &&
						(row["Difinition"].ToString()).Contains(Difinitionname);

			}
			return false;

		}
		private async void manualdata_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			e.Cancel = true;
			if (editingValue || manualdata.Columns[e.ColumnIndex].Name != "Value" ||
				manualdata.Rows[e.RowIndex].DataBoundItem is not DataRowView rowView ||
				!int.TryParse((string)rowView["Index"], out int index))
			{
				return;
			}

			DataRow row = rowView.Row;

			//取寫入的變數名稱
			string symbol = ((string)row["PC 寫變數"]).Trim();
			if (string.IsNullOrWhiteSpace(symbol))
				return;

			double max = Convert.ToDouble(row["Max"].ToString());
			double min = Convert.ToDouble(row["Min"].ToString());

			var point = new ECclass
			{
				Index = index,
				WriteEC = symbol,
				ReadEC = row.Table.Columns.Contains("PC讀") ? ((string)row["PC讀"]).Trim() : ""
			};
			string? positionText = null;

			if (Judgebool(row, "Arm1 Rotate", "Position"))
			{
				positionText = Arm1Rotatetxt.Text;
			}
			else if (Judgebool(row, "Arm2 Rotate", "Position"))
			{
				positionText = Arm2Rotatetxt.Text;
			}
			else if (Judgebool(row, "Arm1 Lift", "Position"))
			{
				positionText = Arm1Lifttxt.Text;
			}
			else if (Judgebool(row, "Arm2 Lift", "Position"))
			{
				positionText = Arm2Lifttxt.Text;
			}
			else if (Judgebool(row, "CUP Lift", "Position"))
			{
				positionText = cuplifttxt.Text;
			}
			else
			{
				positionText = null;
			}
				double? initialValue = null;
				if (double.TryParse(positionText, out double position))
				{
					initialValue = position;
				}
				editingValue = true;
			try
			{
				// 等表格完成取消編輯，再開啟輸入視窗。
				await Task.Yield();

				using var form = new ManualValueForm(max, min, initialValue);
				if (form.ShowDialog(this) == DialogResult.OK)

				{
					double result = form._intput;
					await Task.Run(() => AdsService.WriteManualValue(point, result));
                    row["Value"] = result.ToString(System.Globalization.CultureInfo.CurrentCulture);//寫入時把值填到表格上
                }
			}
			catch (Exception ex)
			{
				Loghelper.Error($"無法寫入 Manual Index {index}（{symbol}）：{ex.ToString()}");

			}
			finally
			{
				editingValue = false;
				//ApplyEcValues();
			}
		}
	}
}

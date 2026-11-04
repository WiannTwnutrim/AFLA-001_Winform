using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFLA_001
{
    public partial class Recipe2Form : Form
    {
        // 接收查詢得到的配方資料，並顯示在此頁表格。
        public void LoadRecipeData(DataTable data)
        {
            dataGridView1.AutoGenerateColumns = false; // 使用設計工具建立的欄位，避免自動產生重複欄位。
            foreach (DataGridViewColumn column in dataGridView1.Columns) // 逐一設定表格欄位與資料來源的對應。
            {
                column.DataPropertyName = column.Name == "ID" ? "StepID" : column.Name; // ID 對應 StepID，其餘欄位依相同名稱綁定。
                // 只有以 SQLite 整數儲存的 Step、BSOIL、BSAIR 勾選欄位需要設定 1 與 0；其他欄位略過。
                if (column is DataGridViewCheckBoxColumn checkBox &&
                    (column.Name == "Step" || column.Name == "BSOIL" || column.Name == "BSAIR"
                    || column.Name == "IPA" || column.Name == "OIL" || column.Name == "GLUE"))
                {
                    checkBox.TrueValue = 1L; // 資料為長整數 1 時顯示勾選，L 表示 long 型別。
                    checkBox.FalseValue = 0L; // 資料為長整數 0 時顯示未勾選。
                }
            }
            dataGridView1.DataSource = data; // 將配方資料表綁定到畫面，顯示所有步驟。
        }
        public Recipe2Form()
        {
            InitializeComponent();
        }
    }
}



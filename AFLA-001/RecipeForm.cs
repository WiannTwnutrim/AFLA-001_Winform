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
    public partial class RecipeForm : Form
    {
        private Sqllite _db = new Sqllite();

        public RecipeForm()
        {
            InitializeComponent();
            LoadRecipe();
        }
        public void LoadRecipe()
        {
            List<string> recipe = _db.GetRecipe();
            recipecombo.DataSource = recipe;
        }
       

        private void recipeLoabtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(recipecombo.Text)) // 檢查配方名稱是否為空或只有空白。
                {
                    MessageBox.Show("請先選擇配方。"); // 提醒使用者先選擇要讀取的配方。
                    Loghelper.Error("操作未選擇配方");
                    Loghelper.Userlog(UserSession.LoginUser, "按下load recipe,載入配方但未選擇配方");
                    return; // 結束此次按鈕事件，避免使用空白名稱查詢。
                }
                DataTable dt = _db.LoadRecipeData(recipecombo.Text) ?? throw new InvalidOperationException("無法讀取配方資料。"); // 依所選配方名稱查詢 SQLite，取得步驟資料
                if (dt.Rows.Count > 0)//如果有資料
                {
                    sizeCombo.Text = Convert.ToString(dt.Rows[0]["Size"]);//取得size欄位第一筆資料

                }
                
                LoadRecipeData(dt); // 將步驟與比例載入同一個表格。
                Loghelper.Userlog(UserSession.LoginUser, "按下load recipe,載入配方成功");
                recipeNametxt.Text = recipecombo.Text;

            }
            catch (Exception ex)
            {
                Loghelper.Error(ex.ToString());
                MessageBox.Show("配方讀取失敗：" + ex.ToString()); // 顯示讀取失敗原因，讓使用者知道此次載入未完成。
            }
        }
        public void LoadRecipeData(DataTable data)
        {
            dataGridView1.AutoGenerateColumns = false; // 使用設計工具建立的欄位，避免自動產生重複欄位。
            foreach (DataGridViewColumn column in dataGridView1.Columns) // 逐一設定表格欄位與資料來源的對應。
            {
                column.DataPropertyName = column.Name == "ID" ? "StepID" : column.Name; // ID 對應 StepID，其餘欄位依相同名稱綁定。
                //只有以 SQLite 整數儲存的 Step、BSOIL、BSAIR 勾選欄位需要設定 1 與 0；其他欄位略過。
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
        private void recipeSavbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(recipeNametxt.Text))
            {
                Loghelper.Error("配方名稱沒有輸入");
                MessageBox.Show("配方名稱沒有輸入");
                return;
            }
        }

        //互鎖處理
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //目前儲存格的值是否已修改但尚未提交(確認目前修改的是 Checkbox)
            if (dataGridView1.IsCurrentCellDirty
                && dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            {
                //過在 CurrentCellDirtyStateChanged 事件中呼叫 CommitEdit，
                //可以讓 CheckBox 一經點擊就立即觸發 CellValueChanged 事件
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //避免處理非資料儲存格的位置
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            //DataGridViewCellEventArgs：提供 DataGridView 儲存格事件資訊的類別,e是該類別的參數
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (columnName != "IPA" && columnName != "OIL" && columnName != "GLUE")
                return;
            //DataGridView 控制項取得所有資料列集合,取得發生事件那一列[e.RowIndex],
            //該列所有資料向項的集合Cells,取得該列指定欄位的儲存格的值
            //dataGridView1[e.ColumnIndex, e.RowIndex].Value先取欄再取列
            bool isChecked = Convert.ToBoolean(
        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

            if (isChecked)//當有一個被選到
            {
                foreach (string name in new[] { "IPA", "OIL", "GLUE" })
                {
                    if (name != columnName)//其他兩個設為FALSE
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[name].Value = false;
                    }
                }
            }
        }
    }
}




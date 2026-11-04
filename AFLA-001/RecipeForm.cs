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
        private Recipe1Form recipe1Form = new Recipe1Form();
        private Recipe2Form recipe2Form = new Recipe2Form();
        private Sqllite _db = new Sqllite();

        private int Nowpage = 1;
        public RecipeForm()
        {
            InitializeComponent();
            PageSwitchManger.ShowPage(recipePanel, recipe1Form);
            LoadRecipe();
        }
        public void LoadRecipe()
        {
            List<string> recipe = _db.GetRecipe();
            recipecombo.DataSource = recipe;
        }
        private void leftRecipebtn_Click(object sender, EventArgs e)
        {
            Loghelper.Userlog(UserSession.LoginUser, "recipe切至第一頁");
            try
            {
                if (Nowpage == 2)
                {
                    PageSwitchManger.ShowPage(recipePanel, recipe1Form);
                    Nowpage = 1;
                }
            }
            catch (Exception ex)
            {
                Loghelper.Error(ex.Message);
            }

        }

        private void rightRecipebtn_Click(object sender, EventArgs e)
        {
            Loghelper.Userlog(UserSession.LoginUser, "recipe切至第二頁");
            try
            {
                if (Nowpage == 1)
                {
                    PageSwitchManger.ShowPage(recipePanel, recipe2Form);
                    Nowpage = 2;
                }
            }
            catch (Exception ex)
            {
                Loghelper.Error(ex.Message);
            }

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
                DataTable dt = _db.LoadRecipeData(recipecombo.Text); // 依所選配方名稱查詢 SQLite，取得步驟資料
    //            if (dt.Rows.Count>1)//如果有資料
    //            {
    //                sizeCombo.Text =Convert.ToString (dt.Rows[0]["Size"]);//取得size欄位第一筆資料

				//}
                recipe1Form.LoadRecipeData(dt); // 將資料載入第一頁的步驟及參數表格。
                recipe2Form.LoadRecipeData(dt); // 將同一份資料載入第二頁的比例表格。
                Loghelper.Userlog(UserSession.LoginUser, "按下load recipe,載入配方成功");
                
            }
            catch(Exception ex) 
            {
                Loghelper.Error(ex.ToString());
                MessageBox.Show("配方讀取失敗：" + ex.Message); // 顯示讀取失敗原因，讓使用者知道此次載入未完成。
            }
        }
    }
}



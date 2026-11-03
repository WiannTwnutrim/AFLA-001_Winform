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

            }
            catch
            {

            }
        }
    }
}

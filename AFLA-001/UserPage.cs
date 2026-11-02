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
    public partial class UserPage : UserControl
    {
        //建立sqllite類別
        private Sqllite db = new Sqllite();
        



        public UserPage()
        {
            InitializeComponent();
            LoadAccount();
        }
        private void LoadAccount()
        {
            List<string> accounts = db.GetAccount();
            accountcombo.DataSource = accounts;
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            db.LoginCheck(accountcombo.Text, passwordtxt.Text);
           bool result= db.LoginCheck(accountcombo.Text, passwordtxt.Text);
            if (!result)
            {
                loginresult.Text = "密碼錯誤";
                passwordtxt.Text = "";//111
            }
            else
            {
                loginresult.Text = "成功登入";
				passwordtxt.Text = "";//111
                //如果這個控制項視窗是form1,那就用mainform當作他的變數
				if (this.FindForm() is Form1 mainForm)//111
				{
					PageSwitchManger.Gohome(mainForm.MainPanel);
				}

			}
        }
    }
}

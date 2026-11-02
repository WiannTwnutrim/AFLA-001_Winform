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
    public partial class UserForm : Form
    {
        private Sqllite _db = new Sqllite();
        public UserForm()
        {
            InitializeComponent();
            LoadAccount();
        }

        private void LoadAccount()
        {
            List<string> accounts = _db.GetAccount();
            accountcombo.DataSource = accounts;
        }
         

        private void loginbtn_Click(object sender, EventArgs e)
        {
            bool loginResult = _db.LoginCheck(accountcombo.Text, passwordtxt.Text);
            if (loginResult)
            {
                loginresult.Text = "登入成功";
                passwordtxt.Text = "";
            }
            else
            {
                loginresult.Text = "登入失敗";
                passwordtxt.Text = "";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFLA_001
{

    public partial class UserEditForm : Form
    {
        public Sqllite _db = new Sqllite();
        public UserEditForm()
        {
            InitializeComponent();
            LoadAccount();
        }
        public void LoadAccount()
        {
            List<string> accounts = _db.GetAccount();
            accountcombo.DataSource = accounts;
        }

        private void alteracbtn_Click(object sender, EventArgs e)
        {
            int access = 1;
            if (acccess1.Checked)
            {
                access = 1;
            }
            else if (acccess2.Checked)
            {
                access = 2;
            }
            else
            {
                access = 3;
            }
            // 先判斷，再執行資料庫操作
            if (accountcombo.Text == "admin")
            {
                Loghelper.Error("修改權限失敗：禁止修改 admin 帳號");
                editresult.Text = "禁止修改 admin 帳號";
                return;
            }
            _db.AlterAccess(accountcombo.Text, access);
        }
    }
}

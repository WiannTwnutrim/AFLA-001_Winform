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
                editresult.Text = "禁止修改 admin 的權限";
                return;
            }
            if (_db.AlterAccess(accountcombo.Text, access))
            {
                editresult.Text = "成功修改權限";

			}
            else
            {
                editresult.Text = "修改失敗：帳號不存在或資料庫操作失敗，請查看log";

			}
            
        }

        private void alterpwbtn_Click(object sender, EventArgs e)
        {
            if (accountcombo.Text == "admin")
            {
                Loghelper.Error("修改密碼失敗：禁止修改 admin 密碼");
                editresult.Text = "禁止修改 admin 的密碼";
                return;
            }
            if (string.IsNullOrWhiteSpace(passwordtxt.Text))
            {
                Loghelper.Error("修改密碼失敗：要輸入密碼");
                editresult.Text = "沒有輸入密碼";
                return;
            }
            if ( _db.AlterPassword(accountcombo.Text, passwordtxt.Text))
            {
				editresult.Text = "成功修改密碼";
			}
            else
            {
				editresult.Text = "修改失敗：帳號不存在或資料庫操作失敗，請查看log";
			}
           
        }

        private void userdelbtn_Click(object sender, EventArgs e)
        {
            if (accountcombo.Text == "admin")
            {
                Loghelper.Error("刪除失敗：禁止刪除 admin 的帳號");
                editresult.Text = "禁止刪除 admin 的帳號";
                return;
            }
            if (string.IsNullOrWhiteSpace(accountcombo.Text))
            {
                editresult.Text = "請選擇要刪除的帳號";
                Loghelper.Error("沒有選擇要做刪除的帳號");
                return;
            }

            if (_db.DeleteAccount(accountcombo.Text))
            {                
                editresult.Text = "帳號刪除成功";
				LoadAccount();
			}
            else
            {
                editresult.Text = "刪除失敗：帳號不存在或資料庫操作失敗，請查看log";
            }
        }
    }
}

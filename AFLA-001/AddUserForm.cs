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
    public partial class AddUserForm : Form
    {
        private Sqllite _db = new Sqllite();
        //建立user改變事件
        public event EventHandler? ChangeUser;

		public AddUserForm()
        {
            InitializeComponent();
        }
    

        private void sureadduserbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(accounttxt.Text) || string.IsNullOrEmpty(passwordtxt.Text))
            {
                addresult.Text = "帳號或密碼沒輸入,新增失敗";
                return;
            }
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
            if (_db.AddUser(accounttxt.Text, passwordtxt.Text, access))
            {
                addresult.Text = "新增帳號成功";
                Clear();
				//觸發,EditUserForm.OnUserChanged 現在才會被執行
				ChangeUser?.Invoke(this, EventArgs.Empty);

			}
			else
			{
                addresult.Text = "新增失敗,請查看log";
                Clear();
			}
			
            
        }
        private void Clear()
        {
            accounttxt.Text = "";
            passwordtxt.Text = "";
        }
    }
}

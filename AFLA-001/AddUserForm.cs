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

            _db.AddUser(accounttxt.Text, passwordtxt.Text, access);
        }
    }
}

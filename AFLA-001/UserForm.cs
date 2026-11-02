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
        //宣告事件,?代表允許目前沒有任何人訂閱
        public event EventHandler? LoginSucceeded;

        //EventHandler是規定接收的方法格式
        //格式:void 方法名稱(object? sender, EventArgs e)
        //sender:誰發事件,e事件附帶的資料
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
                //LoginSucceeded:要觸發的事件,?有人訂閱才執行，沒人訂閱就跳過
                //Invoke:呼叫所有已訂閱的方法
                //將目前的 UserForm 當成 sender 傳出去
                LoginSucceeded?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                loginresult.Text = "登入失敗";
                passwordtxt.Text = "";
            }
        }

        public void ClearloginResult()
        {
            loginresult.Text = "";
        }
    }
}

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

        public event EventHandler? LogoutSucceeded;

        //EventHandler是規定接收的方法格式
        //格式:void 方法名稱(object? sender, EventArgs e)
        //sender:誰發事件,e事件附帶的資料
        public Sqllite _db = new Sqllite();
        public UserForm()
        {
            InitializeComponent();
            LoadAccount();
        }

        public void LoadAccount()
        {
            List<string> accounts = _db.GetAccount();
            accountcombo.DataSource = accounts;
        }


        private void loginbtn_Click(object sender, EventArgs e)
        {
            Loghelper.Userlog(UserSession.LoginUser, "點擊登入按鈕");
            bool loginResult = _db.LoginCheck(accountcombo.Text, passwordtxt.Text);
            if (loginResult)
            {
                UserSession.Login(accountcombo.Text);//紀錄登入帳號
                loginresult.Text = "登入成功";
                Loghelper.Userlog(accountcombo.Text, "登入成功");//寫入log
                passwordtxt.Text = "";
                outeditbtn.Visible = true;//暫時設定登入成功就可編輯
                loginbtn.Visible = false;
                logoutbtn.Visible = true;
                //LoginSucceeded:要觸發的事件,?有人訂閱才執行，沒人訂閱就跳過
                //Invoke:呼叫所有已訂閱的方法
                //將目前的 UserForm 當成 sender 傳出去                
                LoginSucceeded?.Invoke(this, EventArgs.Empty);
                

            }
            else
            {
                loginresult.Text = "登入失敗,密碼錯誤";
                Loghelper.Userlog(UserSession.LoginUser, $"登入失敗,帳號{accountcombo.Text},密碼錯誤");
                passwordtxt.Text = "";
            }
        }

        //清除登入顯示文字
        public void ClearloginResult()
        {
            loginresult.Text = "";
        }

        private void outeditbtn_Click(object sender, EventArgs e)
        {
            EditUserForm editUserForm = new EditUserForm();

			// 顯示視窗前，先訂閱帳號變更事件
			editUserForm.ChangeUser += OnUserChanged;

			editUserForm.Show();
            
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            ClearloginResult();
            Loghelper.Userlog(UserSession.LoginUser, $"帳號{UserSession.LoginUser}登出成功");
            loginbtn.Visible = true;
            loginresult.Text = "登出成功";
            logoutbtn.Visible = false;
            UserSession.Logout();
            LogoutSucceeded?.Invoke(this, EventArgs.Empty);
        }
		private void OnUserChanged(object? sender, EventArgs e)
		{
			// 更新目前登入表單的帳號清單
			LoadAccount();
		}
	}
}

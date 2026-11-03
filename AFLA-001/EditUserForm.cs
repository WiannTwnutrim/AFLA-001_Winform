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
    public partial class EditUserForm : Form
    {
        private UserEditForm userEditform = new UserEditForm();
        private AddUserForm addUserform = new AddUserForm();
		public event EventHandler? ChangeUser;
		public EditUserForm()
        {
            InitializeComponent();
            PageSwitchManger.ShowPage(changeUserPage, userEditform);
            PageSwitchManger.ActiveButton(inEditUserbtn);

			//當 addUserform 發出 ChangeUser 通知時，請執行我的 OnUserChanged 方法
			addUserform.ChangeUser += OnUserChanged;

		}
        private void OnUserChanged(object sender, EventArgs e)
        {
            userEditform.LoadAccount();
			// 通知外面的 UserForm
			ChangeUser?.Invoke(this, EventArgs.Empty);
        }

		private void AddUserbtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(changeUserPage, addUserform);
            PageSwitchManger.ActiveButton(AddUserbtn);
        }

        private void inEditUserbtn_Click(object sender, EventArgs e)
        {
            PageSwitchManger.ShowPage(changeUserPage, userEditform);
            PageSwitchManger.ActiveButton(inEditUserbtn);
			userEditform.LoadAccount();
		}

         
    }
}

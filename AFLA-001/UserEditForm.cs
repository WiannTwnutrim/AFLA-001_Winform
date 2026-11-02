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

            _db.AlterAccess(accountcombo.Text, access);
        }
    }
}

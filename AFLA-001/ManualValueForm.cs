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
    public partial class ManualValueForm : Form
    {
        private int upNum,downNum;//外部上下限取值傳入
        public ManualValueForm(int uplimit,int downlimit)
        {
            InitializeComponent();
            upNum = uplimit;
            downNum = downlimit;
        }

        private void checkManulvaluebtn_Click(object sender, EventArgs e)
        {
            bool inputnull = string.IsNullOrEmpty(Manualvaluetxt.Text);
            bool numcheck = int.TryParse(Manualvaluetxt.Text, out int value);
            if (inputnull||!numcheck)
            {
                MessageBox.Show("請輸入數字");
            }

            if (value >upNum || value < downNum)
            {
                MessageBox.Show("輸入超過上下限");
            }

        }
    }
}

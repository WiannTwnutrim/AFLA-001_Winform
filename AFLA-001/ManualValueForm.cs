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
        private double upNum,downNum, arm1rotatevalue;//外部上下限取值傳入
        public double _intput { get; private set; }
        public ManualValueForm(double uplimit, double downlimit,double? Arm1rotatevalue)
        {
            InitializeComponent();
            upNum = uplimit;
            downNum = downlimit;
            Manualvaluetxt.Text = Arm1rotatevalue?.ToString();
        }

        private void checkManulvaluebtn_Click(object sender, EventArgs e)
        {
            bool inputnull = string.IsNullOrEmpty(Manualvaluetxt.Text);
            bool numcheck = double.TryParse(Manualvaluetxt.Text, out double value);

            //if ()
            //{

            //}
            if (inputnull||!numcheck)
            {
                MessageBox.Show("請輸入數字");
                return;
            }

            if (value >upNum || value < downNum)
            {
                MessageBox.Show("輸入超過上下限");
                return;
            }
            _intput = value;
            DialogResult = DialogResult.OK;
        }
    }
}

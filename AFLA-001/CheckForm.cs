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
    public partial class CheckForm : Form
    {
        public CheckForm()
        {
            InitializeComponent();
        }

        private void Nobtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

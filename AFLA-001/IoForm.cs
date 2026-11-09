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
	public partial class IoForm : Form
	{
		public IoForm()
		{
			InitializeComponent();
		}
		bool ledstatus = false;
		private void pictureBox1_Click(object sender, EventArgs e)
		{			
			if (!ledstatus)
			{
				testpicture.Image = Properties.Resources.HMI_Indicator_ON;
				ledstatus = true;
			}
			else 
			{
				testpicture.Image = Properties.Resources.HMI_Indicator_OFF;
				ledstatus = false;
			}
		}
	}
}

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
    public partial class HomeForm : Form
    {
        private CheckForm form = new CheckForm();
        private bool _check = false;
        public HomeForm()
        {
            InitializeComponent();
        }

        private void buzzerbtn_Click(object sender, EventArgs e)
        {
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                if (buzzerbtn.Text == "BUZZER OFF")
                {
                    buzzerbtn.Text = "BUZZER ON";
                    buzzerbtn.BackColor = Color.Red;
                }
                else
                {
                    buzzerbtn.Text = "BUZZER OFF";
                    buzzerbtn.BackColor = Color.AliceBlue;
                }
            }
        }
        private void vaccumCheck_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;//按到的那個物件轉型為button
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                if (_check)//只要是true就不會變色
                {
                    clickedButton.BackColor = clickedButton.BackColor;
                    _check = false;
                    return;
                }
                else
                {
                    clickedButton.BackColor = Color.Pink;
                    _check = true;
                }
            }
        }

        private void ipapic_Click(object sender, EventArgs e)
        {
            PictureBox currentpic = (PictureBox)sender;
            if (form.ShowDialog(this) == DialogResult.Yes)
            {

                if (_check)//只要是true就不會變色
                {
                    currentpic.Image = Properties.Resources.offar;
                    ipadownpic.Image = Properties.Resources.white;
                    _check = false;
                    return;
                }
                else
                {
                    currentpic.Image = Properties.Resources.onfar;
                    ipadownpic.Image = Properties.Resources.air_down;
                    _check = true;
                }
            }
        }

        private void airpic_Click(object sender, EventArgs e)
        {
            PictureBox currentpic = (PictureBox)sender;
            if (form.ShowDialog(this) == DialogResult.Yes)
            {

                if (_check)//只要是true就不會變色
                {
                    currentpic.Image = Properties.Resources.offar;
                    airtimer.Stop();
                    showair.Visible = false;
                    _check = false;
                    return;
                }
                else
                {
                    currentpic.Image = Properties.Resources.onfar;
                    airtimer.Start();
                    _check = true;
                }
            }
        }

        private void airtimer_Tick(object sender, EventArgs e)
        {
            showair.Visible = !showair.Visible;
        }

        private void oil1pic_Click(object sender, EventArgs e)
        {

            PictureBox currentpic = (PictureBox)sender;
            if (form.ShowDialog(this) == DialogResult.Yes)
            {

                if (_check)//只要是true就不會變色
                {
                    currentpic.Image = Properties.Resources.offar;
                    oiltimer.Stop();
                    showoil.Visible = false;
                    _check = false;
                    return;
                }
                else
                {
                    currentpic.Image = Properties.Resources.onfar;
                    oiltimer.Start();
                    _check = true;
                }
            }
        }

        private void oiltimer_Tick(object sender, EventArgs e)
        {
            showoil.Visible = !showoil.Visible;
        }

        private void oil2pic_Click(object sender, EventArgs e)
        {
            PictureBox currentpic = (PictureBox)sender;
            if (form.ShowDialog(this) == DialogResult.Yes)
            {

                if (_check)//只要是true就不會變色
                {
                    currentpic.Image = Properties.Resources.offar;
                    changefaroil.Image = Properties.Resources.oilfar1;
                    oiluptimer.Stop();
                    oilpupic.Visible = false;
                    _check = false;
                    return;
                }
                else
                {
                    currentpic.Image = Properties.Resources.onfar;
                    changefaroil.Image = Properties.Resources.oifar2;
                    oiluptimer.Start();
                    _check = true;
                }
            }
        }

        private void oiluptimer_Tick(object sender, EventArgs e)
        {
            oilpupic.Visible = !oilpupic.Visible;
        }
    }
}

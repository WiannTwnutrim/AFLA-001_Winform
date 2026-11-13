using PathDrawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AFLA_001
{
    public partial class HomeForm : Form
    {
        private CheckForm form = new CheckForm();

        public HomeForm()
        {
            InitializeComponent();
            //BringToFront移到最上層
            levelTankControl1.BringToFront();
            // Keep the independent metal arms above their connecting pipes.
            arm1Control1.BringToFront();
            arm2Control1.BringToFront();

            // 啟用雙緩衝，減少首頁重繪時的閃爍。
            DoubleBuffered = true;
        }

        /// <summary>
        /// 閥變色,他屬性沒有Invalidate();//重繪
        /// </summary>
        /// <param name="valve"></param>
        /// <returns></returns>
        private bool ToggleValve(ValveControl valve)
        {
            if (form.ShowDialog(this) != DialogResult.Yes)
                return false;

            if (valve.ForeColor == Color.LimeGreen)
            {
                valve.ForeColor = Color.Silver;
            }
            else
            {
                valve.ForeColor = Color.LimeGreen;
            }
            Invalidate();
            return true;
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
            //不是訂閱事件的button或對話框yes會不做下面
            if (sender is not Button clickedButton || form.ShowDialog(this) != DialogResult.Yes)
                return;

            //設定一開始狀態,不管他是false還是true都先把兩顆設為原色
            bool wasHighlighted = clickedButton.BackColor == Color.Pink;
            vaccumonbtn.BackColor = Color.AliceBlue;
            vaccumoffbtn.BackColor = Color.AliceBlue;

            //假設點到的是true則什麼都不做,點到是fasle則變色
            if (!wasHighlighted)
                clickedButton.BackColor = Color.Pink;
        }

        // 確認後只切換被點擊的閥門，並更新glue圖片。
        private void glueval_Click(object sender, EventArgs e)
        {
            ToggleValve(glueval);
            if (glueval.ForeColor == Color.LimeGreen)
            {
                gluepic.Image = Properties.Resources.glueout1;
                pipeglue2.FlowColor = Color.DarkBlue;
            }
            else
            {
                gluepic.Image = Properties.Resources.glueout2;
                pipeglue2.FlowColor = Color.Empty;
            }         
        }

        private void vaccumval_Click(object sender, EventArgs e)
        {
            ToggleValve(vaccumval);
            if (vaccumval.ForeColor == Color.LimeGreen)
            {
                vaccumpic.Image = Properties.Resources.vaccum;
                pipevacc2.FlowColor = Color.Gray;
            }
            else
            {
                vaccumpic.Image = Properties.Resources.vaccum1;
                pipevacc2.FlowColor = Color.Empty;
            }
        }

        private void ipavalve_Click(object sender, EventArgs e)
        {
            ToggleValve(ipavalve);
            if (ipavalve.ForeColor == Color.LimeGreen)
            {
                pipeipa4.FlowColor = Color.Blue;
            }
            else
            {
                pipeipa4.FlowColor = Color.Empty;
            }
        }

        private void ipaLow_Click(object sender, EventArgs e)
        {
            ipatank.Level = 10f;
            ipavalve.ForeColor = Color.Silver;
            pipeipa1.FlowColor = pipeipa2.FlowColor = pipeipa3.FlowColor = Color.Empty;
        }

        private void ipaHigh_Click(object sender, EventArgs e)
        {
            ipatank.Level = 80f;
            pipeipa1.FlowColor = pipeipa2.FlowColor = pipeipa3.FlowColor = Color.Blue;
        }

        private void airval_Click(object sender, EventArgs e)
        {
            ToggleValve(airval);
            if (airval.ForeColor == Color.LimeGreen)
            {
                airpicture.Image = Properties.Resources.air2;
                airpipe3.FlowColor = Color.SkyBlue;
            }
            else
            {
                airpicture.Image = Properties.Resources.air;
                airpipe3.FlowColor = Color.Empty;
            }
        }


        private void oil1val2_Click(object sender, EventArgs e)
        {
            ToggleValve(oil1val2);

            if (oil1val2.ForeColor == Color.LimeGreen)
            {
                pipeoil2.FlowColor = Color.Orange;
            }
            else
            {
                pipeoil2.FlowColor = Color.Empty;
            }            
        }

        private void oilval1_Click(object sender, EventArgs e)
        {
            if (!ToggleValve(oilval1))
                return;

            oilpupic.Visible = oilval1.ForeColor == Color.LimeGreen;
            if (oilval1.ForeColor == Color.LimeGreen)
            {
                pipeoil13.FlowColor = pipeoil17.FlowColor = Color.Orange;
            }
            else
            {
                pipeoil13.FlowColor = pipeoil17.FlowColor = Color.Empty;
            }
        }
        /// <summary>
        /// 閃爍圖片的計時器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showpictimer_Tick(object sender, EventArgs e)
        {
            ShowPic(oilpupic, oilval1);
            ShowPic(showoil, oil1val2);
            ShowPic(showair, airval);
        }
        /// <summary>
        /// 控制圖片閃爍
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="valve"></param>
        private void ShowPic(PictureBox pic, ValveControl valve)
        {
            // 關掉閥直接讓圖片消失
            if (valve.ForeColor == Color.LimeGreen)
            {
                pic.Visible = !pic.Visible;
            }
            else
            {
                pic.Visible = false;
            }
        }
    }
}



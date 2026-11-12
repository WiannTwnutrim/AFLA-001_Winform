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
            levelTankControl1.BringToFront();
            // Keep the independent metal arms above their connecting pipes.
            arm1Control1.BringToFront();
            arm2Control1.BringToFront();

            // 啟用雙緩衝，減少首頁重繪時的閃爍。
            DoubleBuffered = true;

            ipavalve.Click += (_, _) => ToggleValve(ipavalve);
            BindFlowValve(airval, showair, 500);
            BindFlowValve(oil1val2, showoil, 400);
            BindFlowValve(oilval1, oilpupic, 300);
        }


        /// <summary>
        /// 閥變色(ipa變色套用)
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
            if (valve == ipavalve)
            {
                Color flowColor = valve.ForeColor == Color.LimeGreen
                    ? Color.Blue : Color.Empty;
                pipeipa4.FlowColor = flowColor;
            }
            Invalidate();
            return true;
        }

        // 每個流量指示各有自己的計時器，由表單統一釋放。
        private void BindFlowValve(ValveControl valve, PictureBox indicator, int interval)
        {
            var timer = new System.Windows.Forms.Timer(components ??= new Container()) { Interval = interval };
            timer.Tick += (_, _) => indicator.Visible = !indicator.Visible;
            valve.Click += (_, _) =>
            {
                if (!ToggleValve(valve))
                    return;
                if (valve == airval)
                {
                    if (valve.ForeColor == Color.LimeGreen)
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
                //oil下
                if (valve == oil1val2)
                {
                    if (valve.ForeColor == Color.LimeGreen)
                    {
                        pipeoil2.FlowColor = Color.Orange;

                    }
                    else
                    {
                        pipeoil2.FlowColor = Color.Empty;
                    }
                }
                //oil上
                if (valve == oilval1)
                {
                    if (valve.ForeColor == Color.LimeGreen)
                    {
                        pipeoil13.FlowColor = pipeoil17.FlowColor = Color.Orange;
                    }
                    else
                    {
                        pipeoil13.FlowColor = pipeoil17.FlowColor = Color.Empty;
                    }
                }
                if (valve.ForeColor == Color.LimeGreen)
                {
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                    indicator.Hide();
                }
            };
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
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                // 在這裡加入 GLUE 閥門的變色邏輯。
                glueval.ForeColor = glueval.ForeColor == Color.LimeGreen
                ? Color.Silver
                : Color.LimeGreen;
                if (glueval.ForeColor == Color.LimeGreen)
                {
                    gluepic.Image = Properties.Resources.glueout1;
                    pipeglue2.FlowColor = Color.DarkBlue;
                }
                else
                {
                    gluepic.Image = Properties.Resources.glueout2;
                    pipeglue1.FlowColor = Color.Empty;
                }
                Invalidate();//重繪
            }
        }

        private void vaccumval_Click(object sender, EventArgs e)
        {
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                // 在這裡加入 GLUE 閥門的變色邏輯。
                glueval.ForeColor = glueval.ForeColor == Color.LimeGreen
                ? Color.Silver
                : Color.LimeGreen;
                if (glueval.ForeColor == Color.LimeGreen)
                {
                    vaccumpic.Image = Properties.Resources.vaccum;
                    pipevacc2.FlowColor = Color.Gray;
                }
                else
                {
                    vaccumpic.Image = Properties.Resources.vaccum1;
                    pipeglue2.FlowColor = Color.Empty;
                }
                Invalidate();//重繪
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
    }
}



using DocumentFormat.OpenXml.Office2010.CustomUI;
using PathDrawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace AFLA_001
{
    public partial class HomeForm : Form
    {
        private CheckForm form = new CheckForm();

        public HomeForm()
        {
            InitializeComponent();
            // 把功能索引放入 Tag，供點擊事件取用,buzzer.hepa.vaccum待確認
            button2.Tag = 142;
            initialbtn.Tag = 141;
            resetbtn.Tag = 0;
            buzzerbtn.Tag = 2;
            stopbtn.Tag = 12;
            vaccumonbtn.Tag = 144;
            vaccumoffbtn.Tag = 145;


            var motionTimer = new System.Windows.Forms.Timer { Interval = 100 };

            motionTimer.Tick += (_, _) =>
            {
                foreach (Button button in homebtnpanel.Controls.OfType<Button>())
                {
                    if (int.TryParse(button.Tag?.ToString(), out int index))
                        UpdateProcessMotion(index, button);
                }
                foreach (ValveControl val in homepanel2.Controls.OfType<ValveControl>())
                {
                    if (int.TryParse(val.Tag?.ToString(), out int index))
                        UpdateProcessMotion(index, val);
                }
            };
            VisibleChanged += (_, _) => motionTimer.Enabled = Visible;
            Disposed += (_, _) => motionTimer.Dispose();
            motionTimer.Enabled = Visible;
            //BringToFront移到最上層
            levelTankControl1.BringToFront();
            // Keep the independent metal arms above their connecting pipes.
            arm1Control1.BringToFront();
            arm2Control1.BringToFront();
            // 啟用雙緩衝，減少首頁重繪時的閃爍。
            DoubleBuffered = true;
        }
        /// <summary>
        /// 背景讀狀態
        /// </summary>
        /// <param name="index"></param>
        /// <param name="button"></param>
        private void UpdateProcessMotion(int index, Button button)
        {
            try
            {
                bool[] states = AdsService.LatestMotionStates;
                if (states != null)
                {
                    bool status = states[index];
                    button.BackColor = status ? Color.Green : Color.Gray;
                }
            }
            catch (Exception ex)
            {
                Loghelper.Error(ex.ToString());
            }
        }
        private void UpdateProcessMotion(int index, ValveControl val)
        {
            try
            {
                bool[] states = AdsService.LatestMotionStates;
                if (states != null)
                {
                    bool status = states[index];
                    val.ForeColor = status ? Color.Green : Color.Gray;
                }
            }
            catch (Exception ex)
            {
                Loghelper.Error(ex.ToString());
            }
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
               
                buttonSet(sender as Button);
            }
        }


        // 確認後只切換被點擊的閥門，並更新glue圖片。
        private void glueval_Click(object sender, EventArgs e)
        {
            ToggleValve(glueval);
            buttonSet(sender as Button);
            if (glueval.ForeColor == Color.LimeGreen)
            {
                
                gluepic.Image = Properties.Resources.glueout1;
                pipeglue2.FlowColor = Color.Orange;
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
            buttonSet(sender as Button);
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
            buttonSet(sender as Button);
            if (ipavalve.ForeColor == Color.LimeGreen)
            {
                pipeipa4.FlowColor = Color.SkyBlue;
            }
            else
            {
                pipeipa4.FlowColor = Color.Empty;
            }
        }
        //舊測試用
        //private void ipaLow_Click(object sender, EventArgs e)
        //{
        //    ipatank.Level = 10f;
        //    ipavalve.ForeColor = Color.Silver;
        //    pipeipa1.FlowColor = pipeipa2.FlowColor = pipeipa3.FlowColor = Color.Empty;
        //}

        //private void ipaHigh_Click(object sender, EventArgs e)
        //{
        //    ipatank.Level = 80f;
        //    pipeipa1.FlowColor = pipeipa2.FlowColor = pipeipa3.FlowColor = Color.Blue;
        //}

        private void airval_Click(object sender, EventArgs e)
        {
            ToggleValve(airval);
            buttonSet(sender as Button);
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
            buttonSet(sender as Button);
            if (oil1val2.ForeColor == Color.LimeGreen)
            {
               
                pipeoil2.FlowColor = Color.Yellow;
            }
            else
            {
                pipeoil2.FlowColor = Color.Empty;
            }
        }

        private void oilval1_Click(object sender, EventArgs e)
        {
            ToggleValve(oilval1);

            buttonSet(sender as Button);
            oilpupic.Visible = oilval1.ForeColor == Color.LimeGreen;
            if (oilval1.ForeColor == Color.LimeGreen)
            {
                
                pipeoil13.FlowColor = pipeoil17.FlowColor = Color.Yellow;
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
        public void RecipeForm_RecipeApplied(object? sender, RecipeAppliedEventArgs e)
        {
            sizetxt.Text = e.Size;
            rpmtxt.Text = e.Rpm.ToString();
            bsairtxt.Text = e.Bsair.ToString();
            bsoiltxt.Text = e.Bsoil.ToString();
            timetxt.Text = e.Time.ToString();

        }
        /// <summary>
        /// processbtn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object? sender, EventArgs e)
        {

            buttonSet(sender as Button);
        }

        /// <summary>
        /// click寫入true
        /// </summary>
        /// <param name="button"></param>
        private async void buttonSet(Button? button)
        {
            try
            {
                int index = Convert.ToInt16(button.Tag);
                // 用 Tag 的index找點位，每次都寫入 TRUE。
                await Task.Run(() => AdsService.WriteAction(index));
            }
            catch (Exception ex)
            {
                Loghelper.Error($"ADS 寫入失敗:{ex.ToString()}");
            }
        }

        private void initialbtn_Click(object sender, EventArgs e)
        {
            buttonSet(sender as Button);
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            buttonSet(sender as Button);
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            buttonSet(sender as Button);
        }

        private void vaccumonbtn_Click(object sender, EventArgs e)
        {
            buttonSet(sender as Button);
        }

        private void vaccumoffbtn_Click(object sender, EventArgs e)
        {
            buttonSet(sender as Button);
        }
    }
}

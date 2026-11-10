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
        public HomeForm()
        {
            InitializeComponent();

            // 啟用雙緩衝，減少首頁重繪時的閃爍。
            DoubleBuffered = true;

            gluepic.Click += gluepic_Click;
            ipapic.Click += (_, _) => ToggleValve(ipapic);
            BindFlowValve(airpic, showair, 500);
            BindFlowValve(oil1pic, showoil, 400);
            BindFlowValve(oil2pic, oilpupic, 300);
        }

        // 首頁重繪時，依設計座標畫出設備之間的管線。
        protected override void OnPaint(PaintEventArgs e)
        {
            // 先執行表單原有的繪圖流程。
            base.OnPaint(e);

            // 使用這次重繪事件提供的繪圖表面。
            var graphics = e.Graphics;
            // 保存原有的座標轉換和繪圖設定。
            var state = graphics.Save();
            try
            {
                // 取得目前字型的自動縮放尺寸。
                var scale = CurrentAutoScaleDimensions;
                // 以設計器的 7×15 字型尺寸為基準，將管線縮放到目前的控制項位置。
                graphics.ScaleTransform(scale.Width / 7f, scale.Height / 15f);
                // 啟用反鋸齒，使斜線及轉角更平滑。
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // 由 PathDrawing 負責繪製各段管線。
                var drawer = new PathDrawing.PathDrawer();

                // 六個閥門的管線在閥身上下緣分段。
                // 膠液閥（gluepic）接點為上緣 (286, 59)、下緣 (286, 103)。
                drawer.DrawFlowPipe(graphics, gluepic.ForeColor == Color.LimeGreen ? Color.Orange : Color.Empty,
                new(250, 45), new(286, 45), new(286, 59));

                drawer.DrawFlowPipe(graphics,gluepic.ForeColor == Color.LimeGreen ? Color.Orange : Color.Empty,
                new(286, 103),new(286, 174));

                // IPA 閥（ipapic）接點為上緣 (502, 53)、下緣 (502, 97) ok

                drawer.DrawFlowPipe(graphics, ipapic.ForeColor == Color.LimeGreen ? Color.DeepSkyBlue : Color.Empty,
                    new(632, 60), new(632, 26), new(502, 26), new(502, 53));

                drawer.DrawFlowPipe(graphics, ipapic.ForeColor == Color.LimeGreen ? Color.DeepSkyBlue : Color.Empty,
                    new(502, 97), new(502, 175));

                // 油路閥 2（oil2pic）接點為上緣 (624, 247)、下緣 (624, 300)。
                drawer.DrawFlowPipe(graphics, oil2pic.ForeColor == Color.LimeGreen ? Color.Gold : Color.Empty,
                    new(479, 223), new(624, 223), new(624, 247));
                // 這段管線從油路閥 2 的下緣接到油路閥 1（oil1pic）的下緣 (571, 418)。
                drawer.DrawFlowPipe(graphics, oil1pic.ForeColor == Color.LimeGreen ? Color.Gold : Color.Empty,
                    new(624, 300), new(624, 416),
                    new(616, 431), new(582, 431), new(571, 418));

                // 油路閥 1（oil1pic）的上緣接點為 (571, 374)
                drawer.DrawFlowPipe(graphics, oil1pic.ForeColor == Color.LimeGreen ? Color.Gold : Color.Empty,
                    new(571, 374), new(571, 314));
                // 油路閥 2 下方的變色支線從 (624, 320) 分出。
                drawer.DrawFlowPipe(graphics, oil2pic.ForeColor == Color.LimeGreen ? Color.Gold : Color.Empty,
                    new(624, 320), new(698, 320), new(698, 354));

                // 空氣閥（airpic）接點為上緣 (194, 317)、下緣 (194, 361)ok
                drawer.DrawFlowPipe(graphics, airpic.ForeColor == Color.LimeGreen ? Color.DeepSkyBlue : Color.Empty,
                   new(113, 363), new(113, 343), new(124, 332),
                    new(147, 332), new(160, 345), new(160, 375), new(170, 386),
                    new(184, 386), new(194, 375), new(194, 361));

                drawer.DrawFlowPipe(graphics, airpic.ForeColor == Color.LimeGreen ? Color.DeepSkyBlue : Color.Empty,
                    new(194, 317), new(194, 304));

                // 真空閥（vaccumpic）接點為上緣 (368, 362)、下緣 (368, 405)。
                drawer.DrawPipe(graphics, new(368, 355), new(368, 362));
                drawer.DrawPipe(graphics, new(368, 405), new(368, 441), new(325, 441));
                // 垂直管段對準廢液槽上方的接口。
                drawer.DrawPipe(graphics, new(458, 298), new(458, 375));

                // 左側 ARM2 接膠液管，右側 ARM1 接 IPA 管。
                drawer.DrawArm(graphics, new Point(286, 169), -30f);
                drawer.DrawArm(graphics, new Point(502, 170), 30f);
                
            }
            finally
            {
                // 恢復進入這段繪圖前的設定。
                graphics.Restore(state);
            }
        }

        // 確認後只切換被點擊的閥門，並重畫管線。
        private void gluepic_Click(object? sender, EventArgs e)
        {
            if (form.ShowDialog(this) == DialogResult.Yes)
            {
                // 在這裡加入 GLUE 閥門的變色邏輯。
                gluepic.ForeColor = gluepic.ForeColor == Color.LimeGreen
                ? Color.Silver
                : Color.LimeGreen;
                if(gluepic.ForeColor == Color.LimeGreen)
                {
                    gluepicture.Image = Properties.Resources.glueout2;
                }
                else
                {
                    gluepicture.Image = Properties.Resources.glueout1;
                }
                Invalidate();
            }
        }

        private bool ToggleValve(PictureBox valve)
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

        // 每個流量指示各有自己的計時器，由表單統一釋放。
        private void BindFlowValve(PictureBox valve, PictureBox indicator, int interval)
        {
            var timer = new System.Windows.Forms.Timer(components ??= new Container()) { Interval = interval };
            timer.Tick += (_, _) => indicator.Visible = !indicator.Visible;
            valve.Click += (_, _) =>
            {
                if (!ToggleValve(valve))
                    return;
                if(valve == airpic)
                {
                    if(valve.ForeColor == Color.LimeGreen)
                    {
                        airpicture.Image = Properties.Resources.air2;
                    }
                    else
                    {
                        airpicture.Image = Properties.Resources.air;
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

        private void PaintValve(object? sender, PaintEventArgs e)
        {
            if (sender is PictureBox valve)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                new PathDrawing.PathDrawer().DrawValve(e.Graphics, valve.ClientRectangle, valve.ForeColor);
            }
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

    }
}

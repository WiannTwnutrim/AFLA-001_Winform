// 引用 Graphics、Point、Pen 等繪圖型別。
using System.Drawing;
// 引用線端、轉角與漸層畫刷的繪圖選項。
using System.Drawing.Drawing2D;

// 將管路與閥門的繪圖程式集中在 PathDrawing 類別庫。
namespace PathDrawing
{
    // 由呼叫端提供 Graphics 與座標，本類別負責繪製。
    public class PathDrawer
    {
        // 保留原本繪製綠色路徑的入口。
        public void DrawPath(Graphics g, Point[] points)
        {
            // 至少需要兩個點才能畫出一段線。
            if (points == null || points.Length < 2)
                return; // 缺少端點時直接結束。

            // 依序連接所有座標，使用系統提供的綠色畫筆。
            g.DrawLines(Pens.Green, points);
        }

        // 繪製使用預設金屬色的管線(直線只有兩個座標)
        public void DrawPipe(Graphics graphics, params Point[] points)
        {
            // 用空色表示管線未指定流體顏色。
            DrawFlowPipe(graphics, Color.Empty, points);
        }

        // 依座標繪製金屬管，可用變色(轉彎會讓座標增加)
        public void DrawFlowPipe(Graphics graphics, Color flowColor, params Point[] points)
        {
            // 至少需要兩個座標才能形成管段。
            if (points.Length < 2)
                return; // 點數不足時沒有可畫的管段。

            // 先畫最寬的深色輪廓。
            DrawPipeStroke(graphics, points, Color.FromArgb(39, 72, 76), 12f);
            // 疊上較窄的灰藍色管壁。
            DrawPipeStroke(graphics, points, Color.FromArgb(109, 151, 155), 9f);
            // 使用淺灰藍色管身，或套用指定的流體顏色。
            DrawPipeStroke(graphics, points, flowColor.IsEmpty ? Color.FromArgb(186, 217, 219) : flowColor, 5f);
            // 最後畫窄亮線，呈現管身反光。
            DrawPipeStroke(graphics, points, Color.FromArgb(233, 246, 246), 2f);
        }

        // 用兩個三角形和中央圓形畫出直立的閥門。
        public void DrawValve(Graphics graphics, Rectangle bounds, Color color)
        {
            // 找出閥門的水平中心，對準管線中心。
            float centerX = bounds.Left + bounds.Width / 2f;
            // 找出上下兩片閥身交會的高度。
            float centerY = bounds.Top + bounds.Height / 2f;
            // 用控制項寬度的比例決定閥身的半寬。
            float halfWidth = bounds.Width * 0.42f;
            // 用控制項寬度的比例決定中央圓形的半徑。
            float radius = bounds.Width * 0.13f;
            // 上方閥身從控制項上緣開始，接到上游管線。
            float top = bounds.Top;
            // 下方閥身延伸到控制項下緣，接到下游管線。
            float bottom = bounds.Bottom;

            // 建立由亮到暗的水平漸層，離開方法時自動釋放畫刷。
            using var fill = new LinearGradientBrush(
                bounds, Color.WhiteSmoke, color, LinearGradientMode.Horizontal);

            // 繪製上方的倒三角形。
            graphics.FillPolygon(fill, new PointF[]
            {
                new(centerX - halfWidth, top), // 左上角。
                new(centerX + halfWidth, top), // 右上角。
                new(centerX, centerY) // 指向閥門中心的尖端。
            });

            // 繪製下方的正三角形。
            graphics.FillPolygon(fill, new PointF[]
            {
                new(centerX - halfWidth, bottom), // 左下角。
                new(centerX + halfWidth, bottom), // 右下角。
                new(centerX, centerY) // 指向閥門中心的尖端。
            });

            // 用圓形覆蓋兩個尖端的交會處。
            graphics.FillEllipse(fill, centerX - radius, centerY - radius, radius * 2, radius * 2);
        }

        // 從管線接口依指定角度繪製銀色圓筒與端蓋。
        public void DrawArm(Graphics graphics, Point inlet, float angle)
        {
            // 保存呼叫端的座標轉換。
            var state = graphics.Save();
            try
            {
                // 將局部原點移到 ARM1 的管線接口。
                graphics.TranslateTransform(inlet.X, inlet.Y);
                // 以接口為支點旋轉圓筒，讓左右兩支朝中央傾斜。
                graphics.RotateTransform(angle);

                // 用橫向漸層模擬圓筒表面的反光。
                using var metal = new LinearGradientBrush(
                    new Rectangle(-18, 0, 36, 80), Color.SlateGray, Color.DarkGray, LinearGradientMode.Horizontal)
                {
                    InterpolationColors = new ColorBlend
                    {
                        Colors = new[] { Color.SlateGray, Color.Gainsboro, Color.WhiteSmoke, Color.DarkGray },
                        Positions = new[] { 0f, 0.27f, 0.63f, 1f }
                    }
                };

                // 畫出接管套筒、圓筒主體及圓弧端蓋。
                graphics.FillRectangle(metal, -16, 0, 32, 9);
                graphics.FillRectangle(metal, -18, 7, 36, 57);
                graphics.FillRectangle(metal, -16, 64, 32, 9);
                graphics.FillEllipse(metal, -16, 66, 32, 14);

                // 用細線標出端蓋與主體的接縫。
                using var seam = new Pen(Color.FromArgb(145, 115, 126, 130));
                graphics.DrawLine(seam, -16, 66, 16, 66);
            }
            finally
            {
                // 恢復原本的座標，避免旋轉影響後續繪圖。
                graphics.Restore(state);
            }
        }

        // 使用指定顏色與寬度畫出一層管線。
        private static void DrawPipeStroke(Graphics graphics, Point[] points, Color color, float width)
        {
            // 建立本次繪圖專用的畫筆，離開方法時自動釋放,width是線寬以float為單位
            using var pen = new Pen(color, width)
            {
                LineJoin = LineJoin.Round, // 管路轉彎使用圓角。
                StartCap = LineCap.Flat, // 起點切平，讓筆畫停在指定座標。
                EndCap = LineCap.Flat // 終點切平，讓筆畫停在指定座標。
            };

            // 依序連接所有座標，畫出這一層管身。
            graphics.DrawLines(pen, points);
        }
    }
}

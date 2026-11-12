using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PathDrawing;

public enum PipeShape
{
    Horizontal,
    Vertical,
    LeftUp,
    LeftDown,
    RightUp,
    RightDown,
    TeeRight
}

/// <summary>可在 WinForms 設計工具中拖拉、縮放的金屬管路。</summary>
[ToolboxItem(true)]
[DefaultProperty(nameof(Shape))]
public class PipeControl : Control
{
    private readonly PathDrawer drawer = new();
    private PipeShape shape;
    private int bendX = 50;
    private int bendY = 50;
    private Color flowColor = Color.Empty;

    public PipeControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        TabStop = false;
    }

    protected override Size DefaultSize => new(160, 32);

    [Category("管路"), Description("管路的方向或彎頭形狀；端點會隨控制項大小自動計算。")]
    [DefaultValue(PipeShape.Horizontal)]
    public PipeShape Shape
    {
        get => shape;
        set
        {
            if (!Enum.IsDefined(value))
                throw new InvalidEnumArgumentException(nameof(value), (int)value, typeof(PipeShape));
            if (shape == value) return;
            shape = value;
            UpdatePipeRegion();
            Invalidate();
        }
    }

    [Category("管路"), Description("轉折點距左側的百分比（0～100），50 為中央。直管不受影響。")]
    [DefaultValue(50)]
    public int BendX
    {
        get => bendX;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "BendX 必須介於 0 與 100。");
            if (bendX == value) return;
            bendX = value;
            UpdatePipeRegion();
            Invalidate();
        }
    }

    [Category("管路"), Description("轉折點距上側的百分比（0～100），50 為中央。直管不受影響。")]
    [DefaultValue(50)]
    public int BendY
    {
        get => bendY;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "BendY 必須介於 0 與 100。");
            if (bendY == value) return;
            bendY = value;
            UpdatePipeRegion();
            Invalidate();
        }
    }
    [Category("管路"), Description("管內流體顏色；Empty 使用原本金屬色。") ]
    [DefaultValue(typeof(Color), "")]
    public Color FlowColor
    {
        get => flowColor;
        set
        {
            if (flowColor == value) return;
            flowColor = value;
            UpdatePipeRegion();
            Invalidate();
        }
    }

    [DefaultValue(typeof(Color), "Transparent")]
    public override Color BackColor
    {
        get => base.BackColor;
        set => base.BackColor = value;
    }

    [DefaultValue(false)]
    public new bool TabStop
    {
        get => base.TabStop;
        set => base.TabStop = value;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdatePipeRegion();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        UpdatePipeRegion();
    }

    protected override void OnDpiChangedAfterParent(EventArgs e)
    {
        base.OnDpiChangedAfterParent(e);
        UpdatePipeRegion();
    }

    private void UpdatePipeRegion()
    {
        float scale = Math.Min(DeviceDpi / 96f, Math.Min(ClientSize.Width, ClientSize.Height) / 14f);
        var next = new Region();
        next.MakeEmpty();
        if (scale > 0)
        {
            int width = Math.Max(1, (int)(ClientSize.Width / scale));
            int height = Math.Max(1, (int)(ClientSize.Height / scale));
            bool straight = Shape == PipeShape.Horizontal || Shape == PipeShape.Vertical;
            var center = straight ? new Point(width / 2, height / 2)
                : new Point((int)Math.Round(width * BendX / 100.0),
                    (int)Math.Round(height * BendY / 100.0));
            var left = new Point(0, center.Y);
            var right = new Point(width, center.Y);
            var top = new Point(center.X, 0);
            var bottom = new Point(center.X, height);
            using var path = new GraphicsPath();
            Point[] points = Shape switch
            {
                PipeShape.Vertical => [top, bottom],
                PipeShape.LeftUp => [left, center, top],
                PipeShape.LeftDown => [left, center, bottom],
                PipeShape.RightUp => [right, center, top],
                PipeShape.RightDown => [right, center, bottom],
                _ => [left, right]
            };
            if (Shape == PipeShape.TeeRight)
            {
                path.AddLine(top, bottom);
                path.StartFigure();
                path.AddLine(center, right);
            }
            else
            {
                // GDI+ Widen can fail on repeated vertices at 0/100 percent bends.
                var distinct = new List<Point>();
                foreach (var point in points)
                    if (distinct.Count == 0 || distinct[^1] != point) distinct.Add(point);
                if (distinct.Count >= 2) path.AddLines(distinct.ToArray());
            }
            using var pen = new Pen(Color.Black, 12f)
            {
                StartCap = LineCap.Flat, EndCap = LineCap.Flat, LineJoin = LineJoin.Round
            };
            path.Widen(pen);
            using var transform = new Matrix();
            transform.Scale(scale, scale);
            path.Transform(transform);
            next.Union(path);
        }
        var previous = Region;
        Region = next;
        previous?.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // 原繪圖的管徑是 12；依螢幕 DPI 調整，極小尺寸則等比例縮小。
        float scale = Math.Min(DeviceDpi / 96f, Math.Min(ClientSize.Width, ClientSize.Height) / 14f);
        if (scale > 0)
        {
            var state = e.Graphics.Save();
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.ScaleTransform(scale, scale);
                int width = Math.Max(1, (int)(ClientSize.Width / scale));
                int height = Math.Max(1, (int)(ClientSize.Height / scale));
                // 直管維持置中；彎管及三通依百分比定位，縮放時保留比例。
                bool straight = Shape == PipeShape.Horizontal || Shape == PipeShape.Vertical;
                var center = straight
                    ? new Point(width / 2, height / 2)
                    : new Point((int)Math.Round(width * BendX / 100.0),
                                (int)Math.Round(height * BendY / 100.0));
                var left = new Point(0, center.Y);
                var right = new Point(width, center.Y);
                var top = new Point(center.X, 0);
                var bottom = new Point(center.X, height);
                Point[] points = Shape switch
                {
                    PipeShape.Vertical => [top, bottom],
                    PipeShape.LeftUp => [left, center, top],
                    PipeShape.LeftDown => [left, center, bottom],
                    PipeShape.RightUp => [right, center, top],
                    PipeShape.RightDown => [right, center, bottom],
                    _ => [left, right]
                };
                if (Shape == PipeShape.TeeRight)
                    DrawTeeRight(e.Graphics, top, center, bottom, right);
                else
                    drawer.DrawFlowPipe(e.Graphics, FlowColor, points);
            }
            finally
            {
                e.Graphics.Restore(state);
            }
        }
        base.OnPaint(e);
    }

    private void DrawTeeRight(Graphics graphics, Point top, Point center, Point bottom, Point right)
    {
        // 每一層先畫完整三通，再畫下一層，避免支管的深色輪廓蓋住主管。
        using var path = new GraphicsPath();
        path.AddLine(top, bottom);
        path.StartFigure();
        path.AddLine(center, right);
        Color[] colors =
        [
            Color.FromArgb(39, 72, 76),
            Color.FromArgb(109, 151, 155),
            FlowColor.IsEmpty ? Color.FromArgb(186, 217, 219) : FlowColor,
            Color.FromArgb(233, 246, 246)
        ];
        float[] widths = [12f, 9f, 5f, 2f];
        for (int i = 0; i < widths.Length; i++)
        {
            using var pen = new Pen(colors[i], widths[i])
            {
                StartCap = LineCap.Flat,
                EndCap = LineCap.Flat,
                LineJoin = LineJoin.Round
            };
            graphics.DrawPath(pen, path);
        }
    }
}




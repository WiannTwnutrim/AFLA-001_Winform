using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PathDrawing;

/// <summary>使用既有 DrawValve 圖形的工具箱閥門控制項。</summary>
[ToolboxItem(true)]
[DefaultProperty(nameof(ForeColor))]
[DefaultEvent(nameof(Click))]
public class ValveControl : Control
{
    private readonly PathDrawer drawer = new();
    private Orientation orientation = Orientation.Vertical;

    public ValveControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        ForeColor = Color.Silver;
        TabStop = false;
    }

    protected override Size DefaultSize => new(36, 48);

    [Category("閥門"), Description("Vertical 為上下接管；Horizontal 為左右接管。切換後可調整 Size。")]
    [DefaultValue(Orientation.Vertical)]
    public Orientation Orientation
    {
        get => orientation;
        set
        {
            if (!Enum.IsDefined(typeof(Orientation), value))
                throw new InvalidEnumArgumentException(nameof(value), (int)value, typeof(Orientation));
            if (orientation == value) return;
            orientation = value;
            UpdateValveRegion();
            Invalidate();
        }
    }

    [Category("閥門"), Description("閥門的漸層顏色，例如 Silver 或 LimeGreen。")]
    [DefaultValue(typeof(Color), "Silver")]
    public override Color ForeColor
    {
        get => base.ForeColor;
        set => base.ForeColor = value;
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
        UpdateValveRegion();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        UpdateValveRegion();
    }

    protected override void OnDpiChangedAfterParent(EventArgs e)
    {
        base.OnDpiChangedAfterParent(e);
        UpdateValveRegion();
    }

    private void UpdateValveRegion()
    {
        float width = Orientation == Orientation.Horizontal ? ClientSize.Height : ClientSize.Width;
        float height = Orientation == Orientation.Horizontal ? ClientSize.Width : ClientSize.Height;
        var next = new Region();
        next.MakeEmpty();
        if (width > 0 && height > 0)
        {
            float x = width / 2, y = height / 2, half = width * .42f, radius = width * .13f;
            using var upper = new GraphicsPath();
            upper.AddPolygon([new PointF(x - half, 0), new PointF(x + half, 0), new PointF(x, y)]);
            using var lower = new GraphicsPath();
            lower.AddPolygon([new PointF(x - half, height), new PointF(x + half, height), new PointF(x, y)]);
            using var hub = new GraphicsPath();
            hub.AddEllipse(x - radius, y - radius, radius * 2, radius * 2);
            next.Union(upper);
            next.Union(lower);
            next.Union(hub);
            if (Orientation == Orientation.Horizontal)
            {
                using var transform = new Matrix();
                transform.Translate(ClientSize.Width, 0);
                transform.Rotate(90);
                next.Transform(transform);
            }
        }
        var previous = Region;
        Region = next;
        previous?.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (ClientSize.Width > 0 && ClientSize.Height > 0)
        {
            var state = e.Graphics.Save();
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                if (Orientation == Orientation.Horizontal)
                {
                    e.Graphics.TranslateTransform(ClientSize.Width, 0);
                    e.Graphics.RotateTransform(90);
                    drawer.DrawValve(e.Graphics,
                        new Rectangle(0, 0, ClientSize.Height, ClientSize.Width), ForeColor);
                }
                else
                    drawer.DrawValve(e.Graphics, ClientRectangle, ForeColor);
            }
            finally
            {
                e.Graphics.Restore(state);
            }
        }
        base.OnPaint(e);
    }
}


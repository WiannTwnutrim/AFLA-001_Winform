using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PathDrawing;

/// <summary>直立柱狀元件，外框與中央環片可獨立變色。</summary>
[ToolboxItem(true), DefaultProperty(nameof(OuterColor)), DefaultEvent(nameof(Click))]
public class ColumnControl : Control
{
    private Color outerColor = Color.SkyBlue;
    private Color innerColor = Color.Firebrick;
    private Color chamberColor = Color.DimGray;

    public ColumnControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        TabStop = false;
    }

    protected override Size DefaultSize => new(140, 180);

    [Category("柱狀元件"), DefaultValue(typeof(Color), "SkyBlue"), Description("外框、頂蓋與底座的整體顏色。")]
    public Color OuterColor
    {
        get => outerColor;
        set { if (outerColor == value) return; outerColor = value; Invalidate(); }
    }

    [Category("柱狀元件"), DefaultValue(typeof(Color), "Firebrick"), Description("中央環片顏色。")]
    public Color InnerColor
    {
        get => innerColor;
        set { if (innerColor == value) return; innerColor = value; Invalidate(); }
    }

    [Category("柱狀元件"), DefaultValue(typeof(Color), "DimGray"), Description("中央內腔底色。")]
    public Color ChamberColor
    {
        get => chamberColor;
        set { if (chamberColor == value) return; chamberColor = value; Invalidate(); }
    }

    [DefaultValue(typeof(Color), "Transparent")]
    public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

    [DefaultValue(false)]
    public new bool TabStop { get => base.TabStop; set => base.TabStop = value; }

    private Matrix LayoutTransform()
    {
        float scale = Math.Min(ClientSize.Width / 140f, ClientSize.Height / 180f);
        var matrix = new Matrix();
        matrix.Translate((ClientSize.Width - 140 * scale) / 2, (ClientSize.Height - 180 * scale) / 2);
        matrix.Scale(scale, scale);
        return matrix;
    }

    private static GraphicsPath Outline()
    {
        var path = new GraphicsPath(FillMode.Winding);
        path.AddRectangle(new RectangleF(39, 1, 62, 164));
        path.AddRectangle(new RectangleF(31, 157, 78, 14));
        path.AddPolygon([new PointF(1, 177), new PointF(31, 171), new PointF(109, 171),
            new PointF(139, 177), new PointF(139, 179), new PointF(1, 179)]);
        return path;
    }

    protected override void OnHandleCreated(EventArgs e) { base.OnHandleCreated(e); UpdateOutline(); }
    protected override void OnSizeChanged(EventArgs e) { base.OnSizeChanged(e); UpdateOutline(); }
    protected override void OnDpiChangedAfterParent(EventArgs e) { base.OnDpiChangedAfterParent(e); UpdateOutline(); }

    private void UpdateOutline()
    {
        using var path = Outline();
        using var matrix = LayoutTransform();
        path.Transform(matrix);
        var next = new Region();
        next.MakeEmpty();
        if (ClientSize.Width > 0 && ClientSize.Height > 0) next.Union(path);
        var previous = Region;
        Region = next;
        previous?.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (ClientSize.Width > 0 && ClientSize.Height > 0)
        {
            var g = e.Graphics;
            var state = g.Save();
            try
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var matrix = LayoutTransform();
                g.MultiplyTransform(matrix);
                using var outline = Outline();
                using var frame = new SolidBrush(OuterColor);
                using var light = new SolidBrush(ControlPaint.Light(OuterColor));
                using var dark = new Pen(ControlPaint.Dark(OuterColor), .8f);
                g.FillPath(frame, outline);
                using var chamber = new LinearGradientBrush(new Rectangle(55, 9, 30, 148),
                    ChamberColor, ControlPaint.Dark(ChamberColor), LinearGradientMode.Horizontal);
                g.FillRectangle(chamber, 55, 9, 30, 148);
                using var inner = new SolidBrush(InnerColor);
                using var rim = new Pen(ControlPaint.Light(InnerColor), 1);
                using var recess = new SolidBrush(ControlPaint.Dark(InnerColor));
                for (int i = 0; i < 8; i++)
                {
                    float y = 14 + i * 18;
                    g.FillEllipse(inner, 56, y, 28, 8);
                    g.DrawEllipse(rim, 56, y, 28, 8);
                    g.FillEllipse(recess, 62, y + 2, 16, 3);
                    using var seam = new Pen(Color.FromArgb(110, Color.Silver), .7f);
                    g.DrawLine(seam, 55, y + 11, 85, y + 11);
                }
                g.FillRectangle(light, 39, 1, 62, 8);
                g.FillRectangle(light, 31, 157, 78, 4);
                g.DrawLine(dark, 55, 9, 55, 157);
                g.DrawLine(dark, 85, 9, 85, 157);

            }
            finally { g.Restore(state); }
        }
        base.OnPaint(e);
    }
}



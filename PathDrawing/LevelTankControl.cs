using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PathDrawing;

/// <summary>Metal tank with a percentage level and independently colored liquid.</summary>
[ToolboxItem(true), DefaultProperty(nameof(Level)), DefaultEvent(nameof(LevelChanged))]
public class LevelTankControl : Control
{
    private float level = 50;
    private Color liquidColor = Color.Gold;

    public LevelTankControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        TabStop = false;
    }

    protected override Size DefaultSize => new(100, 130);

    [Category("液位桶"), DefaultValue(50f), Description("液位百分比，範圍 0 到 100。")]
    public float Level
    {
        get => level;
        set
        {
            if (!float.IsFinite(value) || value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Level 必須介於 0 與 100。");
            if (level == value) return;
            level = value;
            Invalidate();
            LevelChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    [Category("液位桶"), DefaultValue(typeof(Color), "Gold"), Description("桶內液體顏色。")]
    public Color LiquidColor
    {
        get => liquidColor;
        set { if (liquidColor == value) return; liquidColor = value; Invalidate(); }
    }

    [DefaultValue(typeof(Color), "Transparent")]
    public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

    [DefaultValue(false)]
    public new bool TabStop { get => base.TabStop; set => base.TabStop = value; }

    [Category("液位桶"), Description("液位百分比變更時觸發。")]
    public event EventHandler? LevelChanged;

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateTankRegion();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        UpdateTankRegion();
    }

    protected override void OnDpiChangedAfterParent(EventArgs e)
    {
        base.OnDpiChangedAfterParent(e);
        UpdateTankRegion();
    }

    [System.Diagnostics.CodeAnalysis.AllowNull]
    [Category("液位桶"), Description("刻度字型、大小與樣式；文字不隨桶身縮放，請保留足夠寬度。")]
    public override Font Font { get => base.Font; set => base.Font = value; }

    protected override void OnFontChanged(EventArgs e)
    {
        base.OnFontChanged(e);
        UpdateTankRegion();
        Invalidate();
    }

    private GraphicsPath CreateScaleLabels()
    {
        var path = new GraphicsPath();
        using var format = new StringFormat { LineAlignment = StringAlignment.Center };
        float scale = Math.Min(ClientSize.Width / 100f, ClientSize.Height / 130f);
        float left = (ClientSize.Width - 100 * scale) / 2;
        float top = (ClientSize.Height - 130 * scale) / 2;
        float emSize = Font.SizeInPoints * DeviceDpi / 72f;
        foreach (int value in new[] { 0, 25, 50, 75, 100 })
            path.AddString(value.ToString(), Font.FontFamily, (int)Font.Style,
                emSize, new PointF(left + 75 * scale, top + (120 - value) * scale), format);
        return path;
    }

    private void UpdateTankRegion()
    {
        // A native window region excludes empty space, including gaps between scale labels.
        using var outline = new GraphicsPath(FillMode.Winding);

        outline.AddEllipse(10, 5, 60, 18);
        outline.AddRectangle(new RectangleF(10, 14, 60, 110));
        outline.AddEllipse(10, 116, 60, 12);
        foreach (int value in new[] { 0, 25, 50, 75, 100 })
            outline.AddRectangle(new RectangleF(66.5f, 119.5f - value, 7, 1));
        using var labels = CreateScaleLabels();
        // Keep glyph holes transparent; do not combine them with a winding body path.
        var next = new Region(outline);

        float scale = Math.Min(ClientSize.Width / 100f, ClientSize.Height / 130f);
        using var transform = new Matrix();
        transform.Translate((ClientSize.Width - 100 * scale) / 2,
            (ClientSize.Height - 130 * scale) / 2);
        transform.Scale(scale, scale);
        if (scale > 0) next.Transform(transform);
        else next.MakeEmpty();
        if (scale > 0) next.Union(labels);
        var previous = Region;
        Region = next;
        previous?.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Width < 2 || Height < 2) { base.OnPaint(e); return; }
        var g = e.Graphics;
        var state = g.Save();
        try
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            // Fit a fixed layout while preserving the cylindrical proportions.
            float scale = Math.Min(Width / 100f, Height / 130f);
            g.TranslateTransform((Width - 100 * scale) / 2, (Height - 130 * scale) / 2);
            g.ScaleTransform(scale, scale);
            using var metal = new LinearGradientBrush(new Rectangle(10, 0, 60, 130),
                Color.SlateGray, Color.WhiteSmoke, LinearGradientMode.Horizontal);
            metal.InterpolationColors = new ColorBlend
            {
                Colors = [Color.SlateGray, Color.Gainsboro, Color.WhiteSmoke, Color.DarkGray],
                Positions = [0, .25f, .65f, 1]
            };
            using var border = new Pen(Color.Gray, 1);

            g.FillEllipse(metal, 10, 5, 60, 18);
            g.FillRectangle(metal, 10, 14, 60, 110);
            g.FillEllipse(metal, 10, 116, 60, 12);
            // Visible chamber; zero leaves it empty, one hundred fills it to its top.
            var chamber = new RectangleF(15, 20, 50, 100);
            g.FillRectangle(Brushes.WhiteSmoke, chamber);
            float fillHeight = level;
            if (fillHeight > 0)
            {
                using var liquid = new LinearGradientBrush(chamber,
                    ControlPaint.Light(liquidColor), liquidColor, LinearGradientMode.Horizontal);
                g.FillRectangle(liquid, 15, 120 - fillHeight, 50, fillHeight);
            }
            g.DrawRectangle(border, 15, 20, 50, 100);
            using var ticks = new Pen(ForeColor);




            foreach (int value in new[] { 0, 25, 50, 75, 100 })
            {
                float y = 120 - value;
                g.DrawLine(ticks, 67, y, 73, y);

            }
        }
        finally { g.Restore(state); }
        var labelState = g.Save();
        try
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            using var labels = CreateScaleLabels();
            using var ink = new SolidBrush(ForeColor);
            g.FillPath(ink, labels);
        }
        finally { g.Restore(labelState); }
        base.OnPaint(e);
    }
}


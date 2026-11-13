using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PathDrawing;

/// <summary>圓形金屬框指示燈。</summary>
[ToolboxItem(true), DefaultProperty(nameof(LightColor)), DefaultEvent(nameof(Click))]
public class IndicatorLightControl : Control
{
    private Color lightColor = Color.DimGray;
    private string displayName = "";
    private string ioNumber = "";

    [Category("指示燈"), DefaultValue(""), Description("右側第一行的顯示名稱；Name仍是程式元件識別名稱。")]
    public string DisplayName
    {
        get => displayName;
        set { value ??= ""; if (displayName == value) return; displayName = value; UpdateOutline(); Invalidate(); }
    }

    [Category("指示燈"), DefaultValue(""), Description("右側第二行IO編號，例如DI 2.09。")]
    public string IONumber
    {
        get => ioNumber;
        set { value ??= ""; if (ioNumber == value) return; ioNumber = value; UpdateOutline(); Invalidate(); }
    }

    private bool HasLabels => !string.IsNullOrEmpty(displayName) || !string.IsNullOrEmpty(ioNumber);

    public IndicatorLightControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        TabStop = false;
    }

    protected override Size DefaultSize => new(180, 56);

    [Category("指示燈"), DefaultValue(typeof(Color), "DimGray"), Description("指示燈內部顏色，例如LimeGreen、Red、Gold或DimGray。")]
    public Color LightColor
    {
        get => lightColor;
        set { if (lightColor == value) return; lightColor = value; Invalidate(); }
    }

    [DefaultValue(typeof(Color), "Transparent")]
    public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

    [DefaultValue(false)]
    public new bool TabStop { get => base.TabStop; set => base.TabStop = value; }

    private RectangleF LampBounds()
    {
        float diameter = Math.Max(0, Math.Min(ClientSize.Width, ClientSize.Height) - 2);
        return new RectangleF(HasLabels ? 1f : (ClientSize.Width - diameter) / 2f,
            (ClientSize.Height - diameter) / 2f, diameter, diameter);
    }

    protected override void OnHandleCreated(EventArgs e) { base.OnHandleCreated(e); UpdateOutline(); }
    protected override void OnSizeChanged(EventArgs e) { base.OnSizeChanged(e); UpdateOutline(); }
    protected override void OnDpiChangedAfterParent(EventArgs e) { base.OnDpiChangedAfterParent(e); UpdateOutline(); }

    protected override void OnFontChanged(EventArgs e)
    {
        base.OnFontChanged(e);
        UpdateOutline();
        Invalidate();
    }

    private GraphicsPath LabelPaths()
    {
        var path = new GraphicsPath();
        if (!HasLabels || ClientSize.Width <= 0 || ClientSize.Height <= 0) return path;
        var lamp = LampBounds();
        float x = lamp.Right + 6 * DeviceDpi / 96f;
        float emSize = Font.SizeInPoints * DeviceDpi / 72f;
        using var format = new StringFormat(StringFormat.GenericTypographic);
        float top = (ClientSize.Height - Font.Height * 2) / 2f;
        if (!string.IsNullOrEmpty(displayName))
            path.AddString(displayName, Font.FontFamily, (int)Font.Style, emSize, new PointF(x, top), format);
        if (!string.IsNullOrEmpty(ioNumber))
            path.AddString(ioNumber, Font.FontFamily, (int)Font.Style, emSize,
                new PointF(x, top + Font.Height), format);
        return path;
    }

    private void UpdateOutline()
    {
        using var path = new GraphicsPath();
        var bounds = LampBounds();
        var next = new Region();
        next.MakeEmpty();
        if (bounds.Width > 0)
        {
            path.AddEllipse(bounds);
            next.Union(path);
        }
        using var labels = LabelPaths();
        if (labels.PointCount > 0) next.Union(labels);
        var previous = Region;
        Region = next;
        previous?.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var bounds = LampBounds();
        if (bounds.Width > 0)
        {
            var g = e.Graphics;
            var state = g.Save();
            try
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                float scale = bounds.Width / 54f;
                g.TranslateTransform(bounds.X, bounds.Y);
                g.ScaleTransform(scale, scale);
                using var rim = new LinearGradientBrush(new Rectangle(0,0,54,54),
                    Color.WhiteSmoke, Color.Gray, LinearGradientMode.Vertical);
                g.FillEllipse(rim, 0,0,54,54);
                g.FillEllipse(Brushes.Black, 2,2,50,50);
                using var bezel = new LinearGradientBrush(new Rectangle(4,4,46,46),
                    Color.Silver, Color.FromArgb(55,55,55), LinearGradientMode.ForwardDiagonal);
                g.FillEllipse(bezel,4,4,46,46);
                using var lensPath = new GraphicsPath();
                lensPath.AddEllipse(7,7,40,40);
                using var lens = new PathGradientBrush(lensPath)
                {
                    CenterPoint = new PointF(21,18),
                    CenterColor = ControlPaint.Light(LightColor),
                    SurroundColors = [ControlPaint.Dark(LightColor)]
                };
                g.FillPath(lens,lensPath);
                using var highlight = new LinearGradientBrush(new Rectangle(11,9,30,19),
                    Color.FromArgb(220,Color.White), Color.FromArgb(0,Color.White), LinearGradientMode.Vertical);
                g.FillEllipse(highlight,11,9,30,19);
            }
            finally { g.Restore(state); }
        }
        var textState = e.Graphics.Save();
        try
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var labels = LabelPaths();
            using var ink = new SolidBrush(ForeColor);
            e.Graphics.FillPath(ink, labels);
        }
        finally { e.Graphics.Restore(textState); }
        base.OnPaint(e);
    }
}


using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PathDrawing;

public enum ArmShape { Arm1 = 1, Arm2 = 2 }

/// <summary>沿用 DrawArm 的銀色 ARM 圓筒，依控制項大小等比例縮放。</summary>
[ToolboxItem(false)]
[DefaultProperty(nameof(Shape))]
[DefaultEvent(nameof(Click))]
public class ArmControl : Control
{
    private readonly PathDrawer drawer = new();
    private float? angle;
    private ArmShape shape = ArmShape.Arm1;
    private Color flowColor = Color.Empty;

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(typeof(Color), "")]
    [Description("舊版相容屬性；手臂不再繪製管線，此屬性不影響外觀。")]
    public Color FlowColor
    {
        get => flowColor;
        set { if (flowColor == value) return; flowColor = value; Invalidate(); }
    }

    protected virtual int AssemblyKind => (int)Shape;

    [Category("ARM"), DefaultValue(ArmShape.Arm1)]
    [Description("Arm1：右側圓筒；Arm2：左側細圓筒。未自訂 Angle 時會自動套用對應角度。")]
    public ArmShape Shape
    {
        get => shape;
        set
        {
            if (!Enum.IsDefined(value))
                throw new InvalidEnumArgumentException(nameof(value), (int)value, typeof(ArmShape));
            if (shape == value) return;
            shape = value;
            UpdateArmRegion();
            Invalidate();
        }
    }

    public ArmControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        TabStop = false;
    }

    protected override Size DefaultSize => new(142, 124);

    [Category("ARM"), Description("旋轉角度（-180～180）。0 直立向下；ARM1 使用 30，ARM2 使用 -30。")]
    public float Angle
    {
        get => angle ?? (AssemblyKind == 2 ? -30f : 30f);
        set
        {
            if (!float.IsFinite(value) || value < -180f || value > 180f)
                throw new ArgumentOutOfRangeException(nameof(value), "Angle 必須介於 -180 與 180。");
            if (angle == value) return;
            angle = value;
            UpdateArmRegion();
            Invalidate();
        }
    }

    public void ResetAngle() { angle = null; UpdateArmRegion(); Invalidate(); }
    private bool ShouldSerializeAngle() => angle.HasValue;

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

    // 與 OnPaint 使用同一組邊界，讓呼叫端能取得實際管線接口。
    private (RectangleF Bounds, float Scale) GetLayout()
    {
        float halfWidth = AssemblyKind == 2 ? 13f : 18f;
        float length = AssemblyKind == 2 ? 88f : 80f;
        PointF[] corners = [new(-halfWidth, 0), new(halfWidth, 0), new(halfWidth, length), new(-halfWidth, length)];
        using var rotation = new Matrix();
        rotation.Rotate(Angle);
        rotation.TransformPoints(corners);
        float left = corners.Min(p => p.X), top = corners.Min(p => p.Y);
        var bounds = RectangleF.FromLTRB(left, top, corners.Max(p => p.X), corners.Max(p => p.Y));
        float margin = 4f + 12f * DeviceDpi / 96f;
        float scale = Math.Max(0, Math.Min((ClientSize.Width - margin) / bounds.Width,
                                         (ClientSize.Height - margin) / bounds.Height));
        return (bounds, scale);
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public PointF InletPoint
    {
        get
        {
            var (bounds, scale) = GetLayout();
            return new PointF((ClientSize.Width - bounds.Width * scale) / 2f - bounds.Left * scale,
                              (ClientSize.Height - bounds.Height * scale) / 2f - bounds.Top * scale);
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateArmRegion();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        UpdateArmRegion();
    }

    protected override void OnDpiChangedAfterParent(EventArgs e)
    {
        base.OnDpiChangedAfterParent(e);
        UpdateArmRegion();
    }

    // Clip the native window to the metal so sibling pipes remain visible outside it.
    private void UpdateArmRegion()
    {
        var (_, scale) = GetLayout();
        using var silhouette = new GraphicsPath(FillMode.Winding);
        if (AssemblyKind == 2)
        {
            silhouette.AddRectangle(new RectangleF(-10, 0, 20, 12));
            silhouette.AddRectangle(new RectangleF(-13, 12, 26, 43));
            silhouette.AddPolygon([new PointF(-13, 55), new PointF(13, 55), new PointF(8, 74), new PointF(-8, 74)]);
            silhouette.AddRectangle(new RectangleF(-6, 74, 12, 14));
        }
        else
        {
            silhouette.AddRectangle(new RectangleF(-16, 0, 32, 9));
            silhouette.AddRectangle(new RectangleF(-18, 7, 36, 57));
            silhouette.AddRectangle(new RectangleF(-16, 64, 32, 9));
            silhouette.AddEllipse(-16, 66, 32, 14);
        }
        var inlet = InletPoint;
        using var transform = new Matrix();
        transform.Translate(inlet.X, inlet.Y);
        transform.Scale(scale, scale);
        transform.Rotate(Angle);
        silhouette.Transform(transform);
        var next = new Region();
        next.MakeEmpty();
        if (scale > 0) next.Union(silhouette);
        var previous = Region;
        Region = next;
        previous?.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var (_, scale) = GetLayout();
        if (scale > 0)
        {
            var state = e.Graphics.Save();
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var inlet = InletPoint;
                e.Graphics.TranslateTransform(inlet.X, inlet.Y);
                e.Graphics.ScaleTransform(scale, scale);
                if (AssemblyKind == 2) DrawSlimArm(e.Graphics);
                else drawer.DrawArm(e.Graphics, Point.Empty, Angle);
            }
            finally { e.Graphics.Restore(state); }
        }
        base.OnPaint(e);
    }

    private void DrawSlimArm(Graphics graphics)
    {
        var state = graphics.Save();
        try
        {
            graphics.RotateTransform(Angle);
            using var metal = new LinearGradientBrush(new Rectangle(-13, 0, 26, 88),
                Color.SlateGray, Color.DarkGray, LinearGradientMode.Horizontal)
            {
                InterpolationColors = new ColorBlend
                {
                    Colors = [Color.SlateGray, Color.Gainsboro, Color.WhiteSmoke, Color.DarkGray],
                    Positions = [0f, 0.27f, 0.63f, 1f]
                }
            };
            graphics.FillRectangle(metal, -10, 0, 20, 12);
            graphics.FillRectangle(metal, -13, 12, 26, 43);
            using var taper = new GraphicsPath();
            taper.AddPolygon([new PointF(-13, 55), new PointF(13, 55),
                new PointF(8, 74), new PointF(-8, 74)]);
            graphics.FillPath(metal, taper);
            graphics.FillRectangle(metal, -6, 74, 12, 14);
            using var seam = new Pen(Color.FromArgb(145, 115, 126, 130));
            graphics.DrawLine(seam, -13, 55, 13, 55);
            graphics.DrawLine(seam, -8, 74, 8, 74);
        }
        finally { graphics.Restore(state); }
    }
}

/// <summary>右側 ARM1：向左傾斜的銀色圓筒。</summary>
[ToolboxItem(true), DefaultEvent(nameof(Click))]
public class Arm1Control : ArmControl
{
    protected override int AssemblyKind => 1;
    protected override Size DefaultSize => new(142, 116);
}

/// <summary>左側 ARM2：向右傾斜的細圓筒及下方接頭。</summary>
[ToolboxItem(true), DefaultEvent(nameof(Click))]
public class Arm2Control : ArmControl
{
    public Arm2Control() { Shape = ArmShape.Arm2; }
    protected override int AssemblyKind => 2;
    protected override Size DefaultSize => new(86, 124);

    [DefaultValue(ArmShape.Arm2)]
    public new ArmShape Shape { get => base.Shape; set => base.Shape = value; }
}




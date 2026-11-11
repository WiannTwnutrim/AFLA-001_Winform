using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PathDrawing;

public enum ArmShape { Arm1 = 1, Arm2 = 2 }

/// <summary>沿用 DrawArm 的銀色 ARM 圓筒，依控制項大小等比例縮放。</summary>
[ToolboxItem(true)]
[DefaultProperty(nameof(Shape))]
[DefaultEvent(nameof(Click))]
public class ArmControl : Control
{
    private readonly PathDrawer drawer = new();
    private float? angle;
    private ArmShape shape = ArmShape.Arm1;
    private Color flowColor = Color.Empty;

    [Category("ARM"), DefaultValue(typeof(Color), "")]
    [Description("接管流體顏色，與 PipeControl.FlowColor 相同；Empty 使用預設金屬色。")]
    public Color FlowColor
    {
        get => flowColor;
        set { if (flowColor == value) return; flowColor = value; Invalidate(); }
    }

    protected virtual int AssemblyKind => (int)Shape;

    [Category("ARM"), DefaultValue(ArmShape.Arm1)]
    [Description("Arm1：右側圓筒及橫管；Arm2：左側細圓筒與下接頭。未自訂 Angle 時會自動套用對應角度。")]
    public ArmShape Shape
    {
        get => shape;
        set
        {
            if (!Enum.IsDefined(value))
                throw new InvalidEnumArgumentException(nameof(value), (int)value, typeof(ArmShape));
            if (shape == value) return;
            shape = value;
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
            Invalidate();
        }
    }

    public void ResetAngle() { angle = null; Invalidate(); }
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
        if (AssemblyKind != 0)
            bounds = RectangleF.Union(bounds, AssemblyKind == 1
                ? RectangleF.FromLTRB(-22, -32, 86, 39)
                : RectangleF.FromLTRB(-9, -32, 9, 0));
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
                if (AssemblyKind != 0)
                {
                    DrawPipe(e.Graphics, new PointF(0, -32), PointF.Empty, scale);
                    if (AssemblyKind == 1)
                        DrawPipe(e.Graphics, new PointF(-22, 30), new PointF(86, 30), scale);
                }
                if (AssemblyKind == 2) DrawSlimArm(e.Graphics);
                else drawer.DrawArm(e.Graphics, Point.Empty, Angle);
            }
            finally { e.Graphics.Restore(state); }
        }
        base.OnPaint(e);
    }

    private void DrawPipe(Graphics graphics, PointF start, PointF end, float armScale)
    {
        // 筒身可縮放，接管保持與 PipeControl 相同的 DPI 管徑及四層配色。
        float pipeScale = Math.Min(DeviceDpi / 96f,
            Math.Min(ClientSize.Width, ClientSize.Height) / 14f);
        var state = graphics.Save();
        try
        {
            graphics.ScaleTransform(pipeScale / armScale, pipeScale / armScale);
            Point Map(PointF p) => new((int)Math.Round(p.X * armScale / pipeScale),
                                      (int)Math.Round(p.Y * armScale / pipeScale));
            drawer.DrawFlowPipe(graphics, FlowColor, Map(start), Map(end));
        }
        finally { graphics.Restore(state); }
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

/// <summary>右側 ARM1：上接管、右側橫管與向左傾斜的銀色圓筒。</summary>
[ToolboxItem(true), DefaultEvent(nameof(Click))]
public class Arm1Control : ArmControl
{
    protected override int AssemblyKind => 1;
    protected override Size DefaultSize => new(142, 116);
}

/// <summary>左側 ARM2：上接管、向右傾斜的細圓筒及下方接頭。</summary>
[ToolboxItem(true), DefaultEvent(nameof(Click))]
public class Arm2Control : ArmControl
{
    public Arm2Control() { Shape = ArmShape.Arm2; }
    protected override int AssemblyKind => 2;
    protected override Size DefaultSize => new(86, 124);

    [DefaultValue(ArmShape.Arm2)]
    public new ArmShape Shape { get => base.Shape; set => base.Shape = value; }
}

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

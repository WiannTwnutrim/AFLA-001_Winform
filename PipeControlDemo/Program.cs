using PathDrawing;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        using var form = new Form
        {
            Text = "PathDrawing DLL — PipeControl",
            ClientSize = new Size(720, 515),
            BackColor = Color.WhiteSmoke
        };
        int index = 0;
        foreach (PipeShape shape in Enum.GetValues<PipeShape>())
        {
            int x = 25 + index % 3 * 235;
            int y = 20 + index / 3 * 165;
            form.Controls.Add(new Label { Text = shape.ToString(), Location = new Point(x, y), AutoSize = true });
            var pipe = new PipeControl
            {
                Shape = shape,
                FlowColor = index % 2 == 0 ? Color.Empty : Color.DodgerBlue,
                Location = new Point(x, y + 25),
                Size = new Size(190, 110)
            };
            form.Controls.Add(pipe);
            index++;
        }
        if (args.Length == 2 && args[0] == "--preview")
        {
            form.ShowInTaskbar = false;
            form.Show();
            Application.DoEvents();
            using var bitmap = new Bitmap(form.Width, form.Height);
            form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            bitmap.Save(Path.GetFullPath(args[1]), System.Drawing.Imaging.ImageFormat.Png);
            return;
        }
        Application.Run(form);
    }
}

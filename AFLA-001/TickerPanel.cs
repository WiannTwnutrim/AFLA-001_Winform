namespace AFLA_001
{
    internal sealed class TickerPanel : Panel
    {
        private const TextFormatFlags TextFlags = TextFormatFlags.SingleLine |
            TextFormatFlags.NoPadding | TextFormatFlags.VerticalCenter |
            TextFormatFlags.PreserveGraphicsClipping;

        private string[] messages = Array.Empty<string>();
        private int index;
        private int offset;
        private int textWidth;

        public TickerPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        /// <summary>
        /// 設定要播什麼
        /// </summary>
        /// <param name="latest"></param>
        public void SetMessages(string[] latest)
        {
            if (messages.SequenceEqual(latest))
                return;

            string? current = messages.Length == 0 ? null : messages[index];
            messages = latest;
            int currentIndex = Array.IndexOf(messages, current);
            if (currentIndex >= 0)
                index = currentIndex;
            else
                StartMessage(0, ClientSize.Width);
            Invalidate();
        }

        public void Advance()
        {
            if (messages.Length == 0 || ClientSize.Width == 0)
                return;

            offset -= 5;
            if (offset + textWidth <= 0)
                StartMessage((index + 1) % messages.Length, ClientSize.Width);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (messages.Length == 0 || offset >= ClientSize.Width)
                return;

            var bounds = new Rectangle(offset, 0, textWidth, ClientSize.Height);
            TextRenderer.DrawText(e.Graphics, messages[index], Font, bounds, ForeColor, TextFlags);
        }

        private void StartMessage(int nextIndex, int left)
        {
            index = nextIndex;
            offset = left;
            textWidth = messages.Length == 0 ? 0 :
                TextRenderer.MeasureText(messages[index], Font, Size.Empty, TextFlags).Width;
        }
    }
}

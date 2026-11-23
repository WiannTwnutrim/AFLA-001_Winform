namespace AFLA_001
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string commandCsvPath = Path.Combine(AppContext.BaseDirectory, "ActionCommands.csv");
            if (File.Exists(commandCsvPath))
            {
                try
                {
                    var motions = new ExcelHelper().LoadActionCommands(commandCsvPath);
                    AdsService.ConfigureActionWrites(motions);
                }
                catch (Exception ex)
                {
                    Loghelper.Error($"無法載入動作點位：{ex.Message}");
                }
            }

            using var form = new Form1();
            using var ecTimer = new System.Windows.Forms.Timer { Interval = 500 };
            Task<double[]?>? pendingRead = null;
            bool readFailed = false;

            // 此函式只在背景工作執行，同一時間最多有一筆 EC 讀取。
            double[]? ReadEc()
            {
                try
                {
                    double[] values = AdsService.PollEc();
                    readFailed = false;
                    return values;
                }
                catch (Exception ex)
                {
                    if (!readFailed)
                        Loghelper.Error($"無法讀取 PLC EC：{ex.Message}");
                    readFailed = true;
                    return null;
                }
            }

            async void PollEc(object? sender, EventArgs e)
            {
                if (pendingRead != null || form.IsDisposed)
                    return;

                try
                {
                    pendingRead = Task.Run(ReadEc);
                    double[]? values = await pendingRead;
                    // WinForms 的 await 回到 UI 執行緒，再更新 Manual 表格。
                    if (!form.IsDisposed)
                        form.RefreshManualValues(values);
                }
                finally
                {
                    pendingRead = null;
                }
            }

            ecTimer.Tick += PollEc;
            form.Shown += (sender, e) =>
            {
                ecTimer.Start();
                PollEc(sender, e);
            };

            try
            {
                Application.Run(form);
            }
            finally
            {
                ecTimer.Stop();
                // 等背景讀取完成後才釋放 ADS，避免排程中的讀取在關閉後重新連線。
                try
                {
                    pendingRead?.GetAwaiter().GetResult();
                }
                finally
                {
                    AdsService.Shutdown();
                }
            }
        }
    }
}

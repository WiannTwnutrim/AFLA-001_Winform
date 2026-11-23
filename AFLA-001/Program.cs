namespace AFLA_001
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //debug資料夾下
            string commandCsvPath = Path.Combine(AppContext.BaseDirectory, "ActionCommands.csv");
            if (File.Exists(commandCsvPath))
            {
                try
                {
                    if (new ExcelHelper().TryLoadActionCommands(commandCsvPath, out var motions, out var error))
                        AdsService.ConfigureActionWrites(motions);
                    else
                        Loghelper.Error($"無法載入動作點位：{error}");
                }
                catch (Exception ex)
                {
                    Loghelper.Error($"無法載入動作點位：{ex.ToString()}");
                }
            }

            using var form = new Form1();
            Task<double[]?>? startupRead = null;
            Task? wrPolling = null;
            form.Shown += async (_, _) =>
            {
                Task<bool> connection = Task.Run(AdsService.Connection);

                wrPolling = Task.Run(async () =>
                {
                    if (await connection)
                        await AdsService.PollWrAsync();
                });

                startupRead = Task.Run<double[]?>(async () =>
                {
                    if (!await connection)
                        return null;

                    try
                    {
                        return AdsService.ReadEc();
                    }
                    catch (Exception ex)
                    {
                        Loghelper.Error($"無法讀取 PLC EC：{ex.Message}");
                        return null;
                    }
                });

                double[]? values = await startupRead;
                if (!form.IsDisposed)
                    form.RefreshManualValues(values);
            };


            try
            {
                Application.Run(form);
            }
            finally
            {
                AdsService.StopWrPolling();
                // 等背景讀取完成後才釋放 ADS，避免排程中的讀取在關閉後重新連線。
                try
                {
                    Task.WhenAll(
                        wrPolling ?? Task.CompletedTask,
                        startupRead ?? Task.CompletedTask
                    ).GetAwaiter().GetResult();
                }
                finally
                {
                    AdsService.Shutdown();
                }
            }
        }
    }
}

namespace AFLA_001
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                // 執行檔旁有功能 CSV 時，載入點位對應並初始化 ADS。
                string commandCsvPath = Path.Combine(AppContext.BaseDirectory, "ActionCommands.csv");
                if (File.Exists(commandCsvPath))
                {
                    try
                    {
                        AdsService.Connection(commandCsvPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ADS 初始化失敗",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Application.Run(new Form1());
            }
            finally
            {
                // 程式結束時統一釋放 ADS 連線及 handle。
                AdsService.Shutdown();
            }
        }
    }
}

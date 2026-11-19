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
                AdsService.Connection();
                Application.Run(new Form1());
            }
            finally
            {
                AdsService.Shutdown();
            }
        }
    }
}

namespace ClashSinicizationToolUpgrade
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!string.IsNullOrEmpty(args[0]))
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new UpgradeMainForm(args[0]));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
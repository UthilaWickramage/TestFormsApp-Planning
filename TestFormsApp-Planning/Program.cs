using System.ComponentModel;

namespace TestFormsApp_Planning
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (SplashScreen splash = new SplashScreen())
            {
                splash.Show();
                Application.DoEvents();

               
                var worker = new BackgroundWorker();
              

                worker.RunWorkerCompleted += (s, e) =>
                {
                    if (splash.InvokeRequired)
                    {
                        
                        splash.Invoke(new Action(() =>
                        {
                            splash.Close(); 
                        }));
                    }
                    else
                    {
                    
                        splash.Close();
                    }
                };

                worker.RunWorkerAsync();
                Application.Run(new Scheduler());
            }
        }
    }
}
using Elegant.Ui;
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
           SkinManager.DefaultTheme = EmbeddedTheme.Office2010Black;
            Application.SetCompatibleTextRenderingDefault(false);
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
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
using System;
using System.Threading;
using System.Windows.Forms;

namespace DimScreen
{
    internal static class Program
    {
        private static readonly string MutexName = "MultiScreenDimmerApplicationMutex";

        public static bool LaunchedViaStartup { get; set; }

        [STAThread]
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(true, MutexName, out bool createdNew))
            {
                if (createdNew)
                {
                    LaunchedViaStartup = args != null && args.Any(arg => arg.Equals("startup", StringComparison.CurrentCultureIgnoreCase));

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ApplicationConfiguration.Initialize();

                    var mainForm = new MultiScreenDimmer();
                    if (LaunchedViaStartup)
                    {
                        mainForm.WindowState = FormWindowState.Minimized;
                        mainForm.ShowInTaskbar = false;
                    }

                    Application.Run(mainForm);
                }
                else
                {
                    MessageBox.Show("Another instance of MultiScreenDimmer is already running.");
                    Application.Exit();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run with form or in the system tray as settings
            MainForm mainForm = new MainForm();
            if (Properties.Settings.Default.RunInSystemTray)
            {
                mainForm.MinimizeToSystemTray();
                Application.Run();
            }
            else
            {
                Application.Run(mainForm);
            }
        }
    }
}

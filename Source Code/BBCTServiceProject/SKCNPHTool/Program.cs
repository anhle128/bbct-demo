using DevExpress.XtraSplashScreen;
using KDQHNPHTool.Form;
using KDQHNPHTool.FormLoading;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Windows.Forms;

namespace KDQHNPHTool
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
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                SplashScreenManager.ShowForm(typeof(SplashScreenLoading));
                UpdateApp pizzaUpdater = new UpdateApp();
                bool isUpdateSuccess = pizzaUpdater.InstallUpdateSyncWithInfo();
                SplashScreenManager.CloseForm();
                if (!isUpdateSuccess)
                {
                    Application.Exit();
                }
                else
                {
                    Application.Run(new frmLogin());
                }
            }
            else
            {
                Application.Run(new frmLogin());
            }
        }
    }
}

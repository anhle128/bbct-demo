using DevExpress.XtraSplashScreen;
using BBCTDesignerTool.Common;
using BBCTDesignerTool.Form;
using BBCTDesignerTool.FormLoading;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBCTDesignerTool
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KDQHNPHTool.FormBase;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Model;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.MainDatabaseModels;
using ExitGames.Client.Photon;
using KDQHGameServer.Common.Enum;
using KDQHGameServer.Common.SerializeData.ResponseData;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.UserController
{
    public partial class ucCCU : ucManager
    {
        ListServer server = new ListServer();
        List<vChartCCU> lsCCU = new List<vChartCCU>();
        ConnectPhoton connectPT = new ConnectPhoton();

        public ucCCU()
        {
            InitializeComponent();
            btnChiTiet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            CommonShowDialog.ShowWaitForm();
            HandlerListUser();
            LoadDataToChart();
            CommonShowDialog.CloseWaitForm();
        }

        private void HandlerListUser()
        {
            foreach (var item in server.GetListServerPhoton())
            {
                connectPT.Connectd(item.url, item.port, item.appName);

                vChartCCU vChart = new vChartCCU()
                {
                    idServer = item.idServer,
                    nameServer = item.nameServer,
                    value = connectPT.countUsserOnline
                };

                if (connectPT.countUsserOnline > 0) { lsCCU.Add(vChart); }
            }
        }

        private void LoadDataToChart()
        {
            chartCCU.DataSource = lsCCU;
            chartCCU.RefreshData();
        }

        protected override void OnRefesh()
        {
            lsCCU.Clear();
            CommonShowDialog.ShowWaitForm();
            HandlerListUser();
            LoadDataToChart();
            CommonShowDialog.CloseWaitForm();
        }
    }
}

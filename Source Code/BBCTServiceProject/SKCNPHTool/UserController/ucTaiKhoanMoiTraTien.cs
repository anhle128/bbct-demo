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
using KDQHNPHTool.Model;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Common;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace KDQHNPHTool.UserController
{
    public partial class ucTaiKhoanMoiTraTien : DevExpress.XtraEditors.XtraUserControl
    {
        ListServer server = new ListServer();
        List<vUserInfor> lsUser = new List<vUserInfor>();
        public ucTaiKhoanMoiTraTien()
        {
            InitializeComponent();
            dteFromDate.EditValue = DateTime.Today;
            dteToDate.EditValue = DateTime.Today.AddDays(1);
            LoadDataToLUE();
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";
            lueChonServer.EditValue = 0;
        }

        private void LoadDataToList()
        {
            string idServer = lueChonServer.EditValue.ToString();
            if (idServer != "" && idServer != "0")
            {
                if (dteFromDate.Text != "" && dteToDate.Text != "")
                {
                    DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
                    DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
                    var tmpLogin = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.created_at >= fromDate && a.created_at <= toDate && a.isBot == false && a.server_id == idServer);

                    foreach (var item in tmpLogin)
                    {
                        vUserInfor user = new vUserInfor()
                        {
                            username = item.username
                        };
                        lsUser.Add(user);
                    }

                    int countTrans = 0;
                    foreach (var item in lsUser)
                    {
                        var tmpTrans = MongoController.UserTransaction.GetSingleData(MongoController.DatabaseManager.main_database, a => a.username == item.username && a.server_id == idServer);
                        if (tmpTrans != null)
                        {
                            countTrans++;
                        }
                    }

                    List<vChart1730> lsChart = new List<vChart1730>();
                    vChart1730 chart = new vChart1730()
                    {
                        date = lueChonServer.Text,
                        value = countTrans
                    };
                    lsChart.Add(chart);

                    chartUsser.DataSource = lsChart;
                }
            }
        }

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            CommonShowDialog.ShowWaitForm();
            LoadDataToList();
            CommonShowDialog.CloseWaitForm();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
            CommonShowDialog.ShowSuccessfulDialog("Xuất file thành công!");
        }
        private void ExportToExcel()
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var printingSystem = new PrintingSystemBase();
                    var compositeLink = new CompositeLinkBase();
                    compositeLink.PrintingSystemBase = printingSystem;

                    var link1 = new PrintableComponentLinkBase();
                    link1.Component = chartUsser;

                    compositeLink.Links.Add(link1);

                    var options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                    compositeLink.CreatePageForEachLink();
                    compositeLink.ExportToXlsx(saveDialog.FileName, options);
                }
            }
        }
    }
}

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
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using KDQHNPHTool.Common;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Models;

namespace KDQHNPHTool.UserController
{
    public partial class ucLogNhiemVuHangNgay : DevExpress.XtraEditors.XtraUserControl
    {
        ListServer server = new ListServer();
        List<MNhiemVuHangNgayLog> lsNhiemVu = new List<MNhiemVuHangNgayLog>();
        List<vChartGoldSilver> lsChart = new List<vChartGoldSilver>();

        public ucLogNhiemVuHangNgay()
        {
            InitializeComponent();
            dteFromDate.EditValue = DateTime.Today;
            LoadDataToLUE();
            LoadDataTypeNhiemVu();
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";
            lueChonServer.EditValue = 0;
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
                    link1.Component = chartNhiemVuHangNgay;

                    compositeLink.Links.Add(link1);

                    var options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                    compositeLink.CreatePageForEachLink();
                    compositeLink.ExportToXlsx(saveDialog.FileName, options);
                }
            }
        }

        private void LoadDataTypeNhiemVu()
        {
            lsChart.Clear();
            var tmpTypeNhiemVu = from tmp in ConnectDB.Entities.dbCTTypeNhiemVuHangNgays
                                 select tmp;

            foreach (var item in tmpTypeNhiemVu)
            {
                vChartGoldSilver chart = new vChartGoldSilver()
                {
                    hienCo = item.id,
                    type = item.value,
                    daTieu = 0
                };
                lsChart.Add(chart);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            CommonShowDialog.ShowWaitForm();

            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                if (dteFromDate.Text != "")
                {
                    string idServer = lueChonServer.EditValue.ToString();
                    DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
                    LoadDataToList(idServer, fromDate);

                    foreach (var item in lsNhiemVu)
                    {
                        foreach (var item1 in item.nhiemVuHangNgay)
                        {
                            if (item1.received == true)
                            {
                                var result = lsChart.Where(x => x.hienCo == (int)item1.type).FirstOrDefault();
                                result.daTieu += 1;
                            }
                        }
                    }

                    chartNhiemVuHangNgay.DataSource = lsChart;
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Phải chọn ngày để xem kết quả");
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Phải chọn server!");
            }

            CommonShowDialog.CloseWaitForm();
        }

        private void LoadDataToList(string idServer, DateTime fromDate)
        {
            lsNhiemVu.Clear();
            var tmpNhiemVu = MongoController.LogNhiemVuHangNgay.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

            foreach (var item in tmpNhiemVu)
            {
                MNhiemVuHangNgayLog log = new MNhiemVuHangNgayLog()
                {
                    username = item.username,
                    server_id = item.server_id,
                    created_at = item.created_at,
                    nhiemVuHangNgay = item.nhiemVuHangNgay
                };
                lsNhiemVu.Add(log);
            }
        }
    }
}

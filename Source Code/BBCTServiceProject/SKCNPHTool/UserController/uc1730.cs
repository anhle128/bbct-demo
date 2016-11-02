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
using KDQHNPHTool.Common;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace KDQHNPHTool.UserController
{
    public partial class uc1730 : DevExpress.XtraEditors.XtraUserControl
    {
        List<vUserLogin> lsUserLogin = new List<vUserLogin>();
        ListServer server = new ListServer();

        public uc1730()
        {
            InitializeComponent();
            dteTuNgay.EditValue = DateTime.Today;
            LoadDataToLUE();
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";
            lueChonServer.EditValue = 0;
        }

        private void LoadDataToList(string idServer, DateTime fromDate)
        {
            CommonShowDialog.ShowWaitForm();
            lsUserLogin.Clear();
            var tmpLogin = MongoController.UserLogin.GetListData(MongoController.DatabaseManager.main_database, a => a.server_id == idServer && a.login_time >= fromDate).OrderBy(x => x.login_time);

            foreach (var item in tmpLogin)
            {
                vUserLogin log = new vUserLogin()
                {
                    idServer = item.server_id,
                    username = item.username,
                    login_time = item.login_time,
                    logout_time = item.logout_time,
                    hash_code_time = item.hash_code_time,
                    count_time_login = (item.logout_time - item.login_time).Minutes
                };
                lsUserLogin.Add(log);
            }

            CommonShowDialog.CloseWaitForm();
        }

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                if (dteTuNgay.Text != "")
                {
                    string idServer = lueChonServer.EditValue.ToString();
                    DateTime fromDate = DateTime.Parse(dteTuNgay.EditValue.ToString());
                    LoadDataToList(idServer, fromDate);

                    if (dteDenNgay.Text != "" && dteTuNgay.Text != dteDenNgay.Text)
                    {
                        DateTime toDate = DateTime.Parse(dteDenNgay.EditValue.ToString());
                        TimeSpan timeSpan = toDate - fromDate;
                        List<vChart1730> lsChart = new List<vChart1730>();

                        for (int i = 0; i <= timeSpan.TotalDays; i++)
                        {
                            vChart1730 chart = new vChart1730()
                            {
                                date = fromDate.AddDays(i).ToShortDateString(),
                                value = 0
                            };
                            lsChart.Add(chart);
                        }

                        foreach (var item in lsChart)
                        {
                            var noticesGrouped = lsUserLogin.Where(x => x.login_time.ToShortDateString() == item.date && x.idServer == idServer).GroupBy(n => n.username).Select(group =>
                                                 new
                                                 {
                                                     name = group.Key,
                                                     count = group.Count()
                                                 });

                            var tmp = lsChart.Where(x => x.date == item.date).FirstOrDefault();
                            tmp.value = noticesGrouped.Count();
                        }

                        chart1730.DataSource = lsChart;
                    }
                    else
                    {
                        List<vChart1730> lsChart = new List<vChart1730>();
                        var noticesGrouped = lsUserLogin.Where(x => x.login_time.ToShortDateString() == fromDate.ToShortDateString() && x.idServer == idServer).GroupBy(n => n.username).Select(group =>
                                                new
                                                {
                                                    name = group.Key,
                                                    count = group.Count()
                                                });

                        vChart1730 chart = new vChart1730()
                        {
                            date = fromDate.ToShortDateString(),
                            value = noticesGrouped.Count()
                        };
                        lsChart.Add(chart);

                        chart1730.DataSource = lsChart;
                    }
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
                    link1.Component = chart1730;

                    compositeLink.Links.Add(link1);

                    var options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                    compositeLink.CreatePageForEachLink();
                    compositeLink.ExportToXlsx(saveDialog.FileName, options);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
            CommonShowDialog.ShowSuccessfulDialog("Xuất file thành công!");
        }
    }
}

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
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Common;
using KDQHNPHTool.Model;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace KDQHNPHTool.UserController
{
    public partial class ucPCUACU : DevExpress.XtraEditors.XtraUserControl
    {
        List<vUserLogin> lsUserLogin = new List<vUserLogin>();
        ListServer server = new ListServer();

        public ucPCUACU()
        {
            InitializeComponent();
            dteChonNgay.EditValue = DateTime.Today;
            LoadDataToLUE();
        }

        private void LoadDataToLUE()
        {
            slueChonServer.Properties.DataSource = server.GetListServer();
            slueChonServer.Properties.DisplayMember = "value";
            slueChonServer.Properties.ValueMember = "id";
            slueChonServer.EditValue = 0;
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (slueChonServer.EditValue.ToString() != "" && slueChonServer.EditValue.ToString() != "0")
            {
                if (dteChonNgay.Text != "")
                {
                    string idServer = slueChonServer.EditValue.ToString();

                    DateTime fromDate = DateTime.Parse(dteChonNgay.EditValue.ToString());
                    LoadDataToList(idServer, fromDate);

                    if (dteDenNgay.Text != "" && dteChonNgay.Text != dteDenNgay.Text)
                    {
                        DateTime toDate = DateTime.Parse(dteDenNgay.EditValue.ToString());
                        TimeSpan timeSpan = toDate - fromDate;
                        List<FormatTime> lsCountTimeDate = new List<FormatTime>();
                        List<vChartPCUInTime> lsChart = new List<vChartPCUInTime>();

                        for (int i = 0; i <= timeSpan.TotalDays; i++)
                        {
                            vChartPCUInTime chart = new vChartPCUInTime()
                            {
                                date = fromDate.AddDays(i).ToShortDateString(),
                                value = 0
                            };
                            lsChart.Add(chart);
                        }

                        for (int i = 0; i < 24; i++)
                        {
                            FormatTime time = new FormatTime()
                            {
                                id = i,
                                value = 0
                            };
                            lsCountTimeDate.Add(time);
                        }

                        foreach (var item in lsChart)
                        {
                            foreach (var item1 in lsUserLogin.Where(x => x.idServer == idServer && x.login_time.ToShortDateString() == item.date))
                            {
                                foreach (var item2 in lsCountTimeDate.Where(x => x.id == item1.login_time.Hour))
                                {
                                    var result = lsCountTimeDate.Where(x => x.id == item2.id).FirstOrDefault();
                                    result.value = result.value + 1;
                                }
                            }

                            int maxValue = lsCountTimeDate.Max(s => s.value);
                            var resultMaxValue = lsCountTimeDate.Where(x => x.value == maxValue).FirstOrDefault();
                            var tmpChart = lsChart.Where(x => x.date == item.date).FirstOrDefault();
                            tmpChart.value = maxValue;
                            lsCountTimeDate.ForEach(x => x.value = 0);
                        }

                        int countACU = 0;
                        foreach (var item in lsChart)
                        {
                            countACU += item.value;
                        }
                        int acu = Convert.ToInt32(countACU / timeSpan.TotalDays);
                        lsChart.ForEach(x => x.aven = acu);
                        chartTheoThoiGian.DataSource = lsChart;
                        chartTheoThoiGian.RefreshData();
                        chartPCU.Visible = false;
                        chartTheoThoiGian.Visible = true;
                        lb1.Visible = false;
                        lb2.Visible = false;
                        lbACU.Visible = false;
                        lbPCU.Visible = false;
                    }
                    else
                    {
                        List<FormatTime> lsCountTime = new List<FormatTime>();
                        for (int i = 0; i < 24; i++)
                        {
                            FormatTime time = new FormatTime()
                            {
                                id = i,
                                value = 0
                            };
                            lsCountTime.Add(time);
                        }

                        foreach (var item in lsCountTime)
                        {
                            foreach (var item1 in lsUserLogin.Where(x => x.idServer == idServer && x.hash_code_time == fromDate.GetHashCode()))
                            {
                                if (item1.login_time.Hour == item.id)
                                {
                                    var result = lsCountTime.Where(x => x.id == item.id).FirstOrDefault();
                                    result.value = result.value + 1;
                                }
                            }
                        }

                        //PCU
                        int maxValue = lsCountTime.Max(s => s.value);
                        var resultMaxValue = lsCountTime.Where(x => x.value == maxValue).FirstOrDefault();
                        lbPCU.Text = maxValue + " người vào thời điểm từ " + resultMaxValue.id + " giờ đến " + (resultMaxValue.id + 1) + " giờ";

                        //ACU
                        int countACU = 0;
                        foreach (var item in lsCountTime)
                        {
                            countACU += item.value;
                        }
                        lbACU.Text = (countACU / 24) + " người";
                        lsCountTime.ForEach(x => x.aven = (countACU / 24));

                        //Chart
                        chartPCU.Visible = true;
                        chartTheoThoiGian.Visible = false;
                        chartPCU.DataSource = lsCountTime;
                        chartPCU.RefreshData();
                        lb1.Visible = true;
                        lb2.Visible = true;
                        lbACU.Visible = true;
                        lbPCU.Visible = true;
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
                    link1.Component = chartPCU;

                    compositeLink.Links.Add(link1);

                    var options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                    compositeLink.CreatePageForEachLink();
                    compositeLink.ExportToXlsx(saveDialog.FileName, options);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}

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
using MongoDBModel.MainDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Common;
using KDQHNPHTool.Model_View;

namespace KDQHNPHTool.UserController
{
    public partial class ucLevelUpLog : DevExpress.XtraEditors.XtraUserControl
    {
        ListServer server = new ListServer();
        List<MUserLevelUpLog> lsUserLevelUp = new List<MUserLevelUpLog>();
        List<vChart1730> lsChart = new List<vChart1730>();

        public ucLevelUpLog()
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
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
                    link1.Component = chartLevelUp;

                    compositeLink.Links.Add(link1);

                    var options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                    compositeLink.CreatePageForEachLink();
                    compositeLink.ExportToXlsx(saveDialog.FileName, options);
                }
            }
        }

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            lsChart.Clear();
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                string idServer = lueChonServer.EditValue.ToString();

                if (dteFromDate.Text != "" && dteToDate.Text != "")
                {
                    DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
                    DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());

                    if (txtMinLevel.Text != "" && txtMaxLevel.Text == "")
                    {
                        int level = int.Parse(txtMinLevel.Text);
                        LoadDataToList(idServer, fromDate, toDate);

                        vChart1730 chart = new vChart1730()
                        {
                            date = "Level " + txtMinLevel.Text,
                            value = lsUserLevelUp.Where(x => x.level == level).Count()
                        };
                        lsChart.Add(chart);
                        chartLevelUp.DataSource = lsChart;
                    }
                    else if (txtMinLevel.Text != "" && txtMaxLevel.Text != "")
                    {
                        if (int.Parse(txtMinLevel.Text) < int.Parse(txtMaxLevel.Text))
                        {
                            int minLevel = int.Parse(txtMinLevel.Text);
                            int maxLevel = int.Parse(txtMaxLevel.Text);
                            LoadDataToList(idServer, fromDate, toDate);

                            vChart1730 chart = new vChart1730()
                            {
                                date = "Level " + minLevel + " - " + maxLevel,
                                value = lsUserLevelUp.Where(x => x.level >= minLevel && x.level <= maxLevel).Count()
                            };
                            lsChart.Add(chart);
                            chartLevelUp.DataSource = lsChart;
                        }
                        else
                        {
                            CommonShowDialog.ShowErrorDialog("Min Level phải nhỏ hơn Max Level");
                        }
                    }
                    else
                    {
                        CommonShowDialog.ShowErrorDialog("Phải chọn Min Level");
                    }
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Phải chọn khoảng ngày để xem kết quả");
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Phải chọn server!");
            }
        }

        private void LoadDataToList(string idServer, DateTime fromDate, DateTime toDate)
        {
            lsUserLevelUp.Clear();
            var tmpUserLevelUp = MongoController.UserLevelUp.GetListData(MongoController.DatabaseManager.main_database, a => a.server_id == idServer && a.created_at >= fromDate && a.created_at <= toDate);

            foreach (var item in tmpUserLevelUp)
            {
                MUserLevelUpLog log = new MUserLevelUpLog()
                {
                    server_id = item.server_id,
                    username = item.username,
                    level = item.level,
                    created_at = item.created_at,
                    updated_at = item.updated_at
                };
                lsUserLevelUp.Add(log);
            }
        }
    }
}

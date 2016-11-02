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
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using KDQHNPHTool.Common;
using MongoDBModel.SubDatabaseModels;

namespace KDQHNPHTool.UserController
{
    public partial class ucOnlineTime510152030 : DevExpress.XtraEditors.XtraUserControl
    {
        List<vUserLogin> lsUserLogin = new List<vUserLogin>();
        List<vUserInfor> lsUser = new List<vUserInfor>();
        ListServer server = new ListServer();

        public ucOnlineTime510152030()
        {
            InitializeComponent();
            dteFromDate.EditValue = DateTime.Today;
            dteToDate.EditValue = DateTime.Today.AddDays(1);
            LoadDataToLUE();
        }

        private void LoadDataToList(string idServer)
        {
            lsUserLogin.Clear();
            var tmpLogin = MongoController.UserLogin.GetListData(MongoController.DatabaseManager.main_database, a => a.server_id == idServer).OrderBy(x => x.login_time);

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
        }

        private void LoadDataListUser(string idServer, DateTime fromDate, DateTime toDate)
        {
            lsUser.Clear();
            List<MUserInfo> listUserInfos = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer && a.isBot == false && a.created_at >= fromDate && a.created_at <= toDate);
            foreach (var item in listUserInfos)
            {
                vUserInfor cs = new vUserInfor()
                {
                    avatar = item.avatar,
                    exp = item.exp,
                    gold = item.gold,
                    level = item.level,
                    nickname = item.nickname,
                    posX = item.posX,
                    posY = item.posY,
                    silver = item.silver,
                    stamina = item.stamina,
                    username = item.username,
                    vip = item.vip,
                    hash_code_login_time = item.hash_code_login_time,
                    create_at = item.created_at,
                    update_at = item.updated_at,
                    gold_lock = item.ruby,
                    isBot = item.isBot
                };
                lsUser.Add(cs);
            }
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";
            lueChonServer.EditValue = 0;
        }

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                if (dteFromDate.Text != "" && dteToDate.Text != "")
                {
                    string idServer = lueChonServer.EditValue.ToString();
                    DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
                    DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
                    LoadDataToList(idServer);
                    LoadDataListUser(idServer, fromDate, toDate);
                    List<vChartOnlineTime510152030> lsChart = new List<vChartOnlineTime510152030>();

                    for (int i = 5; i <= 30; i += 5)
                    {
                        vChartOnlineTime510152030 chart = new vChartOnlineTime510152030()
                        {
                            time = i + " phút",
                            value = 0
                        };
                        lsChart.Add(chart);
                    }

                    foreach (var item in lsUser)
                    {
                        foreach (var item1 in lsUserLogin)
                        {
                            if (item1.username == item.username)
                            {
                                if (item1.count_time_login >= 5 && item1.count_time_login <= 9)
                                {
                                    var result = lsChart.Where(x => x.time == "5 phút").FirstOrDefault();
                                    result.value += 1;
                                }
                                else if (item1.count_time_login >= 10 && item1.count_time_login <= 14)
                                {
                                    var result = lsChart.Where(x => x.time == "10 phút").FirstOrDefault();
                                    result.value += 1;
                                }
                                else if (item1.count_time_login >= 15 && item1.count_time_login <= 19)
                                {
                                    var result = lsChart.Where(x => x.time == "15 phút").FirstOrDefault();
                                    result.value += 1;
                                }
                                else if (item1.count_time_login >= 20 && item1.count_time_login <= 24)
                                {
                                    var result = lsChart.Where(x => x.time == "20 phút").FirstOrDefault();
                                    result.value += 1;
                                }
                                else if (item1.count_time_login >= 25 && item1.count_time_login <= 30)
                                {
                                    var result = lsChart.Where(x => x.time == "25 phút").FirstOrDefault();
                                    result.value += 1;
                                }
                                else if (item1.count_time_login >= 30)
                                {
                                    var result = lsChart.Where(x => x.time == "30 phút").FirstOrDefault();
                                    result.value += 1;
                                }
                            }
                        }
                    }
                    chartUser.DataSource = lsChart;
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
                    link1.Component = chartUser;

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

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
using MongoDBModel.SubDatabaseModels;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace KDQHNPHTool.UserController
{
    public partial class ucNguoiChoiKhongDangNhap : DevExpress.XtraEditors.XtraUserControl
    {
        List<vUserLogin> lsUserLogin = new List<vUserLogin>();
        List<vUserInfor> lsUser = new List<vUserInfor>();
        ListServer server = new ListServer();

        public ucNguoiChoiKhongDangNhap()
        {
            InitializeComponent();
            dteMocThoiGian.EditValue = DateTime.Today;
            LoadDataToLUE();
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";
            lueChonServer.EditValue = 0;
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

        private void LoadDataListUser(string idServer)
        {
            lsUser.Clear();
            List<MUserInfo> listUserInfos = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer && a.isBot == false);
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

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            CommonShowDialog.ShowWaitForm();
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                if (dteMocThoiGian.Text != "")
                {
                    string idServer = lueChonServer.EditValue.ToString();
                    DateTime fromDate = DateTime.Parse(dteMocThoiGian.EditValue.ToString());
                    LoadDataToList(idServer);
                    LoadDataListUser(idServer);

                    List<vChartOnlineTime510152030> lsChart = new List<vChartOnlineTime510152030>();
                    vChartOnlineTime510152030 chart = new vChartOnlineTime510152030()
                    {
                        time = "1 ngày",
                        value = 0
                    };
                    lsChart.Add(chart);

                    vChartOnlineTime510152030 chart1 = new vChartOnlineTime510152030()
                    {
                        time = "7 ngày",
                        value = 0
                    };
                    lsChart.Add(chart1);

                    vChartOnlineTime510152030 chart2 = new vChartOnlineTime510152030()
                    {
                        time = "30 ngày",
                        value = 0
                    };
                    lsChart.Add(chart2);

                    foreach (var item in lsUser)
                    {
                        var tmpUser = lsUserLogin.Where(x => x.username == item.username).OrderByDescending(x => x.logout_time).FirstOrDefault();
                        TimeSpan tmpTime = fromDate - tmpUser.logout_time;

                        if (tmpTime.TotalDays >= 1 && tmpTime.TotalDays < 7)
                        {
                            var result = lsChart.Where(x => x.time == "1 ngày").FirstOrDefault();
                            result.value += 1;
                        }
                        else if (tmpTime.TotalDays >= 7 && tmpTime.TotalDays < 30)
                        {
                            var result = lsChart.Where(x => x.time == "7 ngày").FirstOrDefault();
                            result.value += 1;
                        }
                        else if (tmpTime.TotalDays >= 30)
                        {
                            var result = lsChart.Where(x => x.time == "30 ngày").FirstOrDefault();
                            result.value += 1;
                        }
                    }

                    chartNoLogin.DataSource = lsChart;
                }
                else
                {
                    CommonShowDialog.CloseWaitForm();
                    CommonShowDialog.ShowErrorDialog("Phải chọn ngày để xem kết quả");
                }
            }
            else
            {
                CommonShowDialog.CloseWaitForm();
                CommonShowDialog.ShowErrorDialog("Phải chọn server!");
            }
            CommonShowDialog.CloseWaitForm();
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
                    link1.Component = chartNoLogin;

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

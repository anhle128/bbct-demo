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
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using KDQHNPHTool.Model;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using MongoDBModel.MainDatabaseModels;

namespace KDQHNPHTool.UserController
{
    public partial class ucGoldSilver : DevExpress.XtraEditors.XtraUserControl
    {
        List<vLogUseGold> lsUseGold = new List<vLogUseGold>();
        List<vLogUseGold> lsUseSliver = new List<vLogUseGold>();
        List<vUserInfor> lsUser = new List<vUserInfor>();
        ListServer server = new ListServer();

        public ucGoldSilver()
        {
            InitializeComponent();
            LoadDataToLUE();
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
                    link1.Component = chartGoldSilver;

                    compositeLink.Links.Add(link1);

                    var options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                    compositeLink.CreatePageForEachLink();
                    compositeLink.ExportToXlsx(saveDialog.FileName, options);
                }
            }
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                string idServer = lueChonServer.EditValue.ToString();
                LoadDataListUser(idServer);
                LoadDataLogUseGold(idServer);
                LoadDataLogUseSilver(idServer);
                List<vChartGoldSilver> lsChart = new List<vChartGoldSilver>();
                vChartGoldSilver chartgold = new vChartGoldSilver()
                {
                    type = "KNB",
                    hienCo = lsUser.Sum(p => p.gold),
                    daTieu = lsUseGold.Sum(p => p.reward_glod)
                };
                lsChart.Add(chartgold);

                vChartGoldSilver chartSilver = new vChartGoldSilver()
                {
                    type = "Bạc",
                    hienCo = lsUser.Sum(p => p.silver),
                    daTieu = lsUseSliver.Sum(p => p.reward_glod)
                };
                lsChart.Add(chartSilver);
                chartGoldSilver.DataSource = lsChart;
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

        private void LoadDataLogUseGold(string idServer)
        {
            lsUseGold.Clear();
            List<MUsedGoldLog> tmpUserCharacter = MongoController.UseGold.GetListData(MongoController.DatabaseManager.main_database, a => a.server_id == idServer);
            foreach (var item in tmpUserCharacter.OrderByDescending(x => x.created_at))
            {
                vLogUseGold user = new vLogUseGold()
                {
                    reward_glod = item.gold,
                    type = (int)item.type,
                };
                lsUseGold.Add(user);
            }
        }

        private void LoadDataLogUseSilver(string idServer)
        {
            lsUseSliver.Clear();
            List<MUsedSilverLog> tmpUserCharacter = MongoController.UseSilver.GetListData(MongoController.DatabaseManager.main_database, a => a.server_id == idServer);
            foreach (var item in tmpUserCharacter.OrderByDescending(x => x.created_at))
            {
                vLogUseGold user = new vLogUseGold()
                {
                    reward_glod = item.silver,
                    type = (int)item.type,
                };
                lsUseSliver.Add(user);
            }
        }
    }
}

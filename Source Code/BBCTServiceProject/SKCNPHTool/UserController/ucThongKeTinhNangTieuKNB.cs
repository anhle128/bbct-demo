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
using KDQHNPHTool.Common;
using MongoDBModel.MainDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Models;
using MongoDBModel.Enum;

namespace KDQHNPHTool.UserController
{
    public partial class ucThongKeTinhNangTieuKNB : DevExpress.XtraEditors.XtraUserControl
    {
        ListServer server = new ListServer();

        public ucThongKeTinhNangTieuKNB()
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

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                CommonShowDialog.ShowWaitForm();
                string idServer = lueChonServer.EditValue.ToString();
                List<MActionGoldLog> tmpUserCharacter = MongoController.UserActionGoldLog.GetListData(MongoController.DatabaseManager.main_database, a => a.server_id == idServer && a.type == TypeActionGold.Spent);
                List<vLogUseGold> lsUserCharacter = new List<vLogUseGold>();

                foreach (var item in tmpUserCharacter)
                {
                    vLogUseGold user = new vLogUseGold()
                    {
                        old_glod = item.old_glod,
                        new_gold = item.new_gold,
                        reward_glod = item.reward_glod,
                        reason = (int)item.reason,
                        type = (int)item.type,
                        timeUse = item.created_at
                    };
                    lsUserCharacter.Add(user);
                }

                List<vChart1730> lsChart = new List<vChart1730>();
                var tmpTypeTieu = from tmp in ConnectDB.Entities.dbCTReasonActionGoldLogs
                                  select tmp;
                int countType = tmpTypeTieu.Count();

                var tmpTypeTieuKNB = from tmp in ConnectDB.Entities.dbCTReasonSpentGoldLogs
                                     select tmp;

                foreach (var item in tmpTypeTieuKNB)
                {
                    vChart1730 conf = new vChart1730()
                    {
                        date = item.value,
                        value = lsUserCharacter.Where(x => x.reason == (countType + item.id)).Sum(x => x.reward_glod)
                    };
                    lsChart.Add(conf);
                }

                CommonShowDialog.CloseWaitForm();
                chartTieuKNB.DataSource = lsChart;
            }
        }
    }
}

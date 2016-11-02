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
using KDQHNPHTool.Model;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.UserController
{
    public partial class ucThongKeTheoVip : DevExpress.XtraEditors.XtraUserControl
    {
        ListServer server = new ListServer();

        public ucThongKeTheoVip()
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
                List<MUserInfo> listUserInfos = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer && a.isBot == false && a.vip > 0);
                List<vUserInfor> lsUser = new List<vUserInfor>();
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

                List<vChart1730> lsChart = new List<vChart1730>();
                for (int i = 1; i < 16; i++)
                {
                    vChart1730 conf = new vChart1730()
                    {
                        date = "Vip " + i,
                        value = lsUser.Where(x => x.vip == i).Count()
                    };
                    lsChart.Add(conf);
                }

                CommonShowDialog.CloseWaitForm();
                chartVip.DataSource = lsChart;
            }
        }
    }
}

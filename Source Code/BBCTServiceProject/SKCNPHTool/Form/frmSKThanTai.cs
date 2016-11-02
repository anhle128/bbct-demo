using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KDQHNPHTool.FormBase;
using KDQHNPHTool.Model;
using KDQHNPHTool.Models;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Common;
using MongoDB.Bson;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;

namespace KDQHNPHTool.Form
{
    public partial class frmSKThanTai : frmFormChange
    {
        int addOrEdit = 0;
        ObjectId idSuKien;
        ListServer server = new ListServer();
        List<vThanTai> lsRewardThanTai = new List<vThanTai>();
        public frmSKThanTai(string nameForm, int type)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            addOrEdit = type;
            this.Text = nameForm + ": Thần tài";
            LoadDataToLUE();

            if (addOrEdit == 1)
            {
                dteFromDate.Enabled = false;
                dteToDate.Enabled = false;
            }
            else
            {
                lueTrangThai.EditValue = 0;
            }
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";
            lueChonServer.EditValue = 0;

            var tmpStatus = from tmp in ConnectDB.Entities.dbCTStatusSuKiens
                            select tmp;

            lueTrangThai.Properties.DataSource = tmpStatus.ToList();
            lueTrangThai.Properties.DisplayMember = "value";
            lueTrangThai.Properties.ValueMember = "id";
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                string idServer = lueChonServer.EditValue.ToString();
                lsRewardThanTai.Clear();
                if (addOrEdit == 2)
                {
                    dteFromDate.EditValue = DateTime.Now;
                    dteToDate.EditValue = DateTime.Now;

                    vThanTai thantai = new vThanTai()
                    {
                        goldRequire = 200,
                        goldMin = 100,
                        goldMax = 400
                    };
                    lsRewardThanTai.Add(thantai);

                    vThanTai thantai1 = new vThanTai()
                    {
                        goldRequire = 400,
                        goldMin = 450,
                        goldMax = 800
                    };
                    lsRewardThanTai.Add(thantai1);

                    vThanTai thantai2 = new vThanTai()
                    {
                        goldRequire = 800,
                        goldMin = 850,
                        goldMax = 1600
                    };
                    lsRewardThanTai.Add(thantai2);

                    vThanTai thantai3 = new vThanTai()
                    {
                        goldRequire = 2000,
                        goldMin = 2050,
                        goldMax = 4200
                    };
                    lsRewardThanTai.Add(thantai3);

                    vThanTai thantai4 = new vThanTai()
                    {
                        goldRequire = 4000,
                        goldMin = 4050,
                        goldMax = 8200
                    };
                    lsRewardThanTai.Add(thantai4);

                    vThanTai thantai5 = new vThanTai()
                    {
                        goldRequire = 8000,
                        goldMin = 8050,
                        goldMax = 16000
                    };
                    lsRewardThanTai.Add(thantai5);

                    vThanTai thantai6 = new vThanTai()
                    {
                        goldRequire = 15000,
                        goldMin = 15050,
                        goldMax = 33000
                    };
                    lsRewardThanTai.Add(thantai6);

                    vThanTai thantai7 = new vThanTai()
                    {
                        goldRequire = 30000,
                        goldMin = 30050,
                        goldMax = 65000
                    };
                    lsRewardThanTai.Add(thantai7);

                    gcReward.DataSource = null;
                    gcReward.DataSource = lsRewardThanTai;
                }
                else
                {
                    var tmpSk = MongoController.SkThanTai.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.created_at).FirstOrDefault();
                    if (tmpSk != null)
                    {
                        dteFromDate.EditValue = tmpSk.start;
                        dteToDate.EditValue = tmpSk.end;
                        lueTrangThai.EditValue = (int)tmpSk.status;
                        idSuKien = tmpSk._id;
                        foreach (var item in tmpSk.rewards)
                        {
                            vThanTai than = new vThanTai()
                            {
                                goldRequire = item.gold_require,
                                goldMin = item.min_gold_reward,
                                goldMax = item.max_gold_reward
                            };
                            lsRewardThanTai.Add(than);
                        }
                        gcReward.DataSource = null;
                        gcReward.DataSource = lsRewardThanTai;
                    }
                    else
                    {
                        CommonShowDialog.ShowErrorDialog("Server này hiện tại chưa có sự kiện nào, thoát ra và tạo sự kiện mới");
                        this.Close();
                    }
                }
            }
        }

        protected override void OnSave()
        {
            string idServer = lueChonServer.EditValue.ToString();

            DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
            DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
            int status = int.Parse(lueTrangThai.EditValue.ToString());

            if (addOrEdit == 1)
            {
                var result = MongoController.SkThanTai.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.start = fromDate;
                result.end = toDate;
                result.server_id = idServer;
                result.status = (Status)status;
                result.rewards = HandlerThanTaiReward();

                MongoController.SkThanTai.Update(server.GetConnectSubDB(idServer), result);
            }
            else
            {
                var deActiveSK = MongoController.SkThanTai.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

                foreach (var item in deActiveSK)
                {
                    var tmpCheck = MongoController.SkThanTai.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == item._id);
                    tmpCheck.status = Status.Deactivate;
                    MongoController.SkThanTai.Update(server.GetConnectSubDB(idServer), tmpCheck);
                }

                MSKThanTaiConfig conf = new MSKThanTaiConfig()
                {
                    start = fromDate,
                    end = toDate,
                    server_id = idServer,
                    status = (Status)status,
                    rewards = HandlerThanTaiReward()
                };

                MongoController.SkThanTai.Create(server.GetConnectSubDB(idServer), conf);
            }
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private MThanTaiReward[] HandlerThanTaiReward()
        {
            List<MThanTaiReward> lsReward = new List<MThanTaiReward>();
            foreach (var item in lsRewardThanTai)
            {
                MThanTaiReward day = new MThanTaiReward()
                {
                    gold_require = item.goldRequire,
                    max_gold_reward = item.goldMax,
                    min_gold_reward = item.goldMin
                };
                lsReward.Add(day);
            }
            return lsReward.ToArray();
        }
    }
}
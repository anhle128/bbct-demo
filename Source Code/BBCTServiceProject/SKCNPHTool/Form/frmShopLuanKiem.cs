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
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Model;
using MongoDB.Bson;
using KDQHNPHTool.Models;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Common;
using DynamicDBModel.Models;
using MongoDBModel.Enum;

namespace KDQHNPHTool.Form
{
    public partial class frmShopLuanKiem : frmFormChange
    {

        List<vReward> lsReward = new List<vReward>();
        ListReward rewardHandler = new ListReward();
        ListServer server = new ListServer();

        ObjectId idSuKien;

        public frmShopLuanKiem()
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            panelControl2.Enabled = false;
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";

            var tmpTypeReward = from tmp in ConnectDB.Entities.dbCTTypeRewards
                                select tmp;

            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();

            var tmpStatusSuKien = from tmp in ConnectDB.Entities.dbCTStatusSuKiens
                                  select tmp;

            lueStatusSuKien.DataSource = tmpStatusSuKien.ToList();
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                lsReward.Clear();
                gcReward.DataSource = null;
                var tmpSk = MongoController.ShopLuanKiem.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);
                if (tmpSk.Count > 0)
                {
                    foreach (var item in tmpSk)
                    {
                        vReward reward = new vReward()
                        {
                            idFakeString = item._id.ToString(),
                            type_reward = item.reward.type_reward + 1,
                            static_id = rewardHandler.HandlerLoadStaticID(item.reward.type_reward + 1, item.reward.static_id),
                            quantity = item.reward.quantity,
                            idRuong = item.reward.ruong_bau_id,
                            price = item.point_luan_kiem,
                            status = (int)item.status,
                            rank_require = item.rank_require,
                            max_buy_time = item.maxBuyTimes,
                            idFake = 1
                        };
                        lsReward.Add(reward);
                    }
                    gcReward.DataSource = lsReward.Where(x => x.idFake == 1);
                }
            }
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            vReward reward = new vReward()
            {
                idFakeString = (-(lsReward.Count)).ToString(),
                quantity = 0,
                static_id = 1,
                type_reward = 2,
                status = 0,
                price = 0,
                max_buy_time = 0,
                rank_require = 1,
                idFake = 1
            };

            lsReward.Add(reward);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.idFake == 1);
            gvReward.MoveLast();
        }

        private void btnDeleteReward_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                string idReward = (string)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "idFakeString");
                lsReward.Where(x => x.idFakeString == idReward).ToList().ForEach(x => x.idFake = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFake == 1);
            }
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvReward.FocusedRowHandle = -1;
            string idServer = lueChonServer.EditValue.ToString();

            foreach (var item in lsReward.Where(x => x.idFake == 1))
            {
                int tmp;
                bool isInt = int.TryParse(item.idFakeString, out tmp);
                if (isInt == true)
                {
                    MLuanKiemShopItem shop = new MLuanKiemShopItem()
                    {
                        maxBuyTimes = item.max_buy_time,
                        reward = HandlerSubRewardItem(item.type_reward, item.static_id, item.quantity, item.idRuong),
                        server_id = idServer,
                        status = (Status)item.status,
                        point_luan_kiem = item.price,
                        rank_require = item.rank_require
                    };
                    MongoController.ShopLuanKiem.Create(server.GetConnectSubDB(idServer), shop);
                }
                else
                {
                    idSuKien = ObjectId.Parse(item.idFakeString);
                    var result = MongoController.ShopLuanKiem.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                    result.maxBuyTimes = item.max_buy_time;
                    result.reward = HandlerSubRewardItem(item.type_reward, item.static_id, item.quantity, item.idRuong);
                    result.server_id = idServer;
                    result.status = (Status)item.status;
                    result.point_luan_kiem = item.price;
                    result.rank_require = item.rank_require;
                    MongoController.ShopLuanKiem.Update(server.GetConnectSubDB(idServer), result);
                }
            }

            foreach (var item in lsReward.Where(x => x.idFake == 2))
            {
                int tmp;
                bool isInt = int.TryParse(item.idFakeString, out tmp);
                if (isInt == false)
                {
                    idSuKien = ObjectId.Parse(item.idFakeString);
                    MongoController.ShopLuanKiem.DeleteAsync(server.GetConnectSubDB(idServer), idSuKien);
                }
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private SubRewardItem HandlerSubRewardItem(int type, int staticID, int quantity, string idRuong)
        {
            SubRewardItem sub = new SubRewardItem()
            {
                quantity = quantity,
                static_id = rewardHandler.HandlerSaveStaticID(type, staticID),
                type_reward = type - 1,
                ruong_bau_id = idRuong
            };
            return sub;
        }
    }
}
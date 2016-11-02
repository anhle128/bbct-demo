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
using MongoDBModel.Enum;
using DynamicDBModel.Models;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.Form
{
    public partial class frmShopItem : frmFormChange
    {
        List<vReward> lsReward = new List<vReward>();
        List<vReward> lsVip = new List<vReward>();
        ListReward rewardHandler = new ListReward();
        ListServer server = new ListServer();

        ObjectId idSuKien;

        public frmShopItem()
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

            lueTypeRewardMain.DataSource = rewardHandler.LoadTypeReward();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();

            var tmpStatusSuKien = from tmp in ConnectDB.Entities.dbCTStatusSuKiens
                                  select tmp;

            lueStatusSuKien.DataSource = tmpStatusSuKien.ToList();
        }

        private void gvVatPham_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvVatPham.GetRow(gvVatPham.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 4, idServer);
            formTask.ShowDialog();
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                lsVip.Clear();
                lsReward.Clear();
                gcVatPham.DataSource = null;
                gcVip.DataSource = null;
                var tmpSk = MongoController.ShopItem.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);
                if (tmpSk.Count > 0)
                {
                    foreach (var item in tmpSk)
                    {
                        vReward reward = new vReward()
                        {
                            idFakeString = item._id.ToString(),
                            type_reward = item.reward.type_reward + 1,
                            price = item.gold,
                            static_id = rewardHandler.HandlerLoadStaticID(item.reward.type_reward + 1, item.reward.static_id),
                            quantity = item.reward.quantity,
                            idRuong = item.reward.ruong_bau_id,
                            status = (int)item.status,
                            idFake = 1
                        };
                        lsReward.Add(reward);

                        int countVip = 0;
                        foreach (var item1 in item.vip_buy_times)
                        {
                            vReward att = new vReward()
                            {
                                idFakeString = item._id.ToString(),
                                static_id = countVip++,
                                quantity = item1
                            };
                            lsVip.Add(att);
                        }
                    }
                    gcVatPham.DataSource = lsReward.Where(x => x.idFake == 1);
                }
            }
        }

        private void gvVatPham_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvVatPham.RowCount > 0)
            {
                string idReward = (string)gvVatPham.GetRowCellValue(gvVatPham.FocusedRowHandle, "idFakeString");
                gcVip.DataSource = null;
                gcVip.DataSource = lsVip.Where(x => x.idFakeString == idReward);
            }
        }

        protected override void OnSave()
        {
            gVip.FocusedRowHandle = -1;
            gvVatPham.FocusedRowHandle = -1;
            string idServer = lueChonServer.EditValue.ToString();

            foreach (var item in lsReward.Where(x => x.idFake == 1))
            {
                int tmp;
                bool isInt = int.TryParse(item.idFakeString, out tmp);
                if (isInt == true)
                {
                    MShopItem shop = new MShopItem()
                    {
                        gold = item.price,
                        reward = HandlerSubRewardItem(item.type_reward, item.static_id, item.quantity, item.idRuong),
                        server_id = idServer,
                        status = (Status)item.status,
                        vip_buy_times = HandlerArrInt(item.idFakeString)
                    };
                    MongoController.ShopItem.Create(server.GetConnectSubDB(idServer), shop);
                }
                else
                {
                    idSuKien = ObjectId.Parse(item.idFakeString);
                    var result = MongoController.ShopItem.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                    result.gold = item.price;
                    result.status = (Status)item.status;
                    result.reward = HandlerSubRewardItem(item.type_reward, item.static_id, item.quantity, item.idRuong);
                    result.vip_buy_times = HandlerArrInt(item.idFakeString);
                    MongoController.ShopItem.Update(server.GetConnectSubDB(idServer), result);
                }
            }

            foreach (var item in lsReward.Where(x => x.idFake == 2))
            {
                int tmp;
                bool isInt = int.TryParse(item.idFakeString, out tmp);
                if (isInt == false)
                {
                    idSuKien = ObjectId.Parse(item.idFakeString);
                    MongoController.ShopItem.DeleteAsync(server.GetConnectSubDB(idServer), idSuKien);
                }
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private int[] HandlerArrInt(string idFake)
        {
            List<int> lsInt = new List<int>();
            foreach (var item in lsVip.Where(x => x.idFakeString == idFake).OrderBy(x => x.static_id))
            {
                lsInt.Add(item.quantity);
            }
            return lsInt.ToArray();
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

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            vReward reward = new vReward()
            {
                idFakeString = (-(lsReward.Count)).ToString(),
                quantity = 0,
                static_id = 1,
                type_reward = 2,
                status = 0,
                price = 0,
                idFake = 1
            };

            for (int i = 0; i < 16; i++)
            {
                vReward vip = new vReward()
                {
                    idFakeString = (-(lsReward.Count)).ToString(),
                    quantity = i,
                    static_id = i
                };
                lsVip.Add(vip);
            }

            lsReward.Add(reward);
            gcVatPham.DataSource = null;
            gcVatPham.DataSource = lsReward.Where(x => x.idFake == 1);
            gvVatPham.MoveLast();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (gvVatPham.RowCount > 0)
            {
                string idReward = (string)gvVatPham.GetRowCellValue(gvVatPham.FocusedRowHandle, "idFakeString");
                lsVip.RemoveAll(x => x.idFakeString == idReward);

                lsReward.Where(x => x.idFakeString == idReward).ToList().ForEach(x => x.idFake = 2);
                gcVatPham.DataSource = null;
                gcVatPham.DataSource = lsReward.Where(x => x.idFake == 1);
            }
        }
    }
}
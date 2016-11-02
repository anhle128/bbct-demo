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
using MongoDB.Bson;
using KDQHNPHTool.Models;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using DynamicDBModel.Enum;
using MongoDBModel.Enum;
using KDQHNPHTool.Common;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmLeBao : frmFormChange
    {
        ListServer server = new ListServer();
        ListReward rewardhandler = new ListReward();
        List<vLeBao> lsLeBao = new List<vLeBao>();
        List<vReward> lsVip = new List<vReward>();
        List<vReward> lsReward = new List<vReward>();
        ListReward rewardHandler = new ListReward();

        ObjectId idSuKien;

        public frmLeBao()
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
            lueChonServer.EditValue = 0;

            var tmpTypeTimeLeBao = from tmp in ConnectDB.Entities.dbCTTypeLeBaoBuyTimes
                                   select tmp;
            lueThoiGianMua.DataSource = tmpTypeTimeLeBao.ToList();

            var tmpTypeActiveLeBao = from tmp in ConnectDB.Entities.dbCTTypeLeBaoActivationTimes
                                     select tmp;
            lueActive.DataSource = tmpTypeActiveLeBao.ToList();

            var tmpTrangThai = from tmp in ConnectDB.Entities.dbCTStatusSuKiens
                               select tmp;
            lueTrangThai.DataSource = tmpTrangThai.ToList();

            var tmpTypeReward = from tmp in ConnectDB.Entities.dbCTTypeRewards
                                select tmp;

            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();
        }

        private void gvThongTinLeBao_DoubleClick(object sender, EventArgs e)
        {
            string idLeBao = (string)gvThongTinLeBao.GetRowCellValue(gvThongTinLeBao.FocusedRowHandle, "id");
            frmThongTinLeBao formTask = new frmThongTinLeBao(idLeBao, lsLeBao, lsVip);
            formTask.ShowDialog();

            gcReward.DataSource = null;
            gcThongTinLeBao.DataSource = null;
            gcThongTinLeBao.DataSource = lsLeBao.Where(x => x.statusLeBao == 1);
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            HandlerLoadData();
        }

        private void HandlerLoadData()
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                lsLeBao.Clear();
                lsReward.Clear();
                lsVip.Clear();
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                var tmpSK = MongoController.LeBao.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

                if (tmpSK.Count > 0)
                {
                    foreach (var item in tmpSK)
                    {
                        vLeBao leBao = new vLeBao()
                        {
                            id = item._id.ToString(),
                            activation = (int)item.activation,
                            buy_times = (int)item.buy_times,
                            end = item.end,
                            gold = item.gold,
                            max_buy_times = item.max_buy_times,
                            name = item.name,
                            real_gold = item.real_gold,
                            start = item.start,
                            status = (int)item.status,
                            vip_require = item.vip_required,
                            statusLeBao = 1
                        };
                        lsLeBao.Add(leBao);

                        foreach (var item1 in item.rewards)
                        {
                            vReward re = new vReward()
                            {
                                idFakeString = item._id.ToString(),
                                type_reward = item1.type_reward + 1,
                                static_id = rewardhandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                quantity = item1.quantity
                            };
                            lsReward.Add(re);
                        }

                        if (item.vip_buy_times != null)
                        {
                            int count = 0;
                            foreach (var item1 in item.vip_buy_times)
                            {
                                vReward att = new vReward()
                                {
                                    idFakeString = item._id.ToString(),
                                    idFake = count++,
                                    quantity = item1
                                };
                                lsVip.Add(att);
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= 15; i++)
                            {
                                vReward att = new vReward()
                                {
                                    idFakeString = item._id.ToString(),
                                    idFake = i,
                                    quantity = 0
                                };
                                lsVip.Add(att);
                            }
                        }
                    }

                    gcReward.DataSource = null;
                    gcThongTinLeBao.DataSource = null;
                    gcThongTinLeBao.DataSource = lsLeBao.Where(x => x.statusLeBao == 1);
                }
            }
        }

        private void btnAddThongTin_Click(object sender, EventArgs e)
        {
            vLeBao leBao = new vLeBao()
            {
                id = (-lsLeBao.Count()).ToString(),
                activation = 0,
                buy_times = 0,
                end = "",
                gold = 0,
                max_buy_times = 0,
                name = "Tên lễ bao",
                real_gold = 0,
                start = "",
                status = 0,
                vip_require = 0,
                statusLeBao = 1
            };
            lsLeBao.Add(leBao);

            for (int i = 0; i <= 15; i++)
            {
                vReward att = new vReward()
                {
                    idFakeString = leBao.id,
                    idFake = i,
                    quantity = 0
                };
                lsVip.Add(att);
            }

            gcThongTinLeBao.DataSource = null;
            gcThongTinLeBao.DataSource = lsLeBao.Where(x => x.statusLeBao == 1);
            gvThongTinLeBao.MoveLast();
        }

        private void btnDeleteThongTin_Click(object sender, EventArgs e)
        {
            if (gvThongTinLeBao.RowCount > 0)
            {
                string idLeBao = (string)gvThongTinLeBao.GetRowCellValue(gvThongTinLeBao.FocusedRowHandle, "id");
                lsReward.RemoveAll(x => x.idFakeString == idLeBao);
                lsLeBao.Where(x => x.id == idLeBao).ToList().ForEach(x => x.statusLeBao = 2);
                gcThongTinLeBao.DataSource = null;
                gcThongTinLeBao.DataSource = lsLeBao.Where(x => x.statusLeBao == 1);
            }
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            string idLeBao = (string)gvThongTinLeBao.GetRowCellValue(gvThongTinLeBao.FocusedRowHandle, "id");
            vReward reward = new vReward()
            {
                idFakeString = idLeBao,
                quantity = 0,
                static_id = 1,
                type_reward = 2
            };
            lsReward.Add(reward);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.idFakeString == idLeBao);
            gvReward.MoveLast();
        }

        private void btnDeleteReward_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                string idHang = (string)gvThongTinLeBao.GetRowCellValue(gvThongTinLeBao.FocusedRowHandle, "id");

                vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                lsReward.Remove(rewardSelect);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFakeString == idHang);
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
            string idServer = lueChonServer.EditValue.ToString();
            foreach (var item in lsLeBao)
            {
                if (item.statusLeBao == 1)
                {
                    int tmp;
                    bool isInt = int.TryParse(item.id, out tmp);

                    if (isInt == true)
                    {
                        MLebao le = new MLebao()
                        {
                            activation = (TypeLeBaoActivationTime)item.activation,
                            buy_times = (TypeLeBaoBuyTimes)item.buy_times,
                            end = HandlerStartEnd(item.activation, item.end),
                            gold = item.gold,
                            max_buy_times = item.max_buy_times,
                            name = item.name,
                            real_gold = item.real_gold,
                            rewards = HandlerReward(item.id),
                            server_id = idServer,
                            start = HandlerStartEnd(item.activation, item.start),
                            status = (Status)item.status,
                            vip_required = item.vip_require,
                            vip_buy_times = HandlerVipBuyTime(item.id, item.buy_times)
                        };
                        MongoController.LeBao.Create(server.GetConnectSubDB(idServer), le);
                    }
                    else
                    {
                        idSuKien = ObjectId.Parse(item.id);
                        var result = MongoController.LeBao.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                        result.activation = (TypeLeBaoActivationTime)item.activation;
                        result.buy_times = (TypeLeBaoBuyTimes)item.buy_times;
                        result.end = HandlerStartEnd(item.activation, item.end);
                        result.gold = item.gold;
                        result.max_buy_times = item.max_buy_times;
                        result.name = item.name;
                        result.real_gold = item.real_gold;
                        result.rewards = HandlerReward(item.id);
                        result.server_id = idServer;
                        result.start = HandlerStartEnd(item.activation, item.start);
                        result.status = (Status)item.status;
                        result.vip_required = item.vip_require;
                        result.vip_buy_times = HandlerVipBuyTime(item.id, item.buy_times);

                        MongoController.LeBao.Update(server.GetConnectSubDB(idServer), result);
                    }
                }
                else
                {
                    int tmp;
                    bool isInt = int.TryParse(item.id, out tmp);

                    if (isInt == false)
                    {
                        idSuKien = ObjectId.Parse(item.id);
                        MongoController.LeBao.DeleteAsync(server.GetConnectSubDB(idServer), idSuKien);
                    }
                }
            }
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
            HandlerLoadData();
        }

        private int[] HandlerVipBuyTime(string idLeBao, int buyTime)
        {
            List<int> lsInt = new List<int>();
            if (buyTime == 0 || buyTime == 1)
            {
                return null;
            }
            else
            {
                foreach (var item in lsVip.Where(x => x.idFakeString == idLeBao))
                {
                    lsInt.Add(item.quantity);
                }
                return lsInt.ToArray();
            }
        }

        private List<SubRewardItem> HandlerReward(string idReward)
        {
            List<SubRewardItem> tmpLsReward = new List<SubRewardItem>();
            foreach (var item in lsReward.Where(x => x.idFakeString == idReward))
            {
                SubRewardItem sub = new SubRewardItem()
                {
                    quantity = item.quantity,
                    static_id = rewardhandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                    type_reward = item.type_reward - 1
                };
                tmpLsReward.Add(sub);
            }
            return tmpLsReward;
        }

        private string HandlerStartEnd(int active, string strTime)
        {
            if (active == 0)
            {
                return null;
            }
            else
            {
                return strTime;
            }
        }

        private void gvThongTinLeBao_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvThongTinLeBao.RowCount > 0)
            {
                string idHang = (string)gvThongTinLeBao.GetRowCellValue(gvThongTinLeBao.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFakeString == idHang);
            }
        }
    }
}
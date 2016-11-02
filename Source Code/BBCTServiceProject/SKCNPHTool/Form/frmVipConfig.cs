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
using MongoDB.Bson;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Model;
using KDQHNPHTool.Models;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Common;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmVipConfig : frmFormChange
    {
        List<vReward> lsReward = new List<vReward>();
        List<dbCTAffliction> lsVip = new List<dbCTAffliction>();
        ListReward rewardHandler = new ListReward();
        ListServer server = new ListServer();

        public frmVipConfig()
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

            lueTypeReward.DataSource = rewardHandler.LoadTypeReward();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                lsVip.Clear();
                lsReward.Clear();
                var tmpSk = MongoController.VipConfig.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);
                if (tmpSk.Count > 0)
                {
                    foreach (var item in tmpSk)
                    {
                        dbCTAffliction att = new dbCTAffliction()
                        {
                            value = item._id.ToString(),
                            id = item.vip
                        };
                        lsVip.Add(att);

                        foreach (var item1 in item.rewards)
                        {
                            vReward reward = new vReward()
                            {
                                idFakeString = item._id.ToString(),
                                quantity = item1.quantity,
                                static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                type_reward = item1.type_reward + 1,
                                idRuong = item1.ruong_bau_id
                            };
                            lsReward.Add(reward);
                        }
                    }
                    gcVip.DataSource = null;
                    gcQuaVip.DataSource = null;
                    gcVip.DataSource = lsVip;
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Server này chưa có config về Vip, thoát ra để tạo config!");
                    this.Close();
                }
            }
        }

        private void gvVip_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvVip.RowCount > 0)
            {
                string idVip = (string)gvVip.GetRowCellValue(gvVip.FocusedRowHandle, "value");
                gcQuaVip.DataSource = null;
                gcQuaVip.DataSource = lsReward.Where(x => x.idFakeString == idVip);
            }
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            string idVip = (string)gvVip.GetRowCellValue(gvVip.FocusedRowHandle, "value");
            vReward reward = new vReward()
            {
                idFakeString = idVip,
                quantity = 0,
                static_id = 1,
                status = 1,
                type_reward = 2
            };
            lsReward.Add(reward);
            gcQuaVip.DataSource = null;
            gcQuaVip.DataSource = lsReward.Where(x => x.idFakeString == idVip);
            gvQuaVip.MoveLast();
        }

        private void btnDeleteReward_Click(object sender, EventArgs e)
        {
            if (gvQuaVip.RowCount > 0)
            {
                string idNgay = (string)gvVip.GetRowCellValue(gvVip.FocusedRowHandle, "value");
                vReward rewardSelect = (vReward)gvQuaVip.GetRow(gvQuaVip.FocusedRowHandle);
                lsReward.Remove(rewardSelect);
                gcQuaVip.DataSource = null;
                gcQuaVip.DataSource = lsReward.Where(x => x.idFakeString == idNgay);
            }
        }

        private void gvQuaVip_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvQuaVip.GetRow(gvQuaVip.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvQuaVip.FocusedRowHandle = -1;
            string idServer = lueChonServer.EditValue.ToString();

            foreach (var item in lsVip)
            {
                ObjectId idVip = ObjectId.Parse(item.value);
                var result = MongoController.VipConfig.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idVip);
                result.rewards = HandlerReward(item.value);
                MongoController.VipConfig.Update(server.GetConnectSubDB(idServer), result);
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<SubRewardItem> HandlerReward(string idVip)
        {
            List<SubRewardItem> lsSubReward = new List<SubRewardItem>();
            foreach (var item in lsReward.Where(x => x.idFakeString == idVip))
            {
                SubRewardItem sub = new SubRewardItem()
                {
                    quantity = item.quantity,
                    static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                    type_reward = item.type_reward - 1,
                    ruong_bau_id = item.idRuong
                };
                lsSubReward.Add(sub);
            }
            return lsSubReward;
        }
    }
}
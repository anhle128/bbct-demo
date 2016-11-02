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
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Models;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Common;
using MongoDB.Bson;
using DynamicDBModel.Models;
using MongoDBModel.SubDatabaseModels;

namespace KDQHNPHTool.Form
{
    public partial class frmSkThuongNapLanDau : frmFormChange
    {
        ListServer server = new ListServer();
        List<vReward> lsReward = new List<vReward>();
        ListReward rewardHandler = new ListReward();
        ObjectId idSuKien;

        public frmSkThuongNapLanDau()
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            panelControl2.Enabled = false;
            LoadDataToLUE();
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
                lsReward.Clear();
                var tmpSk = MongoController.SkNapLanDau.GetSingleData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);
                if (tmpSk != null)
                {
                    idSuKien = tmpSk._id;

                    foreach (var item in tmpSk.rewards)
                    {
                        vReward reward = new vReward()
                        {
                            idFake = lsReward.Count(),
                            quantity = item.quantity,
                            static_id = rewardHandler.HandlerLoadStaticID(item.type_reward + 1, item.static_id),
                            type_reward = item.type_reward + 1,
                            idRuong = item.ruong_bau_id
                        };
                        lsReward.Add(reward);
                    }
                    gcReward.DataSource = null;
                    gcReward.DataSource = lsReward;
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Server này chưa có config Nạp lần đầu, thoát ra để tạo config!");
                    this.Close();
                }
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            vReward reward = new vReward()
            {
                idFake = 0,
                quantity = 1,
                static_id = 1,
                type_reward = 2
            };
            lsReward.Add(reward);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward;
            gvReward.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                lsReward.Remove(rewardSelect);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward;
            }
        }

        protected override void OnSave()
        {
            gvReward.FocusedRowHandle = -1;
            string idServer = lueChonServer.EditValue.ToString();
            var result = MongoController.SkNapLanDau.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
            result.rewards = HandlerReward();

            MongoController.SkNapLanDau.Update(server.GetConnectSubDB(idServer), result);
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<SubRewardItem> HandlerReward()
        {
            List<SubRewardItem> lsSubReward = new List<SubRewardItem>();
            foreach (var item in lsReward)
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

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }
    }
}
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
using StaticDB.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmChucPhucConfig : frmFormChange
    {
        List<vReward> lsReward = new List<vReward>();
        ListReward rewardHandler = new ListReward();
        ListServer server = new ListServer();

        ObjectId idSuKien;

        public frmChucPhucConfig()
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
                lsReward.Clear();
                var tmpSk = MongoController.ChucPhucConfig.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.created_at).FirstOrDefault();
                if (tmpSk != null)
                {
                    idSuKien = tmpSk._id;

                    foreach (var item in tmpSk.rewards)
                    {
                        vReward reward = new vReward()
                        {
                            idFake = lsReward.Count(),
                            quantity = item.amountMin,
                            price = item.amountMax,
                            static_id = rewardHandler.HandlerLoadStaticID(item.typeReward + 1, item.staticID),
                            type_reward = item.typeReward + 1,
                            proc = item.proc
                        };
                        lsReward.Add(reward);
                    }
                    gcReward.DataSource = null;
                    gcReward.DataSource = lsReward;
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Server này chưa có config về Chúc phúc, thoát ra để tạo config!");
                    this.Close();
                }
            }
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            vReward reward = new vReward()
            {
                idFake = -(lsReward.Count),
                quantity = 0,
                static_id = 1,
                type_reward = 2,
                price = 0,
                proc = 0
            };
            lsReward.Add(reward);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward;
            gvReward.MoveLast();
        }

        private void btnDeleteReward_Click(object sender, EventArgs e)
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
            var result = MongoController.ChucPhucConfig.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
            result.rewards = HandlerReward();

            MongoController.ChucPhucConfig.Update(server.GetConnectSubDB(idServer), result);
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<Reward> HandlerReward()
        {
            List<Reward> lsSubReward = new List<Reward>();
            foreach (var item in lsReward)
            {
                Reward sub = new Reward()
                {
                    amountMin = item.quantity,
                    amountMax = item.price,
                    staticID = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                    typeReward = item.type_reward - 1,
                    proc = item.proc
                };
                lsSubReward.Add(sub);
            }
            return lsSubReward;
        }

        private void gcReward_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 5, idServer);
            formTask.ShowDialog();
        }
    }
}
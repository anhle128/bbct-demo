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
using KDQHNPHTool.Models;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Common;
using MongoDB.Bson;
using MongoDBModel.SubDatabaseModels;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmThanThapConfig : frmFormChange
    {
        List<vReward> lsReward = new List<vReward>();
        List<dbCTAffliction> lsHang = new List<dbCTAffliction>();
        ListReward rewardHandler = new ListReward();
        ListServer server = new ListServer();
        ObjectId idSuKien;

        public frmThanThapConfig()
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
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                lsHang.Clear();
                lsReward.Clear();
                var tmpSk = MongoController.ThanThapConfig.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.server_id == idServer).FirstOrDefault();
                if (tmpSk != null)
                {
                    idSuKien = tmpSk._id;
                    foreach (var item in tmpSk.top_rewards.OrderBy(x => x.index))
                    {
                        dbCTAffliction hang = new dbCTAffliction()
                        {
                            id = item.index + 1
                        };
                        lsHang.Add(hang);

                        foreach (var item1 in item.rewards)
                        {
                            vReward reward = new vReward()
                            {
                                idFake = item.index + 1,
                                quantity = item1.quantity,
                                static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                type_reward = item1.type_reward + 1,
                                idRuong = item1.ruong_bau_id
                            };
                            lsReward.Add(reward);
                        }
                        gcReward.DataSource = null;
                        gcHang.DataSource = null;
                        gcHang.DataSource = lsHang;
                    }
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Server này chưa có config Thần tháp, thoát ra để tạo config!");
                    this.Close();
                }
            }
        }

        private void gvHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvHang.RowCount > 0)
            {
                int idHang = (int)gvHang.GetRowCellValue(gvHang.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFake == idHang);
            }
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            int idHang = (int)gvHang.GetRowCellValue(gvHang.FocusedRowHandle, "id");
            vReward reward = new vReward()
            {
                idFake = idHang,
                quantity = 0,
                static_id = 1,
                type_reward = 2
            };
            lsReward.Add(reward);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.idFake == idHang);
            gvReward.MoveLast();
        }

        private void btnDeleteReward_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idHang = (int)gvHang.GetRowCellValue(gvHang.FocusedRowHandle, "id");
                vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                lsReward.Remove(rewardSelect);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFake == idHang);
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

            foreach (var item in lsHang)
            {
                var result = MongoController.ThanThapConfig.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.top_rewards = HandlerTopReward();

                MongoController.ThanThapConfig.Update(server.GetConnectSubDB(idServer), result);
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<TopReward> HandlerTopReward()
        {
            List<TopReward> lsTopRward = new List<TopReward>();
            foreach (var item in lsHang)
            {
                TopReward top = new TopReward()
                {
                    index = item.id - 1,
                    rewards = HandlerReward(item.id)
                };
                lsTopRward.Add(top);
            }
            return lsTopRward;
        }

        private List<SubRewardItem> HandlerReward(int idHang)
        {
            List<SubRewardItem> lsSubReward = new List<SubRewardItem>();
            foreach (var item in lsReward.Where(x => x.idFake == idHang))
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
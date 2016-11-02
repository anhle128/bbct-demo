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
using KDQHNPHTool.Model;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Models;
using KDQHNPHTool.Common;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmGlobalBossConfig : frmFormChange
    {
        List<vReward> lsRewardKill = new List<vReward>();
        List<vReward> lsRewardTop = new List<vReward>();
        List<dbCTAffliction> lsHang = new List<dbCTAffliction>();
        ListReward rewardHandler = new ListReward();
        ListServer server = new ListServer();
        ObjectId idSuKien;

        public frmGlobalBossConfig()
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

            lueTypeRewardTop.DataSource = rewardHandler.LoadTypeReward();
            lueStaticIDTop.DataSource = rewardHandler.LoadTotalReward();

            lueTypeRewardKill.DataSource = rewardHandler.LoadTypeReward();
            lueStaticIDKill.DataSource = rewardHandler.LoadTotalReward();
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                lsHang.Clear();
                lsRewardTop.Clear();
                lsRewardKill.Clear();
                var tmpSk = MongoController.GlobalBossConfig.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.server_id == idServer).FirstOrDefault();
                if (tmpSk != null)
                {
                    idSuKien = tmpSk._id;
                    txtLevelBoss.Text = tmpSk.level.ToString();
                    foreach (var item in tmpSk.top_rewards)
                    {
                        dbCTAffliction bor = new dbCTAffliction()
                        {
                            id = item.index + 1
                        };
                        lsHang.Add(bor);

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
                            lsRewardTop.Add(reward);
                        }
                    }

                    foreach (var item in tmpSk.kill_boss_rewards)
                    {
                        vReward reward = new vReward()
                        {
                            idFake = lsRewardTop.Count(),
                            quantity = item.quantity,
                            static_id = rewardHandler.HandlerLoadStaticID(item.type_reward + 1, item.static_id),
                            type_reward = item.type_reward + 1,
                            idRuong = item.ruong_bau_id
                        };
                        lsRewardKill.Add(reward);
                    }

                    gcTopBoss.DataSource = null;
                    gcRewardKillBoss.DataSource = null;
                    gcRewardTopBoss.DataSource = null;
                    gcTopBoss.DataSource = lsHang;
                    gcRewardKillBoss.DataSource = lsRewardKill;
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Server này chưa có config Boss thế giới, thoát ra để tạo config!");
                    this.Close();
                }
            }
        }

        private void gvTopBoss_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTopBoss.RowCount > 0)
            {
                int idHang = (int)gvTopBoss.GetRowCellValue(gvTopBoss.FocusedRowHandle, "id");
                gcRewardTopBoss.DataSource = null;
                gcRewardTopBoss.DataSource = lsRewardTop.Where(x => x.idFake == idHang);
            }
        }

        private void btnAddTop_Click(object sender, EventArgs e)
        {
            int idHang = (int)gvTopBoss.GetRowCellValue(gvTopBoss.FocusedRowHandle, "id");
            vReward reward = new vReward()
            {
                idFake = idHang,
                quantity = 0,
                static_id = 1,
                type_reward = 2
            };
            lsRewardTop.Add(reward);
            gcRewardTopBoss.DataSource = null;
            gcRewardTopBoss.DataSource = lsRewardTop.Where(x => x.idFake == idHang);
            gvRewardTopBoss.MoveLast();
        }

        private void btnDeleteTop_Click(object sender, EventArgs e)
        {
            if (gvRewardTopBoss.RowCount > 0)
            {
                int idHang = (int)gvTopBoss.GetRowCellValue(gvTopBoss.FocusedRowHandle, "id");
                vReward rewardSelect = (vReward)gvRewardTopBoss.GetRow(gvRewardTopBoss.FocusedRowHandle);
                lsRewardTop.Remove(rewardSelect);
                gcRewardTopBoss.DataSource = null;
                gcRewardTopBoss.DataSource = lsRewardTop.Where(x => x.idFake == idHang);
            }
        }

        private void btnAddKill_Click(object sender, EventArgs e)
        {
            vReward reward = new vReward()
            {
                idFake = -(lsRewardKill.Count),
                quantity = 0,
                static_id = 1,
                type_reward = 2
            };
            lsRewardKill.Add(reward);
            gcRewardKillBoss.DataSource = null;
            gcRewardKillBoss.DataSource = lsRewardKill;
            gvRewardKillBoss.MoveLast();
        }

        private void btnDeleteKill_Click(object sender, EventArgs e)
        {
            if (gvRewardKillBoss.RowCount > 0)
            {
                vReward rewardSelect = (vReward)gvRewardKillBoss.GetRow(gvRewardKillBoss.FocusedRowHandle);
                lsRewardKill.Remove(rewardSelect);
                gcRewardKillBoss.DataSource = null;
                gcRewardKillBoss.DataSource = lsRewardKill;
            }
        }

        private void gvRewardTopBoss_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvRewardTopBoss.GetRow(gvRewardTopBoss.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        private void gvRewardKillBoss_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvRewardKillBoss.GetRow(gvRewardKillBoss.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvRewardTopBoss.FocusedRowHandle = -1;
            gvRewardKillBoss.FocusedRowHandle = -1;
            string idServer = lueChonServer.EditValue.ToString();
            int level = int.Parse(txtLevelBoss.Text);

            var result = MongoController.GlobalBossConfig.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
            result.top_rewards = HandlerTopReward();
            result.kill_boss_rewards = HandlerReward(2, 0);
            result.level = level;

            MongoController.GlobalBossConfig.Update(server.GetConnectSubDB(idServer), result);

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
                    rewards = HandlerReward(1, item.id)
                };
                lsTopRward.Add(top);
            }
            return lsTopRward;
        }

        private List<SubRewardItem> HandlerReward(int type, int idHang)
        {
            List<SubRewardItem> lsSubReward = new List<SubRewardItem>();
            if (type == 1)
            {
                foreach (var item in lsRewardTop.Where(x => x.idFake == idHang))
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
            }
            else
            {
                foreach (var item in lsRewardKill)
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
            }
            return lsSubReward;
        }
    }
}
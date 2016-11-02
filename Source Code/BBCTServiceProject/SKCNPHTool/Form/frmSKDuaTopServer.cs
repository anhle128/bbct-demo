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
using KDQHNPHTool.Database.Controller;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Common;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmSKDuaTopServer : frmFormChange
    {
        int addOrEdit = 0;
        ObjectId idSuKien;
        ListServer server = new ListServer();
        List<vReward> lsTopLevel = new List<vReward>();
        List<vReward> lsRewardLevel = new List<vReward>();
        List<vReward> lsTopLucChien = new List<vReward>();
        List<vReward> lsRewardLucChien = new List<vReward>();
        ListReward rewardHandler = new ListReward();

        public frmSKDuaTopServer(string nameForm, int type)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            addOrEdit = type;
            this.Text = nameForm + ": Đua Top Server";
            LoadDataToLUE();
            panelControl2.Enabled = false;

            if (addOrEdit == 2)
            {
                lueTrangThai.EditValue = 0;
                dteFromDate.EditValue = DateTime.Now;
                dteToDate.EditValue = DateTime.Now;
            }
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";
            lueChonServer.EditValue = 0;

            var tmpTypeReward = from tmp in ConnectDB.Entities.dbCTTypeRewards
                                select tmp;

            lueTypeRewardLevel.DataSource = tmpTypeReward.ToList();
            lueStaticIDLevel.DataSource = rewardHandler.LoadTotalReward();

            lueTypeRewardLucChien.DataSource = tmpTypeReward.ToList();
            lueStaticIDLucChien.DataSource = rewardHandler.LoadTotalReward();

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
                lsTopLevel.Clear();
                lsRewardLevel.Clear();
                lsTopLucChien.Clear();
                lsRewardLucChien.Clear();
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                if (addOrEdit == 1)
                {
                    var tmpSk = MongoController.SkDuaTopServer.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.created_at).FirstOrDefault();
                    if (tmpSk != null)
                    {
                        dteFromDate.EditValue = tmpSk.start;
                        dteToDate.EditValue = tmpSk.end;
                        lueTrangThai.EditValue = (int)tmpSk.status;
                        idSuKien = tmpSk._id;

                        foreach (var item in tmpSk.top_level_rewards)
                        {

                            vReward top = new vReward()
                            {
                                idFake = item.index + 1
                            };
                            lsTopLevel.Add(top);

                            foreach (var item1 in item.rewards)
                            {
                                vReward reward = new vReward()
                                {
                                    idFake = top.idFake,
                                    quantity = item1.quantity,
                                    static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                    type_reward = item1.type_reward + 1,
                                    idRuong = item1.ruong_bau_id
                                };
                                lsRewardLevel.Add(reward);
                            }
                        }

                        foreach (var item in tmpSk.top_power_rewards)
                        {
                            vReward top = new vReward()
                            {
                                idFake = item.index + 1
                            };
                            lsTopLucChien.Add(top);

                            foreach (var item1 in item.rewards)
                            {
                                vReward reward = new vReward()
                                {
                                    idFake = top.idFake,
                                    quantity = item1.quantity,
                                    static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                    type_reward = item1.type_reward + 1,
                                    idRuong = item1.ruong_bau_id
                                };
                                lsRewardLucChien.Add(reward);
                            }
                        }

                        gcTopLevel.DataSource = null;
                        gcTopLevel.DataSource = lsTopLevel;

                        gcTopLucChien.DataSource = null;
                        gcTopLucChien.DataSource = lsTopLucChien;
                    }
                }
                else
                {
                    for (int i = 1; i < 11; i++)
                    {
                        vReward re = new vReward()
                        {
                            idFake = i
                        };
                        lsTopLevel.Add(re);
                        lsTopLucChien.Add(re);
                    }

                    gcTopLevel.DataSource = null;
                    gcTopLevel.DataSource = lsTopLevel;

                    gcTopLucChien.DataSource = null;
                    gcTopLucChien.DataSource = lsTopLucChien;
                }
            }
        }

        private void gvTopLevel_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTopLevel.RowCount > 0)
            {
                int idMoc = (int)gvTopLevel.GetRowCellValue(gvTopLevel.FocusedRowHandle, "idFake");
                gcRewardLevel.DataSource = null;
                gcRewardLevel.DataSource = lsRewardLevel.Where(x => x.idFake == idMoc);
            }
        }

        private void gvTopLucChien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTopLucChien.RowCount > 0)
            {
                int idMoc = (int)gvTopLucChien.GetRowCellValue(gvTopLucChien.FocusedRowHandle, "idFake");
                gcRewardLucChien.DataSource = null;
                gcRewardLucChien.DataSource = lsRewardLucChien.Where(x => x.idFake == idMoc);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            if (gvTopLevel.RowCount > 0)
            {
                int idMoc = (int)gvTopLevel.GetRowCellValue(gvTopLevel.FocusedRowHandle, "idFake");

                vReward re = new vReward()
                {
                    idFake = idMoc,
                    type_reward = 3,
                    static_id = 1,
                    quantity = 0
                };
                lsRewardLevel.Add(re);
                gcRewardLevel.DataSource = null;
                gcRewardLevel.DataSource = lsRewardLevel.Where(x => x.idFake == idMoc);
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvRewardLevel.RowCount > 0)
            {
                int idMoc = (int)gvTopLevel.GetRowCellValue(gvTopLevel.FocusedRowHandle, "idFake");
                vReward rewardSelect = (vReward)gvRewardLevel.GetRow(gvRewardLevel.FocusedRowHandle);
                lsRewardLevel.Remove(rewardSelect);
                gcRewardLevel.DataSource = null;
                gcRewardLevel.DataSource = lsRewardLevel.Where(x => x.idFake == idMoc);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvTopLucChien.RowCount > 0)
            {
                int idMoc = (int)gvTopLucChien.GetRowCellValue(gvTopLucChien.FocusedRowHandle, "idFake");

                vReward re = new vReward()
                {
                    idFake = idMoc,
                    type_reward = 3,
                    static_id = 1,
                    quantity = 0
                };
                lsRewardLucChien.Add(re);
                gcRewardLucChien.DataSource = null;
                gcRewardLucChien.DataSource = lsRewardLucChien.Where(x => x.idFake == idMoc);
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvRewardLucChien.RowCount > 0)
            {
                int idMoc = (int)gvTopLucChien.GetRowCellValue(gvTopLucChien.FocusedRowHandle, "idFake");
                vReward rewardSelect = (vReward)gvRewardLucChien.GetRow(gvRewardLucChien.FocusedRowHandle);
                lsRewardLucChien.Remove(rewardSelect);
                gcRewardLucChien.DataSource = null;
                gcRewardLucChien.DataSource = lsRewardLucChien.Where(x => x.idFake == idMoc);
            }
        }

        private void gvRewardLevel_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvRewardLevel.GetRow(gvRewardLevel.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        private void gvRewardLucChien_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvRewardLucChien.GetRow(gvRewardLucChien.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvTopLucChien.FocusedRowHandle = -1;
            gvTopLevel.FocusedRowHandle = -1;
            gvRewardLucChien.FocusedRowHandle = -1;
            gvRewardLevel.FocusedRowHandle = -1;

            string idServer = lueChonServer.EditValue.ToString();
            DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
            DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
            int status = int.Parse(lueTrangThai.EditValue.ToString());

            if (addOrEdit == 1)
            {
                var result = MongoController.SkDuaTopServer.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.start = fromDate;
                result.end = toDate;
                result.server_id = idServer;
                result.status = (Status)status;
                result.hide = toDate.AddDays(3);
                result.top_level_rewards = HandlerReward(1);
                result.top_power_rewards = HandlerReward(2);

                MongoController.SkDuaTopServer.Update(server.GetConnectSubDB(idServer), result);
            }
            else
            {
                var deActiveSK = MongoController.SkDuaTopServer.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

                foreach (var item in deActiveSK)
                {
                    var tmpCheck = MongoController.SkDuaTopServer.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == item._id);
                    tmpCheck.status = Status.Deactivate;
                    MongoController.SkDuaTopServer.Update(server.GetConnectSubDB(idServer), tmpCheck);
                }

                MSKDuaTopServerConfig conf = new MSKDuaTopServerConfig()
                {
                    start = fromDate,
                    end = toDate,
                    server_id = idServer,
                    status = (Status)status,
                    hide = toDate.AddDays(3),
                    top_level_rewards = HandlerReward(1),
                    top_power_rewards = HandlerReward(2)
                };

                MongoController.SkDuaTopServer.Create(server.GetConnectSubDB(idServer), conf);
            }
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<TopReward> HandlerReward(int type)
        {
            List<TopReward> lsTopReward = new List<TopReward>();
            if (type == 1)
            {
                foreach (var item in lsTopLevel)
                {
                    TopReward top = new TopReward()
                    {
                        index = item.idFake - 1,
                        rewards = HandlerSubRewardItem(1, item.idFake)
                    };
                    lsTopReward.Add(top);
                }
            }
            else
            {
                foreach (var item in lsTopLucChien)
                {
                    TopReward top = new TopReward()
                    {
                        index = item.idFake - 1,
                        rewards = HandlerSubRewardItem(2, item.idFake)
                    };
                    lsTopReward.Add(top);
                }
            }

            return lsTopReward;
        }

        private List<SubRewardItem> HandlerSubRewardItem(int type, int idTop)
        {
            List<SubRewardItem> lsReward = new List<SubRewardItem>();
            if (type == 1)
            {
                foreach (var item in lsRewardLevel.Where(x => x.idFake == idTop))
                {
                    SubRewardItem re = new SubRewardItem()
                    {
                        type_reward = item.type_reward - 1,
                        static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                        quantity = item.quantity,
                        ruong_bau_id = item.idRuong
                    };
                    lsReward.Add(re);
                }
            }
            else
            {
                foreach (var item in lsRewardLucChien.Where(x => x.idFake == idTop))
                {
                    SubRewardItem re = new SubRewardItem()
                    {
                        type_reward = item.type_reward - 1,
                        static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                        quantity = item.quantity,
                        ruong_bau_id = item.idRuong
                    };
                    lsReward.Add(re);
                }
            }
            return lsReward;
        }
    }
}
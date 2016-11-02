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
using KDQHNPHTool.Models;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.Enum;
using StaticDB.Models;
using DynamicDBModel.Models;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.Form
{
    public partial class frmSKRotDo : frmFormChange
    {
        int addOrEdit = 0;
        ObjectId idSuKien;
        ListServer server = new ListServer();
        ListReward rewardHandler = new ListReward();

        List<vReward> lsDropItem = new List<vReward>();
        List<vReward> lsGoiVatPham = new List<vReward>();
        List<vReward> lsRequireReward = new List<vReward>();
        List<vReward> lsReceiveReward = new List<vReward>();

        public frmSKRotDo(string nameForm, int type)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            addOrEdit = type;
            this.Text = nameForm + ": Rớt đồ";
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

            lueTypeRewardDrop.DataSource = tmpTypeReward.ToList();
            lueStaticIDDrop.DataSource = rewardHandler.LoadTotalReward();

            lueTypeRewardReward.DataSource = tmpTypeReward.ToList();
            lueStaticIDReward.DataSource = rewardHandler.LoadTotalReward();

            lueTypeRewardRequire.DataSource = tmpTypeReward.ToList();
            lueStaticIDRequire.DataSource = rewardHandler.LoadTotalReward();

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
                ClearAll();
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                if (addOrEdit == 1)
                {
                    var tmpSk = MongoController.SkRotDo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.created_at).FirstOrDefault();
                    if (tmpSk != null)
                    {
                        dteFromDate.EditValue = tmpSk.start;
                        dteToDate.EditValue = tmpSk.end;
                        lueTrangThai.EditValue = (int)tmpSk.status;
                        idSuKien = tmpSk._id;

                        foreach (var item in tmpSk.drop_items)
                        {
                            vReward re = new vReward()
                            {
                                idFake = lsDropItem.Count(),
                                type_reward = item.typeReward + 1,
                                static_id = rewardHandler.HandlerLoadStaticID(item.typeReward + 1, item.staticID),
                                quantity = item.amountMin,
                                proc = item.proc,
                                price = item.amountMax,
                                status = 1
                            };
                            lsDropItem.Add(re);
                        }

                        int countRe = 0;
                        foreach (var item in tmpSk.rewards)
                        {
                            vReward re1 = new vReward()
                            {
                                idFake = countRe++,
                                type_reward = item.max_exchange_in_day,
                                status = 1
                            };
                            lsGoiVatPham.Add(re1);

                            foreach (var item1 in item.requires)
                            {
                                vReward re2 = new vReward()
                                {
                                    idFake = re1.idFake,
                                    type_reward = item1.type_reward + 1,
                                    static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                    quantity = item1.quantity
                                };
                                lsRequireReward.Add(re2);
                            }

                            foreach (var item1 in item.rewards)
                            {
                                vReward re2 = new vReward()
                                {
                                    idFake = re1.idFake,
                                    type_reward = item1.type_reward + 1,
                                    static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                    quantity = item1.quantity
                                };
                                lsReceiveReward.Add(re2);
                            }
                        }

                        gcDropItem.DataSource = lsDropItem.Where(x => x.status == 1);
                        gcGoiVatPham.DataSource = lsGoiVatPham.Where(x => x.status == 1);
                    }
                }
                else
                {
                    dteFromDate.EditValue = DateTime.Now;
                    dteToDate.EditValue = DateTime.Now;
                    lueTrangThai.EditValue = 0;
                }
            }
        }

        private void ClearAll()
        {
            gcDropItem.DataSource = null;
            gcGoiVatPham.DataSource = null;
            gcRequireItem.DataSource = null;
            gcReward.DataSource = null;

            lsDropItem.Clear();
            lsGoiVatPham.Clear();
            lsReceiveReward.Clear();
            lsRequireReward.Clear();
        }

        private void gvGoiVatPham_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvGoiVatPham.RowCount > 0)
            {
                int idFake = (int)gvGoiVatPham.GetRowCellValue(gvGoiVatPham.FocusedRowHandle, "idFake");
                gcRequireItem.DataSource = null;
                gcRequireItem.DataSource = lsRequireReward.Where(x => x.idFake == idFake);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReceiveReward.Where(x => x.idFake == idFake);
            }
        }

        private void btnAddDrop_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                idFake = -(lsDropItem.Count),
                type_reward = 2,
                static_id = 1,
                quantity = 0,
                proc = 0,
                price = 0,
                status = 1
            };
            lsDropItem.Add(re);
            gcDropItem.DataSource = null;
            gcDropItem.DataSource = lsDropItem.Where(x => x.status == 1);
            gvDropItem.MoveLast();
        }

        private void btnDeleteDrop_Click(object sender, EventArgs e)
        {
            if (gvDropItem.RowCount > 0)
            {
                int idDrop = (int)gvDropItem.GetRowCellValue(gvDropItem.FocusedRowHandle, "idFake");
                lsDropItem.Where(x => x.idFake == idDrop).ToList().ForEach(x => x.status = 2);
                gcDropItem.DataSource = null;
                gcDropItem.DataSource = lsDropItem.Where(x => x.status == 1);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                idFake = -(lsGoiVatPham.Count),
                type_reward = 0,
                status = 1
            };
            lsGoiVatPham.Add(re);
            gcGoiVatPham.DataSource = null;
            gcGoiVatPham.DataSource = lsGoiVatPham.Where(x => x.status == 1);
            gvGoiVatPham.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvGoiVatPham.RowCount > 0)
            {
                int idGoi = (int)gvGoiVatPham.GetRowCellValue(gvGoiVatPham.FocusedRowHandle, "idFake");
                lsRequireReward.RemoveAll(x => x.idFake == idGoi);
                lsReceiveReward.RemoveAll(x => x.idFake == idGoi);

                lsGoiVatPham.Where(x => x.idFake == idGoi).ToList().ForEach(x => x.status = 2);
                gcGoiVatPham.DataSource = null;
                gcGoiVatPham.DataSource = lsGoiVatPham.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvGoiVatPham.RowCount > 0)
            {
                int idGoi = (int)gvGoiVatPham.GetRowCellValue(gvGoiVatPham.FocusedRowHandle, "idFake");

                vReward re = new vReward()
                {
                    idFake = idGoi,
                    type_reward = 2,
                    static_id = 1,
                    quantity = 0
                };
                lsRequireReward.Add(re);
                gcRequireItem.DataSource = null;
                gcRequireItem.DataSource = lsRequireReward.Where(x => x.idFake == idGoi);
                gvRequireItem.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvRequireItem.RowCount > 0)
            {
                vReward reSelect = (vReward)gvRequireItem.GetRow(gvRequireItem.FocusedRowHandle);
                lsRequireReward.Remove(reSelect);
                int idGoi = (int)gvGoiVatPham.GetRowCellValue(gvGoiVatPham.FocusedRowHandle, "idFake");

                gcRequireItem.DataSource = null;
                gcRequireItem.DataSource = lsRequireReward.Where(x => x.idFake == idGoi);
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            if (gvGoiVatPham.RowCount > 0)
            {
                int idGoi = (int)gvGoiVatPham.GetRowCellValue(gvGoiVatPham.FocusedRowHandle, "idFake");

                vReward re = new vReward()
                {
                    idFake = idGoi,
                    type_reward = 2,
                    static_id = 1,
                    quantity = 0
                };
                lsReceiveReward.Add(re);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReceiveReward.Where(x => x.idFake == idGoi);
                gvReward.MoveLast();
            }
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                vReward reSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                lsReceiveReward.Remove(reSelect);
                int idGoi = (int)gvGoiVatPham.GetRowCellValue(gvGoiVatPham.FocusedRowHandle, "idFake");

                gcReward.DataSource = null;
                gcReward.DataSource = lsReceiveReward.Where(x => x.idFake == idGoi);
            }
        }

        private void gvRequireItem_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvRequireItem.GetRow(gvRequireItem.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        private void gvDropItem_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvDropItem.GetRow(gvDropItem.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 3, idServer);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvDropItem.FocusedRowHandle = -1;
            gvGoiVatPham.FocusedRowHandle = -1;
            gvRequireItem.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;

            string idServer = lueChonServer.EditValue.ToString();

            DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
            DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
            int status = int.Parse(lueTrangThai.EditValue.ToString());

            if (addOrEdit == 1)
            {
                var result = MongoController.SkRotDo.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.start = fromDate;
                result.end = toDate;
                result.server_id = idServer;
                result.status = (Status)status;
                result.drop_items = HandlerDropItem();
                result.rewards = HandlerRotDoReward();
                MongoController.SkRotDo.Update(server.GetConnectSubDB(idServer), result);
            }
            else
            {
                var deActiveSK = MongoController.SkRotDo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

                foreach (var item in deActiveSK)
                {
                    var tmpCheck = MongoController.SkRotDo.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == item._id);
                    tmpCheck.status = Status.Deactivate;
                    MongoController.SkRotDo.Update(server.GetConnectSubDB(idServer), tmpCheck);
                }

                MSKRotDoConfig conf = new MSKRotDoConfig()
                {
                    start = fromDate,
                    end = toDate,
                    server_id = idServer,
                    status = (Status)status,
                    drop_items = HandlerDropItem(),
                    rewards = HandlerRotDoReward()
                };

                MongoController.SkRotDo.Create(server.GetConnectSubDB(idServer), conf);
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<RotDoReward> HandlerRotDoReward()
        {
            List<RotDoReward> tmpLsRotDo = new List<RotDoReward>();
            foreach (var item in lsGoiVatPham)
            {
                if (item.status == 1)
                {
                    RotDoReward rot = new RotDoReward()
                    {
                        max_exchange_in_day = item.type_reward,
                        requires = HandlerReward(1, item.idFake),
                        rewards = HandlerReward(2, item.idFake)
                    };
                    tmpLsRotDo.Add(rot);
                }
            }

            return tmpLsRotDo;
        }

        private List<SubRewardItem> HandlerReward(int type, int idFake)
        {
            List<SubRewardItem> tmpLsReward = new List<SubRewardItem>();
            if (type == 1)
            {
                foreach (var item in lsRequireReward.Where(x => x.idFake == idFake))
                {
                    SubRewardItem sub = new SubRewardItem()
                    {
                        type_reward = item.type_reward - 1,
                        static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                        quantity = item.quantity
                    };
                    tmpLsReward.Add(sub);
                }
            }
            else
            {
                foreach (var item in lsReceiveReward.Where(x => x.idFake == idFake))
                {
                    SubRewardItem sub = new SubRewardItem()
                    {
                        type_reward = item.type_reward - 1,
                        static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                        quantity = item.quantity
                    };
                    tmpLsReward.Add(sub);
                }
            }

            return tmpLsReward;
        }

        private List<Reward> HandlerDropItem()
        {
            List<Reward> tmpLsReward = new List<Reward>();

            foreach (var item in lsDropItem.Where(x => x.status == 1).OrderBy(x => x.proc))
            {
                Reward re = new Reward()
                {
                    typeReward = item.type_reward - 1,
                    staticID = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                    proc = (float)item.proc,
                    amountMin = item.quantity,
                    amountMax = item.price
                };
                tmpLsReward.Add(re);
            }

            return tmpLsReward;
        }
    }
}
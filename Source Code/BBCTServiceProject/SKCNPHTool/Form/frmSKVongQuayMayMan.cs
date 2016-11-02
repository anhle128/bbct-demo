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
using MongoDBModel.Enum;
using MongoDB.Bson;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Enum;
using KDQHNPHTool.Common;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmSKVongQuayMayMan : frmFormChange
    {
        ObjectId idSuKien;
        int addOrEdit = 0;
        ListServer server = new ListServer();
        List<vReward> lsReward = new List<vReward>();
        ListReward rewardHandler = new ListReward();

        List<vReward> lsMoc = new List<vReward>();
        List<vReward> lsRewardMoc = new List<vReward>();

        List<vReward> lsTop = new List<vReward>();
        List<vReward> lsRewardTop = new List<vReward>();

        public frmSKVongQuayMayMan(string nameForm, int status)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            addOrEdit = status;
            this.Text = nameForm + ": Vòng quay may mắn";
            LoadDataToLUE();
            panelControl2.Enabled = false;

            if (addOrEdit == 2)
            {
                lueTrangThai.EditValue = 0;
            }
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";

            lueTypeReward.DataSource = rewardHandler.LoadTypeReward();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();
            lueTypeRewardMoc.DataSource = rewardHandler.LoadTypeReward();
            lueStaticIDMoc.DataSource = rewardHandler.LoadTotalReward();
            lueTypeRewardTop.DataSource = rewardHandler.LoadTypeReward();
            lueStaticIDRewardTop.DataSource = rewardHandler.LoadTotalReward();

            var tmpStatus = from tmp in ConnectDB.Entities.dbCTStatusSuKiens
                            select tmp;

            lueTrangThai.Properties.DataSource = tmpStatus.ToList();
            lueTrangThai.Properties.DisplayMember = "value";
            lueTrangThai.Properties.ValueMember = "id";
        }

        private void LoadDataToList(string idServer)
        {
            if (addOrEdit == 1)
            {
                lsReward.Clear();
                lsMoc.Clear();
                lsRewardMoc.Clear();
                lsTop.Clear();
                lsRewardTop.Clear();
                var tmpSk = MongoController.SkVongQuayMayMan.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.created_at).FirstOrDefault();
                if (tmpSk != null)
                {
                    dteFromDate.EditValue = tmpSk.start;
                    dteToDate.EditValue = tmpSk.end;
                    txtFree.Text = tmpSk.max_free_times.ToString();
                    txtPrice1.Text = tmpSk.price.ToString();
                    txtPrice10.Text = tmpSk.x10_price.ToString();
                    lueTrangThai.EditValue = (int)tmpSk.status;
                    idSuKien = tmpSk._id;

                    foreach (var item in tmpSk.vatPhams)
                    {
                        vReward reward = new vReward
                        {
                            quantity = item.quantity,
                            static_id = rewardHandler.HandlerLoadStaticID((int)item.type + 1, item.static_id),
                            proc = (double)item.proc,
                            type_reward = (int)item.type + 1
                        };
                        lsReward.Add(reward);
                    }
                    gcReward.DataSource = null;
                    gcReward.DataSource = lsReward;

                    foreach (var item in tmpSk.point_rewards)
                    {
                        vReward re = new vReward()
                        {
                            idFake = lsMoc.Count,
                            type_reward = item.point_require
                        };
                        lsMoc.Add(re);

                        foreach (var item1 in item.rewards)
                        {
                            vReward rew = new vReward()
                            {
                                idFake = re.idFake,
                                type_reward = item1.type_reward + 1,
                                static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                quantity = item1.quantity,
                                idRuong = item1.ruong_bau_id
                            };
                            lsRewardMoc.Add(rew);
                        }
                    }

                    gcMocDiem.DataSource = null;
                    gcMocDiem.DataSource = lsMoc;

                    foreach (var item in tmpSk.top_rewards)
                    {
                        vReward re = new vReward()
                        {
                            idFake = lsTop.Count,
                            type_reward = item.index + 1
                        };
                        lsTop.Add(re);

                        foreach (var item1 in item.rewards)
                        {
                            vReward rew = new vReward()
                            {
                                idFake = re.idFake,
                                type_reward = item1.type_reward + 1,
                                static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                quantity = item1.quantity,
                                idRuong = item1.ruong_bau_id
                            };
                            lsRewardTop.Add(rew);
                        }
                    }

                    gcTop.DataSource = null;
                    gcTop.DataSource = lsTop;
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Server này hiện tại chưa có sự kiện nào, thoát ra và tạo sự kiện mới");
                    this.Close();
                }
            }
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                LoadDataToList(idServer);
            }
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 2, idServer);
            formTask.ShowDialog();
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            vReward reward = new vReward()
            {
                quantity = 0,
                static_id = 1,
                status = 0,
                type_reward = 2
            };
            lsReward.Add(reward);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward;
            gvReward.MoveLast();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
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
            string idServer = lueChonServer.EditValue.ToString();

            DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
            DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
            int status = int.Parse(lueTrangThai.EditValue.ToString());

            if (addOrEdit == 1)
            {
                var result = MongoController.SkVongQuayMayMan.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.start = fromDate;
                result.end = toDate;
                result.max_free_times = int.Parse(txtFree.Text);
                result.price = int.Parse(txtPrice1.Text);
                result.x10_price = int.Parse(txtPrice10.Text);
                result.server_id = idServer;
                result.status = (Status)status;
                result.vatPhams = HandlerVatPham();
                result.point_rewards = HandlerPointReward();
                result.top_rewards = HandlerTop();
                MongoController.SkVongQuayMayMan.Update(server.GetConnectSubDB(idServer), result);
            }
            else
            {
                var deActiveSK = MongoController.SkVongQuayMayMan.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

                foreach (var item in deActiveSK)
                {
                    var tmpCheck = MongoController.SkVongQuayMayMan.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == item._id);
                    tmpCheck.status = Status.Deactivate;
                    MongoController.SkVongQuayMayMan.Update(server.GetConnectSubDB(idServer), tmpCheck);
                }

                MSKVongQuayMayManConfig conf = new MSKVongQuayMayManConfig()
                {
                    start = fromDate,
                    end = toDate,
                    max_free_times = int.Parse(txtFree.Text),
                    price = int.Parse(txtPrice1.Text),
                    x10_price = int.Parse(txtPrice10.Text),
                    server_id = idServer,
                    status = (Status)status,
                    vatPhams = HandlerVatPham(),
                    point_rewards = HandlerPointReward(),
                    top_rewards = HandlerTop()
                };

                MongoController.SkVongQuayMayMan.Create(server.GetConnectSubDB(idServer), conf);
            }
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<TopReward> HandlerTop()
        {
            List<TopReward> lsTMPTop = new List<TopReward>();

            foreach (var item in lsTop.OrderBy(x => x.type_reward))
            {
                TopReward top = new TopReward()
                {
                    index = item.type_reward - 1,
                    rewards = HandlerRewardTop(item.idFake)
                };
                lsTMPTop.Add(top);
            }
            return lsTMPTop;
        }

        private List<SubRewardItem> HandlerRewardTop(int idGen)
        {
            List<SubRewardItem> lsSubReward = new List<SubRewardItem>();

            foreach (var item in lsRewardTop.Where(x => x.idFake == idGen))
            {
                SubRewardItem sub = new SubRewardItem()
                {
                    type_reward = item.type_reward - 1,
                    static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                    quantity = item.quantity,
                    ruong_bau_id = item.idRuong
                };
                lsSubReward.Add(sub);
            }
            return lsSubReward;
        }

        private List<PointVongQuayMayManReward> HandlerPointReward()
        {
            List<PointVongQuayMayManReward> lsPoint = new List<PointVongQuayMayManReward>();
            foreach (var item in lsMoc.OrderBy(x => x.type_reward))
            {
                PointVongQuayMayManReward vong = new PointVongQuayMayManReward()
                {
                    point_require = item.type_reward,
                    rewards = HandlerPointReward(item.idFake)
                };
                lsPoint.Add(vong);
            }
            return lsPoint;
        }

        private List<SubRewardItem> HandlerPointReward(int idGen)
        {
            List<SubRewardItem> lsSubReward = new List<SubRewardItem>();

            foreach (var item in lsRewardMoc.Where(x => x.idFake == idGen))
            {
                SubRewardItem sub = new SubRewardItem()
                {
                    type_reward = item.type_reward - 1,
                    static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                    quantity = item.quantity,
                    ruong_bau_id = item.idRuong
                };
                lsSubReward.Add(sub);
            }
            return lsSubReward;
        }

        private MVatPham[] HandlerVatPham()
        {
            List<MVatPham> lsVatPham = new List<MVatPham>();
            foreach (var item in lsReward.OrderBy(x => x.proc))
            {
                MVatPham vatpham = new MVatPham()
                {
                    proc = item.proc,
                    quantity = item.quantity,
                    static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                    type = (TypeReward)item.type_reward - 1
                };
                lsVatPham.Add(vatpham);
            }

            return lsVatPham.ToArray();
        }

        private void btnAddMocDiem_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                idFake = -(lsMoc.Count),
                type_reward = 0
            };
            lsMoc.Add(re);
            gcMocDiem.DataSource = null;
            gcMocDiem.DataSource = lsMoc;
            gvMocDiem.MoveLast();
        }

        private void btnDeleteMocDiem_Click(object sender, EventArgs e)
        {
            if (gvMocDiem.RowCount > 0)
            {
                int idMoc = (int)gvMocDiem.GetRowCellValue(gvMocDiem.FocusedRowHandle, "idFake");
                lsRewardMoc.RemoveAll(x => x.idFake == idMoc);
                lsMoc.RemoveAll(x => x.idFake == idMoc);
                gcMocDiem.DataSource = lsMoc;
            }
        }

        private void btnAddMRewardMoc_Click(object sender, EventArgs e)
        {
            if (gvMocDiem.RowCount > 0)
            {
                int idMoc = (int)gvMocDiem.GetRowCellValue(gvMocDiem.FocusedRowHandle, "idFake");

                vReward re = new vReward()
                {
                    idFake = idMoc,
                    type_reward = 2,
                    static_id = 1,
                    quantity = 0
                };
                lsRewardMoc.Add(re);
                gcRewardMocDiem.DataSource = null;
                gcRewardMocDiem.DataSource = lsRewardMoc.Where(x => x.idFake == idMoc);
                gvRewardMocDiem.MoveLast();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvRewardMocDiem.RowCount > 0)
            {
                int idMoc = (int)gvMocDiem.GetRowCellValue(gvMocDiem.FocusedRowHandle, "idFake");
                vReward vRe = (vReward)gvRewardMocDiem.GetRow(gvRewardMocDiem.FocusedRowHandle);
                lsRewardMoc.Remove(vRe);
                gcRewardMocDiem.DataSource = null;
                gcRewardMocDiem.DataSource = lsRewardMoc.Where(x => x.idFake == idMoc);
            }
        }

        private void gvMocDiem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvMocDiem.RowCount > 0)
            {
                int idGen = (int)gvMocDiem.GetRowCellValue(gvMocDiem.FocusedRowHandle, "idFake");
                gcRewardMocDiem.DataSource = null;
                gcRewardMocDiem.DataSource = lsRewardMoc.Where(x => x.idFake == idGen);
            }
        }

        private void gvRewardMocDiem_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvRewardMocDiem.GetRow(gvRewardMocDiem.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        private void gvTop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTop.RowCount > 0)
            {
                int idGen = (int)gvTop.GetRowCellValue(gvTop.FocusedRowHandle, "idFake");
                gcTopReward.DataSource = null;
                gcTopReward.DataSource = lsRewardTop.Where(x => x.idFake == idGen);
            }
        }

        private void gvTopReward_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvTopReward.GetRow(gvTopReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        private void btnAddTop_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                idFake = -(lsTop.Count),
                type_reward = lsTop.Count + 1
            };
            lsTop.Add(re);
            gcTop.DataSource = null;
            gcTop.DataSource = lsTop;
            gvTop.MoveLast();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gvTop.RowCount > 0)
            {
                int idMoc = (int)gvTop.GetRowCellValue(gvTop.FocusedRowHandle, "idFake");
                lsRewardTop.RemoveAll(x => x.idFake == idMoc);
                lsTop.RemoveAll(x => x.idFake == idMoc);
                gcTop.DataSource = lsTop;
            }
        }

        private void btnAddRewardTop_Click(object sender, EventArgs e)
        {
            if (gvTop.RowCount > 0)
            {
                int idMoc = (int)gvTop.GetRowCellValue(gvTop.FocusedRowHandle, "idFake");

                vReward re = new vReward()
                {
                    idFake = idMoc,
                    type_reward = 2,
                    static_id = 1,
                    quantity = 0
                };
                lsRewardTop.Add(re);
                gcTopReward.DataSource = null;
                gcTopReward.DataSource = lsRewardTop.Where(x => x.idFake == idMoc);
                gvTopReward.MoveLast();
            }
        }

        private void btnDeleteRewardTop_Click(object sender, EventArgs e)
        {
            if (gvTop.RowCount > 0)
            {
                int idMoc = (int)gvTop.GetRowCellValue(gvTop.FocusedRowHandle, "idFake");
                vReward vRe = (vReward)gvTopReward.GetRow(gvTopReward.FocusedRowHandle);
                lsRewardTop.Remove(vRe);
                gcTopReward.DataSource = null;
                gcTopReward.DataSource = lsRewardTop.Where(x => x.idFake == idMoc);
            }
        }
    }
}
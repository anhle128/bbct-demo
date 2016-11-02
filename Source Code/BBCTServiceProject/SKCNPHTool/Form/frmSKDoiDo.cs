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
using MongoDB.Bson;
using KDQHNPHTool.Model;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.FormBase;
using KDQHNPHTool.Models;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using DynamicDBModel.Models;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.Form
{
    public partial class frmSKDoiDo : frmFormChange
    {
        int addOrEdit = 0;
        ObjectId idSuKien;
        ListServer server = new ListServer();
        List<vReward> lsRequireItem = new List<vReward>();
        List<vReward> lsRewardReward = new List<vReward>();
        List<vReward> lsMoc = new List<vReward>();
        List<vReward> lsRewardMoc = new List<vReward>();
        List<vReward> lsTop = new List<vReward>();
        List<vReward> lsRewardTop = new List<vReward>();
        ListReward rewardHandler = new ListReward();

        public frmSKDoiDo(string nameForm, int type)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            addOrEdit = type;
            this.Text = nameForm + ": Đổi đồ";
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

            lueTypeRewardItem.DataSource = tmpTypeReward.ToList();
            lueStaticIDItem.DataSource = rewardHandler.LoadTotalReward();

            lueTypeRewardReward.DataSource = tmpTypeReward.ToList();
            lueStaticIDReward.DataSource = rewardHandler.LoadTotalReward();

            lueTypeRewardMoc.DataSource = tmpTypeReward.ToList();
            lueStaticIDMoc.DataSource = rewardHandler.LoadTotalReward();

            lueTypeRewardTop.DataSource = tmpTypeReward.ToList();
            lueStaticIDTop.DataSource = rewardHandler.LoadTotalReward();

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
                    var tmpSk = MongoController.SkDoiDo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.created_at).FirstOrDefault();
                    if (tmpSk != null)
                    {
                        dteFromDate.EditValue = tmpSk.start;
                        dteToDate.EditValue = tmpSk.end;
                        lueTrangThai.EditValue = (int)tmpSk.status;
                        txtDiemLamMoi.Text = tmpSk.refesh.point_reward.ToString();
                        txtGioLamMoi.Text = tmpSk.refesh.hour_auto_refesh.ToString();
                        txtTienLamMoi.Text = tmpSk.refesh.gold_require.ToString();
                        idSuKien = tmpSk._id;

                        foreach (var item in tmpSk.exchange_items)
                        {
                            vReward re = new vReward()
                            {
                                idFake = lsRequireItem.Count(),
                                type_reward = item.require_item.type_reward + 1,
                                static_id = rewardHandler.HandlerLoadStaticID(item.require_item.type_reward + 1, item.require_item.static_id),
                                quantity = item.require_item.quantity,
                                idRuong = item.require_item.ruong_bau_id,
                                status = 1
                            };
                            lsRequireItem.Add(re);

                            vReward itr = new vReward()
                            {
                                idFake = re.idFake,
                                type_reward = item.reward_item.type_reward + 1,
                                static_id = rewardHandler.HandlerLoadStaticID(item.reward_item.type_reward + 1, item.reward_item.static_id),
                                quantity = item.reward_item.quantity,
                                idRuong = item.reward_item.ruong_bau_id,
                                price = item.reward_point
                            };
                            lsRewardReward.Add(itr);
                        }

                        foreach (var item in tmpSk.point_rewards)
                        {
                            vReward re = new vReward()
                            {
                                idFake = lsMoc.Count(),
                                type_reward = item.point_require,
                                static_id = item.max_buy_times_in_day
                            };
                            lsMoc.Add(re);

                            foreach (var item1 in item.rewards)
                            {
                                vReward itr = new vReward()
                                {
                                    idFake = re.idFake,
                                    type_reward = item1.type_reward + 1,
                                    static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                    quantity = item1.quantity,
                                    idRuong = item1.ruong_bau_id
                                };
                                lsRewardMoc.Add(itr);
                            }
                        }

                        foreach (var item in tmpSk.top_rewards)
                        {
                            vReward re = new vReward()
                            {
                                idFake = item.index,
                                type_reward = item.point_require
                            };
                            lsTop.Add(re);

                            foreach (var item1 in item.rewards)
                            {
                                vReward itr = new vReward()
                                {
                                    idFake = re.idFake,
                                    type_reward = item1.type_reward + 1,
                                    static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                    quantity = item1.quantity,
                                    idRuong = item1.ruong_bau_id
                                };
                                lsRewardTop.Add(itr);
                            }
                        }

                        gcRequireItem.DataSource = lsRequireItem;
                        gcMoc.DataSource = lsMoc;
                        gcTop.DataSource = lsTop;
                    }
                    else
                    {
                        CommonShowDialog.ShowErrorDialog("Server này chưa có sự kiện, hãy thoát ra và tạo mới sự kiện!");
                        this.Close();
                    }
                }
                else
                {
                    dteFromDate.EditValue = DateTime.Now;
                    dteToDate.EditValue = DateTime.Now;
                    lueTrangThai.EditValue = 0;
                    txtDiemLamMoi.Text = "0";
                    txtGioLamMoi.Text = "0";
                    txtTienLamMoi.Text = "0";

                    vReward re = new vReward()
                    {
                        idFake = 0,
                        type_reward = 3000,
                        static_id = 0
                    };
                    lsMoc.Add(re);

                    vReward re1 = new vReward()
                    {
                        idFake = 1,
                        type_reward = 2000,
                        static_id = 0
                    };
                    lsMoc.Add(re1);

                    vReward re2 = new vReward()
                    {
                        idFake = 2,
                        type_reward = 1000,
                        static_id = 0
                    };
                    lsMoc.Add(re2);

                    vReward re3 = new vReward()
                    {
                        idFake = 0,
                        type_reward = 3000
                    };
                    lsTop.Add(re3);

                    vReward re4 = new vReward()
                    {
                        idFake = 1,
                        type_reward = 2000
                    };
                    lsTop.Add(re4);

                    vReward re5 = new vReward()
                    {
                        idFake = 2,
                        type_reward = 1000
                    };
                    lsTop.Add(re5);

                    gcRequireItem.DataSource = lsRequireItem;
                    gcMoc.DataSource = lsMoc;
                    gcTop.DataSource = lsTop;
                }
            }
        }

        private void ClearAll()
        {
            lsMoc.Clear();
            lsRequireItem.Clear();
            lsRewardMoc.Clear();
            lsRewardReward.Clear();
            lsRewardTop.Clear();
            lsTop.Clear();

            gcMoc.DataSource = null;
            gcRequireItem.DataSource = null;
            gcReward.DataSource = null;
            gcRewardMoc.DataSource = null;
            gcRewardTop.DataSource = null;
            gcTop.DataSource = null;
        }

        private void gvRequireItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvRequireItem.RowCount > 0)
            {
                int idFake = (int)gvRequireItem.GetRowCellValue(gvRequireItem.FocusedRowHandle, "idFake");
                gcReward.DataSource = null;
                gcReward.DataSource = lsRewardReward.Where(x => x.idFake == idFake);
            }
        }

        private void gvMoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvMoc.RowCount > 0)
            {
                int idFake = (int)gvMoc.GetRowCellValue(gvMoc.FocusedRowHandle, "idFake");
                gcRewardMoc.DataSource = null;
                gcRewardMoc.DataSource = lsRewardMoc.Where(x => x.idFake == idFake);
            }
        }

        private void gvTop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTop.RowCount > 0)
            {
                int idFake = (int)gvTop.GetRowCellValue(gvTop.FocusedRowHandle, "idFake");
                gcRewardTop.DataSource = null;
                gcRewardTop.DataSource = lsRewardTop.Where(x => x.idFake == idFake);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                idFake = -(lsRequireItem.Count()),
                type_reward = 2,
                static_id = 1,
                quantity = 0,
                status = 1
            };
            lsRequireItem.Add(re);

            vReward itr = new vReward()
            {
                idFake = re.idFake,
                type_reward = 2,
                static_id = 1,
                quantity = 0,
                price = 0
            };
            lsRewardReward.Add(itr);

            gcReward.DataSource = null;
            gcRequireItem.DataSource = null;
            gcRequireItem.DataSource = lsRequireItem.Where(x => x.status == 1);
            gvRequireItem.MoveLast();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (gvRequireItem.RowCount > 0)
            {
                int idFake = (int)gvRequireItem.GetRowCellValue(gvRequireItem.FocusedRowHandle, "idFake");
                lsRewardReward.RemoveAll(x => x.idFake == idFake);
                lsRequireItem.Where(x => x.idFake == idFake).ToList().ForEach(x => x.status = 2);

                gcReward.DataSource = null;
                gcRequireItem.DataSource = null;
                gcRequireItem.DataSource = lsRequireItem.Where(x => x.status == 1);
            }
        }

        private void btnAddMoc_Click(object sender, EventArgs e)
        {
            if (gvMoc.RowCount > 0)
            {
                int idFake = (int)gvMoc.GetRowCellValue(gvMoc.FocusedRowHandle, "idFake");

                vReward re = new vReward()
                {
                    idFake = idFake,
                    type_reward = 2,
                    static_id = 1,
                    quantity = 0
                };
                lsRewardMoc.Add(re);
                gcRewardMoc.DataSource = null;
                gcRewardMoc.DataSource = lsRewardMoc.Where(x => x.idFake == idFake);
                gvRewardMoc.MoveLast();
            }
        }

        private void btnDeleteMoc_Click(object sender, EventArgs e)
        {
            if (gvRewardMoc.RowCount > 0)
            {
                int idFake = (int)gvMoc.GetRowCellValue(gvMoc.FocusedRowHandle, "idFake");
                vReward rewa = (vReward)gvRewardMoc.GetRow(gvRewardMoc.FocusedRowHandle);

                lsRewardMoc.Remove(rewa);
                gcRewardMoc.DataSource = lsRewardMoc.Where(x => x.idFake == idFake);
                gvRewardMoc.MoveLast();
            }
        }

        private void btnAddTop_Click(object sender, EventArgs e)
        {
            if (gvTop.RowCount > 0)
            {
                int idFake = (int)gvTop.GetRowCellValue(gvTop.FocusedRowHandle, "idFake");

                vReward re = new vReward()
                {
                    idFake = idFake,
                    type_reward = 2,
                    static_id = 1,
                    quantity = 0
                };
                lsRewardTop.Add(re);
                gcRewardTop.DataSource = null;
                gcRewardTop.DataSource = lsRewardTop.Where(x => x.idFake == idFake);
                gvRewardTop.MoveLast();
            }
        }

        private void btnDeleteTop_Click(object sender, EventArgs e)
        {
            if (gvRewardTop.RowCount > 0)
            {
                int idFake = (int)gvTop.GetRowCellValue(gvTop.FocusedRowHandle, "idFake");
                vReward rewa = (vReward)gvRewardTop.GetRow(gvRewardTop.FocusedRowHandle);

                lsRewardTop.Remove(rewa);
                gcRewardTop.DataSource = lsRewardTop.Where(x => x.idFake == idFake);
                gvRewardTop.MoveLast();
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

        private void gvRewardMoc_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvRewardMoc.GetRow(gvRewardMoc.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        private void gvRewardTop_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvRewardTop.GetRow(gvRewardTop.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            HandlerSaveGrid();
            string idServer = lueChonServer.EditValue.ToString();

            DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
            DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
            int status = int.Parse(lueTrangThai.EditValue.ToString());

            if (addOrEdit == 1)
            {
                var result = MongoController.SkDoiDo.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.start = fromDate;
                result.end = toDate;
                result.server_id = idServer;
                result.status = (Status)status;
                result.refesh = HandlerRefesh(int.Parse(txtDiemLamMoi.Text), int.Parse(txtGioLamMoi.Text), int.Parse(txtTienLamMoi.Text));
                result.exchange_items = HandlerItemDoiDo();
                result.point_rewards = HandlerPointRewardDoiDo();
                result.top_rewards = HandlerTopRewardDoiDo();
                MongoController.SkDoiDo.Update(server.GetConnectSubDB(idServer), result);
            }
            else
            {
                var deActiveSK = MongoController.SkDoiDo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

                foreach (var item in deActiveSK)
                {
                    var tmpCheck = MongoController.SkDoiDo.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == item._id);
                    tmpCheck.status = Status.Deactivate;
                    MongoController.SkDoiDo.Update(server.GetConnectSubDB(idServer), tmpCheck);
                }


                MSKDoiDoConfig conf = new MSKDoiDoConfig()
                {
                    start = fromDate,
                    end = toDate,
                    server_id = idServer,
                    status = (Status)status,
                    refesh = HandlerRefesh(int.Parse(txtDiemLamMoi.Text), int.Parse(txtGioLamMoi.Text), int.Parse(txtTienLamMoi.Text)),
                    exchange_items = HandlerItemDoiDo(),
                    point_rewards = HandlerPointRewardDoiDo(),
                    top_rewards = HandlerTopRewardDoiDo()
                };

                MongoController.SkDoiDo.Create(server.GetConnectSubDB(idServer), conf);
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void HandlerSaveGrid()
        {
            gvMoc.FocusedRowHandle = -1;
            gvRequireItem.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            gvRewardMoc.FocusedRowHandle = -1;
            gvRewardTop.FocusedRowHandle = -1;
            gvTop.FocusedRowHandle = -1;
        }

        private List<TopRewardDoiDo> HandlerTopRewardDoiDo()
        {
            List<TopRewardDoiDo> tmpLsTop = new List<TopRewardDoiDo>();
            foreach (var item in lsTop)
            {
                TopRewardDoiDo top = new TopRewardDoiDo()
                {
                    index = item.idFake,
                    point_require = item.type_reward,
                    rewards = HandlerReward(2, item.idFake)
                };
                tmpLsTop.Add(top);
            }

            return tmpLsTop;
        }

        private List<PointDoiDoReward> HandlerPointRewardDoiDo()
        {
            List<PointDoiDoReward> tmpLsDoiDo = new List<PointDoiDoReward>();

            foreach (var item in lsMoc)
            {
                PointDoiDoReward point = new PointDoiDoReward()
                {
                    max_buy_times_in_day = item.static_id,
                    point_require = item.type_reward,
                    rewards = HandlerReward(1, item.idFake)
                };
                tmpLsDoiDo.Add(point);
            }
            return tmpLsDoiDo;
        }

        private List<SubRewardItem> HandlerReward(int type, int idGen)
        {
            List<SubRewardItem> tmpList = new List<SubRewardItem>();
            if (type == 1)
            {
                foreach (var item in lsRewardMoc.Where(x => x.idFake == idGen))
                {
                    SubRewardItem sub = new SubRewardItem()
                    {
                        type_reward = item.type_reward - 1,
                        static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                        quantity = item.quantity,
                        ruong_bau_id = item.idRuong
                    };
                    tmpList.Add(sub);
                }
            }
            else
            {
                foreach (var item in lsRewardTop.Where(x => x.idFake == idGen))
                {
                    SubRewardItem sub = new SubRewardItem()
                    {
                        type_reward = item.type_reward - 1,
                        static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                        quantity = item.quantity,
                        ruong_bau_id = item.idRuong
                    };
                    tmpList.Add(sub);
                }
            }

            return tmpList;
        }

        private List<ItemDoiDo> HandlerItemDoiDo()
        {
            List<ItemDoiDo> tmpLsDoiDo = new List<ItemDoiDo>();

            foreach (var item in lsRequireItem.Where(x => x.status == 1))
            {
                ItemDoiDo ite = new ItemDoiDo()
                {
                    reward_point = HandlerPointItem(item.idFake),
                    require_item = HandlerRequireItem(item.type_reward, item.static_id, item.quantity, item.idRuong),
                    reward_item = HandlerRewardItem(item.idFake)
                };
                tmpLsDoiDo.Add(ite);
            }

            return tmpLsDoiDo;
        }

        private int HandlerPointItem(int id)
        {
            var tmp = lsRewardReward.Where(x => x.idFake == id).FirstOrDefault();
            return tmp.price;
        }

        private SubRewardItem HandlerRewardItem(int id)
        {
            var tmp = lsRewardReward.Where(x => x.idFake == id).FirstOrDefault();
            SubRewardItem sub = new SubRewardItem()
            {
                type_reward = tmp.type_reward - 1,
                static_id = rewardHandler.HandlerSaveStaticID(tmp.type_reward, tmp.static_id),
                quantity = tmp.quantity,
                ruong_bau_id = tmp.idRuong
            };
            return sub;
        }

        private SubRewardItem HandlerRequireItem(int type, int staticID, int quan, string idRuong)
        {
            SubRewardItem sub = new SubRewardItem()
            {
                type_reward = type - 1,
                static_id = rewardHandler.HandlerSaveStaticID(type, staticID),
                quantity = quan,
                ruong_bau_id = idRuong
            };

            return sub;
        }

        private MRefeshDoiDoi HandlerRefesh(int diem, int gio, int tien)
        {
            MRefeshDoiDoi re = new MRefeshDoiDoi()
            {
                gold_require = tien,
                hour_auto_refesh = gio,
                point_reward = diem
            };
            return re;
        }
    }
}
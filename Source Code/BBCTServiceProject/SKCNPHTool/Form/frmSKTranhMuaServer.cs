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
    public partial class frmSKTranhMuaServer : frmFormChange
    {
        int addOrEdit = 0;
        ObjectId idSuKien;

        ListServer server = new ListServer();
        List<vReward> lsNgay = new List<vReward>();
        List<vReward> lsReward = new List<vReward>();
        ListReward rewardHandler = new ListReward();

        public frmSKTranhMuaServer(string nameForm, int status)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            addOrEdit = status;
            this.Text = nameForm + ": Tranh mua server";
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
                lsNgay.Clear();
                lsReward.Clear();
                gcNgay.DataSource = null;
                gcReward.DataSource = null;
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();

                if (addOrEdit == 1)
                {
                    var tmpSk = MongoController.SkTranhMuaServer.GetListData(server.GetConnectSubDB(idServer), a => true).OrderByDescending(x => x.created_at).FirstOrDefault();
                    if (tmpSk != null)
                    {
                        int countDate = -1;
                        foreach (var item in tmpSk.days)
                        {
                            countDate++;

                            vReward re = new vReward()
                            {
                                idFake = item.day,
                                idFakeString = tmpSk.start.AddDays(countDate).ToShortDateString()
                            };
                            lsNgay.Add(re);

                            foreach (var item1 in item.items)
                            {
                                vReward re1 = new vReward()
                                {
                                    idFake = re.idFake,
                                    type_reward = item1.item.type_reward + 1,
                                    static_id = rewardHandler.HandlerLoadStaticID(item1.item.type_reward + 1, item1.item.static_id),
                                    quantity = item1.item.quantity,
                                    status = item1.quantity,
                                    price = item1.price,
                                    max_buy_time = item1.quantity_each_user_can_buy,
                                    rank_require = item1.quantity_sold
                                };
                                lsReward.Add(re1);
                            }
                        }
                        gcNgay.DataSource = lsNgay;

                        dteFromDate.EditValue = tmpSk.start;
                        dteToDate.EditValue = tmpSk.end;
                        idSuKien = tmpSk._id;
                        lueTrangThai.EditValue = (int)tmpSk.status;
                    }
                    else
                    {
                        CommonShowDialog.ShowErrorDialog("Server này hiện tại chưa có sự kiện nào, thoát ra và tạo sự kiện mới");
                        this.Close();
                    }
                }
                else
                {
                    lueTrangThai.EditValue = 0;
                    DateTime fro = DateTime.Now;

                    vReward re = new vReward()
                    {
                        idFake = 0,
                        idFakeString = fro.AddDays(0).ToShortDateString()
                    };
                    lsNgay.Add(re);

                    vReward re1 = new vReward()
                    {
                        idFake = 1,
                        idFakeString = fro.AddDays(1).ToShortDateString()
                    };
                    lsNgay.Add(re1);

                    vReward re2 = new vReward()
                    {
                        idFake = 2,
                        idFakeString = fro.AddDays(2).ToShortDateString()
                    };
                    lsNgay.Add(re2);

                    dteFromDate.EditValue = DateTime.Now;
                }
            }
        }

        private void dteFromDate_EditValueChanged(object sender, EventArgs e)
        {
            if (dteFromDate.Text != "")
            {
                DateTime fro = DateTime.Parse(dteFromDate.EditValue.ToString());
                lsNgay.Where(x => x.idFake == 0).ToList().ForEach(x => x.idFakeString = fro.AddDays(0).ToShortDateString());
                lsNgay.Where(x => x.idFake == 1).ToList().ForEach(x => x.idFakeString = fro.AddDays(1).ToShortDateString());
                lsNgay.Where(x => x.idFake == 2).ToList().ForEach(x => x.idFakeString = fro.AddDays(2).ToShortDateString());

                dteToDate.EditValue = fro.AddDays(3);
                gcNgay.DataSource = null;
                gcNgay.DataSource = lsNgay;
            }
        }

        private void gvNgay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvNgay.RowCount > 0)
            {
                int idFake = (int)gvNgay.GetRowCellValue(gvNgay.FocusedRowHandle, "idFake");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFake == idFake);
            }
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            if (gvNgay.RowCount > 0)
            {
                int idFake = (int)gvNgay.GetRowCellValue(gvNgay.FocusedRowHandle, "idFake");

                vReward re = new vReward()
                {
                    idFake = idFake,
                    type_reward = 2,
                    static_id = 1,
                    quantity = 0,
                    status = 0,
                    price = 0,
                    max_buy_time = 0,
                    rank_require = 0
                };
                lsReward.Add(re);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFake == idFake);
                gvReward.MoveLast();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                int idFake = (int)gvNgay.GetRowCellValue(gvNgay.FocusedRowHandle, "idFake");

                lsReward.Remove(rewardSelect);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFake == idFake);
            }
        }

        protected override void OnSave()
        {
            gvNgay.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;

            string idServer = lueChonServer.EditValue.ToString();

            DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
            DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
            int status = int.Parse(lueTrangThai.EditValue.ToString());

            if (addOrEdit == 1)
            {
                var result = MongoController.SkTranhMuaServer.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.start = fromDate;
                result.end = toDate;
                result.status = (Status)status;
                result.days = HandlerDay();

                MongoController.SkTranhMuaServer.Update(server.GetConnectSubDB(idServer), result);
            }
            else
            {
                var deActiveSK = MongoController.SkTranhMuaServer.GetListData(server.GetConnectSubDB(idServer), a => true);

                foreach (var item in deActiveSK)
                {
                    var tmpCheck = MongoController.SkTranhMuaServer.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == item._id);
                    tmpCheck.status = Status.Deactivate;
                    MongoController.SkTranhMuaServer.Update(server.GetConnectSubDB(idServer), tmpCheck);
                }

                MSKTranhMuaServerConfig conf = new MSKTranhMuaServerConfig()
                {
                    start = fromDate,
                    end = toDate,
                    status = (Status)status,
                    days = HandlerDay()
                };

                MongoController.SkTranhMuaServer.Create(server.GetConnectSubDB(idServer), conf);
            }
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<DayTranhMua> HandlerDay()
        {
            List<DayTranhMua> tmpLSDay = new List<DayTranhMua>();

            foreach (var item in lsNgay)
            {
                DayTranhMua day = new DayTranhMua()
                {
                    day = item.idFake,
                    items = HandlerItemDay(item.idFake)
                };
                tmpLSDay.Add(day);
            }

            return tmpLSDay;
        }

        private List<ItemTranhMua> HandlerItemDay(int idNgay)
        {
            List<ItemTranhMua> tmpLsItem = new List<ItemTranhMua>();
            foreach (var item in lsReward.Where(x => x.idFake == idNgay))
            {
                ItemTranhMua it = new ItemTranhMua()
                {
                    price = item.price,
                    quantity = item.status,
                    quantity_each_user_can_buy = item.max_buy_time,
                    quantity_sold = item.rank_require,
                    item = HandlerrRewardDay(item.type_reward, item.static_id, item.quantity)
                };
                tmpLsItem.Add(it);
            }

            return tmpLsItem;
        }

        private SubRewardItem HandlerrRewardDay(int type, int staticID, int quan)
        {
            SubRewardItem sub = new SubRewardItem()
            {
                type_reward = type - 1,
                static_id = rewardHandler.HandlerSaveStaticID(type, staticID),
                quantity = quan
            };
            return sub;
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
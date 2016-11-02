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
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Models;
using MongoDBModel.SubDatabaseModels;
using MongoDBModel.Enum;
using DynamicDBModel.Models;
using KDQHNPHTool.Common;
using MongoDB.Bson;

namespace KDQHNPHTool.Form
{
    public partial class frmSK7NgayNhanThuong : frmFormChange
    {
        int addOrEdit = 0;
        ObjectId idSuKien;

        ListServer server = new ListServer();
        List<dbCTAffliction> lsNGay = new List<dbCTAffliction>();
        List<vReward> lsReward = new List<vReward>();
        ListReward rewardHandler = new ListReward();

        public frmSK7NgayNhanThuong(string nameForm, int status)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            addOrEdit = status;
            this.Text = nameForm + ": 7 ngày nhận thưởng";
            panelControl2.Enabled = false;
            LoadDataToLUE();

            if (addOrEdit == 1)
            {
                dteFromDate.Enabled = false;
                dteToDate.Enabled = false;
            }
            else
            {
                lueTrangThai.EditValue = 0;
            }
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

        private void LoadDataToList(string idServer)
        {
            if (addOrEdit == 2)
            {
                dteFromDate.EditValue = DateTime.Now;
            }
            else
            {
                lsNGay.Clear();
                var tmpSk = MongoController.Sk7NgayNhanThuong.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.created_at).FirstOrDefault();
                if (tmpSk != null)
                {
                    dteFromDate.EditValue = tmpSk.start;
                    dteToDate.EditValue = tmpSk.end;
                    idSuKien = tmpSk._id;

                    lueTrangThai.EditValue = (int)tmpSk.status;
                    foreach (var item in tmpSk.day_rewards)
                    {
                        dbCTAffliction aff = new dbCTAffliction()
                        {
                            id = item.day,
                            value = item.day.ToString()
                        };
                        lsNGay.Add(aff);

                        foreach (var item1 in item.rewards)
                        {
                            vReward reward = new vReward()
                            {
                                idFake = item.day,
                                quantity = item1.quantity,
                                static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                type_reward = item1.type_reward + 1,
                                idRuong = item1.ruong_bau_id
                            };
                            lsReward.Add(reward);
                        }
                    }
                    gcNgay.DataSource = null;
                    gcNgay.DataSource = lsNGay;
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

        private void dteFromDate_EditValueChanged(object sender, EventArgs e)
        {
            if (dteFromDate.Text != "")
            {
                if (addOrEdit == 2)
                {
                    lsNGay.Clear();
                    lsReward.Clear();
                    DateTime timeFromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
                    dteToDate.EditValue = timeFromDate.AddDays(6);

                    for (int i = 0; i < 7; i++)
                    {
                        dbCTAffliction aff = new dbCTAffliction()
                        {
                            id = timeFromDate.AddDays(i).Day,
                            value = timeFromDate.AddDays(i).Day.ToString()
                        };
                        lsNGay.Add(aff);
                    }
                    gcNgay.DataSource = null;
                    gcNgay.DataSource = lsNGay;
                }
            }
        }

        private void gvNgay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvNgay.RowCount > 0)
            {
                int idNgay = (int)gvNgay.GetRowCellValue(gvNgay.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFake == idNgay);
            }
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            int idNgay = (int)gvNgay.GetRowCellValue(gvNgay.FocusedRowHandle, "id");
            vReward reward = new vReward()
            {
                idFake = idNgay,
                quantity = 0,
                static_id = 1,
                status = 1,
                type_reward = 2
            };
            lsReward.Add(reward);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.idFake == idNgay);
            gvReward.MoveLast();
        }

        private void btnDeleteReward_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idNgay = (int)gvNgay.GetRowCellValue(gvNgay.FocusedRowHandle, "id");
                vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                lsReward.Remove(rewardSelect);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFake == idNgay);
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
            string idServer = lueChonServer.EditValue.ToString();

            DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
            DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
            int status = int.Parse(lueTrangThai.EditValue.ToString());

            if (addOrEdit == 1)
            {
                var result = MongoController.Sk7NgayNhanThuong.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.start = fromDate;
                result.end = toDate;
                result.server_id = idServer;
                result.status = (Status)status;
                result.day_rewards = HandlerDayReward();

                MongoController.Sk7NgayNhanThuong.Update(server.GetConnectSubDB(idServer), result);
            }
            else
            {
                var deActiveSK = MongoController.Sk7NgayNhanThuong.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

                foreach (var item in deActiveSK)
                {
                    var tmpCheck = MongoController.Sk7NgayNhanThuong.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == item._id);
                    tmpCheck.status = Status.Deactivate;
                    MongoController.Sk7NgayNhanThuong.Update(server.GetConnectSubDB(idServer), tmpCheck);
                }

                MSK7NgayNhanThuongConfig conf = new MSK7NgayNhanThuongConfig()
                {
                    start = fromDate,
                    end = toDate,
                    server_id = idServer,
                    status = (Status)status,
                    day_rewards = HandlerDayReward()
                };

                MongoController.Sk7NgayNhanThuong.Create(server.GetConnectSubDB(idServer), conf);
            }
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private DayReward[] HandlerDayReward()
        {
            List<DayReward> lsDayReward = new List<DayReward>();
            foreach (var item in lsNGay)
            {
                DayReward day = new DayReward()
                {
                    day = item.id,
                    rewards = HandlerReward(item.id)
                };
                lsDayReward.Add(day);
            }
            return lsDayReward.ToArray();
        }

        private List<SubRewardItem> HandlerReward(int idNgay)
        {
            List<SubRewardItem> lsSubReward = new List<SubRewardItem>();
            foreach (var item in lsReward.Where(x => x.idFake == idNgay))
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
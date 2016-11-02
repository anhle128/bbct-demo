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
using MongoDB.Bson;
using KDQHNPHTool.Models;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Common;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using DynamicDBModel.Enum;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmSKTichLuyNap : frmFormChange
    {
        int addOrEdit = 0;
        ObjectId idSuKien;
        ListServer server = new ListServer();
        List<dbCTStatusSuKien> lsMocTichLuy = new List<dbCTStatusSuKien>();
        List<vReward> lsRewardTichLuy = new List<vReward>();
        ListReward rewardHandler = new ListReward();

        public frmSKTichLuyNap(string nameForm, int type)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            addOrEdit = type;
            this.Text = nameForm + ": Tích lũy nạp";
            LoadDataToLUE();
            panelControl2.Enabled = false;

            if (addOrEdit == 1)
            {
                dteFromDate.Enabled = false;
                dteToDate.Enabled = false;
            }
            else
            {
                lueTrangThai.EditValue = 0;
                lueLoaiSuKien.EditValue = 0;
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

            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();

            var tmpStatus = from tmp in ConnectDB.Entities.dbCTStatusSuKiens
                            select tmp;

            lueTrangThai.Properties.DataSource = tmpStatus.ToList();
            lueTrangThai.Properties.DisplayMember = "value";
            lueTrangThai.Properties.ValueMember = "id";

            List<dbCTStatusSuKien> lsTypeSuKien = new List<dbCTStatusSuKien>();
            dbCTStatusSuKien ct = new dbCTStatusSuKien()
            {
                id = 0,
                value = "Ngày"
            };
            lsTypeSuKien.Add(ct);

            dbCTStatusSuKien ct1 = new dbCTStatusSuKien()
            {
                id = 1,
                value = "Khoảng thời gian"
            };
            lsTypeSuKien.Add(ct1);
            lueLoaiSuKien.Properties.DataSource = lsTypeSuKien;
            lueLoaiSuKien.Properties.DisplayMember = "value";
            lueLoaiSuKien.Properties.ValueMember = "id";
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                lsMocTichLuy.Clear();
                lsRewardTichLuy.Clear();
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                if (addOrEdit == 1)
                {
                    var tmpSk = MongoController.SkTichLuyNap.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.created_at).FirstOrDefault();
                    if (tmpSk != null)
                    {
                        dteFromDate.EditValue = tmpSk.start;
                        dteToDate.EditValue = tmpSk.end;
                        lueLoaiSuKien.EditValue = (int)tmpSk.type;
                        lueTrangThai.EditValue = (int)tmpSk.status;
                        idSuKien = tmpSk._id;

                        for (int i = 0; i < tmpSk.gold_rewards.Count; i++)
                        {

                            dbCTStatusSuKien sukien = new dbCTStatusSuKien()
                            {
                                id = i,
                                value = tmpSk.gold_rewards[i].gold_require.ToString()
                            };
                            lsMocTichLuy.Add(sukien);

                            foreach (var item in tmpSk.gold_rewards[i].rewards)
                            {
                                vReward reward = new vReward()
                                {
                                    idFake = i,
                                    quantity = item.quantity,
                                    static_id = rewardHandler.HandlerLoadStaticID(item.type_reward + 1, item.static_id),
                                    type_reward = item.type_reward + 1,
                                    idRuong = item.ruong_bau_id
                                };
                                lsRewardTichLuy.Add(reward);
                            }
                        }
                        gcMocTichLuy.DataSource = null;
                        gcMocTichLuy.DataSource = lsMocTichLuy;
                    }
                }
                else
                {
                    dbCTStatusSuKien status = new dbCTStatusSuKien()
                    {
                        id = 0,
                        value = "100"
                    };
                    lsMocTichLuy.Add(status);

                    dbCTStatusSuKien status1 = new dbCTStatusSuKien()
                    {
                        id = 1,
                        value = "200"
                    };
                    lsMocTichLuy.Add(status1);

                    dbCTStatusSuKien status2 = new dbCTStatusSuKien()
                    {
                        id = 2,
                        value = "300"
                    };
                    lsMocTichLuy.Add(status2);
                    gcMocTichLuy.DataSource = null;
                    gcMocTichLuy.DataSource = lsMocTichLuy;
                }
            }
        }

        private void gvMocTichLuy_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvMocTichLuy.RowCount > 0)
            {
                int idMoc = (int)gvMocTichLuy.GetRowCellValue(gvMocTichLuy.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsRewardTichLuy.Where(x => x.idFake == idMoc);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                dbCTStatusSuKien star = new dbCTStatusSuKien()
                {
                    id = -(lsMocTichLuy.Count),
                    value = "0"
                };
                lsMocTichLuy.Add(star);
                gcMocTichLuy.DataSource = null;
                gcMocTichLuy.DataSource = lsMocTichLuy;
                gvMocTichLuy.MoveLast();
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Phải chọn server trước");
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                if (gvMocTichLuy.RowCount > 0)
                {
                    dbCTStatusSuKien rewardSelect = (dbCTStatusSuKien)gvMocTichLuy.GetRow(gvMocTichLuy.FocusedRowHandle);
                    int idMoc = (int)gvMocTichLuy.GetRowCellValue(gvMocTichLuy.FocusedRowHandle, "id");
                    lsMocTichLuy.Remove(rewardSelect);
                    lsRewardTichLuy.RemoveAll(x => x.idFake == idMoc);
                    gcMocTichLuy.DataSource = null;
                    gcMocTichLuy.DataSource = lsMocTichLuy;
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Phải chọn server trước");
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                if (gvMocTichLuy.RowCount > 0)
                {
                    int idMoc = (int)gvMocTichLuy.GetRowCellValue(gvMocTichLuy.FocusedRowHandle, "id");
                    vReward reward = new vReward()
                    {
                        idFake = idMoc,
                        quantity = 0,
                        static_id = 1,
                        type_reward = 2
                    };
                    lsRewardTichLuy.Add(reward);
                    gcReward.DataSource = null;
                    gcReward.DataSource = lsRewardTichLuy.Where(x => x.idFake == idMoc);
                    gvReward.MoveLast();
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Phải chọn server trước");
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                if (gvReward.RowCount > 0)
                {
                    int idMoc = (int)gvMocTichLuy.GetRowCellValue(gvMocTichLuy.FocusedRowHandle, "id");
                    vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                    lsRewardTichLuy.Remove(rewardSelect);
                    gcReward.DataSource = null;
                    gcReward.DataSource = lsRewardTichLuy.Where(x => x.idFake == idMoc);
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Phải chọn server trước");
            }
        }

        protected override void OnSave()
        {
            gvMocTichLuy.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;

            string idServer = lueChonServer.EditValue.ToString();
            DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
            DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
            int tySuKien = int.Parse(lueLoaiSuKien.EditValue.ToString());
            int status = int.Parse(lueTrangThai.EditValue.ToString());

            if (addOrEdit == 1)
            {
                var result = MongoController.SkTichLuyNap.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.start = fromDate;
                result.end = toDate;
                result.server_id = idServer;
                result.type = (TypeSuKienTichLuyNap)tySuKien;
                result.status = (Status)status;
                result.gold_rewards = HandlerGoldReward();

                MongoController.SkTichLuyNap.Update(server.GetConnectSubDB(idServer), result);
            }
            else
            {
                var deActiveSK = MongoController.SkTichLuyNap.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

                foreach (var item in deActiveSK)
                {
                    var tmpCheck = MongoController.SkTichLuyNap.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == item._id);
                    tmpCheck.status = Status.Deactivate;
                    MongoController.SkTichLuyNap.Update(server.GetConnectSubDB(idServer), tmpCheck);
                }

                MSKTichLuyNapConfig conf = new MSKTichLuyNapConfig()
                {
                    start = fromDate,
                    end = toDate,
                    server_id = idServer,
                    type = (TypeSuKienTichLuyNap)tySuKien,
                    status = (Status)status,
                    gold_rewards = HandlerGoldReward()
                };

                MongoController.SkTichLuyNap.Create(server.GetConnectSubDB(idServer), conf);
            }
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<MGoldReward> HandlerGoldReward()
        {
            List<MGoldReward> lsGoldReward = new List<MGoldReward>();
            foreach (var item in lsMocTichLuy)
            {
                MGoldReward gold = new MGoldReward()
                {
                    gold_require = int.Parse(item.value),
                    rewards = HandlerReward(item.id)
                };
                lsGoldReward.Add(gold);
            }
            return lsGoldReward;
        }

        private List<SubRewardItem> HandlerReward(int idMoc)
        {
            List<SubRewardItem> lsReward = new List<SubRewardItem>();
            foreach (var item in lsRewardTichLuy.Where(x => x.idFake == idMoc))
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
            return lsReward;
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
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
using MongoDBModel.SubDatabaseModels;
using MongoDB.Bson;
using DynamicDBModel.Models;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.Form
{
    public partial class frmRuongBau : frmFormChange
    {

        List<vRuongBau> lsRuongBau = new List<vRuongBau>();
        List<vReward> lsReward = new List<vReward>();
        ListReward rewardHandler = new ListReward();
        ListServer server = new ListServer();

        public frmRuongBau()
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
            formTask.ShowDialog();
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                lsReward.Clear();
                lsRuongBau.Clear();
                gcRuong.DataSource = null;
                gcReward.DataSource = null;

                var tmpSk = MongoController.RuongBau.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);
                if (tmpSk.Count > 0)
                {
                    foreach (var item in tmpSk)
                    {
                        vRuongBau ruong = new vRuongBau()
                        {
                            idRuong = item._id.ToString(),
                            name = item.name,
                            des = item.desc,
                            status = 1
                        };
                        lsRuongBau.Add(ruong);

                        foreach (var item1 in item.rewards)
                        {
                            vReward reward = new vReward()
                            {
                                idFakeString = ruong.idRuong,
                                static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                                quantity = item1.quantity,
                                type_reward = item1.type_reward + 1
                            };
                            lsReward.Add(reward);
                        }
                    }
                    gcRuong.DataSource = lsRuongBau.Where(x => x.status == 1);
                }
            }
        }

        private void gvRuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvRuong.RowCount > 0)
            {
                string idGen = (string)gvRuong.GetRowCellValue(gvRuong.FocusedRowHandle, "idRuong");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFakeString == idGen);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            vRuongBau ruong = new vRuongBau()
            {
                idRuong = (lsRuongBau.Count.ToString()),
                name = " Tên rương",
                des = "Mô tả",
                status = 1
            };
            lsRuongBau.Add(ruong);
            gcRuong.DataSource = null;
            gcRuong.DataSource = lsRuongBau.Where(x => x.status == 1);
            gvRuong.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvRuong.RowCount > 0)
            {
                string idGen = (string)gvRuong.GetRowCellValue(gvRuong.FocusedRowHandle, "idRuong");
                lsRuongBau.Where(x => x.idRuong == idGen).ToList().ForEach(x => x.status = 2);
                gcRuong.DataSource = null;
                gcRuong.DataSource = lsRuongBau.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvRuong.RowCount > 0)
            {
                string idGen = (string)gvRuong.GetRowCellValue(gvRuong.FocusedRowHandle, "idRuong");
                vReward reward = new vReward()
                {
                    idFakeString = idGen,
                    static_id = 1,
                    quantity = 0,
                    type_reward = 2
                };
                lsReward.Add(reward);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFakeString == idGen);
                gvReward.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                string idGen = (string)gvRuong.GetRowCellValue(gvRuong.FocusedRowHandle, "idRuong");
                vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                lsReward.Remove(rewardSelect);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFakeString == idGen);
            }
        }

        protected override void OnSave()
        {
            gvRuong.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            ObjectId idSuKien;
            string idServer = lueChonServer.EditValue.ToString();

            foreach (var item in lsRuongBau.Where(x => x.status == 1))
            {
                int tmp;
                bool isInt = int.TryParse(item.idRuong, out tmp);
                if (isInt == true)
                {
                    MRuongBauConfig ruong = new MRuongBauConfig()
                    {
                        name = item.name,
                        rewards = HandlerSubRewardItem(item.idRuong),
                        server_id = idServer,
                        desc = item.des
                    };
                    MongoController.RuongBau.Create(server.GetConnectSubDB(idServer), ruong);
                }
                else
                {
                    idSuKien = ObjectId.Parse(item.idRuong);
                    var result = MongoController.RuongBau.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                    result.name = item.name;
                    result.rewards = HandlerSubRewardItem(item.idRuong);
                    result.desc = item.des;
                    MongoController.RuongBau.Update(server.GetConnectSubDB(idServer), result);
                }
            }

            foreach (var item in lsRuongBau.Where(x => x.status == 2))
            {
                int tmp;
                bool isInt = int.TryParse(item.idRuong, out tmp);
                if (isInt == false)
                {
                    idSuKien = ObjectId.Parse(item.idRuong);
                    MongoController.RuongBau.DeleteAsync(server.GetConnectSubDB(idServer), idSuKien);
                }
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private List<SubRewardItem> HandlerSubRewardItem(string idRuong)
        {
            List<SubRewardItem> lsSubReward = new List<SubRewardItem>();
            foreach (var item in lsReward.Where(x => x.idFakeString == idRuong))
            {
                SubRewardItem sub = new SubRewardItem()
                {
                    quantity = item.quantity,
                    static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                    type_reward = item.type_reward - 1
                };
                lsSubReward.Add(sub);
            }
            return lsSubReward;
        }
    }
}
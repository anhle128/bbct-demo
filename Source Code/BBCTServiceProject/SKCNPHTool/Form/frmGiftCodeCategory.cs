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
using MongoDB.Bson;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Models;
using MongoDBModel.MainDatabaseModels;
using MongoDBModel.Enum;
using DynamicDBModel.Models;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.Form
{
    public partial class frmGiftCodeCategory : frmFormChange
    {
        List<vGiftCodeCategory> lsCategory = new List<vGiftCodeCategory>();
        List<vReward> lsReward = new List<vReward>();
        ListReward rewardHandler = new ListReward();
        ListServer server = new ListServer();

        ObjectId idSuKien;

        public frmGiftCodeCategory()
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
        }

        private void LoadDataToLUE()
        {
            List<Server> tmpServer = new List<Server>();

            Server ser = new Server()
            {
                id = "0",
                value = "Tất cả"
            };
            tmpServer.Add(ser);

            foreach (var item in server.GetListServer())
            {
                Server serr = new Server()
                {
                    id = item.id,
                    value = item.value
                };
                tmpServer.Add(serr);
            }
            lueChonServer.DataSource = tmpServer.ToList();

            var tmpTypeReward = from tmp in ConnectDB.Entities.dbCTTypeRewards
                                select tmp;

            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();

            var tmpTypeGift = from tmp in ConnectDB.Entities.dbCTGiftcodes
                              select tmp;

            lueLoaiGiftCode.DataSource = tmpTypeGift.ToList();
        }

        private void LoadDataToList()
        {
            lsCategory.Clear();
            lsReward.Clear();
            gcReward.DataSource = null;
            gcGifftCodeCategory.DataSource = null;
            var tmpSk = MongoController.GiftCodeCategory.GetListData(MongoController.DatabaseManager.main_database, a => true);
            if (tmpSk.Count > 0)
            {
                foreach (var item in tmpSk)
                {
                    vGiftCodeCategory gift = new vGiftCodeCategory()
                    {
                        id = item._id.ToString(),
                        name = item.name,
                        type = (int)item.type,
                        idServer = item.server != "" ? item.server : "0",
                        status = 1
                    };
                    lsCategory.Add(gift);

                    foreach (var item1 in item.rewards)
                    {
                        vReward rewar = new vReward()
                        {
                            idFakeString = item._id.ToString(),
                            type_reward = item1.type_reward + 1,
                            static_id = rewardHandler.HandlerLoadStaticID(item1.type_reward + 1, item1.static_id),
                            quantity = item1.quantity
                        };
                        lsReward.Add(rewar);
                    }
                }
                gcGifftCodeCategory.DataSource = lsCategory.Where(x => x.status == 1);
            }
        }

        private void gvGifftCodeCategory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvGifftCodeCategory.RowCount > 0)
            {
                string idCate = (string)gvGifftCodeCategory.GetRowCellValue(gvGifftCodeCategory.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFakeString == idCate);
            }
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 1, "");
            formTask.ShowDialog();
        }

        private void btnAddLoai_Click(object sender, EventArgs e)
        {
            vGiftCodeCategory gift = new vGiftCodeCategory()
            {
                id = (-lsCategory.Count()).ToString(),
                name = "Tên loại",
                type = 0,
                idServer = "0",
                status = 1
            };
            lsCategory.Add(gift);
            gcGifftCodeCategory.DataSource = null;
            gcGifftCodeCategory.DataSource = lsCategory.Where(x => x.status == 1);
            gvGifftCodeCategory.MoveLast();
        }

        private void btnDeleteLoai_Click(object sender, EventArgs e)
        {
            if (gvGifftCodeCategory.RowCount > 0)
            {
                string idCate = (string)gvGifftCodeCategory.GetRowCellValue(gvGifftCodeCategory.FocusedRowHandle, "id");

                lsReward.RemoveAll(x => x.idFakeString == idCate);
                lsCategory.Where(x => x.id == idCate).ToList().ForEach(x => x.status = 2);
                gcGifftCodeCategory.DataSource = null;
                gcGifftCodeCategory.DataSource = lsCategory.Where(x => x.status == 1);
            }
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            if (gvGifftCodeCategory.RowCount > 0)
            {
                string idCate = (string)gvGifftCodeCategory.GetRowCellValue(gvGifftCodeCategory.FocusedRowHandle, "id");
                vReward reward = new vReward()
                {
                    idFakeString = idCate,
                    quantity = 0,
                    static_id = 1,
                    type_reward = 2,
                };

                lsReward.Add(reward);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFakeString == idCate);
                gvReward.MoveLast();
            }
        }

        private void btnDeleteReward_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                string idCate = (string)gvGifftCodeCategory.GetRowCellValue(gvGifftCodeCategory.FocusedRowHandle, "id");

                vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                lsReward.Remove(rewardSelect);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idFakeString == idCate);
            }
        }

        protected override void OnSave()
        {
            gvGifftCodeCategory.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;

            foreach (var item in lsCategory.Where(x => x.status == 1))
            {
                int tmp;
                bool isInt = int.TryParse(item.id, out tmp);
                if (isInt == true)
                {
                    MGiftCodeCategory code = new MGiftCodeCategory()
                    {
                        name = item.name,
                        server = item.idServer != "0" ? item.idServer : "",
                        type = (GiftCodeType)item.type,
                        rewards = HandlerReward(item.id)
                    };
                    MongoController.GiftCodeCategory.Create(MongoController.DatabaseManager.main_database, code);
                }
                else
                {
                    idSuKien = ObjectId.Parse(item.id);
                    var result = MongoController.GiftCodeCategory.GetSingleData(MongoController.DatabaseManager.main_database, a => a._id == idSuKien);
                    result.name = item.name;
                    result.server = item.idServer != "0" ? item.idServer : "";
                    result.type = (GiftCodeType)item.type;
                    result.rewards = HandlerReward(item.id);
                    MongoController.GiftCodeCategory.Update(MongoController.DatabaseManager.main_database, result);
                }
            }

            foreach (var item in lsCategory.Where(x => x.status == 2))
            {
                int tmp;
                bool isInt = int.TryParse(item.id, out tmp);
                if (isInt == false)
                {
                    idSuKien = ObjectId.Parse(item.id);
                    MongoController.GiftCodeCategory.DeleteAsync(MongoController.DatabaseManager.main_database, idSuKien);
                }
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
            LoadDataToList();
        }

        private SubRewardItem[] HandlerReward(string idCate)
        {
            List<SubRewardItem> lsTmp = new List<SubRewardItem>();
            foreach (var item in lsReward.Where(x => x.idFakeString == idCate))
            {
                SubRewardItem sub = new SubRewardItem()
                {
                    quantity = item.quantity,
                    type_reward = item.type_reward - 1,
                    static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id)
                };
                lsTmp.Add(sub);
            }
            return lsTmp.ToArray();
        }
    }
}
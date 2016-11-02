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
using BBCTDesignerTool.FormBase;
using BBCTDesignerTool.Models;
using BBCTDesignerTool.Common;

namespace BBCTDesignerTool.Form
{
    public partial class frmRuongBau : frmFormChange
    {
        List<dbRuongBauConfig> lsRuong = new List<dbRuongBauConfig>();
        List<dbRuongBauReward> lsReward = new List<dbRuongBauReward>();
        ListReward rewardHandler = new ListReward();

        public frmRuongBau()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
        }

        private void LoadDataToLUE()
        {
            var tmpTpe = from tmp in ConnectDB.Entities.dbCTTypeRewards
                         select tmp;

            lueTypeReward.DataSource = tmpTpe.ToList();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();

            var tmpItem = from tmp in ConnectDB.Entities.dbItems
                          where tmp.status == 1 && tmp.types == 24
                          select new
                          {
                              tmp.idItem,
                              tmp.name
                          };
            lueRuong.DataSource = tmpItem.ToList();
        }

        private void LoadDataToList()
        {
            lsRuong.Clear();
            lsReward.Clear();
            gcRuong.DataSource = null;
            gcReward.DataSource = null;

            var tmpRuong = from tmp in ConnectDB.Entities.dbRuongBauConfigs
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpRuong)
            {
                dbRuongBauConfig ruong = new dbRuongBauConfig()
                {
                    id = item.id,
                    idRuongBau = item.idRuongBau,
                    name = item.name,
                    status = item.status
                };
                lsRuong.Add(ruong);

                var tmpReward = from tmp in ConnectDB.Entities.dbRuongBauRewards
                                where tmp.status == 1 && tmp.idRuong == item.id
                                select tmp;

                foreach (var item1 in tmpReward)
                {
                    dbRuongBauReward reward = new dbRuongBauReward()
                    {
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin,
                        id = item1.id,
                        idRuong = item1.idRuong,
                        procs = item1.procs,
                        staticID = rewardHandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward
                    };
                    lsReward.Add(reward);
                }
            }

            gcRuong.DataSource = lsRuong.Where(x => x.status == 1);
        }

        private void gvRuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvRuong.RowCount > 0)
            {
                int idGen = (int)gvRuong.GetRowCellValue(gvRuong.FocusedRowHandle, "id");

                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idRuong == idGen);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbRuongBauConfig ruong = new dbRuongBauConfig()
            {
                id = -(lsRuong.Count),
                idRuongBau = 56,
                name = "Tên rương",
                status = 1
            };
            lsRuong.Add(ruong);
            gcRuong.DataSource = null;
            gcRuong.DataSource = lsRuong.Where(x => x.status == 1);
            gvRuong.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvRuong.RowCount > 0)
            {
                int idGen = (int)gvRuong.GetRowCellValue(gvRuong.FocusedRowHandle, "id");
                lsRuong.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcRuong.DataSource = null;
                gcRuong.DataSource = lsRuong.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvRuong.RowCount > 0)
            {
                int idGen = (int)gvRuong.GetRowCellValue(gvRuong.FocusedRowHandle, "id");

                dbRuongBauReward reward = new dbRuongBauReward()
                {
                    amountMax = 1,
                    amountMin = 1,
                    id = -(lsReward.Count),
                    idRuong = idGen,
                    procs = 100,
                    staticID = 1,
                    status = 1,
                    typeReward = 2
                };
                lsReward.Add(reward);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idRuong == idGen);
                gvReward.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idGen = (int)gvRuong.GetRowCellValue(gvRuong.FocusedRowHandle, "id");
                int idReward = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");

                lsReward.Where(x => x.id == idReward).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idRuong == idGen);
            }
        }

        protected override void OnSave()
        {
            gvReward.FocusedRowHandle = -1;
            gvRuong.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();

            foreach (var item in lsRuong)
            {
                if (item.id <= 0)
                {
                    var ckeRuong = ConnectDB.Entities.dbRuongBauConfigs.Where(x => x.idRuongBau == item.id).FirstOrDefault();
                    if (ckeRuong == null)
                    {
                        dbRuongBauConfig ruong = new dbRuongBauConfig()
                        {
                            idRuongBau = item.idRuongBau,
                            name = item.name,
                            status = item.status
                        };
                        ConnectDB.Entities.dbRuongBauConfigs.Add(ruong);
                        ConnectDB.Entities.SaveChanges();

                        foreach (var item1 in lsReward.Where(x => x.idRuong == item.id))
                        {
                            dbRuongBauReward reward = new dbRuongBauReward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idRuong = ruong.id,
                                procs = item1.procs,
                                staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbRuongBauRewards.Add(reward);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }
                    else
                    {
                        CommonShowDialog.ShowErrorDialog("ID Rương đã tồn tại");
                    }
                }
                else
                {
                    var result = ConnectDB.Entities.dbRuongBauConfigs.Where(x => x.id == item.id).FirstOrDefault();
                    result.idRuongBau = item.idRuongBau;
                    result.name = item.name;
                    result.status = item.status;

                    foreach (var item1 in lsReward.Where(x => x.idRuong == item.id))
                    {
                        if (item1.id <= 0)
                        {
                            dbRuongBauReward reward = new dbRuongBauReward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idRuong = item.id,
                                procs = item1.procs,
                                staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbRuongBauRewards.Add(reward);
                        }
                        else
                        {
                            var result1 = ConnectDB.Entities.dbRuongBauRewards.Where(x => x.id == item1.id).FirstOrDefault();
                            result1.amountMax = item1.amountMax;
                            result1.amountMin = item1.amountMin;
                            result1.idRuong = item.id;
                            result1.procs = item1.procs;
                            result1.staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID);
                            result1.status = item1.status;
                            result1.typeReward = item1.typeReward;
                        }
                        ConnectDB.Entities.SaveChanges();
                    }
                }

            }

            LoadDataToList();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbRuongBauReward rewardSelect = (dbRuongBauReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null);
            formTask.ShowDialog();
        }
    }
}
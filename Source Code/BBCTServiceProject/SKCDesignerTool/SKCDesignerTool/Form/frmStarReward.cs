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
using KDQHDesignerTool.FormBase;
using KDQHDesignerTool.Models;
using KDQHDesignerTool.Common;

namespace KDQHDesignerTool.Form
{
    public partial class frmStarReward : frmFormChange
    {
        ListReward rewardHandler = new ListReward();
        List<dbStarReward> lsStarReward = new List<dbStarReward>();
        List<dbStarRewardReward> lsReward = new List<dbStarRewardReward>();

        public frmStarReward()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToLUE()
        {
            var tmpTypeReward = from tmp in ConnectDB.Entities.dbCTTypeRewards
                                select tmp;

            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();
        }

        private void LoadDataToList()
        {
            lsStarReward.Clear();
            lsReward.Clear();

            var tmpStar = from tmp in ConnectDB.Entities.dbStarRewards
                          where tmp.status == 1
                          select
                          tmp;

            foreach (var item in tmpStar)
            {
                dbStarReward db = new dbStarReward()
                {
                    id = item.id,
                    starRequire = item.starRequire,
                    status = item.status
                };
                lsStarReward.Add(db);

                var tmpReward = from tmp1 in ConnectDB.Entities.dbStarRewardRewards
                                where tmp1.status == 1
                                select tmp1;

                foreach (var item1 in tmpReward.Where(x => x.idStar == item.id))
                {
                    dbStarRewardReward re = new dbStarRewardReward()
                    {
                        id = item1.id,
                        idStar = item1.idStar,
                        procs = item1.procs,
                        staticID = rewardHandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward,
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin
                    };
                    lsReward.Add(re);
                }
            }
        }

        private void LoadDataToGC()
        {
            gcStar.DataSource = null;
            gcReward.DataSource = null;
            gcStar.DataSource = lsStarReward.Where(x => x.status == 1);
        }

        private void btnAddStar_Click(object sender, EventArgs e)
        {
            dbStarReward star = new dbStarReward()
            {
                id = -(lsStarReward.Count),
                starRequire = 0,
                status = 1
            };
            lsStarReward.Add(star);
            gcStar.DataSource = null;
            gcStar.DataSource = lsStarReward.Where(x => x.status == 1);
            gvStar.MoveLast();
        }

        private void btnDeleteStar_Click(object sender, EventArgs e)
        {
            if (gvStar.RowCount > 0)
            {
                int idGen = (int)gvStar.GetRowCellValue(gvStar.FocusedRowHandle, "id");
                lsStarReward.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcStar.DataSource = null;
                gcStar.DataSource = lsStarReward.Where(x => x.status == 1);
            }
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            if (gvStar.RowCount > 0)
            {
                int idGen = (int)gvStar.GetRowCellValue(gvStar.FocusedRowHandle, "id");
                dbStarRewardReward re = new dbStarRewardReward()
                {
                    amountMax = 0,
                    amountMin = 0,
                    id = -(lsReward.Count),
                    idStar = idGen,
                    procs = 100,
                    staticID = 1,
                    status = 1,
                    typeReward = 3
                };
                lsReward.Add(re);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idStar == idGen);
                gvReward.MoveLast();
            }
        }

        private void btnDeleteReward_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idGen = (int)gvStar.GetRowCellValue(gvStar.FocusedRowHandle, "id");
                int idReward = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");

                lsReward.Where(x => x.id == idReward).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idStar == idGen);
            }
        }

        private void gvStar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvStar.RowCount > 0)
            {
                int idGen = (int)gvStar.GetRowCellValue(gvStar.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idStar == idGen);
            }
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbStarRewardReward rewardSelect = (dbStarRewardReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvStar.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();

            foreach (var item in lsStarReward)
            {
                if (item.id <= 0)
                {
                    dbStarReward star = new dbStarReward()
                    {
                        starRequire = item.starRequire,
                        status = item.status
                    };
                    ConnectDB.Entities.dbStarRewards.Add(star);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsReward.Where(x => x.idStar == item.id))
                    {
                        dbStarRewardReward re = new dbStarRewardReward()
                        {
                            amountMin = item1.amountMin,
                            amountMax = item1.amountMax,
                            idStar = star.id,
                            procs = item1.procs,
                            staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                            status = item1.status,
                            typeReward = item1.typeReward
                        };
                        ConnectDB.Entities.dbStarRewardRewards.Add(re);
                        ConnectDB.Entities.SaveChanges();
                    }
                }
                else
                {
                    var result = ConnectDB.Entities.dbStarRewards.Where(x => x.id == item.id).FirstOrDefault();
                    result.starRequire = item.starRequire;
                    result.status = item.status;

                    foreach (var item1 in lsReward.Where(x => x.idStar == result.id))
                    {
                        if (item1.id <= 0)
                        {
                            dbStarRewardReward re = new dbStarRewardReward()
                            {
                                amountMin = item1.amountMin,
                                amountMax = item1.amountMax,
                                idStar = result.id,
                                procs = item1.procs,
                                staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbStarRewardRewards.Add(re);
                        }
                        else
                        {
                            var result1 = ConnectDB.Entities.dbStarRewardRewards.Where(x => x.id == item1.id).FirstOrDefault();
                            result1.amountMin = item1.amountMin;
                            result1.amountMax = item1.amountMax;
                            result1.idStar = result.id;
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
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}
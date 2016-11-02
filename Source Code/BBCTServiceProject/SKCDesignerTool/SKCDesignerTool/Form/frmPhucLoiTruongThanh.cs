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
    public partial class frmPhucLoiTruongThanh : frmFormChange
    {
        ListReward rewardhandler = new ListReward();
        List<dbPhucLoiTruongThanhLevel> lsLevel = new List<dbPhucLoiTruongThanhLevel>();
        List<dbPhucLoiTruongThanhLevelReward> lsReward = new List<dbPhucLoiTruongThanhLevelReward>();

        public frmPhucLoiTruongThanh()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
        }

        private void LoadDataToLUE()
        {
            var tmpTypeReward = from tmp in ConnectDB.Entities.dbCTTypeRewards
                                select tmp;

            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueStaticID.DataSource = rewardhandler.LoadTotalReward();
        }

        private void LoadDataToList()
        {
            lsLevel.Clear();
            lsReward.Clear();
            gcLevel.DataSource = null;
            gcReward.DataSource = null;

            var tmpCuuChiTon = from tmp in ConnectDB.Entities.dbPhucLoiTruongThanhConfigs
                               select tmp;

            gcThongTin.DataSource = null;
            gcThongTin.DataSource = tmpCuuChiTon.ToList();

            var tmpLevel = from tmp in ConnectDB.Entities.dbPhucLoiTruongThanhLevels
                           where tmp.status == 1
                           orderby tmp.levels ascending
                           select tmp;

            foreach (var item in tmpLevel)
            {
                dbPhucLoiTruongThanhLevel phuc = new dbPhucLoiTruongThanhLevel()
                {
                    id = item.id,
                    levels = item.levels,
                    status = item.status
                };
                lsLevel.Add(phuc);

                var tmpReward = from tmp in ConnectDB.Entities.dbPhucLoiTruongThanhLevelRewards
                                where tmp.status == 1 && tmp.idLevel == item.id
                                select tmp;

                foreach (var item1 in tmpReward)
                {
                    dbPhucLoiTruongThanhLevelReward reward = new dbPhucLoiTruongThanhLevelReward()
                    {
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin,
                        id = item1.id,
                        idLevel = item1.idLevel,
                        procs = item1.procs,
                        staticID = rewardhandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward
                    };
                    lsReward.Add(reward);
                }
            }

            gcLevel.DataSource = null;
            gcLevel.DataSource = lsLevel.Where(x => x.status == 1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int idLevel = (int)gvLevel.GetRowCellValue(gvLevel.FocusedRowHandle, "id");
            dbPhucLoiTruongThanhLevelReward cuu = new dbPhucLoiTruongThanhLevelReward()
            {
                amountMax = 0,
                amountMin = 0,
                id = -(lsReward.Count),
                idLevel = idLevel,
                procs = 100,
                staticID = 1,
                status = 1,
                typeReward = 2
            };
            lsReward.Add(cuu);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idLevel == idLevel);
            gvReward.MoveLast();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idLevel = (int)gvLevel.GetRowCellValue(gvLevel.FocusedRowHandle, "id");
                int idGen = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");

                lsReward.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idLevel == idLevel);
            }
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbPhucLoiTruongThanhLevelReward rewardSelect = (dbPhucLoiTruongThanhLevelReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvReward.FocusedRowHandle = -1;
            gridView1.FocusedRowHandle = -1;
            gvLevel.FocusedRowHandle = -1;

            CommonShowDialog.ShowWaitForm();

            foreach (var item in lsLevel.OrderBy(x => x.levels))
            {
                if (item.id <= 0)
                {
                    dbPhucLoiTruongThanhLevel level = new dbPhucLoiTruongThanhLevel()
                    {
                        levels = item.levels,
                        status = item.status
                    };
                    ConnectDB.Entities.dbPhucLoiTruongThanhLevels.Add(level);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsReward.Where(x => x.idLevel == item.id))
                    {
                        dbPhucLoiTruongThanhLevelReward cuu = new dbPhucLoiTruongThanhLevelReward()
                        {
                            amountMax = item1.amountMax,
                            amountMin = item1.amountMin,
                            idLevel = level.id,
                            procs = item1.procs,
                            staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                            status = item.status,
                            typeReward = item1.typeReward
                        };
                        ConnectDB.Entities.dbPhucLoiTruongThanhLevelRewards.Add(cuu);
                        ConnectDB.Entities.SaveChanges();
                    }
                }
                else
                {
                    var result = ConnectDB.Entities.dbPhucLoiTruongThanhLevels.Where(x => x.id == item.id).FirstOrDefault();
                    result.levels = item.levels;
                    result.status = item.status;

                    foreach (var item1 in lsReward.Where(x => x.idLevel == item.id))
                    {
                        if (item1.id <= 0)
                        {
                            dbPhucLoiTruongThanhLevelReward cuu = new dbPhucLoiTruongThanhLevelReward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idLevel = item.id,
                                procs = item1.procs,
                                staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbPhucLoiTruongThanhLevelRewards.Add(cuu);
                        }
                        else
                        {
                            var result1 = ConnectDB.Entities.dbPhucLoiTruongThanhLevelRewards.Where(x => x.id == item1.id).FirstOrDefault();
                            result1.amountMax = item1.amountMax;
                            result1.amountMin = item1.amountMin;
                            result1.idLevel = item.id;
                            result1.procs = item1.procs;
                            result1.staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID);
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

        private void gvLevel_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvLevel.RowCount > 0)
            {
                int idGen = (int)gvLevel.GetRowCellValue(gvLevel.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idLevel == idGen);
            }
        }

        private void btnAddLevel_Click(object sender, EventArgs e)
        {
            dbPhucLoiTruongThanhLevel level = new dbPhucLoiTruongThanhLevel()
            {
                id = -(lsLevel.Count),
                levels = lsLevel.Count + 1,
                status = 1
            };
            lsLevel.Add(level);
            gcLevel.DataSource = null;
            gcLevel.DataSource = lsLevel.Where(x => x.status == 1);
            gvLevel.MoveLast();
        }

        private void btnDeleteLevel_Click(object sender, EventArgs e)
        {
            if (gvLevel.RowCount > 0)
            {
                int idGen = (int)gvLevel.GetRowCellValue(gvLevel.FocusedRowHandle, "id");
                lsLevel.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcLevel.DataSource = null;
                gcLevel.DataSource = lsLevel.Where(x => x.status == 1);
            }
        }
    }
}
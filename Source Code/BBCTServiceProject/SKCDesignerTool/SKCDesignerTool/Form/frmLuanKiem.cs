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
using BBCTDesignerTool.Form;

namespace BBCTDesignerTool
{
    public partial class frmLuanKiem : frmFormChange
    {
        List<dbLuanKiemRange> lsRange = new List<dbLuanKiemRange>();
        List<dbLuanKiemRangeOpponent> lsOpp = new List<dbLuanKiemRangeOpponent>();
        List<dbLuanKiemRank> lsRank = new List<dbLuanKiemRank>();
        List<dbLuanKiemRankReward> lsReward = new List<dbLuanKiemRankReward>();
        ListReward rewardhandler = new ListReward();

        public frmLuanKiem()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList();
            LoadDataToLUE();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsOpp.Clear();
            lsRange.Clear();
            lsRank.Clear();
            lsReward.Clear();

            var tmpRange = from tmp in ConnectDB.Entities.dbLuanKiemRanges
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpRange)
            {
                dbLuanKiemRange range = new dbLuanKiemRange()
                {
                    id = item.id,
                    idLuanKiem = item.idLuanKiem,
                    rangeEnd = item.rangeEnd,
                    rangeStart = item.rangeStart,
                    status = item.status
                };
                lsRange.Add(range);

                var tmpOppnent = from tmp in ConnectDB.Entities.dbLuanKiemRangeOpponents
                                 where tmp.status == 1 && tmp.idRange == item.id
                                 select tmp;

                foreach (var item1 in tmpOppnent)
                {
                    dbLuanKiemRangeOpponent opp = new dbLuanKiemRangeOpponent()
                    {
                        id = item1.id,
                        idRange = item1.idRange,
                        rangeEnd = item1.rangeEnd,
                        rangeStart = item1.rangeStart,
                        status = item1.status
                    };
                    lsOpp.Add(opp);
                }
            }

            var tmpRank = from tmp in ConnectDB.Entities.dbLuanKiemRanks
                          where tmp.status == 1
                          select tmp;

            foreach (var item in tmpRank)
            {
                dbLuanKiemRank rank = new dbLuanKiemRank()
                {
                    idLuanKiem = item.idLuanKiem,
                    id = item.id,
                    rangeEnd = item.rangeEnd,
                    rangeStart = item.rangeStart,
                    status = item.status
                };
                lsRank.Add(rank);

                var tmpReward = from tmp in ConnectDB.Entities.dbLuanKiemRankRewards
                                where tmp.status == 1 && tmp.idRank == item.id
                                select tmp;

                foreach (var item1 in tmpReward)
                {
                    dbLuanKiemRankReward reward = new dbLuanKiemRankReward()
                    {
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin,
                        id = item1.id,
                        idRank = item1.idRank,
                        procs = item1.procs,
                        staticID = rewardhandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward
                    };
                    lsReward.Add(reward);
                }
            }
        }

        private void LoadDataToGC()
        {
            var tmpChung = from tmp in ConnectDB.Entities.dbLuanKiemConfigs
                           select tmp;

            gcChung.DataSource = tmpChung.ToList();

            var tmpPoint = from tmp in ConnectDB.Entities.dbLuanKiemPoints
                           where tmp.status == 1
                           select tmp;

            gcRankPoint.DataSource = null;
            gcRankPoint.DataSource = tmpPoint.ToList();
            gcRange.DataSource = null;
            gcRange.DataSource = lsRange;
            gcRank.DataSource = null;
            gcRank.DataSource = lsRank;
        }

        private void LoadDataToLUE()
        {
            var tmpType = from tmp in ConnectDB.Entities.dbCTTypeRewards
                          select tmp;
            lueTypeReward.DataSource = tmpType.ToList();

            lueStaticID.DataSource = rewardhandler.LoadTotalReward();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            int idRank = (int)gvRank.GetRowCellValue(gvRank.FocusedRowHandle, "id");
            dbLuanKiemRankReward reward = new dbLuanKiemRankReward()
            {
                amountMax = 0,
                amountMin = 0,
                id = -(lsReward.Count),
                idRank = idRank,
                procs = 100,
                staticID = 1,
                status = 1,
                typeReward = 1
            };
            lsReward.Add(reward);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idRank == idRank);
            gvReward.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idRank = (int)gvRank.GetRowCellValue(gvRank.FocusedRowHandle, "id");
                int idGen = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");
                lsReward.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idRank == idRank);
            }
        }

        private void gvRange_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvRange.RowCount > 0)
            {
                int idGen = (int)gvRange.GetRowCellValue(gvRange.FocusedRowHandle, "id");
                gcOpponent.DataSource = null;
                gcOpponent.DataSource = lsOpp.Where(x => x.status == 1 && x.idRange == idGen);
            }
        }

        private void gvRank_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvRank.RowCount > 0)
            {
                int idGen = (int)gvRank.GetRowCellValue(gvRank.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idRank == idGen);
            }
        }

        protected override void OnSave()
        {
            gvChung.FocusedRowHandle = -1;
            gvRankPoint.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsRank)
            {
                var tmpRank = ConnectDB.Entities.dbLuanKiemRanks.Where(x => x.id == item.id).FirstOrDefault();
                foreach (var item1 in lsReward)
                {
                    if (item1.idRank == item.id)
                    {
                        if (item1.id <= 0)
                        {
                            dbLuanKiemRankReward reward = new dbLuanKiemRankReward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idRank = tmpRank.id,
                                procs = item1.procs,
                                staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbLuanKiemRankRewards.Add(reward);
                        }
                        else
                        {
                            int idGen = item1.id;
                            var result = ConnectDB.Entities.dbLuanKiemRankRewards.Where(x => x.id == idGen).FirstOrDefault();
                            result.amountMax = item1.amountMax;
                            result.amountMin = item1.amountMin;
                            result.idRank = tmpRank.id;
                            result.procs = item1.procs;
                            result.staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID);
                            result.status = item1.status;
                            result.typeReward = item1.typeReward;
                        }
                        ConnectDB.Entities.SaveChanges();
                    }
                }
            }

            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công");
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbLuanKiemRankReward rewardSelect = (dbLuanKiemRankReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }
    }
}
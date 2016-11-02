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
    public partial class frmLuanKiemWinReward : frmFormChange
    {
        ListReward rewardHandler = new ListReward();
        List<dbLuanKiemWinReward> lsWinReward = new List<dbLuanKiemWinReward>();
        List<dbLuanKiemLoseReward> lsLoseReward = new List<dbLuanKiemLoseReward>();

        public frmLuanKiemWinReward()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLue();
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToLue()
        {
            var tmpType = from tmp in ConnectDB.Entities.dbCTTypeRewards
                          select tmp;

            lueTypeReward.DataSource = tmpType.ToList();
            lueTypeRewardLose.DataSource = tmpType.ToList();

            lueStaticID.DataSource = rewardHandler.LoadTotalReward();
            lueStaticIDLose.DataSource = rewardHandler.LoadTotalReward();
        }

        private void LoadDataToList()
        {
            lsWinReward.Clear();
            lsLoseReward.Clear();

            var tmpReward = from tmp in ConnectDB.Entities.dbLuanKiemWinRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbLuanKiemWinReward conf = new dbLuanKiemWinReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    procs = item.procs,
                    staticID = rewardHandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsWinReward.Add(conf);
            }

            var tmpRewardLose = from tmp in ConnectDB.Entities.dbLuanKiemLoseRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpRewardLose)
            {
                dbLuanKiemLoseReward conf = new dbLuanKiemLoseReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    procs = item.procs,
                    staticID = rewardHandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsLoseReward.Add(conf);
            }
        }

        private void LoadDataToGC() 
        {
            gcThang.DataSource = null;
            gcThang.DataSource = lsWinReward;

            gcThua.DataSource = null;
            gcThua.DataSource = lsLoseReward;
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbLuanKiemWinReward db = new dbLuanKiemWinReward()
            {
                amountMax = 0,
                amountMin = 0,
                id = -(lsWinReward.Count),
                procs = 100,
                staticID = 1,
                status = 1,
                typeReward = 2
            };
            lsWinReward.Add(db);
            gcThang.DataSource = null;
            gcThang.DataSource = lsWinReward.Where(x => x.status == 1);
            gvThang.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvThang.RowCount > 0)
            {
                int idRe = (int)gvThang.GetRowCellValue(gvThang.FocusedRowHandle, "id");
                lsWinReward.Where(x => x.id == idRe).ToList().ForEach(x => x.status = 2);
                gcThang.DataSource = null;
                gcThang.DataSource = lsWinReward.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            dbLuanKiemLoseReward db = new dbLuanKiemLoseReward()
            {
                amountMax = 0,
                amountMin = 0,
                id = -(lsLoseReward.Count),
                procs = 100,
                staticID = 1,
                status = 1,
                typeReward = 2
            };
            lsLoseReward.Add(db);
            gcThua.DataSource = null;
            gcThua.DataSource = lsLoseReward.Where(x => x.status == 1);
            gvThua.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvThua.RowCount > 0)
            {
                int idRe = (int)gvThua.GetRowCellValue(gvThua.FocusedRowHandle, "id");
                lsLoseReward.Where(x => x.id == idRe).ToList().ForEach(x => x.status = 2);
                gcThua.DataSource = null;
                gcThua.DataSource = lsLoseReward.Where(x => x.status == 1);
            }
        }

        private void gvThang_DoubleClick(object sender, EventArgs e)
        {
            dbLuanKiemWinReward rewardSelect = (dbLuanKiemWinReward)gvThang.GetRow(gvThang.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,rewardSelect, null);
            formTask.ShowDialog();
        }

        private void gvThua_DoubleClick(object sender, EventArgs e)
        {
            dbLuanKiemLoseReward rewardSelect = (dbLuanKiemLoseReward)gvThua.GetRow(gvThua.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvThang.FocusedRowHandle = -1;
            gvThua.FocusedRowHandle = -1;

            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsWinReward)
            {
                if (item.id <= 0)
                {
                    dbLuanKiemWinReward re = new dbLuanKiemWinReward()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        procs = item.procs,
                        staticID = rewardHandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        status = item.status,
                        typeReward = item.typeReward
                    };
                    ConnectDB.Entities.dbLuanKiemWinRewards.Add(re);
                }
                else
                {
                    var result = ConnectDB.Entities.dbLuanKiemWinRewards.Where(x => x.id == item.id).FirstOrDefault();
                    result.amountMax = item.amountMax;
                    result.amountMin = item.amountMin;
                    result.procs = item.procs;
                    result.staticID = rewardHandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID);
                    result.status = item.status;
                    result.typeReward = item.typeReward;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsLoseReward)
            {
                if (item.id <= 0)
                {
                    dbLuanKiemLoseReward re = new dbLuanKiemLoseReward()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        procs = item.procs,
                        staticID = rewardHandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        status = item.status,
                        typeReward = item.typeReward
                    };
                    ConnectDB.Entities.dbLuanKiemLoseRewards.Add(re);
                }
                else
                {
                    var result = ConnectDB.Entities.dbLuanKiemLoseRewards.Where(x => x.id == item.id).FirstOrDefault();
                    result.amountMax = item.amountMax;
                    result.amountMin = item.amountMin;
                    result.procs = item.procs;
                    result.staticID = rewardHandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID);
                    result.status = item.status;
                    result.typeReward = item.typeReward;
                }
                ConnectDB.Entities.SaveChanges();
            }

            LoadDataToList();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}
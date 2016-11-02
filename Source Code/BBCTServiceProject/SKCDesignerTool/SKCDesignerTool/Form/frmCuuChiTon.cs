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
    public partial class frmCuuChiTon : frmFormChange
    {
        ListReward rewardhandler = new ListReward();
        List<dbCuuCuuTriTonConfigReward> lsReward = new List<dbCuuCuuTriTonConfigReward>();

        public frmCuuChiTon()
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
            lsReward.Clear();

            var tmpCuuChiTon = from tmp in ConnectDB.Entities.dbCuuCuuTriTonConfigs
                               select tmp;

            gcThongTin.DataSource = null;
            gcThongTin.DataSource = tmpCuuChiTon.ToList();

            var tmpReward = from tmp in ConnectDB.Entities.dbCuuCuuTriTonConfigRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbCuuCuuTriTonConfigReward reward = new dbCuuCuuTriTonConfigReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idCuuCuu = item.idCuuCuu,
                    procs = item.procs,
                    staticID = rewardhandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsReward.Add(reward);
            }

            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dbCuuCuuTriTonConfigReward cuu = new dbCuuCuuTriTonConfigReward()
            {
                amountMax = 0,
                amountMin = 0,
                id = -(lsReward.Count),
                idCuuCuu = 1,
                procs = 100,
                staticID = 1,
                status = 1,
                typeReward = 3
            };
            lsReward.Add(cuu);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
            gvReward.MoveLast();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idGen = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");
                lsReward.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1);
            }
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbCuuCuuTriTonConfigReward rewardSelect = (dbCuuCuuTriTonConfigReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvReward.FocusedRowHandle = -1;
            gridView1.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsReward)
            {
                if (item.id <= 0)
                {
                    dbCuuCuuTriTonConfigReward cuu = new dbCuuCuuTriTonConfigReward()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        idCuuCuu = 1,
                        procs = item.procs,
                        staticID = rewardhandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        status = item.status,
                        typeReward = item.typeReward
                    };
                    ConnectDB.Entities.dbCuuCuuTriTonConfigRewards.Add(cuu);
                }
                else
                {
                    var result = ConnectDB.Entities.dbCuuCuuTriTonConfigRewards.Where(x => x.id == item.id).FirstOrDefault();
                    result.amountMax = item.amountMax;
                    result.amountMin = item.amountMin;
                    result.idCuuCuu = 1;
                    result.procs = item.procs;
                    result.staticID = rewardhandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID);
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
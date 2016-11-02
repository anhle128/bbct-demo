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
    public partial class frmPhucLoiThang : frmFormChange
    {
        ListReward rewardHandler = new ListReward();
        List<dbPucLoiThangReward> lsReward = new List<dbPucLoiThangReward>();
        public frmPhucLoiThang()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
        }

        private void LoadDataToLUE()
        {
            var tmpType = from tmp in ConnectDB.Entities.dbCTTypeRewards
                          select tmp;

            lueTypeReward.DataSource = tmpType.ToList();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();
        }

        private void LoadDataToList()
        {
            lsReward.Clear();
            var tmpPhuc = from tmp in ConnectDB.Entities.dbPucLoiThangConfigs
                          select tmp;

            gcConfig.DataSource = null;
            gcConfig.DataSource = tmpPhuc.ToList();

            var tmpReward = from tmp in ConnectDB.Entities.dbPucLoiThangRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbPucLoiThangReward puc = new dbPucLoiThangReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idPhucLoi = item.idPhucLoi,
                    procs = item.procs,
                    staticID = rewardHandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsReward.Add(puc);
            }
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dbPucLoiThangReward puc = new dbPucLoiThangReward()
            {
                amountMax = 1,
                amountMin = 0,
                id = -(lsReward.Count()),
                idPhucLoi = 1,
                procs = 0,
                staticID = 1,
                status = 1,
                typeReward = 2
            };
            lsReward.Add(puc);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idReward = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");
                lsReward.Where(x => x.id == idReward).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1);
            }
        }

        protected override void OnSave()
        {
            gridView1.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsReward)
            {
                if (item.id <= 0)
                {
                    dbPucLoiThangReward puc = new dbPucLoiThangReward()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        idPhucLoi = item.idPhucLoi,
                        procs = item.procs,
                        staticID = rewardHandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        status = item.status,
                        typeReward = item.typeReward
                    };
                    ConnectDB.Entities.dbPucLoiThangRewards.Add(puc);
                }
                else
                {
                    var result = ConnectDB.Entities.dbPucLoiThangRewards.Where(x => x.id == item.id).FirstOrDefault();
                    result.amountMax = item.amountMax;
                    result.amountMin = item.amountMin;
                    result.idPhucLoi = item.idPhucLoi;
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

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbPucLoiThangReward rewardSelect = (dbPucLoiThangReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }
    }
}
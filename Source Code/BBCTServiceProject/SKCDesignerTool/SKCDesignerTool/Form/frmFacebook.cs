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
    public partial class frmFacebook : frmFormChange
    {
        ListReward rewardHandler = new ListReward();
        List<dbShareFacebook> lsReward = new List<dbShareFacebook>();

        public frmFacebook()
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
            var tmpReward = from tmp in ConnectDB.Entities.dbShareFacebooks
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbShareFacebook re = new dbShareFacebook()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    procs = item.procs,
                    staticID = rewardHandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsReward.Add(re);
            }

            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dbShareFacebook db = new dbShareFacebook()
            {
                amountMax = 0,
                amountMin = 0,
                id = -(lsReward.Count),
                procs = 100,
                staticID = 1,
                status = 1,
                typeReward = 2
            };
            lsReward.Add(db);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
            gvReward.MoveLast();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idRe = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");
                lsReward.Where(x => x.id == idRe).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1);
            }
        }

        protected override void OnSave()
        {
            gvReward.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsReward)
            {
                if (item.id <= 0)
                {
                    dbShareFacebook re = new dbShareFacebook()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        procs = item.procs,
                        staticID = rewardHandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        status = item.status,
                        typeReward = item.typeReward
                    };
                    ConnectDB.Entities.dbShareFacebooks.Add(re);
                }
                else
                {
                    var result = ConnectDB.Entities.dbShareFacebooks.Where(x => x.id == item.id).FirstOrDefault();
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

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbShareFacebook rewardSelect = (dbShareFacebook)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }
    }
}
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
    public partial class frmPlayerDefaultConfig : frmFormChange
    {
        ListReward rewardHandler = new ListReward();
        List<dbTaoNickReward> lsReward = new List<dbTaoNickReward>();

        public frmPlayerDefaultConfig()
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
        }

        private void LoadDataToList()
        {
            lsReward.Clear();

            var tmpPlay = from tmp in ConnectDB.Entities.dbPlayerDefaultConfigs
                          select tmp;

            gcPlayer.DataSource = null;
            gcPlayer.DataSource = tmpPlay.ToList();

            var tmpReward = from tmp in ConnectDB.Entities.dbTaoNickRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbTaoNickReward reward = new dbTaoNickReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    procs = item.procs,
                    staticID = rewardHandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsReward.Add(reward);
            }

            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
        }

        protected override void OnSave()
        {
            gvPlayer.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsReward)
            {
                if (item.id <= 0)
                {
                    dbTaoNickReward reward = new dbTaoNickReward()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        procs = item.procs,
                        staticID = rewardHandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        status = item.status,
                        typeReward = item.typeReward
                    };
                    ConnectDB.Entities.dbTaoNickRewards.Add(reward);
                }
                else
                {
                    var result = ConnectDB.Entities.dbTaoNickRewards.Where(x => x.id == item.id).FirstOrDefault();
                    result.amountMax = item.amountMax;
                    result.amountMin = item.amountMin;
                    result.procs = item.procs;
                    result.staticID = rewardHandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID);
                    result.status = item.status;
                    result.typeReward = item.typeReward;
                }
                ConnectDB.Entities.SaveChanges();
            }

            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dbTaoNickReward reward = new dbTaoNickReward()
            {
                amountMax = 1,
                amountMin = 1,
                id = -(lsReward.Count),
                procs = 100,
                staticID = 1,
                status = 1,
                typeReward = 2
            };
            lsReward.Add(reward);
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
            dbTaoNickReward rewardSelect = (dbTaoNickReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null);
            formTask.ShowDialog();
        }
    }
}
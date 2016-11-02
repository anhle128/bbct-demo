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
    public partial class frmLevelReward : frmFormChange
    {
        ListReward rewardHandler = new ListReward();
        List<dbLevelRewardConfig> lsLevel = new List<dbLevelRewardConfig>();
        List<dbLevelReward_Reward> lsReward = new List<dbLevelReward_Reward>();

        public frmLevelReward()
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
            lsLevel.Clear();
            lsReward.Clear();

            var tmpLevel = from tmp in ConnectDB.Entities.dbLevelRewardConfigs
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpLevel)
            {
                dbLevelRewardConfig level = new dbLevelRewardConfig()
                {
                    id = item.id,
                    levels = item.levels,
                    status = item.status
                };
                lsLevel.Add(level);
            }

            var tmpReward = from tmp in ConnectDB.Entities.dbLevelReward_Reward
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbLevelReward_Reward re = new dbLevelReward_Reward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idLevel = item.idLevel,
                    procs = item.procs,
                    staticID = rewardHandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsReward.Add(re);
            }

            gcLevel.DataSource = null;
            gcReward.DataSource = null;
            gcLevel.DataSource = lsLevel.Where(x => x.status == 1);
        }

        private void gvLevel_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvLevel.RowCount > 0)
            {
                int idLevel = (int)gvLevel.GetRowCellValue(gvLevel.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idLevel == idLevel);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbLevelRewardConfig level = new dbLevelRewardConfig()
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

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvLevel.RowCount > 0)
            {
                int idLevel = (int)gvLevel.GetRowCellValue(gvLevel.FocusedRowHandle, "id");
                lsLevel.Where(x => x.id == idLevel).ToList().ForEach(x => x.status = 2);
                gcLevel.DataSource = null;
                gcLevel.DataSource = lsLevel.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvLevel.RowCount > 0)
            {
                int idLevel = (int)gvLevel.GetRowCellValue(gvLevel.FocusedRowHandle, "id");

                dbLevelReward_Reward re = new dbLevelReward_Reward()
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
                lsReward.Add(re);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idLevel == idLevel);
                gvReward.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idLevel = (int)gvLevel.GetRowCellValue(gvLevel.FocusedRowHandle, "id");
                int idReward = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");

                lsReward.Where(x => x.id == idReward).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idLevel == idLevel);
            }
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbLevelReward_Reward rewardSelect = (dbLevelReward_Reward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvLevel.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;

            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsLevel)
            {
                if (item.id <= 0)
                {
                    dbLevelRewardConfig level = new dbLevelRewardConfig()
                    {
                        levels = item.levels,
                        status = item.status
                    };
                    ConnectDB.Entities.dbLevelRewardConfigs.Add(level);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsReward.Where(x => x.idLevel == item.id))
                    {
                        dbLevelReward_Reward re = new dbLevelReward_Reward()
                        {
                            amountMax = item1.amountMax,
                            amountMin = item1.amountMin,
                            idLevel = level.id,
                            procs = item1.procs,
                            staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                            status = item1.status,
                            typeReward = item1.typeReward
                        };
                        ConnectDB.Entities.dbLevelReward_Reward.Add(re);
                        ConnectDB.Entities.SaveChanges();
                    }
                }
                else
                {
                    var result = ConnectDB.Entities.dbLevelRewardConfigs.Where(x => x.id == item.id).FirstOrDefault();
                    result.levels = item.levels;
                    result.status = item.status;

                    foreach (var item1 in lsReward.Where(x => x.idLevel == item.id))
                    {
                        if (item1.id <= 0)
                        {
                            dbLevelReward_Reward re = new dbLevelReward_Reward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idLevel = item.id,
                                procs = item1.procs,
                                staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbLevelReward_Reward.Add(re);
                        }
                        else
                        {
                            var result1 = ConnectDB.Entities.dbLevelReward_Reward.Where(x => x.id == item1.id).FirstOrDefault();
                            result1.amountMax = item1.amountMax;
                            result1.amountMin = item1.amountMin;
                            result1.idLevel = item.id;
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
    }
}
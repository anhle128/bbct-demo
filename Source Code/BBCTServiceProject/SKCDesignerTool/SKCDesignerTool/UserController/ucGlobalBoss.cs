using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KDQHDesignerTool.FormBase;
using KDQHDesignerTool.Models;
using KDQHDesignerTool.Common;
using KDQHDesignerTool.Form;

namespace KDQHDesignerTool.UserController
{
    public partial class ucGlobalBoss : ucManager
    {
        List<dbGlobalAttackConfig> lsAttack = new List<dbGlobalAttackConfig>();
        List<dbGlobalBonusRewardConfig> lsReward = new List<dbGlobalBonusRewardConfig>();
        ListReward rewardhandler = new ListReward();

        public ucGlobalBoss()
        {
            InitializeComponent();
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
            LoadDataToGC();
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
            lsAttack.Clear();
            lsReward.Clear();

            var tmpAttack = from tmp in ConnectDB.Entities.dbGlobalAttackConfigs
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpAttack)
            {
                dbGlobalAttackConfig att = new dbGlobalAttackConfig()
                {
                    id = item.id,
                    idGlobal = item.idGlobal,
                    status = item.status,
                    vipRequire = item.vipRequire,
                    waitTime = item.waitTime
                };
                lsAttack.Add(att);
            }

            var tmpReward = from tmp in ConnectDB.Entities.dbGlobalBonusRewardConfigs
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbGlobalBonusRewardConfig global = new dbGlobalBonusRewardConfig()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idGlobal = item.idGlobal,
                    procs = item.procs,
                    staticID = rewardhandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsReward.Add(global);
            }
        }

        private void LoadDataToGC()
        {
            var tmpChung = from tmp in ConnectDB.Entities.dbGlobalBossConfigs
                           select tmp;

            gcChung.DataSource = null;
            gcChung.DataSource = tmpChung.ToList();
            gcAttack.DataSource = null;
            gcAttack.DataSource = lsAttack;
            gcRewardBoss.DataSource = null;
            gcRewardBoss.DataSource = lsReward;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dbGlobalAttackConfig boss = new dbGlobalAttackConfig()
            {
                id = -(lsAttack.Count),
                idGlobal = 1,
                status = 1,
                vipRequire = 0,
                waitTime = 0
            };
            lsAttack.Add(boss);
            gcAttack.DataSource = null;
            gcAttack.DataSource = lsAttack.Where(x => x.status == 1);
            gvAttack.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvAttack.RowCount > 0)
            {
                int idGen = (int)gvAttack.GetRowCellValue(gvAttack.FocusedRowHandle, "id");
                lsAttack.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcAttack.DataSource = null;
                gcAttack.DataSource = lsAttack.Where(x => x.status == 1);
            }
        }

        protected override void OnSave()
        {
            gvAttack.FocusedRowHandle = -1;
            gvChung.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsAttack)
            {
                if (item.id <= 0)
                {
                    dbGlobalAttackConfig att = new dbGlobalAttackConfig()
                    {
                        idGlobal = item.idGlobal,
                        status = item.status,
                        vipRequire = item.vipRequire,
                        waitTime = item.waitTime
                    };
                    ConnectDB.Entities.dbGlobalAttackConfigs.Add(att);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbGlobalAttackConfigs.Where(x => x.id == idGen).FirstOrDefault();
                    result.idGlobal = item.idGlobal;
                    result.status = item.status;
                    result.vipRequire = item.vipRequire;
                    result.waitTime = item.waitTime;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsReward)
            {
                if (item.id <= 0)
                {
                    dbGlobalBonusRewardConfig bonus = new dbGlobalBonusRewardConfig()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        idGlobal = item.idGlobal,
                        procs = item.procs,
                        staticID = rewardhandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        typeReward = item.typeReward,
                        status = item.status
                    };
                    ConnectDB.Entities.dbGlobalBonusRewardConfigs.Add(bonus);
                }
                else
                {
                    var result = ConnectDB.Entities.dbGlobalBonusRewardConfigs.Where(x => x.id == item.id).FirstOrDefault();
                    result.amountMax = item.amountMax;
                    result.amountMin = item.amountMin;
                    result.idGlobal = item.idGlobal;
                    result.procs = item.procs;
                    result.staticID = rewardhandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID);
                    result.typeReward = item.typeReward;
                    result.status = item.status;
                }
                ConnectDB.Entities.SaveChanges();
            }

            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công");
        }

        private void gvRewardBoss_DoubleClick(object sender, EventArgs e)
        {
            dbGlobalBonusRewardConfig rewardSelect = (dbGlobalBonusRewardConfig)gvRewardBoss.GetRow(gvRewardBoss.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null);
            formTask.ShowDialog();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbGlobalBonusRewardConfig global = new dbGlobalBonusRewardConfig()
            {
                amountMax = 0,
                amountMin = 0,
                id = -(lsReward.Count),
                idGlobal = 1,
                procs = 0,
                staticID = 1,
                status = 1,
                typeReward = 2
            };
            lsReward.Add(global);
            gcRewardBoss.DataSource = null;
            gcRewardBoss.DataSource = lsReward.Where(x => x.status == 1);
            gvRewardBoss.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvRewardBoss.RowCount > 0)
            {
                int idGen = (int)gvRewardBoss.GetRowCellValue(gvRewardBoss.FocusedRowHandle, "id");
                lsReward.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcRewardBoss.DataSource = null;
                gcRewardBoss.DataSource = lsReward.Where(x => x.status == 1);
            }
        }
    }
}

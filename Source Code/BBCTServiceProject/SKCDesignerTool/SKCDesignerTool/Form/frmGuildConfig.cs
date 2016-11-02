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
    public partial class frmGuildConfig : frmFormChange
    {
        List<dbGuildLevelContribution> lsLevelCOntribute = new List<dbGuildLevelContribution>();
        List<dbGuildMission> lsMission = new List<dbGuildMission>();
        List<dbGuildRewardsLuaTrai> lsLuaTraiReward = new List<dbGuildRewardsLuaTrai>();
        List<dbGuildBoss> lsBoss = new List<dbGuildBoss>();
        List<dbGuildBossReward> lsBossReward = new List<dbGuildBossReward>();
        ListReward rewardhandler = new ListReward();

        public frmGuildConfig()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsBoss.Clear();
            lsBossReward.Clear();
            lsLevelCOntribute.Clear();
            lsLuaTraiReward.Clear();
            lsMission.Clear();

            var tmpLevelContribute = from tmp in ConnectDB.Entities.dbGuildLevelContributions
                                     where tmp.status == 1
                                     select tmp;

            int count = 1;
            foreach (var item in tmpLevelContribute)
            {
                dbGuildLevelContribution level = new dbGuildLevelContribution()
                {
                    id = item.id,
                    idGuild = count++,
                    status = item.status,
                    value = item.value
                };
                lsLevelCOntribute.Add(level);
            }

            var tmpMission = from tmp in ConnectDB.Entities.dbGuildMissions
                             where tmp.status == 1
                             select tmp;

            foreach (var item in tmpMission)
            {
                dbGuildMission miss = new dbGuildMission()
                {
                    contribute = item.contribute,
                    contributeMember = item.contributeMember,
                    durationMinutes = item.durationMinutes,
                    id = item.id,
                    idGuild = item.idGuild,
                    name = item.name,
                    status = item.status
                };
                lsMission.Add(miss);
            }

            var tmpLuaTrai = from tmp in ConnectDB.Entities.dbGuildRewardsLuaTrais
                             where tmp.status == 1
                             select tmp;

            foreach (var item in tmpLuaTrai)
            {
                dbGuildRewardsLuaTrai luatrai = new dbGuildRewardsLuaTrai()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idGuild = item.idGuild,
                    procs = item.procs,
                    staticID = rewardhandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsLuaTraiReward.Add(luatrai);
            }

            var tmpBoss = from tmp in ConnectDB.Entities.dbGuildBosses
                          where tmp.status == 1
                          select tmp;

            foreach (var item in tmpBoss)
            {
                dbGuildBoss boss = new dbGuildBoss()
                {
                    id = item.id,
                    idGuild = item.idGuild,
                    maxRange = item.maxRange,
                    minRange = item.minRange,
                    status = item.status
                };
                lsBoss.Add(boss);

                var tmpRewardBoss = from tmp in ConnectDB.Entities.dbGuildBossRewards
                                    where tmp.status == 1 && tmp.idBoss == item.id
                                    select tmp;

                foreach (var item1 in tmpRewardBoss)
                {
                    dbGuildBossReward reward = new dbGuildBossReward()
                    {
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin,
                        id = item1.id,
                        idBoss = item1.idBoss,
                        procs = item1.procs,
                        staticID = rewardhandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward
                    };
                    lsBossReward.Add(reward);
                }
            }
        }

        private void LoadDataToGC()
        {
            var tmpChung = from tmp in ConnectDB.Entities.dbGuildConfigs
                           select tmp;

            gcChung1.DataSource = null;
            gcChung1.DataSource = tmpChung.ToList();
            gcChung2.DataSource = null;
            gcChung2.DataSource = tmpChung.ToList();
            gcChung3.DataSource = null;
            gcChung3.DataSource = tmpChung.ToList();

            gcLevelContribute.DataSource = null;
            gcLevelContribute.DataSource = lsLevelCOntribute;
            gcMissionGuild.DataSource = null;
            gcMissionGuild.DataSource = lsMission;
            gcRewardLuaTrai.DataSource = null;
            gcRewardLuaTrai.DataSource = lsLuaTraiReward;
            gcBossConfig.DataSource = null;
            gcBossConfig.DataSource = lsBoss;
        }

        private void LoadDataToLUE()
        {
            var tmpType = from tmp in ConnectDB.Entities.dbCTTypeRewards
                          select tmp;
            lueTypeRewardBoss.DataSource = tmpType.ToList();
            lueTypeRewardLuaTrai.DataSource = tmpType.ToList();
            lueStaticIDLuaTrai.DataSource = rewardhandler.LoadTotalReward();
            lueStaticIDBoss.DataSource = rewardhandler.LoadTotalReward();

            var tmpCharacter = from tmp in ConnectDB.Entities.dbCharacters
                               where tmp.status == 1
                               orderby tmp.idCharacter ascending
                               select new
                               {
                                   tmp.idCharacter,
                                   tmp.name
                               };
            lueBossID.DataSource = tmpCharacter.ToList();
        }

        private void gvBossConfig_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvBossConfig.RowCount > 0)
            {
                int idGen = (int)gvBossConfig.GetRowCellValue(gvBossConfig.FocusedRowHandle, "id");
                gcRewardBoss.DataSource = lsBossReward.Where(x => x.status == 1 && x.idBoss == idGen);
            }
        }

        private void gvRewardLuaTrai_DoubleClick(object sender, EventArgs e)
        {
            dbGuildRewardsLuaTrai rewardSelect = (dbGuildRewardsLuaTrai)gvRewardLuaTrai.GetRow(gvRewardLuaTrai.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        private void gvRewardBoss_DoubleClick(object sender, EventArgs e)
        {
            dbGuildBossReward rewardSelect = (dbGuildBossReward)gvRewardBoss.GetRow(gvRewardBoss.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbGuildLevelContribution level = new dbGuildLevelContribution()
            {
                id = -(lsLevelCOntribute.Count),
                idGuild = lsLevelCOntribute.Count + 1,
                status = 1,
                value = 0
            };
            lsLevelCOntribute.Add(level);
            gcLevelContribute.DataSource = null;
            gcLevelContribute.DataSource = lsLevelCOntribute.Where(x => x.status == 1);
            gvLevelContribute.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvLevelContribute.RowCount > 0)
            {
                int idGen = (int)gvLevelContribute.GetRowCellValue(gvLevelContribute.FocusedRowHandle, "id");
                lsLevelCOntribute.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcLevelContribute.DataSource = null;
                gcLevelContribute.DataSource = lsLevelCOntribute.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            dbGuildMission level = new dbGuildMission()
            {
                id = -(lsMission.Count),
                idGuild = 1,
                status = 1,
                contribute = 0,
                contributeMember = 0,
                durationMinutes = 0,
                name = "name"
            };
            lsMission.Add(level);
            gcMissionGuild.DataSource = null;
            gcMissionGuild.DataSource = lsMission.Where(x => x.status == 1);
            gvMissionGuild.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvMissionGuild.RowCount > 0)
            {
                int idGen = (int)gvMissionGuild.GetRowCellValue(gvMissionGuild.FocusedRowHandle, "id");
                lsMission.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcMissionGuild.DataSource = null;
                gcMissionGuild.DataSource = lsMission.Where(x => x.status == 1);
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            dbGuildRewardsLuaTrai level = new dbGuildRewardsLuaTrai()
            {
                id = -(lsLuaTraiReward.Count),
                idGuild = 1,
                status = 1,
                amountMax = 1,
                amountMin = 0,
                procs = 0,
                staticID = 1,
                typeReward = 3
            };
            lsLuaTraiReward.Add(level);
            gcRewardLuaTrai.DataSource = null;
            gcRewardLuaTrai.DataSource = lsLuaTraiReward.Where(x => x.status == 1);
            gvRewardLuaTrai.MoveLast();
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (gvRewardLuaTrai.RowCount > 0)
            {
                int idGen = (int)gvRewardLuaTrai.GetRowCellValue(gvRewardLuaTrai.FocusedRowHandle, "id");
                lsLuaTraiReward.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcRewardLuaTrai.DataSource = null;
                gcRewardLuaTrai.DataSource = lsLuaTraiReward.Where(x => x.status == 1);
            }
        }

        private void btnAdd4_Click(object sender, EventArgs e)
        {
            dbGuildBoss level = new dbGuildBoss()
            {
                id = -(lsBoss.Count),
                idGuild = 1,
                status = 1,
                maxRange = 1,
                minRange = 0
            };
            lsBoss.Add(level);
            gcBossConfig.DataSource = null;
            gcBossConfig.DataSource = lsBoss.Where(x => x.status == 1);
            gvBossConfig.MoveLast();
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (gvBossConfig.RowCount > 0)
            {
                int idGen = (int)gvBossConfig.GetRowCellValue(gvBossConfig.FocusedRowHandle, "id");
                lsBoss.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcBossConfig.DataSource = null;
                gcBossConfig.DataSource = lsBoss.Where(x => x.status == 1);
            }
        }

        private void btnAdd5_Click(object sender, EventArgs e)
        {
            if (gvBossConfig.RowCount > 0)
            {
                int idGen = (int)gvBossConfig.GetRowCellValue(gvBossConfig.FocusedRowHandle, "id");
                dbGuildBossReward level = new dbGuildBossReward()
                {
                    id = -(lsBossReward.Count),
                    idBoss = idGen,
                    status = 1,
                    amountMax = 0,
                    amountMin = 0,
                    procs = 100,
                    staticID = 1,
                    typeReward = 3
                };
                lsBossReward.Add(level);
                gcRewardBoss.DataSource = null;
                gcRewardBoss.DataSource = lsBossReward.Where(x => x.status == 1 && x.idBoss == idGen);
                gvRewardBoss.MoveLast();
            }
        }

        private void btnDelete5_Click(object sender, EventArgs e)
        {
            if (gvRewardBoss.RowCount > 0)
            {
                int idReward = (int)gvRewardBoss.GetRowCellValue(gvRewardBoss.FocusedRowHandle, "id");
                int idGen = (int)gvBossConfig.GetRowCellValue(gvBossConfig.FocusedRowHandle, "id");
                lsBossReward.Where(x => x.id == idReward).ToList().ForEach(x => x.status = 2);
                gcRewardBoss.DataSource = null;
                gcRewardBoss.DataSource = lsBossReward.Where(x => x.status == 1 && x.idBoss == idGen);
            }
        }

        protected override void OnSave()
        {
            gvChung1.FocusedRowHandle = -1;
            gvChung2.FocusedRowHandle = -1;
            gvChung3.FocusedRowHandle = -1;
            gvLevelContribute.FocusedRowHandle = -1;
            gvMissionGuild.FocusedRowHandle = -1;
            gvRewardBoss.FocusedRowHandle = -1;
            gvRewardLuaTrai.FocusedRowHandle = -1;
            gvBossConfig.FocusedRowHandle = -1;

            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsLevelCOntribute)
            {
                if (item.id <= 0)
                {
                    dbGuildLevelContribution level = new dbGuildLevelContribution()
                    {
                        idGuild = 1,
                        status = item.status,
                        value = item.value
                    };
                    ConnectDB.Entities.dbGuildLevelContributions.Add(level);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbGuildLevelContributions.Where(x => x.id == idGen).FirstOrDefault();
                    result.idGuild = 1;
                    result.status = item.status;
                    result.value = item.value;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsMission)
            {
                if (item.id <= 0)
                {
                    dbGuildMission miss = new dbGuildMission()
                    {
                        contribute = item.contribute,
                        contributeMember = item.contributeMember,
                        durationMinutes = item.durationMinutes,
                        idGuild = item.idGuild,
                        name = item.name,
                        status = item.status
                    };
                    ConnectDB.Entities.dbGuildMissions.Add(miss);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbGuildMissions.Where(x => x.id == idGen).FirstOrDefault();
                    result.contribute = item.contribute;
                    result.contributeMember = item.contributeMember;
                    result.durationMinutes = item.durationMinutes;
                    result.idGuild = item.idGuild;
                    result.name = item.name;
                    result.status = item.status;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsLuaTraiReward)
            {
                if (item.id <= 0)
                {
                    dbGuildRewardsLuaTrai luatrai = new dbGuildRewardsLuaTrai()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        idGuild = item.idGuild,
                        procs = item.procs,
                        staticID = rewardhandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        status = item.status,
                        typeReward = item.typeReward
                    };
                    ConnectDB.Entities.dbGuildRewardsLuaTrais.Add(luatrai);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbGuildRewardsLuaTrais.Where(x => x.id == idGen).FirstOrDefault();
                    result.amountMax = item.amountMax;
                    result.amountMin = item.amountMin;
                    result.idGuild = item.idGuild;
                    result.procs = item.procs;
                    result.staticID = rewardhandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID);
                    result.status = item.status;
                    result.typeReward = item.typeReward;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsBoss)
            {
                if (item.id <= 0)
                {
                    dbGuildBoss boss = new dbGuildBoss()
                    {
                        idGuild = item.idGuild,
                        maxRange = item.maxRange,
                        minRange = item.minRange,
                        status = item.status
                    };
                    ConnectDB.Entities.dbGuildBosses.Add(boss);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsBossReward)
                    {
                        if (item1.idBoss == item.id)
                        {
                            dbGuildBossReward reward = new dbGuildBossReward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idBoss = boss.id,
                                procs = item1.procs,
                                staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbGuildBossRewards.Add(reward);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbGuildBosses.Where(x => x.id == idGen).FirstOrDefault();
                    result.idGuild = item.idGuild;
                    result.maxRange = item.maxRange;
                    result.minRange = item.minRange;
                    result.status = item.status;
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsBossReward)
                    {
                        if (item1.idBoss == item.id)
                        {
                            if (item1.id <= 0)
                            {
                                dbGuildBossReward reward = new dbGuildBossReward()
                                {
                                    amountMax = item1.amountMax,
                                    amountMin = item1.amountMin,
                                    idBoss = item1.idBoss,
                                    procs = item1.procs,
                                    staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                    status = item1.status,
                                    typeReward = item1.typeReward
                                };
                                ConnectDB.Entities.dbGuildBossRewards.Add(reward);
                            }
                            else
                            {
                                int idReward = item1.id;
                                var result1 = ConnectDB.Entities.dbGuildBossRewards.Where(x => x.id == idReward).FirstOrDefault();
                                result1.amountMax = item1.amountMax;
                                result1.amountMin = item1.amountMin;
                                result1.idBoss = item1.idBoss;
                                result1.procs = item1.procs;
                                result1.staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID);
                                result1.status = item1.status;
                                result1.typeReward = item1.typeReward;
                            }
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
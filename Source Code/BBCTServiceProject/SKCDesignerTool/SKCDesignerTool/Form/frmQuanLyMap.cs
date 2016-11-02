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
    public partial class frmQuanLyMap : frmFormChange
    {
        List<dbMap> lsMap = new List<dbMap>();
        List<dbMapStage> lsStage = new List<dbMapStage>();
        List<dbMapStageMonter> lsMonter = new List<dbMapStageMonter>();
        List<dbMapStageMonterSupper> lsMonterSupper = new List<dbMapStageMonterSupper>();
        List<dbMapStagePath> lsPath = new List<dbMapStagePath>();
        List<dbMapStageReward> lsReward = new List<dbMapStageReward>();
        List<dbMapStageSupper> lsRewardSupper = new List<dbMapStageSupper>();
        ListReward rewardhandler = new ListReward();

        public frmQuanLyMap()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsMap.Clear();
            lsMonter.Clear();
            lsMonterSupper.Clear();
            lsPath.Clear();
            lsReward.Clear();
            lsRewardSupper.Clear();
            lsStage.Clear();

            var tmpMap = from tmp in ConnectDB.Entities.dbMaps
                         where tmp.status == 1
                         select tmp;

            foreach (var item in tmpMap)
            {
                dbMap map = new dbMap()
                {
                    background = item.background,
                    id = item.id,
                    name = item.name,
                    status = item.status
                };
                lsMap.Add(map);

                var tmpStage = from tmp in ConnectDB.Entities.dbMapStages
                               where tmp.status == 1 && tmp.idMap == item.id
                               select tmp;

                foreach (var item1 in tmpStage)
                {
                    dbMapStage stage = new dbMapStage()
                    {
                        background = item1.background,
                        descriptions = item1.descriptions,
                        expPlayer = item1.expPlayer,
                        expRewardMax = item1.expRewardMax,
                        expRewardMin = item1.expRewardMin,
                        id = item1.id,
                        idMap = item1.idMap,
                        maxAttack = item1.maxAttack,
                        name = item1.name,
                        positionX = item1.positionX,
                        positionY = item1.positionY,
                        silverRewardMax = item1.silverRewardMax,
                        silverRewardMin = item1.silverRewardMin,
                        stamina = item1.stamina,
                        status = item1.status,
                        totalPower = item1.totalPower,
                        typeStage = item1.typeStage
                    };
                    lsStage.Add(stage);

                    var tmpReward = from tmp in ConnectDB.Entities.dbMapStageRewards
                                    where tmp.status == 1 && tmp.idStage == item1.id
                                    select tmp;

                    foreach (var item2 in tmpReward)
                    {
                        dbMapStageReward reward = new dbMapStageReward()
                        {
                            amountMax = item2.amountMax,
                            amountMin = item2.amountMin,
                            id = item2.id,
                            idStage = item2.idStage,
                            procs = item2.procs,
                            staticID = rewardhandler.HandlerLoadStaticID((int)item2.typeReward, (int)item2.staticID),
                            status = item2.status,
                            typeReward = item2.typeReward
                        };
                        lsReward.Add(reward);
                    }

                    var tmpRewardSupper = from tmp in ConnectDB.Entities.dbMapStageSuppers
                                          where tmp.status == 1 && tmp.idStage == item1.id
                                          select tmp;

                    foreach (var item2 in tmpRewardSupper)
                    {
                        dbMapStageSupper reward = new dbMapStageSupper()
                        {
                            amountMax = item2.amountMax,
                            amountMin = item2.amountMin,
                            id = item2.id,
                            idStage = item2.idStage,
                            procs = item2.procs,
                            staticID = rewardhandler.HandlerLoadStaticID((int)item2.typeReward, (int)item2.staticID),
                            status = item2.status,
                            typeReward = item2.typeReward
                        };
                        lsRewardSupper.Add(reward);
                    }

                    var tmpPath = from tmp in ConnectDB.Entities.dbMapStagePaths
                                  where tmp.status == 1 && tmp.idStage == item1.id
                                  select tmp;

                    foreach (var item2 in tmpPath)
                    {
                        dbMapStagePath path = new dbMapStagePath()
                        {
                            id = item2.id,
                            idStage = item2.idStage,
                            positionX = item2.positionX,
                            positionY = item2.positionY,
                            status = item2.status
                        };
                        lsPath.Add(path);
                    }

                    var tmpMonter = from tmp in ConnectDB.Entities.dbMapStageMonters
                                    where tmp.status == 1 && tmp.idStage == item1.id
                                    select tmp;

                    foreach (var item2 in tmpMonter)
                    {
                        dbMapStageMonter monter = new dbMapStageMonter()
                        {
                            col = item2.col,
                            id = item2.id,
                            idMonter = item2.idMonter,
                            idStage = item2.idStage,
                            levelPower = item2.levelPower,
                            levels = item2.levels,
                            row = item2.row,
                            star = item2.star,
                            status = item2.status
                        };
                        lsMonter.Add(monter);
                    }

                    var tmpMonterSupper = from tmp in ConnectDB.Entities.dbMapStageMonterSuppers
                                          where tmp.status == 1 && tmp.idStage == item1.id
                                          select tmp;

                    foreach (var item2 in tmpMonterSupper)
                    {
                        dbMapStageMonterSupper monter = new dbMapStageMonterSupper()
                        {
                            col = item2.col,
                            id = item2.id,
                            idMonter = item2.idMonter,
                            idStage = item2.idStage,
                            levelPower = item2.levelPower,
                            levels = item2.levels,
                            row = item2.row,
                            star = item2.star,
                            status = item2.status
                        };
                        lsMonterSupper.Add(monter);
                    }
                }
            }
        }

        private void LoadDataToGC()
        {
            gcMap.DataSource = null;
            gcMap.DataSource = lsMap;
        }

        private void LoadDataToLUE()
        {
            var tmpTypeStage = from tmp in ConnectDB.Entities.dbCTTypeStages
                               select tmp;

            lueTypeStage.DataSource = tmpTypeStage.ToList();

            var tmpCharacter = from tmp in ConnectDB.Entities.dbCharacters
                               where tmp.status == 1
                               select new
                               {
                                   tmp.idCharacter,
                                   tmp.name
                               };
            lueCharacter.DataSource = tmpCharacter.ToList();
            lueMonterSupper.DataSource = tmpCharacter.ToList();

            var tmpTypeReward = from stage in ConnectDB.Entities.dbCTTypeRewards
                                select stage;
            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueTypeRewardSupper.DataSource = tmpTypeReward.ToList();

            lueReward.DataSource = rewardhandler.LoadTotalReward();
            lueStaticIDSupper.DataSource = rewardhandler.LoadTotalReward();
        }

        private void gvMap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gcStage.DataSource = null;
            gcMonter.DataSource = null;
            gcPath.DataSource = null;
            gcReward.DataSource = null;
            if (gvMap.RowCount > 0)
            {
                int idMap = (int)gvMap.GetRowCellValue(gvMap.FocusedRowHandle, "id");
                gcStage.DataSource = lsStage.Where(x => x.idMap == idMap && x.status == 1);
            }
        }

        private void gvStage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvStage.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                gcPath.DataSource = lsPath.Where(x => x.idStage == idStage && x.status == 1);
                gcReward.DataSource = lsReward.Where(x => x.idStage == idStage && x.status == 1);
                gcMonter.DataSource = lsMonter.Where(x => x.idStage == idStage && x.status == 1);
                gcMontersStageSupper.DataSource = lsMonterSupper.Where(x => x.idStage == idStage && x.status == 1);
                gcRewardStageSupper.DataSource = lsRewardSupper.Where(x => x.idStage == idStage && x.status == 1);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbMap map = new dbMap()
            {
                background = 1,
                id = -(lsMap.Count),
                name = "name",
                status = 1
            };
            lsMap.Add(map);
            gcMap.DataSource = null;
            gcMap.DataSource = lsMap.Where(x => x.status == 1);
            gvMap.MoveLast();

            gcMonter.DataSource = null;
            gcPath.DataSource = null;
            gcReward.DataSource = null;
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvMap.RowCount > 0)
            {
                int idGen = (int)gvMap.GetRowCellValue(gvMap.FocusedRowHandle, "id");
                lsMap.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcMap.DataSource = null;
                gcMap.DataSource = lsMap.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvMap.RowCount > 0)
            {
                int idMap = (int)gvMap.GetRowCellValue(gvMap.FocusedRowHandle, "id");
                dbMapStage stage = new dbMapStage()
                {
                    background = 1,
                    descriptions = "Des",
                    expPlayer = 0,
                    expRewardMax = 0,
                    expRewardMin = 0,
                    id = -(lsStage.Count),
                    idMap = idMap,
                    maxAttack = 0,
                    name = "name",
                    positionX = 0,
                    positionY = 0,
                    silverRewardMax = 0,
                    silverRewardMin = 0,
                    stamina = 0,
                    status = 1,
                    totalPower = 0,
                    typeStage = 1
                };
                lsStage.Add(stage);
                gcStage.DataSource = null;
                gcStage.DataSource = lsStage.Where(x => x.status == 1 && x.idMap == idMap);
                gvStage.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvStage.RowCount > 0)
            {
                int idMap = (int)gvMap.GetRowCellValue(gvMap.FocusedRowHandle, "id");
                int idGen = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                lsStage.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcStage.DataSource = null;
                gcStage.DataSource = lsStage.Where(x => x.status == 1 && x.idMap == idMap);
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            if (gvStage.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                dbMapStageReward reward = new dbMapStageReward()
                {
                    amountMax = 0,
                    amountMin = 0,
                    id = -(lsReward.Count),
                    idStage = idStage,
                    procs = 0,
                    staticID = 1,
                    status = 1,
                    typeReward = 3
                };
                lsReward.Add(reward);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idStage == idStage);
                gvReward.MoveLast();
            }
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                int idGen = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");
                lsReward.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idStage == idStage);
            }
        }

        private void btnAdd4_Click(object sender, EventArgs e)
        {
            if (gvStage.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                dbMapStageMonter monter = new dbMapStageMonter()
                {
                    col = 0,
                    id = -(lsMonter.Count),
                    idMonter = 1,
                    idStage = idStage,
                    levelPower = 1,
                    levels = 0,
                    row = 0,
                    star = 1,
                    status = 1
                };
                lsMonter.Add(monter);
                gcMonter.DataSource = null;
                gcMonter.DataSource = lsMonter.Where(x => x.status == 1 && x.idStage == idStage);
                gvMonter.MoveLast();
            }
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (gvMonter.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                int idGen = (int)gvMonter.GetRowCellValue(gvMonter.FocusedRowHandle, "id");
                lsMonter.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcMonter.DataSource = null;
                gcMonter.DataSource = lsMonter.Where(x => x.status == 1 && x.idStage == idStage);
            }
        }

        private void btnAdd5_Click(object sender, EventArgs e)
        {
            if (gvStage.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                dbMapStagePath path = new dbMapStagePath()
                {
                    id = -(lsPath.Count),
                    idStage = idStage,
                    positionX = 0,
                    positionY = 0,
                    status = 1
                };
                lsPath.Add(path);
                gcPath.DataSource = null;
                gcPath.DataSource = lsPath.Where(x => x.status == 1 && x.idStage == idStage);
                gvPath.MoveLast();
            }
        }

        private void btnDelete5_Click(object sender, EventArgs e)
        {
            if (gvPath.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                int idGen = (int)gvPath.GetRowCellValue(gvPath.FocusedRowHandle, "id");
                lsPath.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcPath.DataSource = null;
                gcPath.DataSource = lsPath.Where(x => x.status == 1 && x.idStage == idStage);
            }
        }

        private void SaveDataColumnFocus()
        {
            gvMap.FocusedRowHandle = -1;
            gvMonter.FocusedRowHandle = -1;
            gvPath.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            gvStage.FocusedRowHandle = -1;
            gvMontersStageSupper.FocusedRowHandle = -1;
            gvRewardStageSupper.FocusedRowHandle = -1;
        }

        protected override void OnSave()
        {
            SaveDataColumnFocus();
            CommonShowDialog.ShowWaitForm();

            int idMapSave = (int)gvMap.GetRowCellValue(gvMap.FocusedRowHandle, "id");

            foreach (var item in lsMap.Where(x => x.id == idMapSave))
            {
                if (item.id <= 0)
                {
                    dbMap map = new dbMap()
                    {
                        background = item.background,
                        name = item.name,
                        status = item.status
                    };
                    ConnectDB.Entities.dbMaps.Add(map);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsStage)
                    {
                        if (item1.idMap == item.id)
                        {
                            dbMapStage stage = new dbMapStage()
                            {
                                background = item1.background,
                                descriptions = item1.descriptions,
                                expPlayer = item1.expPlayer,
                                expRewardMax = item1.expRewardMax,
                                expRewardMin = item1.expRewardMin,
                                idMap = map.id,
                                maxAttack = item1.maxAttack,
                                name = item1.name,
                                positionX = item1.positionX,
                                positionY = item1.positionY,
                                silverRewardMax = item1.silverRewardMax,
                                silverRewardMin = item1.silverRewardMin,
                                stamina = item1.stamina,
                                status = item1.status,
                                totalPower = item1.totalPower,
                                typeStage = item1.typeStage
                            };
                            ConnectDB.Entities.dbMapStages.Add(stage);
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsMonter)
                            {
                                if (item2.idStage == item1.id)
                                {
                                    dbMapStageMonter monter = new dbMapStageMonter()
                                    {
                                        col = item2.col,
                                        idMonter = item2.idMonter,
                                        idStage = stage.id,
                                        levelPower = item2.levelPower,
                                        levels = item2.levels,
                                        row = item2.row,
                                        star = item2.star,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbMapStageMonters.Add(monter);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }

                            foreach (var item2 in lsMonterSupper)
                            {
                                if (item2.idStage == item1.id)
                                {
                                    dbMapStageMonterSupper monter = new dbMapStageMonterSupper()
                                    {
                                        col = item2.col,
                                        idMonter = item2.idMonter,
                                        idStage = stage.id,
                                        levelPower = item2.levelPower,
                                        levels = item2.levels,
                                        row = item2.row,
                                        star = item2.star,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbMapStageMonterSuppers.Add(monter);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }

                            foreach (var item2 in lsPath)
                            {
                                if (item2.idStage == item1.id)
                                {
                                    dbMapStagePath path = new dbMapStagePath()
                                    {
                                        idStage = stage.id,
                                        positionX = item2.positionX,
                                        positionY = item2.positionY,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbMapStagePaths.Add(path);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }

                            foreach (var item2 in lsReward)
                            {
                                if (item2.idStage == item1.id)
                                {
                                    dbMapStageReward path = new dbMapStageReward()
                                    {
                                        idStage = stage.id,
                                        amountMax = item2.amountMax,
                                        amountMin = item2.amountMin,
                                        procs = item2.procs,
                                        staticID = rewardhandler.HandlerSaveStaticID((int)item2.typeReward, (int)item2.staticID),
                                        typeReward = item2.typeReward,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbMapStageRewards.Add(path);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }


                            foreach (var item2 in lsRewardSupper)
                            {
                                if (item2.idStage == item1.id)
                                {
                                    dbMapStageSupper path = new dbMapStageSupper()
                                    {
                                        idStage = stage.id,
                                        amountMax = item2.amountMax,
                                        amountMin = item2.amountMin,
                                        procs = item2.procs,
                                        staticID = rewardhandler.HandlerSaveStaticID((int)item2.typeReward, (int)item2.staticID),
                                        typeReward = item2.typeReward,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbMapStageSuppers.Add(path);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }
                    }
                }
                else
                {
                    int idMap = item.id;
                    var result = ConnectDB.Entities.dbMaps.Where(x => x.status == 1 && x.id == idMap).FirstOrDefault();
                    result.background = item.background;
                    result.name = item.name;
                    result.status = item.status;

                    foreach (var item1 in lsStage)
                    {
                        if (item1.idMap == item.id)
                        {
                            if (item1.id <= 0)
                            {
                                dbMapStage stage = new dbMapStage()
                                {
                                    background = item1.background,
                                    descriptions = item1.descriptions,
                                    expPlayer = item1.expPlayer,
                                    expRewardMax = item1.expRewardMax,
                                    expRewardMin = item1.expRewardMin,
                                    idMap = idMap,
                                    maxAttack = item1.maxAttack,
                                    name = item1.name,
                                    positionX = item1.positionX,
                                    positionY = item1.positionY,
                                    silverRewardMax = item1.silverRewardMax,
                                    silverRewardMin = item1.silverRewardMin,
                                    stamina = item1.stamina,
                                    status = item1.status,
                                    totalPower = item1.totalPower,
                                    typeStage = item1.typeStage
                                };
                                ConnectDB.Entities.dbMapStages.Add(stage);
                                ConnectDB.Entities.SaveChanges();

                                foreach (var item2 in lsMonter)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        dbMapStageMonter monter = new dbMapStageMonter()
                                        {
                                            col = item2.col,
                                            idMonter = item2.idMonter,
                                            idStage = stage.id,
                                            levelPower = item2.levelPower,
                                            levels = item2.levels,
                                            row = item2.row,
                                            star = item2.star,
                                            status = item2.status
                                        };
                                        ConnectDB.Entities.dbMapStageMonters.Add(monter);
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }

                                foreach (var item2 in lsMonterSupper)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        dbMapStageMonterSupper monter = new dbMapStageMonterSupper()
                                        {
                                            col = item2.col,
                                            idMonter = item2.idMonter,
                                            idStage = stage.id,
                                            levelPower = item2.levelPower,
                                            levels = item2.levels,
                                            row = item2.row,
                                            star = item2.star,
                                            status = item2.status
                                        };
                                        ConnectDB.Entities.dbMapStageMonterSuppers.Add(monter);
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }

                                foreach (var item2 in lsPath)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        dbMapStagePath path = new dbMapStagePath()
                                        {
                                            idStage = stage.id,
                                            positionX = item2.positionX,
                                            positionY = item2.positionY,
                                            status = item2.status
                                        };
                                        ConnectDB.Entities.dbMapStagePaths.Add(path);
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }

                                foreach (var item2 in lsReward)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        dbMapStageReward path = new dbMapStageReward()
                                        {
                                            idStage = stage.id,
                                            amountMax = item2.amountMax,
                                            amountMin = item2.amountMin,
                                            procs = item2.procs,
                                            staticID = rewardhandler.HandlerSaveStaticID((int)item2.typeReward, (int)item2.staticID),
                                            typeReward = item2.typeReward,
                                            status = item2.status
                                        };
                                        ConnectDB.Entities.dbMapStageRewards.Add(path);
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }

                                foreach (var item2 in lsRewardSupper)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        dbMapStageSupper path = new dbMapStageSupper()
                                        {
                                            idStage = stage.id,
                                            amountMax = item2.amountMax,
                                            amountMin = item2.amountMin,
                                            procs = item2.procs,
                                            staticID = rewardhandler.HandlerSaveStaticID((int)item2.typeReward, (int)item2.staticID),
                                            typeReward = item2.typeReward,
                                            status = item2.status
                                        };
                                        ConnectDB.Entities.dbMapStageSuppers.Add(path);
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }
                            }
                            else
                            {
                                int idStage = item1.id;
                                var result1 = ConnectDB.Entities.dbMapStages.Where(x => x.id == idStage && x.status == 1).FirstOrDefault();
                                result1.background = item1.background;
                                result1.descriptions = item1.descriptions;
                                result1.expPlayer = item1.expPlayer;
                                result1.expRewardMax = item1.expRewardMax;
                                result1.expRewardMin = item1.expRewardMin;
                                result1.idMap = idMap;
                                result1.maxAttack = item1.maxAttack;
                                result1.name = item1.name;
                                result1.positionX = item1.positionX;
                                result1.positionY = item1.positionY;
                                result1.silverRewardMax = item1.silverRewardMax;
                                result1.silverRewardMin = item1.silverRewardMin;
                                result1.stamina = item1.stamina;
                                result1.status = item1.status;
                                result1.totalPower = item1.totalPower;
                                result1.typeStage = item1.typeStage;

                                foreach (var item2 in lsMonter)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        if (item2.id <= 0)
                                        {
                                            dbMapStageMonter monter = new dbMapStageMonter()
                                            {
                                                col = item2.col,
                                                idMonter = item2.idMonter,
                                                idStage = idStage,
                                                levelPower = item2.levelPower,
                                                levels = item2.levels,
                                                row = item2.row,
                                                star = item2.star,
                                                status = item2.status
                                            };
                                            ConnectDB.Entities.dbMapStageMonters.Add(monter);
                                        }
                                        else
                                        {
                                            int idMonter = item2.id;
                                            var result2 = ConnectDB.Entities.dbMapStageMonters.Where(x => x.id == idMonter && x.status == 1).FirstOrDefault();
                                            result2.col = item2.col;
                                            result2.idMonter = item2.idMonter;
                                            result2.idStage = idStage;
                                            result2.levelPower = item2.levelPower;
                                            result2.levels = item2.levels;
                                            result2.row = item2.row;
                                            result2.star = item2.star;
                                            result2.status = item2.status;
                                        }
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }

                                foreach (var item2 in lsMonterSupper)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        if (item2.id <= 0)
                                        {
                                            dbMapStageMonterSupper monter = new dbMapStageMonterSupper()
                                            {
                                                col = item2.col,
                                                idMonter = item2.idMonter,
                                                idStage = idStage,
                                                levelPower = item2.levelPower,
                                                levels = item2.levels,
                                                row = item2.row,
                                                star = item2.star,
                                                status = item2.status
                                            };
                                            ConnectDB.Entities.dbMapStageMonterSuppers.Add(monter);
                                        }
                                        else
                                        {
                                            int idMonter = item2.id;
                                            var result2 = ConnectDB.Entities.dbMapStageMonterSuppers.Where(x => x.id == idMonter && x.status == 1).FirstOrDefault();
                                            result2.col = item2.col;
                                            result2.idMonter = item2.idMonter;
                                            result2.idStage = idStage;
                                            result2.levelPower = item2.levelPower;
                                            result2.levels = item2.levels;
                                            result2.row = item2.row;
                                            result2.star = item2.star;
                                            result2.status = item2.status;
                                        }
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }

                                foreach (var item2 in lsPath)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        if (item2.id <= 0)
                                        {
                                            dbMapStagePath path = new dbMapStagePath()
                                            {
                                                idStage = idStage,
                                                positionX = item2.positionX,
                                                positionY = item2.positionY,
                                                status = item2.status
                                            };
                                            ConnectDB.Entities.dbMapStagePaths.Add(path);
                                        }
                                        else
                                        {
                                            int idPath = item2.id;
                                            var result2 = ConnectDB.Entities.dbMapStagePaths.Where(x => x.status == 1 && x.id == idPath).FirstOrDefault();
                                            result2.idStage = idStage;
                                            result2.positionX = item2.positionX;
                                            result2.positionY = item2.positionY;
                                            result2.status = item2.status;
                                        }
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }

                                foreach (var item2 in lsReward)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        if (item2.id <= 0)
                                        {
                                            dbMapStageReward path = new dbMapStageReward()
                                            {
                                                idStage = idStage,
                                                amountMax = item2.amountMax,
                                                amountMin = item2.amountMin,
                                                procs = item2.procs,
                                                staticID = rewardhandler.HandlerSaveStaticID((int)item2.typeReward, (int)item2.staticID),
                                                typeReward = item2.typeReward,
                                                status = item2.status
                                            };
                                            ConnectDB.Entities.dbMapStageRewards.Add(path);
                                        }
                                        else
                                        {
                                            int idReward = item2.id;
                                            var result2 = ConnectDB.Entities.dbMapStageRewards.Where(x => x.id == idReward && x.status == 1).FirstOrDefault();
                                            result2.idStage = idStage;
                                            result2.amountMax = item2.amountMax;
                                            result2.amountMin = item2.amountMin;
                                            result2.procs = item2.procs;
                                            result2.staticID = rewardhandler.HandlerSaveStaticID((int)item2.typeReward, (int)item2.staticID);
                                            result2.typeReward = item2.typeReward;
                                            result2.status = item2.status;
                                        }
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }

                                foreach (var item2 in lsRewardSupper)
                                {
                                    if (item2.idStage == item1.id)
                                    {
                                        if (item2.id <= 0)
                                        {
                                            dbMapStageSupper path = new dbMapStageSupper()
                                            {
                                                idStage = idStage,
                                                amountMax = item2.amountMax,
                                                amountMin = item2.amountMin,
                                                procs = item2.procs,
                                                staticID = rewardhandler.HandlerSaveStaticID((int)item2.typeReward, (int)item2.staticID),
                                                typeReward = item2.typeReward,
                                                status = item2.status
                                            };
                                            ConnectDB.Entities.dbMapStageSuppers.Add(path);
                                        }
                                        else
                                        {
                                            int idReward = item2.id;
                                            var result2 = ConnectDB.Entities.dbMapStageSuppers.Where(x => x.id == idReward && x.status == 1).FirstOrDefault();
                                            result2.idStage = idStage;
                                            result2.amountMax = item2.amountMax;
                                            result2.amountMin = item2.amountMin;
                                            result2.procs = item2.procs;
                                            result2.staticID = rewardhandler.HandlerSaveStaticID((int)item2.typeReward, (int)item2.staticID);
                                            result2.typeReward = item2.typeReward;
                                            result2.status = item2.status;
                                        }
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbMapStageReward rewardSelect = (dbMapStageReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        private void btnAdd6_Click(object sender, EventArgs e)
        {
            if (gvStage.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                dbMapStageSupper reward = new dbMapStageSupper()
                {
                    amountMax = 0,
                    amountMin = 0,
                    id = -(lsRewardSupper.Count),
                    idStage = idStage,
                    procs = 0,
                    staticID = 1,
                    status = 1,
                    typeReward = 3
                };
                lsRewardSupper.Add(reward);
                gcRewardStageSupper.DataSource = null;
                gcRewardStageSupper.DataSource = lsRewardSupper.Where(x => x.status == 1 && x.idStage == idStage);
                gvRewardStageSupper.MoveLast();
            }
        }

        private void btnDelete6_Click(object sender, EventArgs e)
        {
            if (gvRewardStageSupper.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                int idGen = (int)gvRewardStageSupper.GetRowCellValue(gvRewardStageSupper.FocusedRowHandle, "id");
                lsRewardSupper.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcRewardStageSupper.DataSource = null;
                gcRewardStageSupper.DataSource = lsRewardSupper.Where(x => x.status == 1 && x.idStage == idStage);
            }
        }

        private void btnAdd7_Click(object sender, EventArgs e)
        {
            if (gvStage.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                dbMapStageMonterSupper monter = new dbMapStageMonterSupper()
                {
                    col = 0,
                    id = -(lsMonterSupper.Count),
                    idMonter = 1,
                    idStage = idStage,
                    levelPower = 1,
                    levels = 0,
                    row = 0,
                    star = 1,
                    status = 1
                };

                lsMonterSupper.Add(monter);
                gcMontersStageSupper.DataSource = null;
                gcMontersStageSupper.DataSource = lsMonterSupper.Where(x => x.status == 1 && x.idStage == idStage);
                gvMontersStageSupper.MoveLast();
            }
        }

        private void btnDelete7_Click(object sender, EventArgs e)
        {
            if (gvMontersStageSupper.RowCount > 0)
            {
                int idStage = (int)gvStage.GetRowCellValue(gvStage.FocusedRowHandle, "id");
                int idGen = (int)gvMontersStageSupper.GetRowCellValue(gvMontersStageSupper.FocusedRowHandle, "id");
                lsMonterSupper.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcMontersStageSupper.DataSource = null;
                gcMontersStageSupper.DataSource = lsMonterSupper.Where(x => x.status == 1 && x.idStage == idStage);
            }
        }

        private void gvRewardStageSupper_DoubleClick(object sender, EventArgs e)
        {
            dbMapStageSupper rewardSelect = (dbMapStageSupper)gvRewardStageSupper.GetRow(gvRewardStageSupper.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }
    }
}
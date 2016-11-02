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
    public partial class frmThanThap : frmFormChange
    {
        List<dbThanThapStarReward> lsStarReward = new List<dbThanThapStarReward>();
        List<dbThanThapAttribute> lsAttribute = new List<dbThanThapAttribute>();
        List<dbThanThapPlusAttributeRequire> lsPlus = new List<dbThanThapPlusAttributeRequire>();
        List<dbThanThapMoneyReset> lsMoney = new List<dbThanThapMoneyReset>();
        List<dbThanThapFloorReward> lsFloorReward = new List<dbThanThapFloorReward>();
        List<dbThanThapMonster> lsListMonter = new List<dbThanThapMonster>();
        List<dbThanThapDetailMonster> lsDetailMonter = new List<dbThanThapDetailMonster>();
        ListReward rewardhandler = new ListReward();

        public frmThanThap()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsAttribute.Clear();
            lsDetailMonter.Clear();
            lsFloorReward.Clear();
            lsListMonter.Clear();
            lsMoney.Clear();
            lsPlus.Clear();
            lsStarReward.Clear();

            var tmpStarReward = from tmp in ConnectDB.Entities.dbThanThapStarRewards
                                where tmp.status == 1
                                select tmp;

            foreach (var item in tmpStarReward)
            {
                dbThanThapStarReward star = new dbThanThapStarReward()
                {
                    id = item.id,
                    idThanThap = item.idThanThap,
                    status = item.status,
                    value = item.value
                };
                lsStarReward.Add(star);
            }

            var tmpAttribute = from tmp in ConnectDB.Entities.dbThanThapAttributes
                               where tmp.status == 1
                               select tmp;

            foreach (var item in tmpAttribute)
            {
                dbThanThapAttribute att = new dbThanThapAttribute()
                {
                    id = item.id,
                    idThanThap = item.idThanThap,
                    status = item.status,
                    value = item.value
                };
                lsAttribute.Add(att);
            }

            var tmpMoneyReset = from tmp in ConnectDB.Entities.dbThanThapMoneyResets
                                where tmp.status == 1
                                select tmp;

            foreach (var item in tmpMoneyReset)
            {
                dbThanThapMoneyReset money = new dbThanThapMoneyReset()
                {
                    id = item.id,
                    idThanThap = item.idThanThap,
                    quantity = item.quantity,
                    status = item.status,
                    types = item.types
                };
                lsMoney.Add(money);
            }


            var tmpPlus = from tmp in ConnectDB.Entities.dbThanThapPlusAttributeRequires
                          where tmp.status == 1
                          select tmp;

            foreach (var item in tmpPlus)
            {
                dbThanThapPlusAttributeRequire plus = new dbThanThapPlusAttributeRequire()
                {
                    id = item.id,
                    idThanThap = item.idThanThap,
                    procReceive = item.procReceive,
                    startRequire = item.startRequire,
                    status = item.status
                };
                lsPlus.Add(plus);
            }

            var tmpFloor = from tmp in ConnectDB.Entities.dbThanThapFloorRewards
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpFloor)
            {
                dbThanThapFloorReward reward = new dbThanThapFloorReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idThanThap = item.idThanThap,
                    procs = item.procs,
                    staticID = rewardhandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsFloorReward.Add(reward);
            }

            var tmpMonter = from tmp in ConnectDB.Entities.dbThanThapMonsters
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpMonter)
            {
                dbThanThapMonster monter = new dbThanThapMonster()
                {
                    id = item.id,
                    idThanThap = item.idThanThap,
                    status = item.status
                };
                lsListMonter.Add(monter);

                var tmpList = from tmp in ConnectDB.Entities.dbThanThapDetailMonsters
                              where tmp.status == 1 && tmp.idThanThapMonter == item.id
                              select tmp;

                foreach (var item1 in tmpList)
                {
                    dbThanThapDetailMonster detail = new dbThanThapDetailMonster()
                    {
                        col = item1.col,
                        id = item1.id,
                        idMonter = item1.idMonter,
                        idThanThapMonter = item1.idThanThapMonter,
                        levelPower = item1.levelPower,
                        levels = item1.levels,
                        row = item1.row,
                        star = item1.star,
                        status = item1.status
                    };
                    lsDetailMonter.Add(detail);
                }
            }
        }

        private void LoadDataToGC()
        {
            var tmpChung = from tmp in ConnectDB.Entities.dbThanThaps
                           where tmp.status == 1
                           select tmp;

            gcChung.DataSource = null;
            gcChung.DataSource = tmpChung.ToList();
            gcFloorReward.DataSource = null;
            gcFloorReward.DataSource = lsFloorReward;
            gcListMonter.DataSource = null;
            gcListMonter.DataSource = lsListMonter;
            gcMoneyReset.DataSource = null;
            gcMoneyReset.DataSource = lsMoney;
            gcPlusAttributeRequire.DataSource = null;
            gcPlusAttributeRequire.DataSource = lsPlus;
            gcAttribute.DataSource = null;
            gcAttribute.DataSource = lsAttribute;
            gcStarReward.DataSource = null;
            gcStarReward.DataSource = lsStarReward;
        }

        private void gvListMonter_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvListMonter.RowCount > 0)
            {
                int idGen = (int)gvListMonter.GetRowCellValue(gvListMonter.FocusedRowHandle, "id");
                gcDetailMonter.DataSource = lsDetailMonter.Where(x => x.status == 1 && x.idThanThapMonter == idGen);
            }
        }

        private void LoadDataToLUE()
        {
            var tmpCharacter = from tmp in ConnectDB.Entities.dbCharacters
                               where tmp.status == 1
                               select new
                               {
                                   tmp.idCharacter,
                                   tmp.name
                               };
            lueCharacter.DataSource = tmpCharacter.ToList();

            var tmpTypeReward = from stage in ConnectDB.Entities.dbCTTypeRewards
                                select stage;
            lueTypeReward.DataSource = tmpTypeReward.ToList();

            lueStaticID.DataSource = rewardhandler.LoadTotalReward();
        }

        private void gvFloorReward_DoubleClick(object sender, EventArgs e)
        {
            dbThanThapFloorReward rewardSelect = (dbThanThapFloorReward)gvFloorReward.GetRow(gvFloorReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbThanThapStarReward star = new dbThanThapStarReward()
            {
                id = -(lsStarReward.Count),
                idThanThap = 1,
                status = 1,
                value = 0
            };
            lsStarReward.Add(star);
            gcStarReward.DataSource = null;
            gcStarReward.DataSource = lsStarReward.Where(x => x.status == 1);
            gvStarReward.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvStarReward.RowCount > 0)
            {
                int idGen = (int)gvStarReward.GetRowCellValue(gvStarReward.FocusedRowHandle, "id");
                lsStarReward.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcStarReward.DataSource = null;
                gcStarReward.DataSource = lsStarReward.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            dbThanThapAttribute star = new dbThanThapAttribute()
            {
                id = -(lsAttribute.Count),
                idThanThap = 1,
                status = 1,
                value = 0
            };
            lsAttribute.Add(star);
            gcAttribute.DataSource = null;
            gcAttribute.DataSource = lsAttribute.Where(x => x.status == 1);
            gvAttribute.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvAttribute.RowCount > 0)
            {
                int idGen = (int)gvAttribute.GetRowCellValue(gvAttribute.FocusedRowHandle, "id");
                lsAttribute.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcAttribute.DataSource = null;
                gcAttribute.DataSource = lsAttribute.Where(x => x.status == 1);
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            dbThanThapMoneyReset star = new dbThanThapMoneyReset()
            {
                id = -(lsMoney.Count),
                idThanThap = 1,
                status = 1,
                types = 0,
                quantity = 0
            };
            lsMoney.Add(star);
            gcMoneyReset.DataSource = null;
            gcMoneyReset.DataSource = lsMoney.Where(x => x.status == 1);
            gvMoneyReset.MoveLast();
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (gvMoneyReset.RowCount > 0)
            {
                int idGen = (int)gvMoneyReset.GetRowCellValue(gvMoneyReset.FocusedRowHandle, "id");
                lsMoney.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcMoneyReset.DataSource = null;
                gcMoneyReset.DataSource = lsMoney.Where(x => x.status == 1);
            }
        }

        private void btnAdd4_Click(object sender, EventArgs e)
        {
            dbThanThapFloorReward star = new dbThanThapFloorReward()
            {
                id = -(lsFloorReward.Count),
                idThanThap = 1,
                status = 1,
                amountMax = 1,
                amountMin = 0,
                procs = 0,
                staticID = 1,
                typeReward = 3
            };
            lsFloorReward.Add(star);
            gcFloorReward.DataSource = null;
            gcFloorReward.DataSource = lsFloorReward.Where(x => x.status == 1);
            gvFloorReward.MoveLast();
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (gvFloorReward.RowCount > 0)
            {
                int idGen = (int)gvFloorReward.GetRowCellValue(gvFloorReward.FocusedRowHandle, "id");
                lsFloorReward.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcFloorReward.DataSource = null;
                gcFloorReward.DataSource = lsFloorReward.Where(x => x.status == 1);
            }
        }

        private void btnAdd5_Click(object sender, EventArgs e)
        {
            dbThanThapPlusAttributeRequire star = new dbThanThapPlusAttributeRequire()
            {
                id = -(lsPlus.Count),
                idThanThap = 1,
                status = 1,
                procReceive = 0,
                startRequire = 0
            };
            lsPlus.Add(star);
            gcPlusAttributeRequire.DataSource = null;
            gcPlusAttributeRequire.DataSource = lsPlus.Where(x => x.status == 1);
            gvPlusAttributeRequire.MoveLast();
        }

        private void btnDelete5_Click(object sender, EventArgs e)
        {
            if (gvPlusAttributeRequire.RowCount > 0)
            {
                int idGen = (int)gvPlusAttributeRequire.GetRowCellValue(gvPlusAttributeRequire.FocusedRowHandle, "id");
                lsPlus.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcPlusAttributeRequire.DataSource = null;
                gcPlusAttributeRequire.DataSource = lsPlus.Where(x => x.status == 1);
            }
        }

        private void btnAdd6_Click(object sender, EventArgs e)
        {
            dbThanThapMonster star = new dbThanThapMonster()
            {
                id = -(lsListMonter.Count),
                idThanThap = 1,
                status = 1
            };
            lsListMonter.Add(star);
            gcListMonter.DataSource = null;
            gcListMonter.DataSource = lsListMonter.Where(x => x.status == 1);
            gvListMonter.MoveLast();
        }

        private void btnDelete6_Click(object sender, EventArgs e)
        {
            if (gvListMonter.RowCount > 0)
            {
                int idGen = (int)gvListMonter.GetRowCellValue(gvListMonter.FocusedRowHandle, "id");
                lsListMonter.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcListMonter.DataSource = null;
                gcListMonter.DataSource = lsListMonter.Where(x => x.status == 1);
            }
        }

        private void btnAdd7_Click(object sender, EventArgs e)
        {
            if (gvListMonter.RowCount > 0)
            {
                int idGen = (int)gvListMonter.GetRowCellValue(gvListMonter.FocusedRowHandle, "id");
                dbThanThapDetailMonster star = new dbThanThapDetailMonster()
                {
                    id = -(lsDetailMonter.Count),
                    idThanThapMonter = idGen,
                    status = 1,
                    col = 0,
                    idMonter = 1,
                    levelPower = 0,
                    levels = 1,
                    row = 0,
                    star = 1
                };
                lsDetailMonter.Add(star);
                gcDetailMonter.DataSource = null;
                gcDetailMonter.DataSource = lsDetailMonter.Where(x => x.status == 1 && x.idThanThapMonter == idGen);
                gvDetailMonter.MoveLast();
            }
        }

        private void btnDelete7_Click(object sender, EventArgs e)
        {
            if (gvDetailMonter.RowCount > 0)
            {
                int idMon = (int)gvListMonter.GetRowCellValue(gvListMonter.FocusedRowHandle, "id");
                int idGen = (int)gvDetailMonter.GetRowCellValue(gvDetailMonter.FocusedRowHandle, "id");
                lsDetailMonter.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcDetailMonter.DataSource = null;
                gcDetailMonter.DataSource = lsDetailMonter.Where(x => x.status == 1 && x.idThanThapMonter == idMon);
            }
        }

        private void SaveDataGCFocus()
        {
            gvChung.FocusedRowHandle = -1;
            gvDetailMonter.FocusedRowHandle = -1;
            gvFloorReward.FocusedRowHandle = -1;
            gvListMonter.FocusedRowHandle = -1;
            gvMoneyReset.FocusedRowHandle = -1;
            gvPlusAttributeRequire.FocusedRowHandle = -1;
            gvStarReward.FocusedRowHandle = -1;
        }

        protected override void OnSave()
        {
            SaveDataGCFocus();
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsStarReward)
            {
                if (item.id <= 0)
                {
                    dbThanThapStarReward star = new dbThanThapStarReward()
                    {
                        idThanThap = item.idThanThap,
                        status = item.status,
                        value = item.value
                    };
                    ConnectDB.Entities.dbThanThapStarRewards.Add(star);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbThanThapStarRewards.Where(x => x.id == idGen).FirstOrDefault();
                    result.idThanThap = item.idThanThap;
                    result.status = item.status;
                    result.value = item.value;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsAttribute)
            {
                if (item.id <= 0)
                {
                    dbThanThapAttribute star = new dbThanThapAttribute()
                    {
                        idThanThap = item.idThanThap,
                        status = item.status,
                        value = item.value
                    };
                    ConnectDB.Entities.dbThanThapAttributes.Add(star);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbThanThapAttributes.Where(x => x.id == idGen).FirstOrDefault();
                    result.idThanThap = item.idThanThap;
                    result.status = item.status;
                    result.value = item.value;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsMoney)
            {
                if (item.id <= 0)
                {
                    dbThanThapMoneyReset star = new dbThanThapMoneyReset()
                    {
                        idThanThap = item.idThanThap,
                        status = item.status,
                        quantity = item.quantity,
                        types = item.types
                    };
                    ConnectDB.Entities.dbThanThapMoneyResets.Add(star);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbThanThapMoneyResets.Where(x => x.id == idGen).FirstOrDefault();
                    result.idThanThap = item.idThanThap;
                    result.status = item.status;
                    result.quantity = item.quantity;
                    result.types = item.types;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsFloorReward)
            {
                if (item.id <= 0)
                {
                    dbThanThapFloorReward reward = new dbThanThapFloorReward()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        idThanThap = item.idThanThap,
                        procs = item.procs,
                        staticID = rewardhandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        status = item.status,
                        typeReward = item.typeReward
                    };
                    ConnectDB.Entities.dbThanThapFloorRewards.Add(reward);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbThanThapFloorRewards.Where(x => x.id == idGen).FirstOrDefault();
                    result.amountMax = item.amountMax;
                    result.amountMin = item.amountMin;
                    result.idThanThap = item.idThanThap;
                    result.procs = item.procs;
                    result.staticID = rewardhandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID);
                    result.status = item.status;
                    result.typeReward = item.typeReward;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsPlus)
            {
                if (item.id <= 0)
                {
                    dbThanThapPlusAttributeRequire star = new dbThanThapPlusAttributeRequire()
                    {
                        idThanThap = item.idThanThap,
                        status = item.status,
                        procReceive = item.procReceive,
                        startRequire = item.startRequire
                    };
                    ConnectDB.Entities.dbThanThapPlusAttributeRequires.Add(star);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbThanThapPlusAttributeRequires.Where(x => x.id == idGen).FirstOrDefault();
                    result.idThanThap = item.idThanThap;
                    result.status = item.status;
                    result.procReceive = item.procReceive;
                    result.startRequire = item.startRequire;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsListMonter)
            {
                if (item.id <= 0)
                {
                    dbThanThapMonster star = new dbThanThapMonster()
                    {
                        idThanThap = item.idThanThap,
                        status = item.status
                    };
                    ConnectDB.Entities.dbThanThapMonsters.Add(star);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsDetailMonter)
                    {
                        if (item1.idThanThapMonter == item.id)
                        {
                            dbThanThapDetailMonster detail = new dbThanThapDetailMonster()
                            {
                                col = item1.col,
                                idMonter = item1.idMonter,
                                idThanThapMonter = star.id,
                                levelPower = item1.levelPower,
                                levels = item1.levels,
                                row = item1.row,
                                star = item1.star,
                                status = item1.status
                            };
                            ConnectDB.Entities.dbThanThapDetailMonsters.Add(detail);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbThanThapMonsters.Where(x => x.id == idGen).FirstOrDefault();
                    result.idThanThap = item.idThanThap;
                    result.status = item.status;

                    foreach (var item1 in lsDetailMonter)
                    {
                        if (item1.idThanThapMonter == item.id)
                        {
                            if (item1.id <= 0)
                            {
                                dbThanThapDetailMonster detail = new dbThanThapDetailMonster()
                                {
                                    col = item1.col,
                                    idMonter = item1.idMonter,
                                    idThanThapMonter = item1.idThanThapMonter,
                                    levelPower = item1.levelPower,
                                    levels = item1.levels,
                                    row = item1.row,
                                    star = item1.star,
                                    status = item1.status
                                };
                                ConnectDB.Entities.dbThanThapDetailMonsters.Add(detail);
                            }
                            else
                            {
                                int idMon = item1.id;
                                var result1 = ConnectDB.Entities.dbThanThapDetailMonsters.Where(x => x.id == idMon).FirstOrDefault();
                                result1.col = item1.col;
                                result1.idMonter = item1.idMonter;
                                result1.idThanThapMonter = item1.idThanThapMonter;
                                result1.levelPower = item1.levelPower;
                                result1.levels = item1.levels;
                                result1.row = item1.row;
                                result1.star = item1.star;
                                result1.status = item1.status;
                            }
                            ConnectDB.Entities.SaveChanges();
                        }
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
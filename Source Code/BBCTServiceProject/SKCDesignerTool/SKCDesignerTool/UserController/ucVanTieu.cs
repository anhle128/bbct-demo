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
using BBCTDesignerTool.FormBase;
using BBCTDesignerTool.Models;
using BBCTDesignerTool.Form;
using BBCTDesignerTool.Common;

namespace BBCTDesignerTool.UserController
{
    public partial class ucVanTieu : ucManager
    {
        List<dbVanTieu> lsVanTieu = new List<dbVanTieu>();
        List<dbVanTieuProtectReward> lsProtectReward = new List<dbVanTieuProtectReward>();
        List<dbVanTieuRobReward> lsRobReward = new List<dbVanTieuRobReward>();
        ListReward rewardhandler = new ListReward();

        public ucVanTieu()
        {
            InitializeComponent();
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsProtectReward.Clear();
            lsRobReward.Clear();
            lsVanTieu.Clear();

            var tmpVehicle = from tmp in ConnectDB.Entities.dbVanTieux
                             where tmp.status == 1
                             select tmp;

            foreach (var item in tmpVehicle)
            {
                dbVanTieu van = new dbVanTieu()
                {
                    id = item.id,
                    idConfig = item.idConfig,
                    procs = item.procs,
                    silverReward = item.silverReward,
                    status = item.status
                };
                lsVanTieu.Add(van);

                var tmpProtect = from tmp in ConnectDB.Entities.dbVanTieuProtectRewards
                                 where tmp.status == 1 && tmp.idVanTieu == item.id
                                 select tmp;

                foreach (var item1 in tmpProtect)
                {
                    dbVanTieuProtectReward pro = new dbVanTieuProtectReward()
                    {
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin,
                        id = item1.id,
                        idVanTieu = item1.idVanTieu,
                        procs = item1.procs,
                        staticID = rewardhandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward
                    };
                    lsProtectReward.Add(pro);
                }

                var tmpRob = from tmp in ConnectDB.Entities.dbVanTieuRobRewards
                             where tmp.status == 1 && tmp.idVanTieu == item.id
                             select tmp;

                foreach (var item1 in tmpRob)
                {
                    dbVanTieuRobReward pro = new dbVanTieuRobReward()
                    {
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin,
                        id = item1.id,
                        idVanTieu = item1.idVanTieu,
                        procs = item1.procs,
                        staticID = rewardhandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward
                    };
                    lsRobReward.Add(pro);
                }
            }
        }

        private void LoadDataToGC()
        {
            var tmpConfig = from tmp in ConnectDB.Entities.dbConfigs
                            select tmp;

            gcVanTieu.DataSource = null;
            gcVanTieu.DataSource = tmpConfig.ToList();
            gcVehicle.DataSource = null;
            gcVehicle.DataSource = lsVanTieu;
        }

        private void LoadDataToLUE()
        {
            var tmpTypeReward = from stage in ConnectDB.Entities.dbCTTypeRewards
                                select stage;
            lueTypeRewardPro.DataSource = tmpTypeReward.ToList();
            lueTypeRewardPro.DisplayMember = "value";
            lueTypeRewardPro.ValueMember = "id";

            lueTypeRewardRob.DataSource = tmpTypeReward.ToList();
            lueTypeRewardRob.DisplayMember = "value";
            lueTypeRewardRob.ValueMember = "id";

            lueStaticIDPro.DataSource = rewardhandler.LoadTotalReward();
            lueStaticIDRob.DataSource = rewardhandler.LoadTotalReward();

        }

        private void gvVehicle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvVehicle.RowCount > 0)
            {
                int idVic = (int)gvVehicle.GetRowCellValue(gvVehicle.FocusedRowHandle, "id");
                gcRobReward.DataSource = null;
                gcRobReward.DataSource = lsRobReward.Where(x => x.idVanTieu == idVic && x.status == 1);
                gcProtectReward.DataSource = null;
                gcProtectReward.DataSource = lsProtectReward.Where(x => x.idVanTieu == idVic && x.status == 1);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbVanTieu van = new dbVanTieu()
            {
                id = -(lsVanTieu.Count),
                idConfig = 1,
                procs = 0,
                silverReward = 0,
                status = 1
            };
            lsVanTieu.Add(van);
            gcVehicle.DataSource = null;
            gcVehicle.DataSource = lsVanTieu.Where(x => x.status == 1);
            gvVehicle.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvVehicle.RowCount > 0)
            {
                int idVanTieu = (int)gvVehicle.GetRowCellValue(gvVehicle.FocusedRowHandle, "id");
                lsVanTieu.Where(x => x.id == idVanTieu).ToList().ForEach(x => x.status = 2);
                gcVehicle.DataSource = null;
                gcVehicle.DataSource = lsVanTieu.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvVehicle.RowCount > 0)
            {
                int idVanTieu = (int)gvVehicle.GetRowCellValue(gvVehicle.FocusedRowHandle, "id");
                dbVanTieuProtectReward van = new dbVanTieuProtectReward()
                {
                    amountMax = 1,
                    amountMin = 0,
                    id = -(lsProtectReward.Count),
                    idVanTieu = idVanTieu,
                    procs = 0,
                    staticID = 1,
                    status = 1,
                    typeReward = 3
                };
                lsProtectReward.Add(van);
                gcProtectReward.DataSource = null;
                gcProtectReward.DataSource = lsProtectReward.Where(x => x.status == 1 && x.idVanTieu == idVanTieu);
                gvProtectReward.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvProtectReward.RowCount > 0)
            {
                int idVanTieu = (int)gvVehicle.GetRowCellValue(gvVehicle.FocusedRowHandle, "id");
                int idPro = (int)gvProtectReward.GetRowCellValue(gvProtectReward.FocusedRowHandle, "id");

                lsProtectReward.Where(x => x.id == idPro).ToList().ForEach(x => x.status = 2);
                gcProtectReward.DataSource = null;
                gcProtectReward.DataSource = lsProtectReward.Where(x => x.status == 1 && x.idVanTieu == idVanTieu);
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            if (gvVehicle.RowCount > 0)
            {
                int idVanTieu = (int)gvVehicle.GetRowCellValue(gvVehicle.FocusedRowHandle, "id");
                dbVanTieuRobReward van = new dbVanTieuRobReward()
                {
                    amountMax = 1,
                    amountMin = 0,
                    id = -(lsRobReward.Count),
                    idVanTieu = idVanTieu,
                    procs = 0,
                    staticID = 1,
                    status = 1,
                    typeReward = 3
                };
                lsRobReward.Add(van);
                gcRobReward.DataSource = null;
                gcRobReward.DataSource = lsRobReward.Where(x => x.status == 1 && x.idVanTieu == idVanTieu);
                gvRobReward.MoveLast();
            }
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (gvRobReward.RowCount > 0)
            {
                int idVanTieu = (int)gvVehicle.GetRowCellValue(gvVehicle.FocusedRowHandle, "id");
                int idRob = (int)gvRobReward.GetRowCellValue(gvRobReward.FocusedRowHandle, "id");

                lsRobReward.Where(x => x.id == idRob).ToList().ForEach(x => x.status = 2);
                gcRobReward.DataSource = null;
                gcRobReward.DataSource = lsRobReward.Where(x => x.status == 1 && x.idVanTieu == idVanTieu);
            }
        }

        private void gvProtectReward_DoubleClick(object sender, EventArgs e)
        {
            dbVanTieuProtectReward rewardSelect = (dbVanTieuProtectReward)gvProtectReward.GetRow(gvProtectReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        private void gvRobReward_DoubleClick(object sender, EventArgs e)
        {
            dbVanTieuRobReward rewardSelect = (dbVanTieuRobReward)gvRobReward.GetRow(gvRobReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            gvProtectReward.FocusedRowHandle = -1;
            gvRobReward.FocusedRowHandle = -1;
            gvVanTieu.FocusedRowHandle = -1;
            gvVehicle.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsVanTieu)
            {
                if (item.id <= 0)
                {
                    dbVanTieu van = new dbVanTieu()
                    {
                        idConfig = item.idConfig,
                        procs = item.procs,
                        silverReward = item.silverReward,
                        status = item.status
                    };
                    ConnectDB.Entities.dbVanTieux.Add(van);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsProtectReward)
                    {
                        if (item1.idVanTieu == item.id)
                        {
                            dbVanTieuProtectReward pro = new dbVanTieuProtectReward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idVanTieu = van.id,
                                procs = item1.procs,
                                staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbVanTieuProtectRewards.Add(pro);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }

                    foreach (var item1 in lsRobReward)
                    {
                        if (item1.idVanTieu == item.id)
                        {
                            dbVanTieuRobReward pro = new dbVanTieuRobReward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idVanTieu = van.id,
                                procs = item1.procs,
                                staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbVanTieuRobRewards.Add(pro);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbVanTieux.Where(x => x.id == idGen).FirstOrDefault();
                    result.idConfig = item.idConfig;
                    result.procs = item.procs;
                    result.silverReward = item.silverReward;
                    result.status = item.status;
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsProtectReward)
                    {
                        if (item1.idVanTieu == item.id)
                        {
                            if (item1.id <= 0)
                            {
                                dbVanTieuProtectReward pro = new dbVanTieuProtectReward()
                                {
                                    amountMax = item1.amountMax,
                                    amountMin = item1.amountMin,
                                    idVanTieu = idGen,
                                    procs = item1.procs,
                                    staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                    status = item1.status,
                                    typeReward = item1.typeReward
                                };
                                ConnectDB.Entities.dbVanTieuProtectRewards.Add(pro);
                            }
                            else
                            {
                                int idPro = item1.id;
                                var result1 = ConnectDB.Entities.dbVanTieuProtectRewards.Where(x => x.id == idPro).FirstOrDefault();
                                result1.amountMax = item1.amountMax;
                                result1.amountMin = item1.amountMin;
                                result1.idVanTieu = idGen;
                                result1.procs = item1.procs;
                                result1.staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID);
                                result1.status = item1.status;
                                result1.typeReward = item1.typeReward;
                            }
                            ConnectDB.Entities.SaveChanges();
                        }
                    }

                    foreach (var item1 in lsRobReward)
                    {
                        if (item1.idVanTieu == item.id)
                        {
                            if (item1.id <= 0)
                            {
                                dbVanTieuRobReward pro = new dbVanTieuRobReward()
                                {
                                    amountMax = item1.amountMax,
                                    amountMin = item1.amountMin,
                                    idVanTieu = idGen,
                                    procs = item1.procs,
                                    staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                    status = item1.status,
                                    typeReward = item1.typeReward
                                };
                                ConnectDB.Entities.dbVanTieuRobRewards.Add(pro);
                            }
                            else
                            {
                                int idPro = item1.id;
                                var result1 = ConnectDB.Entities.dbVanTieuRobRewards.Where(x => x.id == idPro).FirstOrDefault();
                                result1.amountMax = item1.amountMax;
                                result1.amountMin = item1.amountMin;
                                result1.idVanTieu = idGen;
                                result1.procs = item1.procs;
                                result1.staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID);
                                result1.status = item1.status;
                                result1.typeReward = item1.typeReward;
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

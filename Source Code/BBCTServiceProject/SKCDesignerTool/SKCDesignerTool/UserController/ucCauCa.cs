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
    public partial class ucCauCa : ucManager
    {
        List<dbCauCaConfig> lsCauCa = new List<dbCauCaConfig>();
        List<dbCauCaReward> lsReward = new List<dbCauCaReward>();
        ListReward rewardhandler = new ListReward();

        public ucCauCa()
        {
            InitializeComponent();
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
        }

        private void LoadDataToList()
        {
            lsCauCa.Clear();
            lsReward.Clear();

            var tmpCauCa = from tmp in ConnectDB.Entities.dbCauCaConfigs
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpCauCa)
            {
                dbCauCaConfig cauca = new dbCauCaConfig()
                {
                    duration = item.duration,
                    gold = item.gold,
                    id = item.id,
                    idConfig = item.idConfig,
                    name = item.name,
                    silver = item.silver,
                    status = item.status,
                    vipRequire = item.vipRequire
                };
                lsCauCa.Add(cauca);

                var tmpReward = from tmp in ConnectDB.Entities.dbCauCaRewards
                                where tmp.status == 1 && tmp.idCauca == item.id
                                select tmp;

                foreach (var item1 in tmpReward)
                {
                    dbCauCaReward reward = new dbCauCaReward()
                    {
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin,
                        id = item1.id,
                        idCauca = item1.idCauca,
                        procs = item1.procs,
                        staticID = rewardhandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward
                    };
                    lsReward.Add(reward);
                }
            }
            gcChung.DataSource = null;
            gcChung.DataSource = lsCauCa;
        }

        private void gvChung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvChung.RowCount > 0)
            {
                int idGen = (int)gvChung.GetRowCellValue(gvChung.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idCauca == idGen);
            }
        }

        private void LoadDataToLUE()
        {
            var tmpTypeReward = from stage in ConnectDB.Entities.dbCTTypeRewards
                                select stage;
            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueStaticID.DataSource = rewardhandler.LoadTotalReward();
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbCauCaReward rewardSelect = (dbCauCaReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbCauCaConfig cauca = new dbCauCaConfig()
            {
                duration = 0,
                gold = 0,
                id = -(lsCauCa.Count),
                idConfig = 1,
                name = "name",
                silver = 0,
                status = 1,
                vipRequire = 1
            };
            lsCauCa.Add(cauca);
            gcChung.DataSource = null;
            gcChung.DataSource = lsCauCa.Where(x => x.status == 1);
            gvChung.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvChung.RowCount > 0)
            {
                int idGen = (int)gvChung.GetRowCellValue(gvChung.FocusedRowHandle, "id");
                lsCauCa.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcChung.DataSource = null;
                gcChung.DataSource = lsCauCa.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvChung.RowCount > 0)
            {
                int idGen = (int)gvChung.GetRowCellValue(gvChung.FocusedRowHandle, "id");
                dbCauCaReward cauca = new dbCauCaReward()
                {
                    amountMax = 1,
                    amountMin = 0,
                    id = -(lsReward.Count),
                    idCauca = idGen,
                    procs = 0,
                    status = 1,
                    staticID = 1,
                    typeReward = 3
                };
                lsReward.Add(cauca);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idCauca == idGen);
                gvReward.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idGen = (int)gvChung.GetRowCellValue(gvChung.FocusedRowHandle, "id");
                int idReward = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");
                lsReward.Where(x => x.id == idReward).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idCauca == idGen);
            }
        }

        protected override void OnSave()
        {
            gvChung.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsCauCa)
            {
                if (item.id <= 0)
                {
                    dbCauCaConfig cauca = new dbCauCaConfig()
                    {
                        duration = item.duration,
                        gold = item.gold,
                        idConfig = item.idConfig,
                        name = item.name,
                        silver = item.silver,
                        status = item.status,
                        vipRequire = item.vipRequire
                    };
                    ConnectDB.Entities.dbCauCaConfigs.Add(cauca);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsReward)
                    {
                        if (item1.idCauca == item.id)
                        {
                            dbCauCaReward reward = new dbCauCaReward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idCauca = cauca.id,
                                procs = item1.procs,
                                staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbCauCaRewards.Add(reward);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }
                }
                else
                {
                    int idCau = item.id;
                    var result = ConnectDB.Entities.dbCauCaConfigs.Where(x => x.id == idCau).FirstOrDefault();
                    result.duration = item.duration;
                    result.gold = item.gold;
                    result.idConfig = item.idConfig;
                    result.name = item.name;
                    result.silver = item.silver;
                    result.status = item.status;
                    result.vipRequire = item.vipRequire;

                    foreach (var item1 in lsReward)
                    {
                        if (item1.idCauca == item.id)
                        {
                            if (item1.id <= 0)
                            {
                                dbCauCaReward reward = new dbCauCaReward()
                                {
                                    amountMax = item1.amountMax,
                                    amountMin = item1.amountMin,
                                    idCauca = idCau,
                                    procs = item1.procs,
                                    staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                    status = item1.status,
                                    typeReward = item1.typeReward
                                };
                                ConnectDB.Entities.dbCauCaRewards.Add(reward);
                            }
                            else
                            {
                                int idRe = item1.id;
                                var result1 = ConnectDB.Entities.dbCauCaRewards.Where(x => x.id == idRe).FirstOrDefault();
                                result1.amountMax = item1.amountMax;
                                result1.amountMin = item1.amountMin;
                                result1.idCauca = idCau;
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
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}

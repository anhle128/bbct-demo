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
    public partial class frmBangChien : frmFormChange
    {
        ListReward rewardhandler = new ListReward();
        List<dbGuildRewardBangChien> lsReward = new List<dbGuildRewardBangChien>();

        public frmBangChien()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
        }

        private void LoadDataToLUE()
        {
            var tmpTypeReward = from stage in ConnectDB.Entities.dbCTTypeRewards
                                select stage;
            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueStaticID.DataSource = rewardhandler.LoadTotalReward();

            List<dbCTAffliction> tmpNgay = new List<dbCTAffliction>();
            dbCTAffliction ct = new dbCTAffliction()
            {
                id = 0,
                value = "Chủ nhật"
            };
            tmpNgay.Add(ct);
            dbCTAffliction ct1 = new dbCTAffliction()
            {
                id = 1,
                value = "Thứ 2"
            };
            tmpNgay.Add(ct1);
            dbCTAffliction ct2 = new dbCTAffliction()
            {
                id = 2,
                value = "Thứ 3"
            };
            tmpNgay.Add(ct2);
            dbCTAffliction ct3 = new dbCTAffliction()
            {
                id = 3,
                value = "Thứ 4"
            };
            tmpNgay.Add(ct3);
            dbCTAffliction ct4 = new dbCTAffliction()
            {
                id = 4,
                value = "Thứ 5"
            };
            tmpNgay.Add(ct4);
            dbCTAffliction ct5 = new dbCTAffliction()
            {
                id = 5,
                value = "Thứ 6"
            };
            tmpNgay.Add(ct5);
            dbCTAffliction ct6 = new dbCTAffliction()
            {
                id = 6,
                value = "Thứ 7"
            };
            tmpNgay.Add(ct6);

            lueNgay.DataSource = tmpNgay;
        }

        private void LoadDataToList()
        {
            lsReward.Clear();
            var tmpGuild = from tmp in ConnectDB.Entities.dbGuildConfigs
                           select tmp;

            gcThongTin.DataSource = null;
            gcThongTin.DataSource = tmpGuild.ToList();

            var tmpReward = from tmp in ConnectDB.Entities.dbGuildRewardBangChiens
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbGuildRewardBangChien re = new dbGuildRewardBangChien()
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
                lsReward.Add(re);
            }
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbGuildRewardBangChien rewardSelect = (dbGuildRewardBangChien)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dbGuildRewardBangChien db = new dbGuildRewardBangChien()
            {
                amountMax = 1,
                amountMin = 0,
                id = -(lsReward.Count),
                idGuild = 1,
                procs = 0,
                staticID = 1,
                typeReward = 2,
                status = 1
            };
            lsReward.Add(db);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
            gvReward.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
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
            CommonShowDialog.ShowWaitForm();
            gvReward.FocusedRowHandle = -1;
            gridView1.FocusedRowHandle = -1;

            foreach (var item in lsReward)
            {
                if (item.id <= 0)
                {
                    dbGuildRewardBangChien db = new dbGuildRewardBangChien()
                    {
                        amountMax = item.amountMax,
                        amountMin = item.amountMin,
                        idGuild = item.idGuild,
                        procs = item.procs,
                        staticID = rewardhandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID),
                        status = item.status,
                        typeReward = item.typeReward
                    };
                    ConnectDB.Entities.dbGuildRewardBangChiens.Add(db);
                }
                else
                {
                    var result = ConnectDB.Entities.dbGuildRewardBangChiens.Where(x => x.id == item.id).FirstOrDefault();
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
            LoadDataToList();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}
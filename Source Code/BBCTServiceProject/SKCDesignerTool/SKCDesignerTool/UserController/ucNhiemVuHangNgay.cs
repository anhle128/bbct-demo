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
    public partial class ucNhiemVuHangNgay : ucManager
    {
        List<dbNhiemVuHangNgayReward> lsReward = new List<dbNhiemVuHangNgayReward>();
        ListReward rewardhandler = new ListReward();
        public ucNhiemVuHangNgay()
        {
            InitializeComponent();
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList();
            LoadDataToLUE();
            LoadDataToGC();
        }

        private void LoadDataToGC()
        {
            var tmpCOnfig = ConnectDB.Entities.dbNhiemVuHangNgayConfigs.FirstOrDefault();
            txtGoldRequireCompolete.Text = tmpCOnfig.goldRequireCompolete.ToString();

            var tmpNhiemVu = from tmp in ConnectDB.Entities.dbNhiemVuHangNgays
                             where tmp.status == 1
                             select tmp;

            gcNhiemVu.DataSource = null;
            gcNhiemVu.DataSource = tmpNhiemVu.ToList();
        }

        private void LoadDataToList()
        {
            lsReward.Clear();
            var tmpNhiemVu = from tmp in ConnectDB.Entities.dbNhiemVuHangNgays
                             where tmp.status == 1
                             select tmp;

            foreach (var item in tmpNhiemVu)
            {
                var tmpReward = from tmp in ConnectDB.Entities.dbNhiemVuHangNgayRewards
                                where tmp.idNhiemVu == item.id
                                select tmp;

                foreach (var item1 in tmpReward)
                {
                    dbNhiemVuHangNgayReward reward = new dbNhiemVuHangNgayReward()
                    {
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin,
                        id = item1.id,
                        idNhiemVu = item1.idNhiemVu,
                        procs = item1.procs,
                        staticID = rewardhandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward
                    };
                    lsReward.Add(reward);
                }
            }
        }

        private void LoadDataToLUE()
        {
            var tmpTypeReward = from stage in ConnectDB.Entities.dbCTTypeRewards
                                select stage;
            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueStaticID.DataSource = rewardhandler.LoadTotalReward();
        }

        private void gcReward_DoubleClick(object sender, EventArgs e)
        {
            dbNhiemVuHangNgayReward rewardSelect = (dbNhiemVuHangNgayReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        private void gvNhiemVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvNhiemVu.RowCount > 0)
            {
                int idGen = (int)gvNhiemVu.GetRowCellValue(gvNhiemVu.FocusedRowHandle, "id");
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idNhiemVu == idGen);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            int idGen = (int)gvNhiemVu.GetRowCellValue(gvNhiemVu.FocusedRowHandle, "id");
            dbNhiemVuHangNgayReward nhiem = new dbNhiemVuHangNgayReward()
            {
                amountMax = 0,
                amountMin = 0,
                id = -(lsReward.Count),
                idNhiemVu = idGen,
                procs = 100,
                staticID = 1,
                status = 1,
                typeReward = 2
            };
            lsReward.Add(nhiem);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idNhiemVu == idGen);
            gvReward.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idGen = (int)gvNhiemVu.GetRowCellValue(gvNhiemVu.FocusedRowHandle, "id");
                int idReward = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");
                lsReward.Where(x => x.id == idReward).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idNhiemVu == idGen);
            }
        }

        protected override void OnSave()
        {
            gvNhiemVu.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item1 in lsReward)
            {
                if (item1.id <= 0)
                {
                    dbNhiemVuHangNgayReward reward = new dbNhiemVuHangNgayReward()
                    {
                        amountMax = item1.amountMax,
                        amountMin = item1.amountMin,
                        idNhiemVu = item1.idNhiemVu,
                        procs = item1.procs,
                        staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        typeReward = item1.typeReward
                    };
                    ConnectDB.Entities.dbNhiemVuHangNgayRewards.Add(reward);
                }
                else
                {
                    var result = ConnectDB.Entities.dbNhiemVuHangNgayRewards.Where(x => x.id == item1.id).FirstOrDefault();
                    result.amountMax = item1.amountMax;
                    result.amountMin = item1.amountMin;
                    result.idNhiemVu = item1.idNhiemVu;
                    result.procs = item1.procs;
                    result.staticID = rewardhandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID);
                    result.status = item1.status;
                    result.typeReward = item1.typeReward;
                }
                ConnectDB.Entities.SaveChanges();
            }

            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thàng công!");
        }
    }
}

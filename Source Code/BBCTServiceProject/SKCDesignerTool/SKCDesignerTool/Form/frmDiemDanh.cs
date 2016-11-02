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
    public partial class frmDiemDanh : frmFormChange
    {
        ListReward rewardHandler = new ListReward();
        List<dbHoatDongDiemDanhMonth> lsMonth = new List<dbHoatDongDiemDanhMonth>();
        List<dbHoatDongDiemDanhMonthReward> lsReward = new List<dbHoatDongDiemDanhMonthReward>();

        public frmDiemDanh()
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
            lsMonth.Clear();
            lsReward.Clear();

            int lastDate = int.Parse(DateTime.DaysInMonth(DateTime.Now.Year, 2).ToString());
            var tmpReward1 = ConnectDB.Entities.dbHoatDongDiemDanhMonthRewards.Where(x => x.date == 29 && x.idMonth == 2).FirstOrDefault();
            if (lastDate == 28)
            {
                tmpReward1.status = 2;
            }
            else
            {
                tmpReward1.status = 1;
            }
            ConnectDB.Entities.SaveChanges();

            var tmpConfig = ConnectDB.Entities.dbHoatDongDiemDanhConfigs.FirstOrDefault();
            txtGold.Text = tmpConfig.goldRequireBuyMissingReward.ToString();

            var tmpThang = from tmp in ConnectDB.Entities.dbHoatDongDiemDanhMonths
                           where tmp.status == 1
                           select tmp;

            foreach (var item in tmpThang)
            {
                dbHoatDongDiemDanhMonth month = new dbHoatDongDiemDanhMonth()
                {
                    id = item.id,
                    idDiemDanh = item.idDiemDanh,
                    months = item.months,
                    status = item.status
                };
                lsMonth.Add(month);
            }

            var tmpReward = from tmp in ConnectDB.Entities.dbHoatDongDiemDanhMonthRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbHoatDongDiemDanhMonthReward re = new dbHoatDongDiemDanhMonthReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    date = item.date,
                    id = item.id,
                    idMonth = item.idMonth,
                    procs = item.procs,
                    staticID = rewardHandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsReward.Add(re);
            }
            gcReward.DataSource = null;
            gcThang.DataSource = null;
            gcThang.DataSource = lsMonth;
        }

        protected override void OnSave()
        {
            gvReward.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            var tmpConfig = ConnectDB.Entities.dbHoatDongDiemDanhConfigs.FirstOrDefault();
            tmpConfig.goldRequireBuyMissingReward = int.Parse(txtGold.Text);

            foreach (var item in lsReward)
            {
                var result = ConnectDB.Entities.dbHoatDongDiemDanhMonthRewards.Where(x => x.id == item.id).FirstOrDefault();
                result.amountMax = item.amountMax;
                result.amountMin = item.amountMin;
                result.date = item.date;
                result.id = item.id;
                result.idMonth = item.idMonth;
                result.procs = item.procs;
                result.staticID = rewardHandler.HandlerSaveStaticID((int)item.typeReward, (int)item.staticID);
                result.status = item.status;
                result.typeReward = item.typeReward;
                ConnectDB.Entities.SaveChanges();
            }
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void gvThang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvThang.RowCount > 0)
            {
                int idThang = (int)gvThang.GetRowCellValue(gvThang.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.idMonth == idThang);
            }
        }

        private void gcReward_DoubleClick(object sender, EventArgs e)
        {
            dbHoatDongDiemDanhMonthReward rewardSelect = (dbHoatDongDiemDanhMonthReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null, null, null, null, null, null, null, null, null, null, null);
            formTask.ShowDialog();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CommonShowDialog.ShowWaitForm();
            var tmpThang1 = from tmp in ConnectDB.Entities.dbHoatDongDiemDanhMonthRewards
                            where tmp.idMonth == 1
                            select tmp;

            foreach (var item in tmpThang1)
            {
                for (int i = 2; i < 13; i++)
                {
                    var tmpThang = ConnectDB.Entities.dbHoatDongDiemDanhMonthRewards.Where(x => x.date == item.date && x.idMonth == i).FirstOrDefault();
                    if (tmpThang != null)
                    {
                        tmpThang.procs = item.procs;
                        tmpThang.staticID = item.staticID;
                        tmpThang.typeReward = item.typeReward;
                        tmpThang.amountMax = item.amountMax;
                        tmpThang.amountMin = item.amountMin;
                    }
                }
            }
            ConnectDB.Entities.SaveChanges();

            LoadDataToList();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Copy dữ liệu thành công!");
        }
    }
}
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

namespace KDQHDesignerTool.UserController
{
    public partial class ucCuopTieu : ucManager
    {
        public ucCuopTieu()
        {
            InitializeComponent();
            LoadDataToGC();
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void LoadDataToGC()
        {
            var tmpCuopTieu = from tmp in ConnectDB.Entities.dbCuopTieuConfigs
                              select tmp;
            gcCuopTieu.DataSource = tmpCuopTieu.ToList();
        }

        protected override void OnSave()
        {
            gvCuopTieu.FocusedRowHandle = -1;
            ConnectDB.Entities.SaveChanges();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công");
        }
    }
}

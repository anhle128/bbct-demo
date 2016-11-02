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
using BBCTDesignerTool.Common;

namespace BBCTDesignerTool.UserController
{
    public partial class ucVipConfig : ucManager
    {
        public ucVipConfig()
        {
            InitializeComponent();
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToGC();
        }

        private void LoadDataToGC()
        {
            var tmpVipConfig = from tmp in ConnectDB.Entities.dbVipConfigs
                               where tmp.status == 1
                               select tmp;

            gcVip.DataSource = tmpVipConfig.ToList();
        }

        protected override void OnSave()
        {
            gvVip.FocusedRowHandle = -1;
            ConnectDB.Entities.SaveChanges();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}

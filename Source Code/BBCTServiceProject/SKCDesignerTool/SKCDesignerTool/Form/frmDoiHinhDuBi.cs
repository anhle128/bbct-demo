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
    public partial class frmDoiHinhDuBi : frmFormChange
    {
        public frmDoiHinhDuBi()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList(); 
        }

        private void LoadDataToList() 
        {
            var tmpData = from tmp in ConnectDB.Entities.dbDoiHinhDuBiRequires
                          where tmp.status == 1
                          select tmp;

            gcConfig.DataSource = null;
            gcConfig.DataSource = tmpData.ToList();
        }

        protected override void OnSave()
        {
            gvConfig.FocusedRowHandle = -1;
            ConnectDB.Entities.SaveChanges();
            LoadDataToList();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}
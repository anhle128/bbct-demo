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
    public partial class frmTutorial : frmFormChange
    {
        public frmTutorial()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToGC();
        }

        private void LoadDataToGC() 
        {
            var tmpTuto = from tmp in ConnectDB.Entities.dbTutorialConfigs
                          select tmp;

            gcTuto.DataSource = null;
            gcTuto.DataSource = tmpTuto.ToList();
        }

        protected override void OnSave()
        {
            gridView1.FocusedRowHandle = -1;
            ConnectDB.Entities.SaveChanges();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}
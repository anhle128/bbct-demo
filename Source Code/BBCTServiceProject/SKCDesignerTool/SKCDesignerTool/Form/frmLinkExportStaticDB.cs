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

namespace BBCTDesignerTool.Form
{
    public partial class frmLinkExportStaticDB : frmFormChange
    {
        List<MChooseLinkStaticDB> lsChar = new List<MChooseLinkStaticDB>();
        public frmLinkExportStaticDB(List<MChooseLinkStaticDB> tmpLsChar)
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lsChar = tmpLsChar;
            LoadDataToGC();
        }

        private void LoadDataToGC()
        {
            gcChoose.DataSource = null;
            gcChoose.DataSource = lsChar;
        }

        protected override void OnSave()
        {
            gvChoose.FocusedRowHandle = -1;
            this.Close();
        }
    }
}
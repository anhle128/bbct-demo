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

namespace BBCTDesignerTool.FormBase
{
    public partial class frmFormChange : DevExpress.XtraEditors.XtraForm
    {
        public frmFormChange()
        {
            InitializeComponent();
        }

        private void btnUpload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnUpload();
        }

        protected virtual void OnUpload()
        {

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSave();
        }

        protected virtual void OnSave()
        {

        }
    }
}
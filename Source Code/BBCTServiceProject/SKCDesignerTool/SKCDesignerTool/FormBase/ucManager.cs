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

namespace BBCTDesignerTool.FormBase
{
    public partial class ucManager : DevExpress.XtraEditors.XtraUserControl
    {
        public ucManager()
        {
            InitializeComponent();
        }

        private void ucManager_Load(object sender, EventArgs e)
        {

        }

        private void btnTaoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnAdd();
        }

        protected virtual void OnAdd() { }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnChange();
        }
        protected virtual void OnChange() { }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnDelete();
        }

        protected virtual void OnDelete() { }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSave();
        }

        protected virtual void OnSave() { }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnRefesh();
        }

        protected virtual void OnRefesh() { }
    }
}

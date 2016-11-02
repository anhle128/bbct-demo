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
using KDQHNPHTool.Model;

namespace KDQHNPHTool.FormBase
{
    public partial class ucManager : DevExpress.XtraEditors.XtraUserControl
    {
        public ucManager()
        {
            InitializeComponent();
            if (UserSession.TypeUser == 2)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnTaoMoi.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnDetail();
        }

        protected virtual void OnDetail() { }

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

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnRefesh();
        }

        protected virtual void OnRefesh() { }
    }
}

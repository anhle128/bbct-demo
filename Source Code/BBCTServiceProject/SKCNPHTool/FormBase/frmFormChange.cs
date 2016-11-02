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
using KDQHNPHTool.Model;

namespace KDQHNPHTool.FormBase
{
    public partial class frmFormChange : DevExpress.XtraEditors.XtraForm
    {
        public frmFormChange()
        {
            InitializeComponent();
            if (UserSession.TypeUser == 2) 
            {
                btnAdd.Enabled = false;
                btnExcel.Enabled = false;
                btnLuu.Enabled = false;
                btnSendMail.Enabled = false;
            }
        }

        protected virtual void OnSave() { }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSave();
        }

        private void btnSendMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSendMail();
        }

        protected virtual void OnSendMail() { }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnAdd();
        }

        protected virtual void OnAdd() { }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnExportExcel();
        }

        protected virtual void OnExportExcel() { }
    }
}
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
using KDQHNPHTool.FormBase;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Common;
using KDQHNPHTool.Form;

namespace KDQHNPHTool
{
    public partial class frmGiftCode : frmFormChange
    {
        public frmGiftCode()
        {
            InitializeComponent();
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
        }

        private void LoadDataToLUE()
        {
            List<vGiftCode> lsTmp = new List<vGiftCode>();
            var tmpSk = MongoController.GiftCodeCategory.GetListData(MongoController.DatabaseManager.main_database, a => true);
            if (tmpSk.Count > 0)
            {
                foreach (var item in tmpSk)
                {
                    vGiftCode gift = new vGiftCode()
                    {
                        category = item._id.ToString(),
                        code = item.name
                    };
                    lsTmp.Add(gift);
                }
                lueType.DataSource = lsTmp;
            }
        }

        private void LoadDataToList()
        {
            List<vGiftCode> lsGiftCode = new List<vGiftCode>();
            var tmpSk = MongoController.GiftCode.GetListData(MongoController.DatabaseManager.main_database, a => a.username == null);
            if (tmpSk.Count > 0)
            {
                foreach (var item in tmpSk)
                {
                    vGiftCode gift = new vGiftCode()
                    {
                        category = item.category,
                        code = item.code
                    };
                    lsGiftCode.Add(gift);
                }
                gcGiftCode.DataSource = null;
                gcGiftCode.DataSource = lsGiftCode;
            }
        }

        protected override void OnExportExcel()
        {
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.DefaultExt = "*.xlsx";
            saveFileDialog1.Filter = "Excel(*.xlsx)|*.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                gcGiftCode.ExportToXlsx(saveFileDialog1.FileName);
                CommonShowDialog.ShowSuccessfulDialog("Xuất file excel thành công!");
            }

        }

        protected override void OnAdd()
        {
            frmTaoGiftCode frm = new frmTaoGiftCode();
            frm.ShowDialog();
            LoadDataToList();
        }
    }
}
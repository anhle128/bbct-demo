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
using KDQHDesignerTool.FormBase;
using KDQHDesignerTool.Models;
using KDQHDesignerTool.Common;

namespace KDQHDesignerTool.Form
{
    public partial class frmTips : frmFormChange
    {
        List<dbTip> lsTip = new List<dbTip>();

        public frmTips()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList();
        }

        private void LoadDataToList()
        {
            lsTip.Clear();
            var tmpTip = from tmp in ConnectDB.Entities.dbTips
                         where tmp.status == 1
                         select tmp;

            foreach (var item in tmpTip)
            {
                dbTip db = new dbTip()
                {
                    id = item.id,
                    keywords = item.keywords,
                    status = item.status
                };
                lsTip.Add(db);
            }

            gcTips.DataSource = null;
            gcTips.DataSource = lsTip.Where(x => x.status == 1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dbTip db = new dbTip()
            {
                id = -(lsTip.Count()),
                keywords = "Nhập tips",
                status = 1
            };
            lsTip.Add(db);
            gcTips.DataSource = null;
            gcTips.DataSource = lsTip.Where(x => x.status == 1);
            gvTips.MoveLast();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvTips.RowCount > 0)
            {
                int idTip = (int)gvTips.GetRowCellValue(gvTips.FocusedRowHandle, "id");
                lsTip.Where(x => x.id == idTip).ToList().ForEach(x => x.status = 2);
                gcTips.DataSource = null;
                gcTips.DataSource = lsTip.Where(x => x.status == 1);
            }
        }

        protected override void OnSave()
        {
            gvTips.FocusedRowHandle = -1;

            foreach (var item in lsTip)
            {
                if (item.id <= 0)
                {
                    dbTip db = new dbTip()
                    {
                        keywords = item.keywords,
                        status = item.status
                    };
                    ConnectDB.Entities.dbTips.Add(db);
                }
                else
                {
                    var result = ConnectDB.Entities.dbTips.Where(x => x.id == item.id).FirstOrDefault();
                    result.keywords = item.keywords;
                    result.status = item.status;
                }
                ConnectDB.Entities.SaveChanges();
            }

            LoadDataToList();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}
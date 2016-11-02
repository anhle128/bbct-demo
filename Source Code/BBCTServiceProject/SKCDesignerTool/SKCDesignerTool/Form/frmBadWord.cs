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
    public partial class frmBadWord : frmFormChange
    {
        List<dbBadWord> lsBadWord = new List<dbBadWord>();

        public frmBadWord()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList();
        }

        private void LoadDataToList()
        {
            lsBadWord.Clear();
            var tmpBadWord = from tmp in ConnectDB.Entities.dbBadWords
                             where tmp.status == 1
                             orderby tmp.keys ascending
                             select tmp;

            foreach (var item in tmpBadWord)
            {
                dbBadWord bad = new dbBadWord()
                {
                    id = item.id,
                    keys = item.keys,
                    status = item.status
                };
                lsBadWord.Add(bad);
            }

            gcTuNguCam.DataSource = null;
            gcTuNguCam.DataSource = lsBadWord;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dbBadWord bad = new dbBadWord()
            {
                id = -(lsBadWord.Count),
                keys = "Từ cấm",
                status = 1
            };
            lsBadWord.Add(bad);
            gcTuNguCam.DataSource = null;
            gcTuNguCam.DataSource = lsBadWord.Where(x => x.status == 1);
            gvTuNguCam.MoveLast();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvTuNguCam.RowCount > 0)
            {
                int idTuCam = (int)gvTuNguCam.GetRowCellValue(gvTuNguCam.FocusedRowHandle, "id");
                lsBadWord.Where(x => x.id == idTuCam).ToList().ForEach(x => x.status = 2);
                gcTuNguCam.DataSource = null;
                gcTuNguCam.DataSource = lsBadWord.Where(x => x.status == 1);
            }
        }

        protected override void OnSave()
        {
            CommonShowDialog.ShowWaitForm();
            gvTuNguCam.FocusedRowHandle = -1;
            foreach (var item in lsBadWord)
            {
                if (item.id < 0)
                {
                    dbBadWord bad = new dbBadWord()
                    {
                        keys = item.keys,
                        status = item.status
                    };
                    ConnectDB.Entities.dbBadWords.Add(bad);
                }
                else
                {
                    int idTuNgu = item.id;
                    var result = ConnectDB.Entities.dbBadWords.Where(x => x.id == idTuNgu).FirstOrDefault();
                    result.keys = item.keys;
                    result.status = item.status;
                }
                ConnectDB.Entities.SaveChanges();
            }
            LoadDataToList();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công");
        }
    }
}
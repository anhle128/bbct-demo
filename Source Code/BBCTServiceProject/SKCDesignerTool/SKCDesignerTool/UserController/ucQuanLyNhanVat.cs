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
using BBCTDesignerTool.FormBase;
using BBCTDesignerTool.Models;
using BBCTDesignerTool.Common;
using BBCTDesignerTool.Form;

namespace BBCTDesignerTool.UserController
{
    public partial class ucQuanLyNhanVat : ucManager
    {
        public ucQuanLyNhanVat()
        {
            InitializeComponent();
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToGC();
        }

        private void LoadDataToGC()
        {
            var tmpCharacter = from tmp in ConnectDB.Entities.dbCharacters
                               where tmp.status == 1
                               orderby tmp.idCharacter ascending
                               select tmp;

            gcCharacter.DataSource = tmpCharacter.ToList();
        }

        private void LoadDataToLUE()
        {
            var tmpLueCategory = from tmp in ConnectDB.Entities.dbCTCategoryCharacters
                                 select tmp;
            lueCategory.DataSource = tmpLueCategory.ToList();

            var tmpLueClass = from tmp in ConnectDB.Entities.dbCTClassCharacters
                              select tmp;
            lueClassCharacter.DataSource = tmpLueClass.ToList();

            var tmpLuePromotion = from tmp in ConnectDB.Entities.dbCTPromotionCharacters
                                  select tmp;
            luePromotion.DataSource = tmpLuePromotion.ToList();

            List<String> lsStringmain = new List<string>();
            lsStringmain.Add("Chính");
            lsStringmain.Add("Phụ");

            lueMainCharacter.DataSource = lsStringmain.ToList();
        }

        protected override void OnDelete()
        {
            DialogResult dr = new DialogResult();
            dr = CommonShowDialog.ShowYesNoDialog("Bạn có chắc muốn xóa nhân vật này?");
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                int idChar = (int)gvCharacter.GetRowCellValue(gvCharacter.FocusedRowHandle, "id");
                var result = ConnectDB.Entities.dbCharacters.Where(x => x.id == idChar).FirstOrDefault();
                result.status = 2;
                ConnectDB.Entities.SaveChanges();
                CommonShowDialog.ShowSuccessfulDialog("Xóa nhân vật thành công!");
                OnRefesh();
            }
        }

        protected override void OnAdd()
        {
            frmDetailCharater frm = new frmDetailCharater(0);
            frm.ShowDialog();
        }

        protected override void OnChange()
        {
            if (gvCharacter.RowCount > 0)
            {
                int idChr = (int)gvCharacter.GetRowCellValue(gvCharacter.FocusedRowHandle, "id");
                frmDetailCharater frm = new frmDetailCharater(idChr);
                frm.ShowDialog();
            }
        }

        protected override void OnRefesh()
        {
            LoadDataToGC();
        }
    }
}

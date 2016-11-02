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
using KDQHDesignerTool.FormBase;
using KDQHDesignerTool.Models;
using KDQHDesignerTool.Common;

namespace KDQHDesignerTool.UserController
{
    public partial class ucCharacterConfig : ucManager
    {
        List<dbCharSelection> lsSelection = new List<dbCharSelection>();
        List<dbCharacterLevelExp> lsEXP = new List<dbCharacterLevelExp>();

        public ucCharacterConfig()
        {
            InitializeComponent();
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsSelection.Clear();
            lsEXP.Clear();

            var tmpSelection = from tmp in ConnectDB.Entities.dbCharSelections
                               where tmp.status == 1
                               select tmp;

            foreach (var item in tmpSelection)
            {
                dbCharSelection chr = new dbCharSelection()
                {
                    id = item.id,
                    idChr = item.idChr,
                    background = item.background,
                    status = item.status
                };
                lsSelection.Add(chr);
            }

            var tmpExp = from tmp in ConnectDB.Entities.dbCharacterLevelExps
                         where tmp.status == 1
                         select tmp;

            foreach (var item in tmpExp)
            {
                dbCharacterLevelExp level = new dbCharacterLevelExp()
                {
                    exps = item.exps,
                    id = item.id,
                    levels = item.levels,
                    status = item.status
                };
                lsEXP.Add(level);
            }

            var tmpConf = ConnectDB.Entities.dbCharacterConfigs;
            gcConfig.DataSource = tmpConf.ToList();
        }

        private void LoadDataToLUE()
        {
            var tmpCharacter = from tmp in ConnectDB.Entities.dbCharacters
                               where tmp.status == 1
                               orderby tmp.idCharacter ascending
                               select new
                               {
                                   tmp.idCharacter,
                                   tmp.name
                               };

            lueCharacterSelection.DataSource = tmpCharacter.ToList();
        }

        private void LoadDataToGC()
        {
            var tmpChacterConfig = from tmp in ConnectDB.Entities.dbCharDefaultConfigs
                                   select tmp;

            gcDefaultConfig.DataSource = null;
            gcDefaultConfig.DataSource = tmpChacterConfig.ToList();
            gcLevelEXP.DataSource = null;
            gcLevelEXP.DataSource = lsEXP;
            gcCharSelection.DataSource = null;
            gcCharSelection.DataSource = lsSelection;
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbCharSelection chr = new dbCharSelection()
            {
                id = -(lsSelection.Count),
                idChr = 1,
                background = 1,
                status = 1
            };
            lsSelection.Add(chr);
            gcCharSelection.DataSource = null;
            gcCharSelection.DataSource = lsSelection.Where(x => x.status == 1);
            gvCharSelection.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvCharSelection.RowCount > 0)
            {
                int idAtt = (int)gvCharSelection.GetRowCellValue(gvCharSelection.FocusedRowHandle, "id");
                lsSelection.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcCharSelection.DataSource = null;
                gcCharSelection.DataSource = lsSelection.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            dbCharacterLevelExp chr = new dbCharacterLevelExp()
            {
                id = -(lsEXP.Count),
                exps = 0,
                levels = lsEXP.Count + 1,
                status = 1
            };
            lsEXP.Add(chr);
            gcLevelEXP.DataSource = null;
            gcLevelEXP.DataSource = lsEXP.Where(x => x.status == 1);
            gvLevelEXP.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvLevelEXP.RowCount > 0)
            {
                int idAtt = (int)gvLevelEXP.GetRowCellValue(gvLevelEXP.FocusedRowHandle, "id");
                lsEXP.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcLevelEXP.DataSource = null;
                gcLevelEXP.DataSource = lsEXP.Where(x => x.status == 1);
            }
        }

        protected override void OnSave()
        {
            gvCharSelection.FocusedRowHandle = -1;
            gvDefaultConfig.FocusedRowHandle = -1;
            gvLevelEXP.FocusedRowHandle = -1;
            gvConfig.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsSelection)
            {
                if (item.id <= 0)
                {
                    dbCharSelection chr = new dbCharSelection()
                    {
                        idChr = item.idChr,
                        background = item.background,
                        status = item.status
                    };
                    ConnectDB.Entities.dbCharSelections.Add(chr);
                }
                else
                {
                    int idSelect = item.id;
                    var result = ConnectDB.Entities.dbCharSelections.Where(x => x.id == idSelect).FirstOrDefault();
                    result.idChr = item.idChr;
                    result.background = item.background;
                    result.status = item.status;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsEXP)
            {
                if (item.id <= 0)
                {
                    dbCharacterLevelExp chr = new dbCharacterLevelExp()
                    {
                        exps = item.exps,
                        levels = item.levels,
                        status = item.status
                    };
                    ConnectDB.Entities.dbCharacterLevelExps.Add(chr);
                }
                else
                {
                    int idSelect = item.id;
                    var result = ConnectDB.Entities.dbCharacterLevelExps.Where(x => x.id == idSelect).FirstOrDefault();
                    result.exps = item.exps;
                    result.levels = item.levels;
                    result.status = item.status;
                }
                ConnectDB.Entities.SaveChanges();
            }

            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}

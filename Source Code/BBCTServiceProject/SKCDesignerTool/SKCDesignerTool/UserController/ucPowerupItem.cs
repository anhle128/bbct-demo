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

namespace BBCTDesignerTool.UserController
{
    public partial class ucPowerupItem : ucManager
    {
        List<dbPowerUpItem> lsPower = new List<dbPowerUpItem>();
        List<dbPowerUpItemsAttribute> lsAttribute = new List<dbPowerUpItemsAttribute>();

        public ucPowerupItem()
        {
            InitializeComponent();
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList();
            LoadDataToLUE();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsPower.Clear();
            lsAttribute.Clear();
            var tmpPowerYp = from tmp in ConnectDB.Entities.dbPowerUpItems
                             where tmp.status == 1
                             select tmp;

            foreach (var item in tmpPowerYp)
            {
                dbPowerUpItem power = new dbPowerUpItem()
                {
                    id = item.id,
                    description = item.description,
                    idPowerUpItems = item.idPowerUpItems,
                    levelRequire = item.levelRequire,
                    name = item.name,
                    promotion = item.promotion,
                    status = item.status
                };
                lsPower.Add(power);

                var tmpAttribute = from tmp in ConnectDB.Entities.dbPowerUpItemsAttributes
                                   where tmp.status == 1 && tmp.idPowerUpItems == item.id
                                   select tmp;

                foreach (var item1 in tmpAttribute)
                {
                    dbPowerUpItemsAttribute att = new dbPowerUpItemsAttribute()
                    {
                        attribute = item1.attribute,
                        growthMod = item1.growthMod,
                        id = item1.id,
                        idPowerUpItems = item1.idPowerUpItems,
                        mods = item1.mods,
                        status = item1.status
                    };
                    lsAttribute.Add(att);
                }
            }
        }

        private void LoadDataToGC()
        {
            gcPowerUp.DataSource = null;
            gcPowerUpAttribute.DataSource = null;
            gcPowerUp.DataSource = lsPower.Where(x => x.status == 1);
        }

        private void LoadDataToLUE()
        {
            var tmpPromo = from tmp in ConnectDB.Entities.dbCTPromotionCharacters
                           select tmp;

            luePromotion.DataSource = tmpPromo.ToList();

            var tmpAtt = from tmp in ConnectDB.Entities.dbCTCharacterAttributes
                         select tmp;

            lueAttribute.DataSource = tmpAtt.ToList();
        }

        private void gvPowerUp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvPowerUp.RowCount > 0)
            {
                int idPow = (int)gvPowerUp.GetRowCellValue(gvPowerUp.FocusedRowHandle, "id");
                gcPowerUpAttribute.DataSource = null;
                gcPowerUpAttribute.DataSource = lsAttribute.Where(x => x.idPowerUpItems == idPow && x.status == 1);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbPowerUpItem pow = new dbPowerUpItem()
            {
                description = "Des",
                id = -(lsPower.Count),
                idPowerUpItems = lsPower.Count + 1,
                levelRequire = 1,
                name = "name",
                promotion = 1,
                status = 1
            };
            lsPower.Add(pow);
            gcPowerUp.DataSource = null;
            gcPowerUp.DataSource = lsPower.Where(x => x.status == 1);
            gvPowerUp.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvPowerUp.RowCount > 0)
            {
                int idPow = (int)gvPowerUp.GetRowCellValue(gvPowerUp.FocusedRowHandle, "id");
                lsPower.Where(x => x.id == idPow).ToList().ForEach(x => x.status = 2);
                gcPowerUp.DataSource = null;
                gcPowerUp.DataSource = lsPower.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvPowerUp.RowCount > 0)
            {
                int idPow = (int)gvPowerUp.GetRowCellValue(gvPowerUp.FocusedRowHandle, "id");
                dbPowerUpItemsAttribute pow = new dbPowerUpItemsAttribute()
                {
                    attribute = 1,
                    growthMod = 0,
                    id = -(lsAttribute.Count),
                    idPowerUpItems = idPow,
                    status = 1,
                    mods = 0,
                };
                lsAttribute.Add(pow);
                gcPowerUpAttribute.DataSource = null;
                gcPowerUpAttribute.DataSource = lsAttribute.Where(x => x.status == 1 && x.idPowerUpItems == idPow);
                gvPowerUpAttribute.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvPowerUp.RowCount > 0)
            {
                int idPow = (int)gvPowerUp.GetRowCellValue(gvPowerUp.FocusedRowHandle, "id");
                int idAtt = (int)gvPowerUpAttribute.GetRowCellValue(gvPowerUpAttribute.FocusedRowHandle, "id");
                lsAttribute.Where(x => x.id == idAtt).ToList().ForEach(x => x.status = 2);
                gcPowerUpAttribute.DataSource = null;
                gcPowerUpAttribute.DataSource = lsAttribute.Where(x => x.status == 1 && x.idPowerUpItems == idPow);
            }
        }

        protected override void OnSave()
        {
            gvPowerUp.FocusedRowHandle = -1;
            gvPowerUpAttribute.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsPower)
            {
                if (item.id <= 0)
                {
                    dbPowerUpItem power = new dbPowerUpItem()
                    {
                        description = item.description,
                        idPowerUpItems = item.idPowerUpItems,
                        levelRequire = item.levelRequire,
                        name = item.name,
                        promotion = item.promotion,
                        status = item.status
                    };

                    ConnectDB.Entities.dbPowerUpItems.Add(power);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsAttribute)
                    {
                        if (item1.idPowerUpItems == item.id)
                        {
                            dbPowerUpItemsAttribute att = new dbPowerUpItemsAttribute()
                            {
                                attribute = item1.attribute,
                                growthMod = item1.growthMod,
                                idPowerUpItems = power.id,
                                mods = item1.mods,
                                status = item1.status
                            };
                            ConnectDB.Entities.dbPowerUpItemsAttributes.Add(att);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }
                }
                else
                {
                    int idPow = item.id;
                    var result = ConnectDB.Entities.dbPowerUpItems.Where(x => x.id == idPow).FirstOrDefault();
                    result.description = item.description;
                    result.idPowerUpItems = item.idPowerUpItems;
                    result.levelRequire = item.levelRequire;
                    result.name = item.name;
                    result.promotion = item.promotion;
                    result.status = item.status;
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsAttribute)
                    {
                        if (item1.idPowerUpItems == idPow)
                        {
                            if (item1.id <= 0)
                            {
                                dbPowerUpItemsAttribute att = new dbPowerUpItemsAttribute()
                                {
                                    attribute = item1.attribute,
                                    growthMod = item1.growthMod,
                                    idPowerUpItems = idPow,
                                    mods = item1.mods,
                                    status = item1.status
                                };
                                ConnectDB.Entities.dbPowerUpItemsAttributes.Add(att);
                                ConnectDB.Entities.SaveChanges();
                            }
                            else
                            {
                                int idAtt = item1.id;
                                var result1 = ConnectDB.Entities.dbPowerUpItemsAttributes.Where(x => x.id == idAtt).FirstOrDefault();
                                result1.attribute = item1.attribute;
                                result1.idPowerUpItems = idPow;
                                result1.mods = item1.mods;
                                result1.status = item1.status;
                                ConnectDB.Entities.SaveChanges();
                            }
                        }
                    }
                }
            }
            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công");
        }
    }
}

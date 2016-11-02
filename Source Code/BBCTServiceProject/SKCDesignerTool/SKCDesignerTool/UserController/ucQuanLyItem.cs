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
    public partial class ucQuanLyItem : ucManager
    {
        List<dbItem> lsItem = new List<dbItem>();
        List<dbItemAttribute> lsAttribute = new List<dbItemAttribute>();

        public ucQuanLyItem()
        {
            InitializeComponent();
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList();
            LoadDataLUE();
            LoadDataGC();
        }

        private void LoadDataToList()
        {
            lsAttribute.Clear();
            lsItem.Clear();

            var tmpItem = from tmp in ConnectDB.Entities.dbItems
                          where tmp.status == 1
                          select tmp;

            foreach (var item in tmpItem)
            {
                dbItem db = new dbItem()
                {
                    border = item.border,
                    descriptions = item.descriptions,
                    id = item.id,
                    idItem = item.idItem,
                    name = item.name,
                    sellPrice = item.sellPrice,
                    status = item.status,
                    types = item.types
                };
                lsItem.Add(db);

                var tmpAttribute = from tm in ConnectDB.Entities.dbItemAttributes
                                   where tm.status == 1 && tm.idItem == item.id
                                   select tm;

                foreach (var item1 in tmpAttribute)
                {
                    dbItemAttribute att = new dbItemAttribute()
                    {
                        id = item1.id,
                        idItem = item1.idItem,
                        status = item1.status,
                        value = item1.value
                    };
                    lsAttribute.Add(att);
                }
            }
        }

        private void LoadDataLUE()
        {
            var tmpPromotion = from tmp in ConnectDB.Entities.dbCTPromotionCharacters
                               select tmp;

            luePromotion.DataSource = tmpPromotion.ToList();

            var tmpCategory = from tmp in ConnectDB.Entities.dbCTTypeItems
                              where tmp.id != 25 && tmp.status == 1
                              select new
                              {
                                  tmp.id,
                                  tmp.value
                              };

            lueCategory.DataSource = tmpCategory.ToList();
        }

        private void LoadDataGC()
        {
            gcItem.DataSource = null;
            gcItem.DataSource = lsItem.ToList();
        }

        private void gvItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvItem.RowCount > 0)
            {
                int iditem = (int)gvItem.GetRowCellValue(gvItem.FocusedRowHandle, "id");
                gcAttribute.DataSource = lsAttribute.Where(x => x.status == 1 && x.idItem == iditem);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbItem chr = new dbItem()
            {
                border = 1,
                descriptions = "Des",
                id = -(lsItem.Count),
                idItem = lsItem.Count + 1,
                name = "name",
                sellPrice = 0,
                types = 1,
                status = 1
            };
            lsItem.Add(chr);
            gcItem.DataSource = null;
            gcItem.DataSource = lsItem.Where(x => x.status == 1);
            gvItem.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvItem.RowCount > 0)
            {
                int idAtt = (int)gvItem.GetRowCellValue(gvItem.FocusedRowHandle, "id");
                lsAttribute.Where(x => x.idItem == idAtt).ToList().ForEach(y => y.status = 2);
                lsItem.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcItem.DataSource = null;
                gcItem.DataSource = lsItem.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvItem.RowCount > 0)
            {
                int idAtt = (int)gvItem.GetRowCellValue(gvItem.FocusedRowHandle, "id");
                dbItemAttribute chr = new dbItemAttribute()
                {
                    id = -(lsAttribute.Count),
                    idItem = idAtt,
                    value = 0,
                    status = 1
                };
                lsAttribute.Add(chr);
                gcAttribute.DataSource = null;
                gcAttribute.DataSource = lsAttribute.Where(x => x.status == 1 && x.idItem == idAtt);
                gvAttribute.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvAttribute.RowCount > 0)
            {
                int idAtt = (int)gvAttribute.GetRowCellValue(gvAttribute.FocusedRowHandle, "id");
                int idItem = (int)gvItem.GetRowCellValue(gvItem.FocusedRowHandle, "id");
                lsAttribute.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcAttribute.DataSource = null;
                gcAttribute.DataSource = lsAttribute.Where(x => x.status == 1 && x.idItem == idItem);
            }
        }

        protected override void OnSave()
        {
            gvAttribute.FocusedRowHandle = -1;
            gvItem.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsItem)
            {
                if (item.id < 0)
                {
                    dbItem gh = new dbItem()
                    {
                        border = item.border,
                        descriptions = item.descriptions,
                        idItem = item.idItem,
                        name = item.name,
                        sellPrice = item.sellPrice,
                        status = item.status,
                        types = item.types
                    };
                    ConnectDB.Entities.dbItems.Add(gh);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsAttribute)
                    {
                        if (item1.idItem == gh.id)
                        {
                            dbItemAttribute att = new dbItemAttribute()
                            {
                                idItem = gh.id,
                                status
                                = item1.status,
                                value = item1.value
                            };
                            ConnectDB.Entities.dbItemAttributes.Add(att);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }
                }
                else
                {
                    int iditem = item.id;
                    var result = ConnectDB.Entities.dbItems.Where(x => x.id == iditem).FirstOrDefault();
                    result.border = item.border;
                    result.descriptions = item.descriptions;
                    result.idItem = item.idItem;
                    result.name = item.name;
                    result.sellPrice = item.sellPrice;
                    result.status = item.status;
                    result.types = item.types;
                };
                ConnectDB.Entities.SaveChanges();

                foreach (var item1 in lsAttribute)
                {
                    if (item1.idItem == item.id)
                    {
                        if (item1.id <= 0)
                        {
                            dbItemAttribute att = new dbItemAttribute()
                            {
                                idItem = item.id,
                                status = item1.status,
                                value = item1.value
                            };
                            ConnectDB.Entities.dbItemAttributes.Add(att);
                        }
                        else
                        {
                            int idArr = item1.id;
                            var result1 = ConnectDB.Entities.dbItemAttributes.Where(x => x.id == idArr).FirstOrDefault();
                            result1.idItem = item.id;
                            result1.status = item1.status;
                            result1.value = item1.value;
                        }
                        ConnectDB.Entities.SaveChanges();
                    }
                }
            }

            LoadDataToList();
            LoadDataGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}

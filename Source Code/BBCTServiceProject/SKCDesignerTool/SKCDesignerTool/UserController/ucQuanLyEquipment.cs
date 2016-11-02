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
    public partial class ucQuanLyEquipment : ucManager
    {
        List<dbEquipment> lsEquipment = new List<dbEquipment>();
        List<dbEquipmentAttribute> lsAttribute = new List<dbEquipmentAttribute>();
        List<dbEquipmentStarUp> lsStarUp = new List<dbEquipmentStarUp>();
        List<dbEquipmentReceipt> lsReceipt = new List<dbEquipmentReceipt>();

        public ucQuanLyEquipment()
        {
            InitializeComponent();
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsAttribute.Clear();
            lsEquipment.Clear();
            lsReceipt.Clear();
            lsStarUp.Clear();
            var tmpEquipment = from tmp in ConnectDB.Entities.dbEquipments
                               where tmp.status == 1
                               select tmp;

            foreach (var item in tmpEquipment)
            {
                dbEquipment equi = new dbEquipment()
                {
                    category = item.category,
                    descriptions = item.descriptions,
                    id = item.id,
                    idEquipment = item.idEquipment,
                    name = item.name,
                    promotion = item.promotion,
                    baseMarketPrice = item.baseMarketPrice,
                    canSellMarket = item.canSellMarket,
                    icon = item.icon,
                    status = item.status
                };
                lsEquipment.Add(equi);

                var tmpAttribute = from tmp in ConnectDB.Entities.dbEquipmentAttributes
                                   where tmp.status == 1 && tmp.idEquipment == item.id
                                   select tmp;

                foreach (var item1 in tmpAttribute)
                {
                    dbEquipmentAttribute att = new dbEquipmentAttribute()
                    {
                        attribute = item1.attribute,
                        growthMod = item1.growthMod,
                        id = item1.id,
                        idEquipment = item1.idEquipment,
                        mods = item1.mods,
                        status = item1.status
                    };
                    lsAttribute.Add(att);
                }

                var tmpStarUp = from tmp in ConnectDB.Entities.dbEquipmentStarUps
                                where tmp.status == 1 && tmp.idEquipment == item.id
                                select tmp;

                foreach (var item1 in tmpStarUp)
                {
                    dbEquipmentStarUp up = new dbEquipmentStarUp()
                    {
                        id = item1.id,
                        idEquipment = item1.idEquipment,
                        status = item1.status,
                        value = item1.value
                    };
                    lsStarUp.Add(up);

                    var tmpReceipt = from tmp in ConnectDB.Entities.dbEquipmentReceipts
                                     where tmp.status == 1 && tmp.idStarUp == item1.id
                                     select tmp;

                    foreach (var item2 in tmpReceipt)
                    {
                        dbEquipmentReceipt re = new dbEquipmentReceipt()
                        {
                            amount = item2.amount,
                            id = item2.id,
                            idItem = item2.idItem,
                            idStarUp = item2.idStarUp,
                            status = item2.status
                        };
                        lsReceipt.Add(re);
                    }
                }
            }
        }

        private void LoadDataToGC()
        {
            gcAttribute.DataSource = null;
            gcEquipment.DataSource = null;
            gcReceipt.DataSource = null;
            gcStarUp.DataSource = null;
            gcEquipment.DataSource = lsEquipment;
        }

        private void LoadDataToLUE()
        {
            var tmpPromotion = from tmp in ConnectDB.Entities.dbCTPromotionCharacters
                               select tmp;

            var tmpCategory = from tmp in ConnectDB.Entities.dbCTTypeEquipments
                              select tmp;

            var tmpAttribute = from tmp in ConnectDB.Entities.dbCTCharacterAttributes
                               select tmp;

            lueAttribute.DataSource = tmpAttribute.ToList();
            luePromotion.DataSource = tmpPromotion.ToList();
            lueCategoryEquip.DataSource = tmpCategory.ToList();

            var tmpItem = from tmp in ConnectDB.Entities.dbItems
                          where tmp.status == 1
                          select new
                          {
                              tmp.id,
                              tmp.name
                          };

            lueItem.DataSource = tmpItem.ToList();


            List<dbCTAffliction> lsTrue = new List<dbCTAffliction>();
            dbCTAffliction aff = new dbCTAffliction()
            {
                id = 0,
                value = "False"
            };
            lsTrue.Add(aff);

            dbCTAffliction aff1 = new dbCTAffliction()
            {
                id = 1,
                value = "True"
            };
            lsTrue.Add(aff1);

            lueTrueFalse.DataSource = lsTrue;
        }

        private void gvEquipment_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvEquipment.RowCount > 0)
            {
                int idEqui = (int)gvEquipment.GetRowCellValue(gvEquipment.FocusedRowHandle, "id");
                gcAttribute.DataSource = null;
                gcAttribute.DataSource = lsAttribute.Where(x => x.idEquipment == idEqui && x.status == 1);
                gcStarUp.DataSource = null;
                gcStarUp.DataSource = lsStarUp.Where(x => x.idEquipment == idEqui && x.status == 1);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbEquipment equi = new dbEquipment()
            {
                category = 2,
                descriptions = "Des",
                id = -(lsEquipment.Count),
                idEquipment = lsEquipment.Count + 1,
                name = "name",
                promotion = 1,
                baseMarketPrice = 0,
                canSellMarket = 0,
                icon = 1,
                status = 1
            };
            lsEquipment.Add(equi);
            gcEquipment.DataSource = null;
            gcEquipment.DataSource = lsEquipment.Where(x => x.status == 1);
            gvEquipment.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            int idEqui = (int)gvEquipment.GetRowCellValue(gvEquipment.FocusedRowHandle, "id");
            lsStarUp.Where(x => x.idEquipment == idEqui).ToList().ForEach(y => y.status = 2);
            lsAttribute.Where(x => x.idEquipment == idEqui).ToList().ForEach(y => y.status = 2);
            lsEquipment.Where(x => x.id == idEqui).ToList().ForEach(y => y.status = 2);
            gcEquipment.DataSource = null;
            gcEquipment.DataSource = lsEquipment.Where(x => x.status == 1);
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvEquipment.RowCount > 0)
            {
                int idEqui = (int)gvEquipment.GetRowCellValue(gvEquipment.FocusedRowHandle, "id");
                dbEquipmentAttribute equi = new dbEquipmentAttribute()
                {
                    attribute = 1,
                    growthMod = 1,
                    id = -(lsAttribute.Count),
                    idEquipment = idEqui,
                    mods = 1,
                    status = 1
                };
                lsAttribute.Add(equi);
                gcAttribute.DataSource = null;
                gcAttribute.DataSource = lsAttribute.Where(x => x.status == 1 && x.idEquipment == idEqui);
                gvAttribute.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvEquipment.RowCount > 0)
            {
                int idEqui = (int)gvEquipment.GetRowCellValue(gvEquipment.FocusedRowHandle, "id");
                int idAtt = (int)gvAttribute.GetRowCellValue(gvAttribute.FocusedRowHandle, "id");
                lsAttribute.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcAttribute.DataSource = null;
                gcAttribute.DataSource = lsAttribute.Where(x => x.status == 1 && x.idEquipment == idEqui);
            }
        }

        protected override void OnSave()
        {
            gvAttribute.FocusedRowHandle = -1;
            gvEquipment.FocusedRowHandle = -1;
            gvReceipt.FocusedRowHandle = -1;
            gvStarUp.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsEquipment)
            {
                if (item.id <= 0)
                {
                    dbEquipment equi = new dbEquipment()
                    {
                        category = item.category,
                        descriptions = item.descriptions,
                        idEquipment = item.idEquipment,
                        name = item.name,
                        promotion = item.promotion,
                        baseMarketPrice = item.baseMarketPrice,
                        canSellMarket = item.canSellMarket,
                        icon = item.icon,
                        status = item.status
                    };
                    ConnectDB.Entities.dbEquipments.Add(equi);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsAttribute)
                    {
                        if (item1.idEquipment == item.id)
                        {
                            dbEquipmentAttribute att = new dbEquipmentAttribute()
                            {
                                attribute = item1.attribute,
                                growthMod = item1.growthMod,
                                idEquipment = equi.id,
                                mods = item1.mods,
                                status = item1.status
                            };
                            ConnectDB.Entities.dbEquipmentAttributes.Add(att);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }

                    foreach (var item1 in lsStarUp)
                    {
                        if (item1.idEquipment == item.id)
                        {
                            dbEquipmentStarUp att = new dbEquipmentStarUp()
                            {
                                idEquipment = equi.id,
                                value = item1.value,
                                status = item1.status
                            };
                            ConnectDB.Entities.dbEquipmentStarUps.Add(att);
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsReceipt)
                            {
                                if (item2.idStarUp == item1.id)
                                {
                                    dbEquipmentReceipt rece = new dbEquipmentReceipt()
                                    {
                                        amount = item2.amount,
                                        idItem = item2.idItem,
                                        idStarUp = att.id,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbEquipmentReceipts.Add(rece);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }
                    }
                }
                else
                {
                    int idEquip = item.id;
                    var result = ConnectDB.Entities.dbEquipments.Where(x => x.id == idEquip).FirstOrDefault();
                    result.category = item.category;
                    result.descriptions = item.descriptions;
                    result.idEquipment = item.idEquipment;
                    result.name = item.name;
                    result.promotion = item.promotion;
                    result.baseMarketPrice = item.baseMarketPrice;
                    result.canSellMarket = item.canSellMarket;
                    result.icon = item.icon;
                    result.status = item.status;

                    foreach (var item1 in lsAttribute)
                    {
                        if (item1.idEquipment == item.id)
                        {
                            if (item1.id <= 0)
                            {
                                dbEquipmentAttribute att = new dbEquipmentAttribute()
                                {
                                    attribute = item1.attribute,
                                    growthMod = item1.growthMod,
                                    idEquipment = result.id,
                                    mods = item1.mods,
                                    status = item1.status
                                };
                                ConnectDB.Entities.dbEquipmentAttributes.Add(att);
                            }
                            else
                            {
                                int idAtt = item1.id;
                                var result1 = ConnectDB.Entities.dbEquipmentAttributes.Where(x => x.id == idAtt).FirstOrDefault();
                                result1.attribute = item1.attribute;
                                result1.growthMod = item1.growthMod;
                                result1.idEquipment = result.id;
                                result1.mods = item1.mods;
                                result1.status = item1.status;
                            }
                            ConnectDB.Entities.SaveChanges();
                        }
                    }

                    foreach (var item1 in lsStarUp)
                    {
                        if (item1.idEquipment == item.id)
                        {
                            if (item1.id <= 0)
                            {
                                dbEquipmentStarUp att = new dbEquipmentStarUp()
                                {
                                    idEquipment = result.id,
                                    value = item1.value,
                                    status = item1.status
                                };
                                ConnectDB.Entities.dbEquipmentStarUps.Add(att);
                                ConnectDB.Entities.SaveChanges();

                                foreach (var item2 in lsReceipt)
                                {
                                    if (item2.idStarUp == item1.id)
                                    {
                                        dbEquipmentReceipt rece = new dbEquipmentReceipt()
                                        {
                                            amount = item2.amount,
                                            idItem = item2.idItem,
                                            idStarUp = att.id,
                                            status = item2.status
                                        };
                                        ConnectDB.Entities.dbEquipmentReceipts.Add(rece);
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }
                            }
                            else
                            {
                                int idStar = item1.id;
                                var result1 = ConnectDB.Entities.dbEquipmentStarUps.Where(x => x.id == idStar).FirstOrDefault();
                                result1.idEquipment = result.id;
                                result1.value = item1.value;
                                result1.status = item1.status;

                                foreach (var item2 in lsReceipt)
                                {
                                    if (item2.idStarUp == item1.id)
                                    {
                                        if (item2.id <= 0)
                                        {
                                            dbEquipmentReceipt rece = new dbEquipmentReceipt()
                                            {
                                                amount = item2.amount,
                                                idItem = item2.idItem,
                                                idStarUp = idStar,
                                                status = item2.status
                                            };
                                            ConnectDB.Entities.dbEquipmentReceipts.Add(rece);
                                        }
                                        else
                                        {
                                            int idRece = item2.id;
                                            var result2 = ConnectDB.Entities.dbEquipmentReceipts.Where(x => x.id == idRece).FirstOrDefault();
                                            result2.amount = item2.amount;
                                            result2.idItem = item2.idItem;
                                            result2.idStarUp = idStar;
                                            result2.status = item2.status;
                                        }
                                        ConnectDB.Entities.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void gvStarUp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvStarUp.RowCount > 0)
            {
                int idEStar = (int)gvStarUp.GetRowCellValue(gvStarUp.FocusedRowHandle, "id");
                gcReceipt.DataSource = null;
                gcReceipt.DataSource = lsReceipt.Where(x => x.idStarUp == idEStar && x.status == 1);
            }
            else
            {
                gcReceipt.DataSource = null;
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            if (gvEquipment.RowCount > 0)
            {
                int idEqui = (int)gvEquipment.GetRowCellValue(gvEquipment.FocusedRowHandle, "id");
                dbEquipmentStarUp equi = new dbEquipmentStarUp()
                {
                    id = -(lsStarUp.Count),
                    idEquipment = idEqui,
                    value = 1,
                    status = 1
                };
                lsStarUp.Add(equi);
                gcStarUp.DataSource = null;
                gcStarUp.DataSource = lsStarUp.Where(x => x.status == 1 && x.idEquipment == idEqui);
                gvStarUp.MoveLast();
            }
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (gvEquipment.RowCount > 0)
            {
                int idEqui = (int)gvStarUp.GetRowCellValue(gvStarUp.FocusedRowHandle, "id");
                lsReceipt.Where(x => x.idStarUp == idEqui).ToList().ForEach(y => y.status = 2);
                lsStarUp.Where(x => x.id == idEqui).ToList().ForEach(y => y.status = 2);
                gcStarUp.DataSource = null;
                gcStarUp.DataSource = lsStarUp.Where(x => x.status == 1 && x.idEquipment == idEqui);
            }
        }

        private void btnAdd4_Click(object sender, EventArgs e)
        {
            if (gvStarUp.RowCount > 0)
            {
                int idStar = (int)gvStarUp.GetRowCellValue(gvStarUp.FocusedRowHandle, "id");
                dbEquipmentReceipt equi = new dbEquipmentReceipt()
                {
                    id = -(lsReceipt.Count),
                    amount = 0,
                    idItem = 1,
                    idStarUp = idStar,
                    status = 1
                };
                lsReceipt.Add(equi);
                gcReceipt.DataSource = null;
                gcReceipt.DataSource = lsReceipt.Where(x => x.status == 1 && x.idStarUp == idStar);
                gvReceipt.MoveLast();
            }
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (gvReceipt.RowCount > 0)
            {
                int idEqui = (int)gvReceipt.GetRowCellValue(gvReceipt.FocusedRowHandle, "id");
                int idStar = (int)gvStarUp.GetRowCellValue(gvStarUp.FocusedRowHandle, "id");
                lsReceipt.Where(x => x.id == idEqui).ToList().ForEach(y => y.status = 2);
                gcReceipt.DataSource = null;
                gcReceipt.DataSource = lsReceipt.Where(x => x.status == 1 && x.idStarUp == idStar);
            }
        }
    }
}

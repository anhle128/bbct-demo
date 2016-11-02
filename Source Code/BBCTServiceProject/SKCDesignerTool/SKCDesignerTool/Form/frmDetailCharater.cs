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
    public partial class frmDetailCharater : frmFormChange
    {
        int idCharacter = 0;
        List<dbCharacter> lsCharacter = new List<dbCharacter>();
        List<dbCharSkill> lsSkill = new List<dbCharSkill>();
        List<dbCharAttribute> lsCharAttribute = new List<dbCharAttribute>();
        List<dbCharDuyenPhan> lsChrDuyenPhan = new List<dbCharDuyenPhan>();
        List<dbCharDuyenPhanAttribute> lsDuyenPhanAttribute = new List<dbCharDuyenPhanAttribute>();
        List<dbCharDuyenPhanID> lsDuyenPhanIDS = new List<dbCharDuyenPhanID>();
        List<dbCharPowerUpReceipt> lsPowerUpReceipt = new List<dbCharPowerUpReceipt>();
        List<dbCharDetailPowerUpReceipt> lsDetailPowerUp = new List<dbCharDetailPowerUpReceipt>();
        List<dbCharSkillAttribute> lsSkillAttribute = new List<dbCharSkillAttribute>();
        List<dbCharSkillAfflictionAttribute> lsSkillAfflictionAttribute = new List<dbCharSkillAfflictionAttribute>();
        List<dbCTAffliction> lsLueDuyenPhanChar = new List<dbCTAffliction>();
        List<dbCTAffliction> lsLueDuyenPhanEquip = new List<dbCTAffliction>();

        public frmDetailCharater(int idChar)
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            idCharacter = idChar;
            LoadDataToLUE();
            LoadDataList();
            LoadDataToGC();
        }

        private void LoadDataToGC()
        {
            gcThongTinNhanVat.DataSource = null;
            gcThongTinNhanVat.DataSource = lsCharacter.ToList();
            gcAttribute.DataSource = null;
            gcAttribute.DataSource = lsCharAttribute.ToList();
            gcDuyenPhan.DataSource = null;
            gcDuyenPhan.DataSource = lsChrDuyenPhan.ToList();
            gcPowerUpReceipt.DataSource = null;
            gcPowerUpReceipt.DataSource = lsPowerUpReceipt.ToList();
            gcSkill.DataSource = null;
            gcSkill.DataSource = lsSkill.ToList();
        }

        private void LoadDataList()
        {
            if (idCharacter == 0)
            {
                dbCharacter chr = new dbCharacter()
                {
                    category = 1,
                    classCharacter = 1,
                    descriptions = "Mô tả",
                    idCharacter = ReturnCountCharacter(),
                    isMain = 1,
                    name = "Tên nhân vật",
                    orders = ReturnCountCharacter(),
                    promotion = 1,
                    status = 1,
                    id = -1,
                    amountPieceToImport = 10
                };
                lsCharacter.Add(chr);

                for (int i = 1; i < 13; i++)
                {
                    dbCharAttribute att = new dbCharAttribute()
                   {
                       attribute = i,
                       growthMod = 0,
                       idCharacter = -1,
                       mods = 0,
                       status = 1
                   };
                    lsCharAttribute.Add(att);
                }
            }
            else
            {
                dbCharacter tmpChr = ConnectDB.Entities.dbCharacters.Where(x => x.id == idCharacter).FirstOrDefault();
                lsCharacter.Add(tmpChr);
                //attribute
                var tmpAttribute = from tmp in ConnectDB.Entities.dbCharAttributes
                                   where tmp.status == 1 && tmp.idCharacter == idCharacter
                                   orderby tmp.id ascending
                                   select tmp;

                foreach (var item in tmpAttribute)
                {
                    dbCharAttribute att = new dbCharAttribute()
                    {
                        attribute = item.attribute,
                        growthMod = item.growthMod,
                        id = item.id,
                        idCharacter = item.idCharacter,
                        mods = item.mods,
                        status = item.status
                    };
                    lsCharAttribute.Add(att);
                }

                //Duyen phan
                var tmpDuyenPhan = from tmp in ConnectDB.Entities.dbCharDuyenPhans
                                   where tmp.status == 1 && tmp.idCharacter == idCharacter
                                   select tmp;

                foreach (var item in tmpDuyenPhan)
                {
                    dbCharDuyenPhan duyen = new dbCharDuyenPhan()
                    {
                        category = item.category,
                        id = item.id,
                        idCharacter = item.idCharacter,
                        isOne = item.isOne,
                        name = item.name,
                        status = item.status
                    };
                    lsChrDuyenPhan.Add(duyen);

                    var tmpDuyenPhanIDS = from tmpIDS in ConnectDB.Entities.dbCharDuyenPhanIDS
                                          where tmpIDS.status == 1 && tmpIDS.idDuyen == item.id
                                          select tmpIDS;

                    foreach (var item1 in tmpDuyenPhanIDS)
                    {
                        dbCharDuyenPhanID ids = new dbCharDuyenPhanID()
                        {
                            id = item1.id,
                            idDuyen = item1.idDuyen,
                            value = item1.value,
                            status = item1.status
                        };
                        lsDuyenPhanIDS.Add(ids);
                    }

                    var tmpDuyenPhanAtt = from tmpIDS in ConnectDB.Entities.dbCharDuyenPhanAttributes
                                          where tmpIDS.status == 1 && tmpIDS.idDuyen == item.id
                                          select tmpIDS;

                    foreach (var item2 in tmpDuyenPhanAtt)
                    {
                        dbCharDuyenPhanAttribute ids = new dbCharDuyenPhanAttribute()
                        {
                            id = item2.id,
                            idDuyen = item2.idDuyen,
                            value = item2.value,
                            attribute = item2.attribute,
                            growthMod = item2.growthMod,
                            status = item2.status
                        };
                        lsDuyenPhanAttribute.Add(ids);
                    }
                }

                var tmpPowerupReceipt = from tmp in ConnectDB.Entities.dbCharPowerUpReceipts
                                        where tmp.idCharacter == idCharacter && tmp.status == 1
                                        select tmp;

                foreach (var item in tmpPowerupReceipt)
                {
                    dbCharPowerUpReceipt chr = new dbCharPowerUpReceipt()
                    {
                        id = item.id,
                        idCharacter = item.idCharacter,
                        gen = item.gen,
                        status = item.status
                    };
                    lsPowerUpReceipt.Add(chr);

                    var tmpDetail = from detail in ConnectDB.Entities.dbCharDetailPowerUpReceipts
                                    where detail.idReceipt == item.id && detail.status == 1
                                    select detail;

                    foreach (var item1 in tmpDetail)
                    {
                        dbCharDetailPowerUpReceipt de = new dbCharDetailPowerUpReceipt()
                        {
                            id = item1.id,
                            idItem = item1.idItem,
                            idReceipt = item1.idReceipt,
                            status = item1.status,
                            amount = item1.amount
                        };
                        lsDetailPowerUp.Add(de);
                    }
                }

                //skill
                var tmpSkill = from tmp in ConnectDB.Entities.dbCharSkills
                               where tmp.status == 1 && tmp.idCharacter == idCharacter
                               select tmp;

                foreach (var item in tmpSkill)
                {
                    dbCharSkill skill = new dbCharSkill()
                    {
                        id = item.id,
                        idCharacter = item.idCharacter,
                        descriptions = item.descriptions,
                        afflictionSkill = item.afflictionSkill,
                        category = item.category,
                        cooldown = item.cooldown,
                        effect = item.effect,
                        name = item.name,
                        orders = item.orders,
                        ranges = item.ranges,
                        slot = item.slot,
                        status = item.status,
                        targets = item.targets,
                        countTurn = item.countTurn,
                        typeSpawnSkill = item.typeSpawnSkill,
                        manaCost = item.manaCost,
                        types = item.types,
                        afflictionDuration = item.afflictionDuration,
                        afflictionProc = item.afflictionProc
                    };
                    lsSkill.Add(skill);

                    var tmpAttributeSkill = from tmp in ConnectDB.Entities.dbCharSkillAttributes
                                            where tmp.status == 1 && tmp.idSkill == item.id
                                            select tmp;

                    foreach (var item1 in tmpAttributeSkill)
                    {
                        dbCharSkillAttribute att = new dbCharSkillAttribute()
                        {
                            attribute = item1.attribute,
                            growthMod = item1.growthMod,
                            id = item1.id,
                            idSkill = item1.idSkill,
                            mods = item1.mods,
                            status = item1.status
                        };
                        lsSkillAttribute.Add(att);
                    }

                    var tmpAttributeAffSkill = from tmp in ConnectDB.Entities.dbCharSkillAfflictionAttributes
                                               where tmp.status == 1 && tmp.idSkill == item.id
                                               select tmp;

                    foreach (var item1 in tmpAttributeAffSkill)
                    {
                        dbCharSkillAfflictionAttribute aff = new dbCharSkillAfflictionAttribute()
                        {
                            attribute = item1.attribute,
                            growthMod = item1.growthMod,
                            id = item1.id,
                            idSkill = item1.idSkill,
                            mods = item1.mods,
                            status = item1.status
                        };
                        lsSkillAfflictionAttribute.Add(aff);
                    }

                }
            }
        }

        private int ReturnCountCharacter()
        {
            var tmpChr = from tmp in ConnectDB.Entities.dbCharacters
                         where tmp.status == 1
                         select tmp;

            return tmpChr.Count();
        }

        private void LoadDataToLUE()
        {
            var tmpLueCategory = from tmp in ConnectDB.Entities.dbCTCategoryCharacters
                                 select tmp;
            lueCategory.DataSource = tmpLueCategory.ToList();
            lueCategorySkill.DataSource = tmpLueCategory.ToList();

            var tmpLueClass = from tmp in ConnectDB.Entities.dbCTClassCharacters
                              select tmp;
            lueClassCharacter.DataSource = tmpLueClass.ToList();

            var tmpLuePromotion = from tmp in ConnectDB.Entities.dbCTPromotionCharacters
                                  select tmp;
            luePromotion.DataSource = tmpLuePromotion.ToList();

            var lsStringmain = from tmp in ConnectDB.Entities.dbCTChacacterMains
                               select tmp;
            lueMainCharacter.DataSource = lsStringmain.ToList();

            var lsTypeSkill = from tmp in ConnectDB.Entities.dbCTTypeSkillCompares
                              select tmp;
            lueTypeSkill.DataSource = lsTypeSkill.ToList();

            var lsRangeSkill = from tmp in ConnectDB.Entities.dbCTRangeSkills
                               select tmp;
            lueRangeSkill.DataSource = lsRangeSkill.ToList();

            var lsSpawmSkill = from tmp in ConnectDB.Entities.dbCTTypeSpawnSkills
                               select tmp;
            lueSpawnSkill.DataSource = lsSpawmSkill.ToList();

            var lsAffSkill = from tmp in ConnectDB.Entities.dbCTAfflictions
                             select tmp;
            lueAfflictionSkill.DataSource = lsAffSkill.ToList();

            var lsEffectSkill = from tmp in ConnectDB.Entities.dbCTEffectSkills
                                select tmp;
            lueEffectSkill.DataSource = lsEffectSkill.ToList();

            var lsTargetSkill = from tmp in ConnectDB.Entities.dbCTTargetSkills
                                select tmp;
            lueTargetSkill.DataSource = lsTargetSkill.ToList();

            var lsAtribute = from tmp in ConnectDB.Entities.dbCTCharacterAttributes
                             select tmp;
            lueAttributeAffliction.DataSource = lsAtribute.ToList();
            lueAttributeChar.DataSource = lsAtribute.ToList();
            lueAttributeSkill.DataSource = lsAtribute.ToList();
            lueAttributeDuyenPhan.DataSource = lsAtribute.ToList();

            var lsOne = from tmp in ConnectDB.Entities.dbCTOneorAlls
                        select tmp;
            lueIsOne.DataSource = lsOne.ToList();

            var tmpPower = from tmp in ConnectDB.Entities.dbPowerUpItems
                           where tmp.status == 1
                           select new
                           {
                               tmp.idPowerUpItems,
                               tmp.name
                           };
            luePowerUpItem.DataSource = tmpPower.ToList();

            List<dbCTAffliction> lsCateDuyenPhan = new List<dbCTAffliction>();
            dbCTAffliction db = new dbCTAffliction()
            {
                id = 1,
                value = "Nhân vật"
            };
            lsCateDuyenPhan.Add(db);
            dbCTAffliction db1 = new dbCTAffliction()
            {
                id = 2,
                value = "Trang bị"
            };
            lsCateDuyenPhan.Add(db1);
            lueCategoryDuyenPhan.DataSource = lsCateDuyenPhan;

            var tmpCharDuyen = from tmp in ConnectDB.Entities.dbCharacters
                               where tmp.status == 1
                               orderby tmp.idCharacter ascending
                               select new
                               {
                                   tmp.idCharacter,
                                   tmp.name
                               };

            foreach (var item in tmpCharDuyen)
            {
                dbCTAffliction aff = new dbCTAffliction()
                {
                    id = (int)item.idCharacter,
                    value = item.name
                };
                lsLueDuyenPhanChar.Add(aff);
            }

            var tmpEquipDuyen = from tmp in ConnectDB.Entities.dbEquipments
                                where tmp.status == 1
                                orderby tmp.idEquipment ascending
                                select new
                                {
                                    tmp.idEquipment,
                                    tmp.name
                                };
            foreach (var item in tmpEquipDuyen)
            {
                dbCTAffliction aff = new dbCTAffliction()
                {
                    id = (int)item.idEquipment,
                    value = item.name
                };
                lsLueDuyenPhanEquip.Add(aff);
            }

            var tmpCharIdHuaNguyen = from tmp in ConnectDB.Entities.dbCharacters
                                     where tmp.status == 1
                                     orderby tmp.idCharacter
                                     select new
                                     {
                                         tmp.idCharacter,
                                         tmp.name
                                     };

            lueIdCharacterHuaNguyen.DataSource = tmpCharIdHuaNguyen.ToList();
        }

        private void gvSkill_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvSkill.RowCount > 0)
            {
                int idSkill = (int)gvSkill.GetRowCellValue(gvSkill.FocusedRowHandle, "id");
                gcAttributeSkill.DataSource = null;
                gcAttributeSkill.DataSource = lsSkillAttribute.Where(x => x.idSkill == idSkill && x.status == 1);
                gcAfflictionSkill.DataSource = null;
                gcAfflictionSkill.DataSource = lsSkillAfflictionAttribute.Where(x => x.idSkill == idSkill && x.status == 1);
            }
        }

        private void gvPowerUpReceipt_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvPowerUpReceipt.RowCount > 0)
            {
                int idPow = (int)gvPowerUpReceipt.GetRowCellValue(gvPowerUpReceipt.FocusedRowHandle, "id");
                gcReceipt.DataSource = lsDetailPowerUp.Where(x => x.idReceipt == idPow);
            }
        }

        private void gvDuyenPhan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvDuyenPhan.RowCount > 0)
            {
                int idPow = (int)gvDuyenPhan.GetRowCellValue(gvDuyenPhan.FocusedRowHandle, "id");
                int cate = (int)gvDuyenPhan.GetRowCellValue(gvDuyenPhan.FocusedRowHandle, "category");
                if (cate == 1)
                {
                    lueEquipCharacter.DataSource = lsLueDuyenPhanChar;
                }
                else
                {
                    lueEquipCharacter.DataSource = lsLueDuyenPhanEquip;
                }

                gcDuyenPhanAttribute.DataSource = lsDuyenPhanAttribute.Where(x => x.idDuyen == idPow);
                gcDuyenPhanIDS.DataSource = lsDuyenPhanIDS.Where(x => x.idDuyen == idPow);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbCharSkill skill = new dbCharSkill()
            {
                afflictionSkill = 1,
                category = 1,
                cooldown = 1,
                countTurn = 1,
                descriptions = "Des",
                effect = 1,
                id = -(lsSkill.Count),
                idCharacter = idCharacter,
                manaCost = 1,
                name = "name",
                orders = 1,
                ranges = 1,
                slot = 1,
                status = 1,
                targets = 1,
                types = 1,
                typeSpawnSkill = 1,
                afflictionProc = 0,
                afflictionDuration = 0
            };
            lsSkill.Add(skill);
            gcSkill.DataSource = null;
            gcSkill.DataSource = lsSkill.Where(x => x.status == 1);
            gvSkill.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvSkill.RowCount > 0)
            {
                int idAtt = (int)gvSkill.GetRowCellValue(gvSkill.FocusedRowHandle, "id");
                lsSkillAttribute.Where(x => x.idSkill == idAtt).ToList().ForEach(y => y.status = 2);
                lsSkillAfflictionAttribute.Where(x => x.idSkill == idAtt).ToList().ForEach(y => y.status = 2);
                lsSkill.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcSkill.DataSource = null;
                gcSkill.DataSource = lsSkill.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvSkill.RowCount > 0)
            {
                int idSkill = (int)gvSkill.GetRowCellValue(gvSkill.FocusedRowHandle, "id");
                dbCharSkillAttribute chr = new dbCharSkillAttribute()
                {
                    attribute = 1,
                    growthMod = 0,
                    id = -(lsSkillAttribute.Count),
                    idSkill = idSkill,
                    mods = 0,
                    status = 1
                };
                lsSkillAttribute.Add(chr);
                gcAttributeSkill.DataSource = null;
                gcAttributeSkill.DataSource = lsSkillAttribute.Where(x => x.status == 1 && x.idSkill == idSkill);
                gvAttributeSkill.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvAttributeSkill.RowCount > 0)
            {
                int idAtt = (int)gvAttributeSkill.GetRowCellValue(gvAttributeSkill.FocusedRowHandle, "id");
                int idSkill = (int)gvSkill.GetRowCellValue(gvSkill.FocusedRowHandle, "id");

                lsSkillAttribute.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcAttributeSkill.DataSource = null;
                gcAttributeSkill.DataSource = lsSkillAttribute.Where(x => x.status == 1 && x.idSkill == idSkill);
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            if (gvSkill.RowCount > 0)
            {
                int idSkill = (int)gvSkill.GetRowCellValue(gvSkill.FocusedRowHandle, "id");
                dbCharSkillAfflictionAttribute chr = new dbCharSkillAfflictionAttribute()
                {
                    attribute = 1,
                    growthMod = 0,
                    id = -(lsSkillAfflictionAttribute.Count),
                    idSkill = idSkill,
                    mods = 0,
                    status = 1
                };
                lsSkillAfflictionAttribute.Add(chr);
                gcAfflictionSkill.DataSource = null;
                gcAfflictionSkill.DataSource = lsSkillAfflictionAttribute.Where(x => x.status == 1 && x.idSkill == idSkill);
                gvAfflictionSkill.MoveLast();
            }
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (gvAfflictionSkill.RowCount > 0)
            {
                int idAtt = (int)gvAfflictionSkill.GetRowCellValue(gvAfflictionSkill.FocusedRowHandle, "id");
                int idSkill = (int)gvSkill.GetRowCellValue(gvSkill.FocusedRowHandle, "id");

                lsSkillAfflictionAttribute.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcAfflictionSkill.DataSource = null;
                gcAfflictionSkill.DataSource = lsSkillAfflictionAttribute.Where(x => x.status == 1 && x.idSkill == idSkill);
            }
        }

        private void btnAdd4_Click(object sender, EventArgs e)
        {
            dbCharPowerUpReceipt chr = new dbCharPowerUpReceipt()
            {
                id = -(lsPowerUpReceipt.Count),
                idCharacter = idCharacter,
                status = 1,
                gen = lsPowerUpReceipt.Count + 1,
            };
            lsPowerUpReceipt.Add(chr);
            gcPowerUpReceipt.DataSource = null;
            gcPowerUpReceipt.DataSource = lsPowerUpReceipt.Where(x => x.status == 1);
            gvPowerUpReceipt.MoveLast();
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (gvPowerUpReceipt.RowCount > 0)
            {
                int idAtt = (int)gvPowerUpReceipt.GetRowCellValue(gvPowerUpReceipt.FocusedRowHandle, "id");
                lsDetailPowerUp.Where(x => x.idReceipt == idAtt).ToList().ForEach(y => y.status = 2);
                lsPowerUpReceipt.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcPowerUpReceipt.DataSource = null;
                gcPowerUpReceipt.DataSource = lsPowerUpReceipt.Where(x => x.status == 1);
            }
        }

        private void btnAdd5_Click(object sender, EventArgs e)
        {
            if (gvPowerUpReceipt.RowCount > 0)
            {
                int idPow = (int)gvPowerUpReceipt.GetRowCellValue(gvPowerUpReceipt.FocusedRowHandle, "id");
                if (lsDetailPowerUp.Where(x => x.status == 1 && x.idReceipt == idPow).Count() < 6)
                {
                    dbCharDetailPowerUpReceipt chr = new dbCharDetailPowerUpReceipt()
                    {
                        id = -(lsDetailPowerUp.Count),
                        idReceipt = idPow,
                        idItem = 1,
                        amount = 1,
                        status = 1
                    };
                    lsDetailPowerUp.Add(chr);
                    gcReceipt.DataSource = null;
                    gcReceipt.DataSource = lsDetailPowerUp.Where(x => x.status == 1 && x.idReceipt == idPow);
                    gvReceipt.MoveLast();
                }
            }
        }

        private void btnDelete5_Click(object sender, EventArgs e)
        {
            if (gvReceipt.RowCount > 0)
            {
                int idAtt = (int)gvReceipt.GetRowCellValue(gvReceipt.FocusedRowHandle, "id");
                int idPower = (int)gvPowerUpReceipt.GetRowCellValue(gvPowerUpReceipt.FocusedRowHandle, "id");

                lsDetailPowerUp.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcReceipt.DataSource = null;
                gcReceipt.DataSource = lsDetailPowerUp.Where(x => x.status == 1 && x.idReceipt == idPower);
            }
        }

        private void btnAdd6_Click(object sender, EventArgs e)
        {
            dbCharDuyenPhan chr = new dbCharDuyenPhan()
            {
                id = -(lsChrDuyenPhan.Count),
                idCharacter = idCharacter,
                category = 1,
                isOne = 1,
                name = "name",
                status = 1
            };
            lsChrDuyenPhan.Add(chr);
            gcDuyenPhan.DataSource = null;
            gcDuyenPhan.DataSource = lsChrDuyenPhan.Where(x => x.status == 1);
            gvDuyenPhan.MoveLast();
        }

        private void btnDelete6_Click(object sender, EventArgs e)
        {
            if (gvDuyenPhan.RowCount > 0)
            {
                int idAtt = (int)gvDuyenPhan.GetRowCellValue(gvDuyenPhan.FocusedRowHandle, "id");

                lsDuyenPhanAttribute.Where(x => x.idDuyen == idAtt).ToList().ForEach(y => y.status = 2);
                lsDuyenPhanIDS.Where(x => x.idDuyen == idAtt).ToList().ForEach(y => y.status = 2);
                lsChrDuyenPhan.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcDuyenPhan.DataSource = null;
                gcDuyenPhan.DataSource = lsChrDuyenPhan.Where(x => x.status == 1);
            }
        }

        private void btnAdd7_Click(object sender, EventArgs e)
        {
            if (gvDuyenPhan.RowCount > 0)
            {
                int idDuyen = (int)gvDuyenPhan.GetRowCellValue(gvDuyenPhan.FocusedRowHandle, "id");
                dbCharDuyenPhanAttribute chr = new dbCharDuyenPhanAttribute()
                {
                    id = -(lsDuyenPhanAttribute.Count),
                    idDuyen = idDuyen,
                    value = 0,
                    growthMod = 0,
                    attribute = 1,
                    status = 1
                };
                lsDuyenPhanAttribute.Add(chr);
                gcDuyenPhanAttribute.DataSource = null;
                gcDuyenPhanAttribute.DataSource = lsDuyenPhanAttribute.Where(x => x.status == 1 && x.idDuyen == idDuyen);
                gvDuyenPhanAttribute.MoveLast();
            }
        }

        private void btnDelete7_Click(object sender, EventArgs e)
        {
            if (gvDuyenPhanAttribute.RowCount > 0)
            {
                int idAtt = (int)gvDuyenPhanAttribute.GetRowCellValue(gvDuyenPhanAttribute.FocusedRowHandle, "id");
                int idDuyen = (int)gvDuyenPhan.GetRowCellValue(gvDuyenPhan.FocusedRowHandle, "id");
                lsDuyenPhanAttribute.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcDuyenPhanAttribute.DataSource = null;
                gcDuyenPhanAttribute.DataSource = lsDuyenPhanAttribute.Where(x => x.status == 1 && x.idDuyen == idDuyen);
            }
        }

        private void btnAdd8_Click(object sender, EventArgs e)
        {
            if (gvDuyenPhan.RowCount > 0)
            {
                int idDuyen = (int)gvDuyenPhan.GetRowCellValue(gvDuyenPhan.FocusedRowHandle, "id");
                dbCharDuyenPhanID chr = new dbCharDuyenPhanID()
                {
                    id = -(lsDuyenPhanIDS.Count),
                    idDuyen = idDuyen,
                    value = 0,
                    status = 1
                };
                lsDuyenPhanIDS.Add(chr);
                gcDuyenPhanIDS.DataSource = null;
                gcDuyenPhanIDS.DataSource = lsDuyenPhanIDS.Where(x => x.status == 1 && x.idDuyen == idDuyen);
                gvDuyenPhanIDS.MoveLast();
            }
        }

        private void btnDelete8_Click(object sender, EventArgs e)
        {
            if (gvDuyenPhanIDS.RowCount > 0)
            {
                int idAtt = (int)gvDuyenPhanIDS.GetRowCellValue(gvDuyenPhanIDS.FocusedRowHandle, "id");
                int idDuyen = (int)gvDuyenPhan.GetRowCellValue(gvDuyenPhan.FocusedRowHandle, "id");
                lsDuyenPhanIDS.Where(x => x.id == idAtt).ToList().ForEach(y => y.status = 2);
                gcDuyenPhanIDS.DataSource = null;
                gcDuyenPhanIDS.DataSource = lsDuyenPhanIDS.Where(x => x.status == 1 && x.idDuyen == idDuyen);
            }
        }

        private void SaveDataColumnFocus()
        {
            gvAfflictionSkill.FocusedRowHandle = -1;
            gvAttribute.FocusedRowHandle = -1;
            gvAttributeSkill.FocusedRowHandle = -1;
            gvDuyenPhan.FocusedRowHandle = -1;
            gvDuyenPhanAttribute.FocusedRowHandle = -1;
            gvDuyenPhanIDS.FocusedRowHandle = -1;
            gvPowerUpReceipt.FocusedRowHandle = -1;
            gvReceipt.FocusedRowHandle = -1;
            gvSkill.FocusedRowHandle = -1;
            gvThongTinNhanVat.FocusedRowHandle = -1;
        }

        protected override void OnSave()
        {
            int idChTemp = (int)gvThongTinNhanVat.GetRowCellValue(gvThongTinNhanVat.FocusedRowHandle, "idCharacter");
            var checkChr = ConnectDB.Entities.dbCharacters.Where(x => x.idCharacter == idChTemp && x.status == 1).FirstOrDefault();
            SaveDataColumnFocus();

            if (idCharacter <= 0)
            {
                if (checkChr == null)
                {
                    foreach (var item in lsCharacter)
                    {
                        dbCharacter chr = new dbCharacter()
                        {
                            category = item.category,
                            classCharacter = item.classCharacter,
                            descriptions = item.descriptions,
                            idCharacter = idChTemp,
                            isMain = item.isMain,
                            name = item.name,
                            orders = item.orders,
                            promotion = item.promotion,
                            status = 1,
                            amountPieceToImport = item.amountPieceToImport,
                            idCharHuaNguyen = item.idCharHuaNguyen
                        };
                        ConnectDB.Entities.dbCharacters.Add(chr);
                        ConnectDB.Entities.SaveChanges();
                        idCharacter = chr.id;

                        foreach (var item1 in lsCharAttribute)
                        {
                            dbCharAttribute att = new dbCharAttribute()
                            {
                                attribute = item1.attribute,
                                growthMod = item1.growthMod,
                                idCharacter = idCharacter,
                                mods = item1.mods,
                                status = item1.status
                            };
                            ConnectDB.Entities.dbCharAttributes.Add(att);
                            ConnectDB.Entities.SaveChanges();
                        }

                        //Skill
                        foreach (var item1 in lsSkill)
                        {
                            dbCharSkill skill = new dbCharSkill()
                            {
                                afflictionSkill = item1.afflictionSkill,
                                category = item1.category,
                                cooldown = item1.cooldown,
                                countTurn = item1.countTurn,
                                descriptions = item1.descriptions,
                                effect = item1.effect,
                                idCharacter = idCharacter,
                                manaCost = item1.manaCost,
                                name = item1.name,
                                orders = item1.orders,
                                ranges = item1.ranges,
                                slot = item1.slot,
                                status = item1.status,
                                targets = item1.targets,
                                types = item1.types,
                                typeSpawnSkill = item1.typeSpawnSkill,
                                afflictionDuration = item1.afflictionDuration,
                                afflictionProc = item1.afflictionProc
                            };
                            ConnectDB.Entities.dbCharSkills.Add(skill);
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsSkillAttribute)
                            {
                                if (item2.idSkill == item1.id)
                                {
                                    dbCharSkillAttribute att = new dbCharSkillAttribute()
                                    {
                                        attribute = item2.attribute,
                                        growthMod = item2.growthMod,
                                        idSkill = skill.id,
                                        mods = item2.mods,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbCharSkillAttributes.Add(att);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }

                            foreach (var item2 in lsSkillAfflictionAttribute)
                            {
                                if (item2.idSkill == item1.id)
                                {
                                    dbCharSkillAfflictionAttribute att = new dbCharSkillAfflictionAttribute()
                                    {
                                        attribute = item2.attribute,
                                        growthMod = item2.growthMod,
                                        idSkill = skill.id,
                                        mods = item2.mods,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbCharSkillAfflictionAttributes.Add(att);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }

                        //Duyen phan
                        foreach (var item1 in lsChrDuyenPhan)
                        {
                            dbCharDuyenPhan duyen = new dbCharDuyenPhan()
                            {
                                category = item1.category,
                                idCharacter = idCharacter,
                                isOne = item1.isOne,
                                name = item1.name,
                                status = item1.status
                            };
                            ConnectDB.Entities.dbCharDuyenPhans.Add(duyen);
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsDuyenPhanAttribute)
                            {
                                if (item2.idDuyen == item1.id)
                                {
                                    dbCharDuyenPhanAttribute att = new dbCharDuyenPhanAttribute()
                                    {
                                        idDuyen = duyen.id,
                                        status = item2.status,
                                        value = item2.value,
                                        growthMod = item2.growthMod,
                                        attribute = item2.attribute
                                    };
                                    ConnectDB.Entities.dbCharDuyenPhanAttributes.Add(att);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }

                            foreach (var item2 in lsDuyenPhanIDS)
                            {
                                if (item2.idDuyen == item1.id)
                                {
                                    dbCharDuyenPhanID att = new dbCharDuyenPhanID()
                                    {
                                        idDuyen = duyen.id,
                                        status = item2.status,
                                        value = item2.value
                                    };
                                    ConnectDB.Entities.dbCharDuyenPhanIDS.Add(att);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }

                        //Power up
                        foreach (var item1 in lsPowerUpReceipt)
                        {
                            dbCharPowerUpReceipt pow = new dbCharPowerUpReceipt()
                            {
                                gen = item1.gen,
                                idCharacter = idCharacter,
                                status = item1.status
                            };
                            ConnectDB.Entities.dbCharPowerUpReceipts.Add(pow);
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsDetailPowerUp)
                            {
                                if (item2.idReceipt == item1.id)
                                {
                                    dbCharDetailPowerUpReceipt re = new dbCharDetailPowerUpReceipt()
                                    {
                                        amount = item2.amount,
                                        idItem = item2.idItem,
                                        idReceipt = pow.id,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbCharDetailPowerUpReceipts.Add(re);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }
                    }
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("ID nhân vật đã tồn tại");
                }
            }
            else
            {
                var result = ConnectDB.Entities.dbCharacters.Where(x => x.id == idCharacter).FirstOrDefault();
                foreach (var item in lsCharacter)
                {
                    result.category = item.category;
                    result.classCharacter = item.classCharacter;
                    result.descriptions = item.descriptions;
                    result.isMain = item.isMain;
                    result.name = item.name;
                    result.orders = item.orders;
                    result.promotion = item.promotion;
                    result.status = 1;
                    result.amountPieceToImport = item.amountPieceToImport;
                    result.idCharHuaNguyen = item.idCharHuaNguyen;
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsCharAttribute)
                    {
                        int idSkill = item1.id;
                        var result1 = ConnectDB.Entities.dbCharAttributes.Where(x => x.id == idSkill).FirstOrDefault();
                        result1.attribute = item1.attribute;
                        result1.growthMod = item1.growthMod;
                        result1.idCharacter = idCharacter;
                        result1.mods = item1.mods;
                        result1.status = item1.status;
                        ConnectDB.Entities.SaveChanges();
                    }

                    //Skill
                    foreach (var item1 in lsSkill)
                    {
                        if (item1.id <= 0)
                        {
                            dbCharSkill skill = new dbCharSkill()
                            {
                                afflictionSkill = item1.afflictionSkill,
                                category = item1.category,
                                cooldown = item1.cooldown,
                                countTurn = item1.countTurn,
                                descriptions = item1.descriptions,
                                effect = item1.effect,
                                idCharacter = idCharacter,
                                manaCost = item1.manaCost,
                                name = item1.name,
                                orders = item1.orders,
                                ranges = item1.ranges,
                                slot = item1.slot,
                                status = item1.status,
                                targets = item1.targets,
                                types = item1.types,
                                typeSpawnSkill = item1.typeSpawnSkill,
                                afflictionDuration = item1.afflictionDuration,
                                afflictionProc = item1.afflictionProc
                            };
                            ConnectDB.Entities.dbCharSkills.Add(skill);
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsSkillAttribute)
                            {
                                if (item2.idSkill == item1.id)
                                {
                                    dbCharSkillAttribute att = new dbCharSkillAttribute()
                                    {
                                        attribute = item2.attribute,
                                        growthMod = item2.growthMod,
                                        idSkill = skill.id,
                                        mods = item2.mods,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbCharSkillAttributes.Add(att);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }

                            foreach (var item2 in lsSkillAfflictionAttribute)
                            {
                                if (item2.idSkill == item1.id)
                                {
                                    dbCharSkillAfflictionAttribute att = new dbCharSkillAfflictionAttribute()
                                    {
                                        attribute = item2.attribute,
                                        growthMod = item2.growthMod,
                                        idSkill = skill.id,
                                        mods = item2.mods,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbCharSkillAfflictionAttributes.Add(att);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            int idSkill = item1.id;
                            var result1 = ConnectDB.Entities.dbCharSkills.Where(x => x.id == idSkill).FirstOrDefault();
                            result1.afflictionSkill = item1.afflictionSkill;
                            result1.category = item1.category;
                            result1.cooldown = item1.cooldown;
                            result1.countTurn = item1.countTurn;
                            result1.descriptions = item1.descriptions;
                            result1.effect = item1.effect;
                            result1.idCharacter = idCharacter;
                            result1.manaCost = item1.manaCost;
                            result1.name = item1.name;
                            result1.orders = item1.orders;
                            result1.ranges = item1.ranges;
                            result1.slot = item1.slot;
                            result1.status = item1.status;
                            result1.targets = item1.targets;
                            result1.types = item1.types;
                            result1.typeSpawnSkill = item1.typeSpawnSkill;
                            result1.afflictionDuration = item1.afflictionDuration;
                            result1.afflictionProc = item1.afflictionProc;
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsSkillAttribute)
                            {
                                if (item2.idSkill == item1.id)
                                {
                                    if (item2.id <= 0)
                                    {
                                        dbCharSkillAttribute att = new dbCharSkillAttribute()
                                        {
                                            attribute = item2.attribute,
                                            growthMod = item2.growthMod,
                                            idSkill = idSkill,
                                            mods = item2.mods,
                                            status = item2.status
                                        };
                                        ConnectDB.Entities.dbCharSkillAttributes.Add(att);
                                    }
                                    else
                                    {
                                        int idAttSkill = item2.id;
                                        var result2 = ConnectDB.Entities.dbCharSkillAttributes.Where(x => x.id == idAttSkill).FirstOrDefault();
                                        result2.attribute = item2.attribute;
                                        result2.growthMod = item2.growthMod;
                                        result2.idSkill = idSkill;
                                        result2.mods = item2.mods;
                                        result2.status = item2.status;
                                    }
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }

                            foreach (var item2 in lsSkillAfflictionAttribute)
                            {
                                if (item2.idSkill == item1.id)
                                {
                                    if (item2.id <= 0)
                                    {
                                        dbCharSkillAfflictionAttribute att = new dbCharSkillAfflictionAttribute()
                                        {
                                            attribute = item2.attribute,
                                            growthMod = item2.growthMod,
                                            idSkill = idSkill,
                                            mods = item2.mods,
                                            status = item2.status
                                        };
                                        ConnectDB.Entities.dbCharSkillAfflictionAttributes.Add(att);
                                    }
                                    else
                                    {
                                        int idAttSkill = item2.id;
                                        var result2 = ConnectDB.Entities.dbCharSkillAfflictionAttributes.Where(x => x.id == idAttSkill).FirstOrDefault();
                                        result2.attribute = item2.attribute;
                                        result2.growthMod = item2.growthMod;
                                        result2.idSkill = idSkill;
                                        result2.mods = item2.mods;
                                        result2.status = item2.status;
                                    }
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }
                    }

                    //Duyen phan
                    foreach (var item1 in lsChrDuyenPhan)
                    {
                        if (item1.id <= 0)
                        {
                            dbCharDuyenPhan duyen = new dbCharDuyenPhan()
                            {
                                category = item1.category,
                                idCharacter = idCharacter,
                                isOne = item1.isOne,
                                name = item1.name,
                                status = item1.status
                            };
                            ConnectDB.Entities.dbCharDuyenPhans.Add(duyen);
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsDuyenPhanAttribute)
                            {
                                if (item2.idDuyen == item1.id)
                                {
                                    dbCharDuyenPhanAttribute att = new dbCharDuyenPhanAttribute()
                                    {
                                        idDuyen = duyen.id,
                                        status = item2.status,
                                        value = item2.value,
                                        growthMod = item2.growthMod,
                                        attribute = item2.attribute
                                    };
                                    ConnectDB.Entities.dbCharDuyenPhanAttributes.Add(att);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }

                            foreach (var item2 in lsDuyenPhanIDS)
                            {
                                if (item2.idDuyen == item1.id)
                                {
                                    dbCharDuyenPhanID att = new dbCharDuyenPhanID()
                                    {
                                        idDuyen = duyen.id,
                                        status = item2.status,
                                        value = item2.value
                                    };
                                    ConnectDB.Entities.dbCharDuyenPhanIDS.Add(att);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            int idDuyen = item1.id;
                            var result1 = ConnectDB.Entities.dbCharDuyenPhans.Where(x => x.id == idDuyen).FirstOrDefault();
                            result1.category = item1.category;
                            result1.idCharacter = idCharacter;
                            result1.isOne = item1.isOne;
                            result1.name = item1.name;
                            result1.status = item1.status;
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsDuyenPhanAttribute)
                            {
                                if (item2.idDuyen == item1.id)
                                {
                                    if (item2.id <= 0)
                                    {
                                        dbCharDuyenPhanAttribute att = new dbCharDuyenPhanAttribute()
                                        {
                                            idDuyen = idDuyen,
                                            status = item2.status,
                                            value = item2.value,
                                            growthMod = item2.growthMod,
                                            attribute = item2.attribute
                                        };
                                        ConnectDB.Entities.dbCharDuyenPhanAttributes.Add(att);
                                    }
                                    else
                                    {
                                        int idAtt = item2.id;
                                        var result2 = ConnectDB.Entities.dbCharDuyenPhanAttributes.Where(x => x.id == idAtt).FirstOrDefault();
                                        result2.idDuyen = idDuyen;
                                        result2.status = item2.status;
                                        result2.value = item2.value;
                                        result2.growthMod = item2.growthMod;
                                        result2.attribute = item2.attribute;
                                    }
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }

                            foreach (var item2 in lsDuyenPhanIDS)
                            {
                                if (item2.idDuyen == item1.id)
                                {
                                    if (item2.id <= 0)
                                    {
                                        dbCharDuyenPhanID att = new dbCharDuyenPhanID()
                                        {
                                            idDuyen = idDuyen,
                                            status = item2.status,
                                            value = item2.value
                                        };
                                        ConnectDB.Entities.dbCharDuyenPhanIDS.Add(att);
                                    }
                                    else
                                    {
                                        int idAtt = item2.id;
                                        var result2 = ConnectDB.Entities.dbCharDuyenPhanIDS.Where(x => x.id == idAtt).FirstOrDefault();
                                        result2.idDuyen = idDuyen;
                                        result2.status = item2.status;
                                        result2.value = item2.value;
                                    }
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }
                    }

                    //Power up
                    foreach (var item1 in lsPowerUpReceipt)
                    {
                        if (item1.id <= 0)
                        {
                            dbCharPowerUpReceipt pow = new dbCharPowerUpReceipt()
                            {
                                gen = item1.gen,
                                idCharacter = idCharacter,
                                status = item1.status
                            };
                            ConnectDB.Entities.dbCharPowerUpReceipts.Add(pow);
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsDetailPowerUp)
                            {
                                if (item2.idReceipt == item1.id)
                                {
                                    dbCharDetailPowerUpReceipt re = new dbCharDetailPowerUpReceipt()
                                    {
                                        amount = item2.amount,
                                        idItem = item2.idItem,
                                        idReceipt = pow.id,
                                        status = item2.status
                                    };
                                    ConnectDB.Entities.dbCharDetailPowerUpReceipts.Add(re);
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            int idPow = item1.id;
                            var result1 = ConnectDB.Entities.dbCharPowerUpReceipts.Where(x => x.id == idPow).FirstOrDefault();
                            result1.gen = item1.gen;
                            result1.idCharacter = idCharacter;
                            result1.status = item1.status;
                            ConnectDB.Entities.SaveChanges();

                            foreach (var item2 in lsDetailPowerUp)
                            {
                                if (item2.idReceipt == item1.id)
                                {
                                    if (item2.id <= 0)
                                    {
                                        dbCharDetailPowerUpReceipt re = new dbCharDetailPowerUpReceipt()
                                        {
                                            amount = item2.amount,
                                            idItem = item2.idItem,
                                            idReceipt = idPow,
                                            status = item2.status
                                        };
                                        ConnectDB.Entities.dbCharDetailPowerUpReceipts.Add(re);
                                    }
                                    else
                                    {
                                        int idRe = item2.id;
                                        var result2 = ConnectDB.Entities.dbCharDetailPowerUpReceipts.Where(x => x.id == idRe).FirstOrDefault();
                                        result2.amount = item2.amount;
                                        result2.idItem = item2.idItem;
                                        result2.idReceipt = idPow;
                                        result2.status = item2.status;
                                    }
                                    ConnectDB.Entities.SaveChanges();
                                }
                            }
                        }
                    }
                }
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void gvDuyenPhan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int cate = (int)gvDuyenPhan.GetRowCellValue(gvDuyenPhan.FocusedRowHandle, "category");
            if (e.Column == gvDuyenPhan.Columns["category"])
            {
                if (cate == 1)
                {
                    lueEquipCharacter.DataSource = lsLueDuyenPhanChar;
                }
                else
                {
                    lueEquipCharacter.DataSource = lsLueDuyenPhanEquip;
                }
            }
        }
    }
}
using StaticDB;
using StaticDB.Enum;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BattleSimulator
{
    public class CharacterCalculator
    {
        #region Must Have

        public Entity staticDB { get; set; }
        public int idInStatic { get; set; }
        public int level { get; set; }
        public int levelPowerUp { get; set; }
        public int star { get; set; }

        #endregion

        #region Optional

        public int[] formation { get; set; }
        public List<EquipmentCalculator> equipments { get; set; }
        public int[] powerUpItems { get; set; }
        public MainAttribute[] bonusThanThap { get; set; }
        #endregion

        #region Result Calculator

        private float[] attributes { get; set; }
        private Character info { get; set; }
        private float[] equipmentAttributes { get; set; }
        private float[] buffAttributes { get; set; }

        #endregion

        public CharacterCalculator()
        {

        }

        #region Calculate

        public void Calculate()
        {
            info = staticDB.characters.Where(x => x.id == idInStatic).First();
            attributes = new float[info.attributes.Length];
            equipmentAttributes = new float[info.attributes.Length];
            buffAttributes = new float[info.attributes.Length];

            for (int i = 0; i < attributes.Length; i++)
            {
                //                float modStar = 1f;
                //                if (i <= 4)
                //                {
                //                    modStar = (1f + (staticDB.configs.characterConfig.modStar * star));
                //                }
                //                attributes[i] = (info.attributes[i].mod + (level - 1) * info.attributes[i].growthMod) * modStar;
                attributes[i] = (info.attributes[i].mod + (level - 1) * info.attributes[i].growthMod);
                equipmentAttributes[i] = 0f;
            }

            CalculatePowerUp();
            CalculateEquipment();
            CalculateDuyenPhan();
            CalculateThanThap();
        }

        private void CalculatePowerUp()
        {
            for (int i = 0; i < levelPowerUp; i++)
            {
                //                Receipt[] rc = info.powerupReceipt[i].items;
                //                foreach (var r in rc)
                //                {
                //                    PowerUpItem item = staticDB.powerUpItems.Where(x => x.id == r.idItem).FirstOrDefault();
                //                    for (int a = 0; a < r.amount; a++)
                //                    {
                //                        foreach (var att in item.attributes)
                //                        {
                //                            attributes[(int)att.attribute - 1] += att.mod;
                //                        }
                //                    }
                //                }
            }
            if (powerUpItems != null)
            {
                for (int i = 0; i < powerUpItems.Length; i++)
                {
                    if (powerUpItems[i] != -1)
                    {
                        int idItem = powerUpItems[i];
                        PowerUpItem item = staticDB.powerUpItems.Where(x => x.id == idItem).FirstOrDefault();
                        foreach (var att in item.attributes)
                        {
                            attributes[(int)att.attribute - 1] += att.mod;
                        }
                    }
                }
            }
        }

        private void CalculateEquipment()
        {
            if (equipments != null)
            {
                foreach (var eq in equipments)
                {
                    eq.Calculate(staticDB);
                    var eAttributes = eq.GetAttributes();
                    foreach (var att in eAttributes)
                    {
                        equipmentAttributes[((int)att.attribute - 1)] += att.mod;
                    }
                }
            }
        }

        private void CalculateDuyenPhan()
        {
            if (info.duyenphans != null)
            {
                for (int i = 0; i < info.duyenphans.Length; i++)
                {
                    if (info.duyenphans[i].category == (short)CategoryDuyenPhan.Character)
                    {
                        if (formation != null)
                        {
                            if (info.duyenphans[i].ids.Length == 1)
                            {
                                foreach (int id in formation)
                                {
                                    if (info.duyenphans[i].ids[0] == id)
                                    {
                                        CalculateDPArray(info.duyenphans[i].attributes);
                                        break;
                                    }
                                }
                            }
                            else if (info.duyenphans[i].isOne == true)
                            {
                                foreach (int idDP in info.duyenphans[i].ids)
                                {
                                    bool isBreak = false;
                                    foreach (int id in formation)
                                    {
                                        if (idDP == id)
                                        {
                                            CalculateDPArray(info.duyenphans[i].attributes);
                                            isBreak = true;
                                            break;
                                        }
                                    }
                                    if (isBreak)
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (info.duyenphans[i].isOne == false)
                            {
                                int count = 0;
                                foreach (int idDP in info.duyenphans[i].ids)
                                {
                                    foreach (int id in formation)
                                    {
                                        if (idDP == id)
                                        {
                                            count++;
                                            break;
                                        }
                                    }
                                }
                                if (count == info.duyenphans[i].ids.Length)
                                {
                                    CalculateDPArray(info.duyenphans[i].attributes);
                                }
                            }
                        }
                    }
                    else if (info.duyenphans[i].category == (short)CategoryDuyenPhan.Equipment)
                    {
                        if (equipments != null)
                        {
                            if (info.duyenphans[i].ids.Length == 1)
                            {
                                foreach (var eq in equipments)
                                {
                                    if (eq != null)
                                    {
                                        if (info.duyenphans[i] == null || eq.GetInfo() == null)
                                            continue;
                                        if (info.duyenphans[i].ids[0] == eq.GetInfo().id)
                                        {
                                            CalculateDPArray(info.duyenphans[i].attributes);
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (info.duyenphans[i].isOne == true)
                            {
                                foreach (int idDP in info.duyenphans[i].ids)
                                {
                                    bool isBreak = false;
                                    foreach (var eq in equipments)
                                    {
                                        if (eq != null)
                                        {
                                            if (idDP == eq.GetInfo().id)
                                            {
                                                CalculateDPArray(info.duyenphans[i].attributes);
                                                isBreak = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (isBreak)
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (info.duyenphans[i].isOne == false)
                            {
                                int count = 0;
                                foreach (int idDP in info.duyenphans[i].ids)
                                {
                                    foreach (var eq in equipments)
                                    {
                                        if (eq != null)
                                        {
                                            if (idDP == eq.GetInfo().id)
                                            {
                                                count++;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (count == info.duyenphans[i].ids.Length)
                                {
                                    CalculateDPArray(info.duyenphans[i].attributes);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CalculateDPArray(MainAttribute[] attributes)
        {
            foreach (var att in attributes)
            {
                CalculateDP(att);
            }
        }

        private void CalculateDP(MainAttribute att)
        {
            attributes[(int)att.attribute - 1] += (att.mod / 100f) * GetBaseAttribute(att.attribute);
        }

        public void CalculateThanThap()
        {
            if (bonusThanThap != null)
            {
                CalculateDPArray(bonusThanThap);
            }
        }
        #endregion

        #region Action

        public float GetAttribute(CharacterAttribute attribute)
        {
            return attributes[(int)attribute - 1] + equipmentAttributes[(int)attribute - 1] + buffAttributes[(int)attribute - 1];
        }

        public void SetBaseAttribute(CharacterAttribute attribute, float v)
        {
            attributes[(int)attribute - 1] = v;
        }

        public float GetBaseAttribute(CharacterAttribute attribute)
        {
            return attributes[(int)attribute - 1] + equipmentAttributes[(int)attribute - 1];
        }

        public Character GetInfo()
        {
            return info;
        }

        public void Buff(CharacterAttribute attribute, float modifier)
        {
            buffAttributes[(int)attribute - 1] += GetBaseAttribute(attribute) * modifier / 100f;
        }

        public void Debuff(CharacterAttribute attribute, float modifier)
        {
            buffAttributes[(int)attribute - 1] -= GetBaseAttribute(attribute) * modifier / 100f;
        }

        public void BuffPoint(CharacterAttribute attribute, float point)
        {
            buffAttributes[(int)attribute - 1] += point;
        }

        public void DeBuffPoint(CharacterAttribute attribute, float point)
        {
            buffAttributes[(int)attribute - 1] -= point;
        }

        public double GetPower()
        {
            double power = GetAttribute(CharacterAttribute.Hp) +
                GetAttribute(CharacterAttribute.Def) * 10 +
                GetAttribute(CharacterAttribute.Agi) * 10 +
                GetAttribute(CharacterAttribute.Magic) * 5 +
                GetAttribute(CharacterAttribute.Physic) * 5 +
                GetAttribute(CharacterAttribute.Accurate) * 100 +
                GetAttribute(CharacterAttribute.CritRate) * 100 +
                GetAttribute(CharacterAttribute.CritModifier) * 20 +
                GetAttribute(CharacterAttribute.BlockRate) * 100 +
                GetAttribute(CharacterAttribute.BlockModifier) * 20 +
                GetAttribute(CharacterAttribute.ResistCrit) * 100;

            if (equipments != null)
            {
                foreach (var eq in equipments)
                {
                    //power += eq.levelPowerUp * (eq.star + 1) * (eq.GetInfo().promotion + 1) * 0.5f;
                }
            }

            return power;
        }

        #endregion
    }
}

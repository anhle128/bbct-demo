using StaticDB;
using StaticDB.Models;

namespace BattleSimulator
{
    public class EquipmentCalculator
    {
        public int idStatic { get; set; }
        public int levelPowerUp { get; set; }
        public int star { get; set; }

        private Equipment info;

        private MainAttribute[] attributes;

        public EquipmentCalculator()
        {

        }

        public void Calculate(Entity staticDB)
        {
            //            info = staticDB.equipments.FirstOrDefault(x => x.id == idStatic);
            //            attributes = new MainAttribute[info.attributes.Length];
            //
            //            for (int i = 0; i < attributes.Length; i++)
            //            {
            //                MainAttribute mA = new MainAttribute()
            //                {
            //                    attribute = info.attributes[i].attribute,
            //                    mod = (info.attributes[i].mod + (info.attributes[i].growthMod * levelPowerUp))
            //                };
            //                mA.mod = mA.mod + mA.mod * (staticDB.configs.equipmentConfig.modStar * star);
            //
            //                attributes[i] = mA;
            //            }
        }

        public MainAttribute[] GetAttributes()
        {
            return attributes;
        }

        public Equipment GetInfo()
        {
            return info;
        }
    }
}

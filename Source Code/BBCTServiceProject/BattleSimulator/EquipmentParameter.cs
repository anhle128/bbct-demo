using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleSimulator
{
    public class EquipmentParameter
    {
        public int idStatic { get; set; }
        public int levelPowerUp { get; set; }
        public int star { get; set; }

        public EquipmentParameter()
        {

        }

        public EquipmentCalculator ConvertToCalculator()
        {
            return new EquipmentCalculator()
            {
                idStatic = idStatic,
                levelPowerUp = levelPowerUp,
                star = star
            };
        }
    }
}

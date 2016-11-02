
using StaticDB.Enum;
using StaticDB.Models;
using System.Collections.Generic;

namespace BattleSimulator
{
    public class CharacterParameter
    {
        public string idInDatabase { get; set; }
        public int idInStatic { get; set; }
        public int level { get; set; }
        public int levelPowerUp { get; set; }
        public int star { get; set; }
        public bool isMainTeam { get; set; }
        public int levelNormalSkill { get; set; }
        public int levelUltimateSkill { get; set; }
        public int levelUltimateSkill2 { get; set; }
        public int levelPassiveSkill1 { get; set; }
        public int colFormation { get; set; }
        public int rowFormation { get; set; }
        public ICharacterViewer viewer { get; set; }
        public int[] powerUpItems { get; set; }
        public int[] formation { get; set; }
        public List<EquipmentParameter> equipments { get; set; }
        public MainAttribute[] bonusThanThap { get; set; }
        public TypeElement typeElement { get; set; }

        public int indexSkillUltimate { get; set; }
        public int indexSkillPassive1 { get; set; }
        public int indexSkillPassive2 { get; set; }


        public CharacterParameter()
        {

        }

        public List<EquipmentCalculator> GetEquipmentsCalculator()
        {
            if (equipments == null)
            {
                return null;
            }
            else
            {
                List<EquipmentCalculator> eQ = new List<EquipmentCalculator>();
                foreach (var item in equipments)
                {
                    eQ.Add(item.ConvertToCalculator());
                }
                return eQ;
            }
        }
    }
}

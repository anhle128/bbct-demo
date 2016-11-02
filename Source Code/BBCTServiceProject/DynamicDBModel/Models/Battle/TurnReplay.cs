using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models.Battle
{
    [ProtoContract]
    public class TurnReplay
    {
        public enum TypeSkillCharacter : int
        {
            Normal = 1,
            Ultimate = 2,
            Passive = 3,
        }

        [ProtoMember(1)]
        public string idOwner { get; set; }

        [ProtoMember(2)]
        public bool canProcSkill { get; set; }

        [ProtoMember(3)]
        public TypeSkillCharacter typeSkill { get; set; }

        [ProtoMember(4)]
        public List<TargetReplay> targets { get; set; }

        [ProtoMember(5)]
        public int manaTeamA { get; set; }

        [ProtoMember(6)]
        public int manaTeamB { get; set; }

        [ProtoMember(7)]
        public float affDmg { get; set; }

        [ProtoMember(8)]
        public int hp { get; set; }

        [ProtoMember(9)]
        public int result { get; set; }

        public TurnReplay()
        {

        }
    }
}

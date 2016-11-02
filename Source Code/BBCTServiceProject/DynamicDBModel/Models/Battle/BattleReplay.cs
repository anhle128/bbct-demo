using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicDBModel.Models.Battle
{
    [ProtoContract]
    public class BattleReplay
    {
        [ProtoMember(1)]
        public int result { get; set; }

        [ProtoMember(2)]
        public int turnEnd { get; set; }

        [ProtoMember(3)]
        public int idBackground { get; set; }

        [ProtoMember(4)]
        public List<TurnReplay> turns { get; set; }

        [ProtoMember(5)]
        public List<CharacterReplay> teamA { get; set; }

        [ProtoMember(6)]
        public List<CharacterReplay> teamB { get; set; }

        [ProtoMember(7)]
        public int star { get; set; }

        [ProtoMember(8)]
        public List<CharacterReplay> teamAS { get; set; }

        [ProtoMember(9)]
        public List<CharacterReplay> teamBS { get; set; }
        [ProtoMember(10)]
        public List<CharacterReplay> teamASStart { get; set; }

        [ProtoMember(11)]
        public List<CharacterReplay> teamBSStart { get; set; }

        public BattleReplay()
        {

        }
    }
}

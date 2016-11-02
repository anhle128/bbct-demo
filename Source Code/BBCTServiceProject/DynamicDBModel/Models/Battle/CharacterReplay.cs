using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicDBModel.Models.Battle
{
    [ProtoContract]
    public class CharacterReplay
    {
        [ProtoMember(1)]
        public string id { get; set; }
        [ProtoMember(2)]
        public int idStatic { get; set; }
        [ProtoMember(3)]
        public int level { get; set; }
        [ProtoMember(4)]
        public int powerUpLevel { get; set; }
        [ProtoMember(5)]
        public int star { get; set; }
        [ProtoMember(6)]
        public int colFormation { get; set; }
        [ProtoMember(7)]
        public int rowFormation { get; set; }
        [ProtoMember(8)]
        public float hpMax { get; set; }
        [ProtoMember(9)]
        public int indexUltimate { get; set; }
        [ProtoMember(10)]
        public bool isMain { get; set; }

        public CharacterReplay()
        {

        }
    }
}

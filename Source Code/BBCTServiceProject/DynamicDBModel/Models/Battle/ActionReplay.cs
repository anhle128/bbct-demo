using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicDBModel.Models.Battle
{
    [ProtoContract]
    public class ActionReplay
    {
        [ProtoMember(1)]
        public int attribute { get; set; }

        [ProtoMember(2)]
        public int hp { get; set; }

        [ProtoMember(3)]
        public bool isMiss { get; set; }

        [ProtoMember(4)]
        public bool isCrit { get; set; }

        [ProtoMember(5)]
        public bool isAffliction { get; set; }

        [ProtoMember(6)]
        public bool isBlock { get; set; }
    }
}

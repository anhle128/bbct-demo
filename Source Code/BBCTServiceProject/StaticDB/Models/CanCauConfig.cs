using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class CanCauConfig
    {
        [ProtoMember(1)]
        public string name;
        [ProtoMember(2)]
        public int gold;
        [ProtoMember(3)]
        public int silver;
        [ProtoMember(4)]
        public int vipRequire;
        [ProtoMember(5)]
        public int duration;
        [ProtoMember(6)]
        public Reward[] rewards;
    }
}

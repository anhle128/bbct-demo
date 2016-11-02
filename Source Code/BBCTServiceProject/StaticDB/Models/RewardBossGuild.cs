using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class RewardBossGuild
    {
        [ProtoMember(1)]
        public int minRange { get; set; }
        [ProtoMember(2)]
        public int maxRange { get; set; }
        [ProtoMember(3)]
        public Reward[] rewards { get; set; }
    }
}

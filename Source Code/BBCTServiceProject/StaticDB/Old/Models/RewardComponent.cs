using ProtoBuf;
using System;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class RewardComponent
    {
        [ProtoMember(1)]
        public int startRatings { get; set; }

        [ProtoMember(2)]
        public int endRatings { get; set; }

        [ProtoMember(3)]
        public int glory { get; set; }
    }
}

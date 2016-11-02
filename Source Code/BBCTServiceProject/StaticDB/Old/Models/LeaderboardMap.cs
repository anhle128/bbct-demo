using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class LeaderboardMap
    {
        [ProtoMember(1)]
        public List<SubReward> rewards { get; set; }
    }
}

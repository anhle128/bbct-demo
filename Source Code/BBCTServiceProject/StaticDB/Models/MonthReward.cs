using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class MonthReward
    {
        [ProtoMember(1)]
        public int month { get; set; }
        [ProtoMember(2)]
        public List<Reward> rewards { get; set; }
    }
}

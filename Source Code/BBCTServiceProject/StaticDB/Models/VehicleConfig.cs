using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class VehicleConfig
    {
        [ProtoMember(1)]
        public int proc { get; set; }
        [ProtoMember(2)]
        public int silverReward { get; set; }
        [ProtoMember(3)]
        public Reward[] protectRewards { get; set; }
        [ProtoMember(4)]
        public Reward[] robRewards { get; set; }
    }
}

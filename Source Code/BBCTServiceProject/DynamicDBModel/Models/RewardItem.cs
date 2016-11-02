using System.Collections.Generic;
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class RewardItem
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public int type_reward { get; set; }
        [ProtoMember(3)]
        public int static_id { get; set; }
        [ProtoMember(4)]
        public int quantity { get; set; }
        [ProtoMember(5)]
        public List<SubRewardItem> rewards { get; set; } 
    }
}

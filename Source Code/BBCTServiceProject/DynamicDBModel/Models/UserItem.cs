using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserItem
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public int static_id { get; set; }
        [ProtoMember(3)]
        public int quantity { get; set; }
        [ProtoMember(4)]
        public List<SubRewardItem> rewards { get; set; }
    }
}

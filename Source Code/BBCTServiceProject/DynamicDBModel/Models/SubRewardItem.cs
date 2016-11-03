using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class SubRewardItem
    {
        [ProtoMember(1)]
        public int type_reward { get; set; }
        [ProtoMember(2)]
        public int static_id { get; set; }
        [ProtoMember(3)]
        public int quantity { get; set; }
        [ProtoMember(4)]
        public string ruong_bau_id { get; set; }
        [ProtoMember(5)]
        public int star { get; set; } // chỉ dùng cho character
    }
}

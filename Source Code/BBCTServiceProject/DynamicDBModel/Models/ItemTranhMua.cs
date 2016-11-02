
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class ItemTranhMua
    {
        [ProtoMember(1)]
        public SubRewardItem item { get; set; }
        [ProtoMember(2)]
        public int quantity { get; set; }
        [ProtoMember(3)]
        public int quantity_sold { get; set; }
        [ProtoMember(4)]
        public int price { get; set; }
        [ProtoMember(5)]
        public int quantity_each_user_can_buy { get; set; }
    }
}

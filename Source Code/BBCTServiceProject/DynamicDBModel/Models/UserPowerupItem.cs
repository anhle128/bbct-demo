using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserPowerUpItem
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public int item_id { get; set; }
        [ProtoMember(3)]
        public int quantity { get; set; }
    }
}

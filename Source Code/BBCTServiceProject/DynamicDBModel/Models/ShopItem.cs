using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class ShopItem
    {
        [ProtoMember(1)]
        public string _id;

        [ProtoMember(2)]
        public RewardItem reward;

        [ProtoMember(3)]
        public int gold;

        [ProtoMember(4)]
        public int totalNumberCanBuy;

        [ProtoMember(5)]
        public int totalNumberBought;
    }
}

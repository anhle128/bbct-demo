using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class LuanKiemShopItem
    {
        [ProtoMember(1)]
        public string _id { get; set; }

        [ProtoMember(2)]
        public RewardItem reward { get; set; }

        [ProtoMember(3)]
        public int pointLuanKiem { get; set; }

        [ProtoMember(4)]
        public int totalNumberCanBuy { get; set; }

        [ProtoMember(5)]
        public int totalNumberBought { get; set; }
        [ProtoMember(6)]
        public int rankRequire { get; set; }
    }
}

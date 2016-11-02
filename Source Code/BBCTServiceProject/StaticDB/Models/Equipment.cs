using ProtoBuf;
using StaticDB.Enum;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Equipment
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int icon { get; set; }
        [ProtoMember(3)]
        public string name { get; set; }
        [ProtoMember(4)]
        public string description { get; set; }
        [ProtoMember(5)]
        public CategoryEquipment category { get; set; }
        [ProtoMember(6)]
        public MainAttribute attribute { get; set; }
        [ProtoMember(7)]
        public ElementBonusAttribute[] bonusAttributes { get; set; }
        [ProtoMember(8)]
        public int baseMarketPrice { get; set; }
        [ProtoMember(9)]
        public bool canSellMarket { get; set; }
        [ProtoMember(10)]
        public int lowestStarLevel { get; set; } // số sao nhỏ nhất của trang bi
        [ProtoMember(11)]
        public int highestStarLevel { get; set; } // số sao lớn nhất của trang bị

        public Equipment()
        {

        }
    }
}

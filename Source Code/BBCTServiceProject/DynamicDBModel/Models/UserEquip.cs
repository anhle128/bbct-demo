using ProtoBuf;
using StaticDB.Enum;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserEquip
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public int equip_id { get; set; }
        [ProtoMember(3)]
        public int powerup_level { get; set; } // cường hóa
        [ProtoMember(4)]
        public int star_level { get; set; } // tinh luyện
        [ProtoMember(5)]
        public string char_equip { get; set; }
        [ProtoMember(6)]
        public TypeElement element { get; set; }
        [ProtoMember(7)]
        public CharacterAttribute bonusAttribute { get; set; }
        [ProtoMember(8)]
        public float bonusAttributeGrowMod { get; set; }
        [ProtoMember(9)]
        public float bonusAttributeMod { get; set; }
    }
}

using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class EquipStarUpConfig
    {
        [ProtoMember(1)]
        public float[] rateByPromotion { get; set; }
        [ProtoMember(2)]
        public int star { get; set; } // số sao của equip được thăng sao
        [ProtoMember(3)]
        public int promotion { get; set; } // promotion của eqiup được thăng sao

    }
}

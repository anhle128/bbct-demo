using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class EquipLevelUpConfig
    {
        [ProtoMember(1)]
        public int baseGold { get; set; }
        [ProtoMember(2)]
        public float[] powRateByPromotion { get; set; }
    }
}

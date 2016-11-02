using ProtoBuf;
using StaticDB.Enum;

namespace StaticDB.Models
{
    [ProtoContract]
    public class BonusAttribute
    {
        [ProtoMember(1)]
        public CharacterAttribute attribute { get; set; }

        [ProtoMember(2)]
        public float minMod { get; set; }
        [ProtoMember(3)]
        public float maxMod { get; set; }
        [ProtoMember(4)]
        public float minGrowMod { get; set; }
        [ProtoMember(5)]
        public float maxGrowMod { get; set; }
        [ProtoMember(6)]
        public float proc { get; set; }

    }
}

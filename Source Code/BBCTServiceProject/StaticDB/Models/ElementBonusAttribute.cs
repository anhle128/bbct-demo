using ProtoBuf;
using StaticDB.Enum;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ElementBonusAttribute
    {
        [ProtoMember(1)]
        public TypeElement element { get; set; }

        [ProtoMember(2)]
        public BonusAttribute[] bonusAttributes { get; set; }
    }
}

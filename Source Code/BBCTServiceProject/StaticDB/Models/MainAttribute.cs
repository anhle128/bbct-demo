using ProtoBuf;
using StaticDB.Enum;

namespace StaticDB.Models
{
    [ProtoContract]
    public class MainAttribute
    {
        [ProtoMember(1)]
        public CharacterAttribute attribute { get; set; }
        [ProtoMember(2)]
        public float mod { get; set; }
        [ProtoMember(3)]
        public float growthMod { get; set; }
    }
}

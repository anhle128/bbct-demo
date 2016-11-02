using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class CharacterLevelExp
    {
        [ProtoMember(1)]
        public int level { get; set; }
        [ProtoMember(2)]
        public int exp { get; set; }

    }
}

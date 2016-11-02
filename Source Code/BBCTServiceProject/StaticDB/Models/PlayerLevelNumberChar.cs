using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class PlayerLevelNumberChar
    {
        [ProtoMember(1)]
        public int level { get; set; }
        [ProtoMember(2)]
        public int maxNumberChar { get; set; }
    }
}

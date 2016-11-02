
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class LevelNumCharInFormation
    {
        [ProtoMember(1)]
        public int level { get; set; }
        [ProtoMember(2)]
        public int numberCharInFormation { get; set; }
    }
}

using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class CharSelection
    {
        [ProtoMember(1)]
        public int id;
        [ProtoMember(2)]
        public int background;
    }
}

using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Range
    {
        [ProtoMember(1)]
        public int start;

        [ProtoMember(2)]
        public int end;
    }
}

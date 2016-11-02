using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Hour
    {
        [ProtoMember(1)]
        public int hour { get; set; }
        [ProtoMember(2)]
        public int minute { get; set; }
    }
}

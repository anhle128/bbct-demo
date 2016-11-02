using ProtoBuf;

namespace StaticDB.Models
{

    [ProtoContract]
    public class PlusAttributeRequire
    {
        [ProtoMember(1)]
        public int startRequire { get; set; }
        [ProtoMember(2)]
        public int procReceive { get; set; }
    }
}

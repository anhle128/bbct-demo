using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class StarUpReceipt
    {
        [ProtoMember(1)]
        public Receipt[] items { get; set; }
    }
}

using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class PowerUpReceipt
    {
        [ProtoMember(1)]
        public Receipt[] items { get; set; }
    }
}

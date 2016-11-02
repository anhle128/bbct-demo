using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class MoneyResetThanThap
    {
        [ProtoMember(1)]
        public int type;
        [ProtoMember(2)]
        public int quantity;

    }
}

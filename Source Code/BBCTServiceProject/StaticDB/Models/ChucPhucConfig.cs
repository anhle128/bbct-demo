using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ChucPhucConfig
    {
        [ProtoMember(1)]
        public int maxChucPhuc { get; set; }
    }
}

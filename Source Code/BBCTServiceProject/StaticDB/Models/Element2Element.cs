using ProtoBuf;
using StaticDB.Enum;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Element2Element
    {
        public TypeElement element { get; set; }
        public TypeElement elementSupport { get; set; }
    }
}

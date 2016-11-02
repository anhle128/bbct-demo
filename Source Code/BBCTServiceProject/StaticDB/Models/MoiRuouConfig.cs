
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class MoiRuouConfig
    {
        [ProtoMember(1)]
        public int stamina;
    }
}


using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class RuongRewardConfig
    {
        [ProtoMember(1)]
        public int idRuong { get; set; }
        [ProtoMember(2)]
        public Reward[] rewards { get; set; }
    }
}

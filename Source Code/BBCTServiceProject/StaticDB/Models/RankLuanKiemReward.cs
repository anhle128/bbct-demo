using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class RankLuanKiemReward
    {
        [ProtoMember(1)]
        public Range rangeRank { get; set; }
        [ProtoMember(2)]
        public Reward[] rewards { get; set; }
    }
}

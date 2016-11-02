using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class RankLuanKiemPoint
    {
        [ProtoMember(1)]
        public Range rank { get; set; }
        [ProtoMember(2)]
        public int pointReward { get; set; }
        [ProtoMember(3)]
        public int silverReward { get; set; }
        [ProtoMember(4)]
        public int goldReward { get; set; }
    }
}

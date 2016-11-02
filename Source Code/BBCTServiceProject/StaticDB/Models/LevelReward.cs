using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class LevelReward
    {
        [ProtoMember(1)]
        public int level { get; set; }
        [ProtoMember(2)]
        public Reward[] rewards { get; set; }
    }
}

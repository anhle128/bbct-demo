using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class StarReward
    {
        [ProtoMember(1)]
        public int starRequire { get; set; }
        [ProtoMember(2)]
        public Reward[] rewards { get; set; }
    }
}

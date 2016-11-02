using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class PlayerDefaultConfig
    {
        [ProtoMember(1)]
        public int level { get; set; }
        [ProtoMember(2)]
        public int gold { get; set; }
        [ProtoMember(3)]
        public int silver { get; set; }
        [ProtoMember(4)]
        public int stamina { get; set; }

        [ProtoMember(5)]
        public Reward[] rewards { get; set; }
    }
}

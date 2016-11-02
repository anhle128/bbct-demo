using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class AttackGlobalBossConfig
    {
        [ProtoMember(1)]
        public int vipRequire { get; set; }
        [ProtoMember(2)]
        public int waitTime { get; set; }
    }
}

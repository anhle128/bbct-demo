using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class CharDefaultConfig
    {
        [ProtoMember(1)]
        public int levelSkill { get; set; }
        [ProtoMember(2)]
        public int starSkill { get; set; }
        [ProtoMember(3)]
        public int levelChar { get; set; }
        [ProtoMember(4)]
        public int powerupLevelChar { get; set; }
    }
}

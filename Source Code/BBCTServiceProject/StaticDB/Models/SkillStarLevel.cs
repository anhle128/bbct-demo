using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class SkillStarLevel
    {
        [ProtoMember(1)]
        public int star { get; set; }
        [ProtoMember(2)]
        public int numberItemRequire { get; set; }
        [ProtoMember(3)]
        public int silverRequire { get; set; }
        [ProtoMember(4)]
        public int maxLevel { get; set; }
    }
}

using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class LevelSkill
    {
        [ProtoMember(1)]

        public int level;

        [ProtoMember(2)]
        public int star { get; set; }
    }
}

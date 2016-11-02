
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class TutorialConfig
    {
        [ProtoMember(1)]
        public int normalCharReward { get; set; }
        [ProtoMember(2)]
        public int specialCharReward { get; set; }
    }
}

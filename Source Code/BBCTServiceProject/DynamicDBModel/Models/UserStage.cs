using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserStage
    {
        [ProtoMember(1)]
        public StageMode stage { get; set; }
        [ProtoMember(2)]
        public int star { get; set; }
        [ProtoMember(3)]
        public int attack_times { get; set; }

    }
}

using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class FormationConfig
    {
        [ProtoMember(1)]
        public LevelOpendSlotMainFormation[] levelOpendSlotMainFormation { get; set; }
        [ProtoMember(2)]
        public int vipRequireOpendLastMainFormation { get; set; }
        [ProtoMember(3)]
        public int levelRequireOpendSubFormation { get; set; }
        [ProtoMember(4)]
        public int maxNumberCharInFormation { get; set; }
        [ProtoMember(5)]
        public int totalNumberFormation { get; set; }
    }
}

using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class MonsterStage
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int level { get; set; }
        [ProtoMember(3)]
        public int levelPower { get; set; }
        [ProtoMember(4)]
        public int star { get; set; }
        [ProtoMember(5)]
        public int col { get; set; }
        [ProtoMember(6)]
        public int row { get; set; }

    }
}

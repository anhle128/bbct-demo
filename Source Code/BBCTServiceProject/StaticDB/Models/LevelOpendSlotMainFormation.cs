using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class LevelOpendSlotMainFormation
    {
        [ProtoMember(1)]
        public int level { get; set; }
        [ProtoMember(2)]

        public int slotOpend { get; set; }
    }
}

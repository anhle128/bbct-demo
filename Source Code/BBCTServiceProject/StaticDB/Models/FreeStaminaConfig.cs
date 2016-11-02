using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class FreeStaminaConfig
    {
        [ProtoMember(1)]
        public int from { get; set; }
        [ProtoMember(2)]
        public int to { get; set; }
        [ProtoMember(3)]
        public int stamina { get; set; }
    }
}

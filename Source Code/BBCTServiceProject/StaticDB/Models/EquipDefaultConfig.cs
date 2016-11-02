using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class EquipDefaultConfig
    {
        [ProtoMember(1)]
        public int powerup { get; set; }
    }
}

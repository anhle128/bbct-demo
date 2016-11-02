using ProtoBuf;
using StaticDB.Enum;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Equip2Equip
    {
        [ProtoMember(1)]
        public CategoryEquipment equip { get; set; }
        [ProtoMember(2)]
        public CategoryEquipment equipSupport { get; set; }
    }
}

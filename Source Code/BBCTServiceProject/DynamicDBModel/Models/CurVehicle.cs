using ProtoBuf;
using StaticDB.Enum;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class CurVehicle
    {
        [ProtoMember(1)]
        public TypeVehicle type { get; set; }
        [ProtoMember(2)]
        public double time { get; set; }
        [ProtoMember(3)]
        public bool going_on { get; set; }
        [ProtoMember(4)]
        public int countTimesBiCuop { get; set; }
        [ProtoMember(5)]
        public List<SubRewardItem> rewards { get; set; }
    }
}

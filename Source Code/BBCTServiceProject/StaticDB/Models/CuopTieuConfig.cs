using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class CuopTieuConfig
    {
        //[ProtoMember(1)]
        //public int maxTimesCuopTieu { get; set; }
        [ProtoMember(2)]
        public int maxTimesVehicleBiCuop { get; set; }
        [ProtoMember(3)]
        public int procLoseSilver { get; set; }
        [ProtoMember(4)]
        public int procGetSilver { get; set; }
    }
}

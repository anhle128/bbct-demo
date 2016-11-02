
using ProtoBuf;
using StaticDB.Enum;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class VanTieuConfig
    {
        [ProtoMember(1)]
        public List<VehicleConfig> vehicles { get; set; }
        [ProtoMember(2)]
        public int vipRequireToEnd { get; set; }
        [ProtoMember(3)]
        public int goldRequireToEnd { get; set; }
        [ProtoMember(4)]
        public int goldRefeshVehicle { get; set; }
        [ProtoMember(5)]
        public int minutesDurationTime { get; set; }
        [ProtoMember(6)]
        public int levelRequire { get; set; }
        public VehicleConfig GetVehicle(TypeVehicle type)
        {
            return vehicles[(int)type];
        }

        public double GetSecondDurationTime()
        {
            return minutesDurationTime * 60;
        }


    }
}

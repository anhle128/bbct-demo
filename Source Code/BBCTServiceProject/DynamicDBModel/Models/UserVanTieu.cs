using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserVanTieu
    {
        [ProtoMember(1)]
        public string id { get; set; }
        [ProtoMember(2)]
        public string userid { get; set; }

        [ProtoMember(3)]
        public string nickname { get; set; }
        [ProtoMember(4)]
        public int level { get; set; }
        [ProtoMember(5)]
        public int vip { get; set; }
        [ProtoMember(6)]
        public int times { get; set; }
        [ProtoMember(7)]
        public CurVehicle currentVehicle { get; set; }
    }
}

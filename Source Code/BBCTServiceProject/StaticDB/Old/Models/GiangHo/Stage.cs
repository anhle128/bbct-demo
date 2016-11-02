using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models.GiangHo
{
    [ProtoContract]
    public class Stage
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int stamina { get; set; }
        [ProtoMember(10)]
        public List<Wave> waves { get; set; }
        [ProtoMember(11)]
        public List<Reward> rewards { get; set; }
        [ProtoMember(12)]
        public int silver { get; set; }
        [ProtoMember(13)]
        public int exp { get; set; }
        [ProtoMember(14)]
        public int honor { get; set; }
        [ProtoMember(15)]
        public float posX { get; set; }
        [ProtoMember(16)]
        public float posY { get; set; }
        [ProtoMember(17)]
        public int maxAttack { get; set; }
        [ProtoMember(18)]
        public int idIcon { get; set; }
       
        public Stage()
        { }
    }
}

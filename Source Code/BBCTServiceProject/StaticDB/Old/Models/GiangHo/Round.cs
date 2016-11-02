
using ProtoBuf;
using System.Collections.Generic;
namespace StaticDB.Models.GiangHo
{
    [ProtoContract]
    public class Round
    {
        [ProtoMember(1)]
        public int id { get; set; }
        //[ProtoMember(2)]
        //public string name { get; set; }
        [ProtoMember(2)]
        public int stamina { get; set; }
        [ProtoMember(3)]
        public List<Wave> waves { get; set; }
        [ProtoMember(4)]
        public List<Reward> rewards { get; set; }
        //[ProtoMember(6)]
        //public int roundCategory { get; set; }
        [ProtoMember(5)]
        public int silver { get; set; }
        [ProtoMember(6)]
        public int exp { get; set; }
        [ProtoMember(7)]
        public int honor { get; set; }

        public Round()
        { }
    }
}

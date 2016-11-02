using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class BattleBangChien
    {
        public enum Result : int
        {
            ChuaDienRa = 0,
            DangDienRa = 1,
            BenAThang = 2,
            BenBThang = 3,
        };

        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public int result { get; set; }
        [ProtoMember(3)]
        public int round { get; set; }
        [ProtoMember(4)]
        public string guildA { get; set; }
        [ProtoMember(5)]
        public string guildB { get; set; }
        [ProtoMember(6)]
        public double dmgTopA { get; set; }
        [ProtoMember(7)]
        public double dmgMidA { get; set; }
        [ProtoMember(8)]
        public double dmgBotA { get; set; }
        [ProtoMember(9)]
        public double dmgTopB { get; set; }
        [ProtoMember(10)]
        public double dmgMidB { get; set; }
        [ProtoMember(11)]
        public double dmgBotB { get; set; }
    }
}

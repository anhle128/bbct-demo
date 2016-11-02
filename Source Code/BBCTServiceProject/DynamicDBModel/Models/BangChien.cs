using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class BangChien
    {
        public enum State : int
        {
            DangDienRa = 1,
            DaKetThuc = 2,
        };
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public State state { get; set; }
        [ProtoMember(3)]
        public Guild[] guilds { get; set; }
        [ProtoMember(4)]
        public List<BattleBangChien> battles { get; set; }
    }
}

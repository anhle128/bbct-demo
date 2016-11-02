using ProtoBuf;
using StaticDB.Models.GiangHo;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class PhuBan
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(9)]
        public List<StagePhuBan> stages { get; set; }
        [ProtoMember(11)]
        public float posX { get; set; }
        [ProtoMember(12)]
        public float posY { get; set; }
        [ProtoMember(10)]
        public List<Reward> rewards { get; set; }
        [ProtoMember(13)]
        public int dayInWeek { get; set; }
        [ProtoMember(14)]
        public int idBackground { get; set; }

        public PhuBan()
        { }
    }
}

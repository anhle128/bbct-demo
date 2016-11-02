using ProtoBuf;
using System;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class LienMinh
    {
        [ProtoMember(1)]
        public int[] pointDedicationTeDan { get; set; }
        [ProtoMember(2)]
        public int[] pointDedicationTuNghiaDuong { get; set; }
        [ProtoMember(3)]
        public int[] pointDedicationThuongHoi { get; set; }
        [ProtoMember(4)]
        public List<DotLuaReward> dotLuaRewards { get; set; }
        [ProtoMember(5)]
        public List<LevelTHReward> thuongHoiRewards { get; set; }
    }
}

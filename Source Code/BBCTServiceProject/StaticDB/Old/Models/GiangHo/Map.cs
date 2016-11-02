using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models.GiangHo
{
    [ProtoContract]
    public class Map
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public List<StageGiangHo> stages { get; set; }
        [ProtoMember(3)]
        public float posX { get; set; }
        [ProtoMember(4)]
        public float posY { get; set; }
        [ProtoMember(5)]
        public int idBackground { get; set; }
        [ProtoMember(14)]
        public List<Reward> rewards { get; set; }
        public Map()
        { }
    }
}

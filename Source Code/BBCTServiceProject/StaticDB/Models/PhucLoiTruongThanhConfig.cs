using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class PhucLoiTruongThanhConfig
    {
        [ProtoMember(1)]
        public int ruby_require { get; set; }
        [ProtoMember(2)]
        public List<LevelReward> rewards { get; set; }
        [ProtoMember(3)]
        public int duration { get; set; }
    }
}

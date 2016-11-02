using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class TopRewardDoiDo
    {
        [ProtoMember(1)]
        public int index { get; set; }
        [ProtoMember(2)]
        public List<SubRewardItem> rewards { get; set; }
        [ProtoMember(3)]
        public int point_require { get; set; }
    }
}

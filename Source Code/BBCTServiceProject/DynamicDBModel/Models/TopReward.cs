using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class TopReward
    {
        [ProtoMember(1)]
        public int index { get; set; } // bắt đầu từ 0
        [ProtoMember(2)]
        public List<SubRewardItem> rewards { get; set; }

    }
}

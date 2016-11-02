using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class PointDoiDoReward
    {
        [ProtoMember(1)]
        public int point_require { get; set; }
        [ProtoMember(2)]
        public List<SubRewardItem> rewards { get; set; }
        [ProtoMember(3)]
        public int max_buy_times_in_day { get; set; }
    }
}

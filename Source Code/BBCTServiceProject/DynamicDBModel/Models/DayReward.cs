using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class DayReward
    {
        [ProtoMember(1)]
        public List<SubRewardItem> rewards { get; set; }
        [ProtoMember(2)]
        public int day { get; set; }

    }
}

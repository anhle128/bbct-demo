using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class RotDoReward
    {
        [ProtoMember(1)]
        public List<SubRewardItem> requires { get; set; }
        [ProtoMember(2)]
        public List<SubRewardItem> rewards { get; set; }
        [ProtoMember(3)]
        public int max_exchange_in_day { get; set; }
    }
}

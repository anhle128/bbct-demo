using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class VipReward
    {
        [ProtoMember(1)]
        public int vip;
        [ProtoMember(2)]
        public List<RewardItem> rewards;
    }
}

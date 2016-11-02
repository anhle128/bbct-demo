using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class GoldReward
    {
        [ProtoMember(1)]
        public int goldRequire;
        [ProtoMember(2)]
        public bool received;
        [ProtoMember(3)]
        public List<SubRewardItem> rewards;
    }
}

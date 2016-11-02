using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class ItemDoiDo
    {
        [ProtoMember(1)]
        public SubRewardItem require_item;
        [ProtoMember(2)]
        public SubRewardItem reward_item;
        [ProtoMember(3)]
        public int reward_point;
    }
}

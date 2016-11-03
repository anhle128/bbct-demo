using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserFriend
    {
        [ProtoMember(1)]
        public string userid;
        [ProtoMember(2)]
        public string nickname;
        [ProtoMember(3)]
        public int vip;
        [ProtoMember(4)]
        public int level;
        [ProtoMember(5)]
        public int rank_dau_truong;
        [ProtoMember(6)]
        public int avatar;
    }
}

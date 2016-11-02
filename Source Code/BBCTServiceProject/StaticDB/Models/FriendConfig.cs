using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class FriendConfig
    {
        [ProtoMember(1)]
        public int numberFriendCanAdd;
        [ProtoMember(2)]
        public int numberSuggestFriends;
        [ProtoMember(3)]
        public int giftStamina;
    }
}

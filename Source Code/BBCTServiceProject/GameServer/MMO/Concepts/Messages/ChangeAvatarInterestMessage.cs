using GameServer.MMO.Concepts.Messages.Core;

namespace GameServer.MMO.Concepts.Messages
{
    public class ChangeAvatarInterestMessage : InterestMessage
    {
        public int avatar { get; set; }

        public ChangeAvatarInterestMessage(int avatar)
        {
            this.type = Type.ChangeAvatar;
            this.avatar = avatar;
        }
    }
}

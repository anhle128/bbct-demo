using GameServer.MMO.Concepts.Messages.Core;

namespace GameServer.MMO.Concepts.Messages
{
    public class ChangeAvatarRegionMessage : RegionMessage
    {
        public int avatar{ get; set; }

        public ChangeAvatarRegionMessage(int avatar)
        {
            this.type = Type.ChangeAvatar;
            this.avatar = avatar;
        }
    }
}

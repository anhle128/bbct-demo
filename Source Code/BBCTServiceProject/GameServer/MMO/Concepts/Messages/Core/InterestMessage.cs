
namespace GameServer.MMO.Concepts.Messages.Core
{
    /// <summary>
    /// Message mà interest area gửi cho Item Owner báo cáo về các hoạt động của các Item trong vùng nó quan sát được
    /// </summary>
    public abstract class InterestMessage
    {
        public enum Type
        {
            Subscription,
            Move,
            Unsubscription,
            ChangeAvatar,
            ChangeName
        }
        public Item source;
        public Type type;

        public void SetSource(Item source)
        {
            this.source = source;
        }
    }
}

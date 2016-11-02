
namespace GameServer.MMO.Concepts.Messages.Core
{
    /// <summary>
    /// Message mà các region gửi về cho các interest area đang lắng nghe nó
    /// Message chứa các thông tin hoạt động của các Item nằm trên region đó
    /// </summary>
    public abstract class RegionMessage
    {
        public enum Type
        {
            Enter,
            Move,
            Exit,
            ChangeAvatar,
            ChangeName
        }

        public Item source;
        public Type type;

        public void SetSource(Item source)
        {
            this.source = source;
        }

        /*
        public readonly Vector2D position;
        
        public readonly Region oldRegion;
        public readonly Region newRegion;
        public int newAvatar;
        public string newName;

        public RegionMessage(Item source, Vector2D position, Type type, Region oldRegion, Region newRegion)
        {
            this.source = source;
            this.position = position;
            this.type = type;
            this.oldRegion = oldRegion;
            this.newRegion = newRegion;
        }

        public RegionMessage(Item source, int newAvatar)
        {
            type = Type.ChangeAvatar;
            this.source = source;
            this.newAvatar = newAvatar;
        }

        public RegionMessage(Item source, string newName)
        {
            type = Type.ChangeName;
            this.source = source;
            this.newName = newName;
        }*/
    }
}

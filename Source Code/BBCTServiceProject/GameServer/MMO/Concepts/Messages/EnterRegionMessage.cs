using GameServer.MMO.Concepts.Messages.Core;

namespace GameServer.MMO.Concepts.Messages
{
    public class EnterRegionMessage : RegionMessage
    {
        public Vector2D position { get; set; }
        public Region oldRegion { get; set; }

        public EnterRegionMessage(Vector2D position, Region oldRegion)
        {
            this.type = Type.Enter;
            this.position = position;
            this.oldRegion = oldRegion;
        }
    }
}

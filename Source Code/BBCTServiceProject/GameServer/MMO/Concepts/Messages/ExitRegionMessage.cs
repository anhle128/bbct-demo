using GameServer.MMO.Concepts.Messages.Core;

namespace GameServer.MMO.Concepts.Messages
{
    public class ExitRegionMessage : RegionMessage
    {
        public Vector2D position { get; set; }
        public Region newRegion { get; set; }

        public ExitRegionMessage(Vector2D position, Region newRegion)
        {
            this.type = Type.Exit;
            this.position = position;
            this.newRegion = newRegion;
        }
    }
}

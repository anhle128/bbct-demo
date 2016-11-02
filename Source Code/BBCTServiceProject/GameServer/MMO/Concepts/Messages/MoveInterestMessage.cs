using GameServer.MMO.Concepts.Messages.Core;

namespace GameServer.MMO.Concepts.Messages
{
    public class MoveInterestMessage : InterestMessage
    {
        public Vector2D position { get; set; }

        public MoveInterestMessage(Vector2D position)
        {
            this.type = Type.Move;
            this.position = position;
        }
    }
}

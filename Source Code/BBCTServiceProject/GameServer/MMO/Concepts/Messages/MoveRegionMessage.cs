using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.MMO.Concepts.Messages.Core;

namespace GameServer.MMO.Concepts.Messages
{
    public class MoveRegionMessage : RegionMessage
    {
        public Vector2D position { get; set; }

        public MoveRegionMessage(Vector2D position)
        {
            this.type = Type.Move;
            this.position = position;
        }
    }
}

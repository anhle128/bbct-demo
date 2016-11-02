using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.MMO.Concepts.Messages.Core;

namespace GameServer.MMO.Concepts.Messages
{
    public class UnsubscriptionInterestMessage : InterestMessage
    {

        public UnsubscriptionInterestMessage()
        {
            this.type = Type.Unsubscription;
        }
    }
}

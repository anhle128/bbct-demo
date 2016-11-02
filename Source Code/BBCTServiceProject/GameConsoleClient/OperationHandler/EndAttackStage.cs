using GameConsoleClient.Action;
using GameConsoleClient.Components;
using GameServer.Common.Enum;
using System.Collections.Generic;

namespace GameConsoleClient.OperationHandler
{
    public class EndAttackStage : AbsOperationHandler
    {
        public EndAttackStage(Player player, OperationCode code, AbsAction parentAction)
            : base(player, code, parentAction)
        {
        }

        public override void OnRequest(Dictionary<byte, object> dataRequest)
        {
            Player.Peer.OpCustom((byte)Code, dataRequest, true);
        }
    }
}

using ExitGames.Client.Photon;
using GameConsoleClient.Action;
using GameConsoleClient.Components;
using GameConsoleClient.Cores;
using GameServer.Common.Enum;
using System.Collections.Generic;

namespace GameConsoleClient.OperationHandler
{
    public class AbsOperationHandler : IOperationHandleable
    {
        public Player Player;
        public AbsAction parentAction;
        public OperationCode Code;

        public AbsOperationHandler(Player player, OperationCode code)
        {
            this.Player = player;
            this.Code = code;
        }

        public AbsOperationHandler(Player player, OperationCode code, AbsAction parentAction)
        {
            this.Player = player;
            this.parentAction = parentAction;
            this.Code = code;
        }

        public virtual void OnRequest(Dictionary<byte, object> dataRequest)
        {
            Player.Tracker.Plus(Tracker.Param.AmountRequest);
        }

        public virtual void OnResponse(OperationResponse operationResponse)
        {
            if (parentAction != null)
                parentAction.OnResponse(operationResponse);
        }
    }
}

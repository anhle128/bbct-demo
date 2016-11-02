using ExitGames.Client.Photon;
using GameConsoleClient.Components;
using GameConsoleClient.Helpers.Common;
using GameServer.Common.Enum;

namespace GameConsoleClient.Action
{
    public class AbsAction : IActionable
    {
        public Player player;

        public AbsAction(Player player)
        {
            this.player = player;
        }

        public virtual void DoAction()
        {
            Prepare();
        }

        public virtual void OnResponse(OperationResponse operationResponse)
        {
            if (operationResponse.ReturnCode != (short)ReturnCode.OK)
            {
                player.StartNewAction();
            }
        }

        public virtual void Prepare()
        {
            return;
        }


    }
}

using ExitGames.Client.Photon;
using GameConsoleClient.Components;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using System.Collections.Generic;

namespace GameConsoleClient.OperationHandler
{
    public class EnterWorldHandler : AbsOperationHandler
    {
        public EnterWorldHandler(Player player, OperationCode code)
            : base(player, code)
        {
        }

        public override void OnRequest(Dictionary<byte, object> dataRequest)
        {
            Player.Peer.OpCustom((byte)Code, new Dictionary<byte, object>(), true);
            Player.Tracker.Plus(Tracker.Param.AmountRequest);
        }

        public override void OnResponse(OperationResponse operationResponse)
        {
            if (operationResponse.ReturnCode == (short)ReturnCode.OK)
            {
                EnterWorldResponseData data = new EnterWorldResponseData();
                data.Deserialize(operationResponse.Parameters);
                Player.state = Player.State.InWorld;
                Player.X = data.x;
                Player.Y = data.y;
            }
        }


    }
}

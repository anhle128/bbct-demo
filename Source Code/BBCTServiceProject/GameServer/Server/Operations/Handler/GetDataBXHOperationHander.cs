using DynamicDBModel.Models;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataBXHOperationHander : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            List<TopUser>[] arrTopUsers = BangXepHangInfo.GetTopUsers(false);

            BangXepHangResponseData responseData = new BangXepHangResponseData();
            responseData.top_level = arrTopUsers[0];
            responseData.top_power = arrTopUsers[1];

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataBXHOperationHander done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

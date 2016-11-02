
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataRuongBauOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionRuongBauRequestData requestData = new ActionRuongBauRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MRuongBauConfig ruongConfig = MongoController.ConfigDb.RuongBau.GetData(requestData.id);
            if (ruongConfig == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            RuongBauRewardResponseData responseData = new RuongBauRewardResponseData()
            {
                rewards = ruongConfig.rewards
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataRuongBauOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}

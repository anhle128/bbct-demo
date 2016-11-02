using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataThuongNapLanDauOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

                MThuongNapLanDauConfig config = MongoController.ConfigDb.ThuongNapLanDau.GetData();
                if (config == null)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);

                SubRewardResponseData responseData = new SubRewardResponseData();
                responseData.rewards = config.rewards;

                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "OperationResponse done!",
                    Parameters = responseData.Serialize(),
                    ReturnCode = (short)ReturnCode.OK
                };

        }
    }
}

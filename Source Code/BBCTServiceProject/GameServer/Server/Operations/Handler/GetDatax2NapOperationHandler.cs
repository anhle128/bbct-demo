
using DynamicDBModel.Enum;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetDatax2NapOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

                MSKx2NapConfig config = MongoController.ConfigDb.Skx2Nap.GetData();
                if (config == null)
                {
                    SuKienInfo.SetDeactiveSuKien(TypeSuKien.x2Nap);
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
                }

                Skx2NapResponseData responseData = new Skx2NapResponseData();
                responseData.end_time = config.end;

                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "GetDatax2NapOperationHandler done!",
                    Parameters = responseData.Serialize(),
                    ReturnCode = (short)ReturnCode.OK
                };

        }
    }
}

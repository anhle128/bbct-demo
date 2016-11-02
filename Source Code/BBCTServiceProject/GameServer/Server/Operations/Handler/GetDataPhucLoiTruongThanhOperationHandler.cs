using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataPhucLoiTruongThanhOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            MPhucLoiTruongThanhLog log = MongoController.LogSubDB.SkPhucLoiTruongThanh.GetData(player.cacheData.id);


            SkPhucLoiTruongThanhResponseData responseData = new SkPhucLoiTruongThanhResponseData();

            responseData.index_received = new List<int>();

            if (log != null)
            {
                responseData.index_received = log.index_received;
            }

            // response
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

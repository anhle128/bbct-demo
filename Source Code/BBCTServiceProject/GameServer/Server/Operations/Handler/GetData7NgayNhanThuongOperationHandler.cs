using DynamicDBModel.Enum;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetData7NgayNhanThuongOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSK7NgayNhanThuongConfig sk = MongoController.ConfigDb.Sk7NgayNhanThuong.GetData();

            if (sk == null)
            {
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.BayNgayNhanThuong);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            MSK7NgayNhanThuongLog log =
                MongoController.LogSubDB.Sk7NgayNhanThuong.GetData(player.cacheData.id, sk._id);

            Sk7NgayNhanThuongResponseData responseData = new Sk7NgayNhanThuongResponseData();
            responseData.currentDay = DateTime.Now.Day;
            responseData.rewards = sk.day_rewards;
            responseData.day_received = log != null ? log.day_received : null;
            responseData.end_time = sk.end;

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetData7NgayNhanThuongOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

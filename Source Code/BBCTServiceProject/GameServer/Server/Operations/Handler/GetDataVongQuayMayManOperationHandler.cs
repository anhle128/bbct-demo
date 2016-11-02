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
    public class GetDataVongQuayMayManOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSKVongQuayMayManConfig config = MongoController.ConfigDb.SkVongQuayMayMan.GetData();
            if (config == null)
            {
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.VongQuayMayMan);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            MSKVongQuayMayManLog log = MongoController.LogSubDB.SkVongQuayMayMan.GetData(player.cacheData.id, config._id);

            VongQuayMayManResponseData responseData = new VongQuayMayManResponseData
            {
                max_free_times = config.max_free_times,
                rewards = CommonFunc.ConvertToSubRewardItem(config.vatPhams),
                free_times = log != null ? log.count_times_quay_free : 0,
                price = config.price,
                x10_price = config.x10_price,
                rest_time = (config.end - DateTime.Now).TotalSeconds,
                total_point = log != null ? log.total_point : 0,
                index_point_receiveds = log != null ? log.index_point_received : null,
                top_rewards = config.top_rewards,
                point_rewards = config.point_rewards
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataVongQuayMayManOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

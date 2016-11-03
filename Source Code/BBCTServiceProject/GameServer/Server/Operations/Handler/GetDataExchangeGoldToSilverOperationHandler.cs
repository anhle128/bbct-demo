
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataExchangeGoldToSilverOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ExchangeGoldToSilverConfig config = StaticDatabase.entities.configs.exchangeGoldToSilverConfig;
            if (config.levelRequire > player.cacheData.level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            MExchangeGoldToSilverLog log =
               MongoController.LogSubDB.ExchangeGoldToSilver.GetData(player.cacheData.info._id,
                   CommonFunc.GetHashCodeTime());

            GetDataExchangeGoldResponseData responseData = new GetDataExchangeGoldResponseData();
            responseData.total_times_exchange = log == null ? 0 : log.times;

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataExchangeGoldToSilverOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}

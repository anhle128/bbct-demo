using DynamicDBModel.Enum;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataThanTaiOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSKThanTaiConfig config = MongoController.ConfigDb.SkThanTai.GetData();
            if (config == null)
            {
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.ThanTai);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            MSKThanTaiLog log = MongoController.LogSubDB.SkThanTai.GetData(player.cacheData.info._id,
                config._id.ToString());

            SkThanTaiResponseData responseData = new SkThanTaiResponseData();
            responseData.gold_requires = config.rewards.Select(a => a.gold_require).ToList();
            responseData.current_index_reward = 0;
            responseData.end_time = config.end;
            if (log != null)
            {
                responseData.current_index_reward = log.current_index_reward;
            }

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataThanTaiOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

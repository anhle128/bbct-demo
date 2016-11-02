using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardPointDoiDoOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MSKDoiDoConfig config = MongoController.ConfigDb.SkDoiDo.GetData(SuKienDoiDoInfo.SuKienId);


            MSKDoiDoLog log = MongoController.LogSubDB.SkDoiDo.GetData(player.cacheData.id,
                config._id);

            if (log.hash_code_time != CommonFunc.GetHashCodeTime())
                log.index_receiveds = new List<IndexReceived>();

            if (log.index_receiveds == null)
                log.index_receiveds = new List<IndexReceived>();

            PointDoiDoReward pointReward = config.point_rewards[requestData.index];
            if (pointReward.point_require > log.current_point)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughPoint);

            IndexReceived receive =
                   log.index_receiveds.FirstOrDefault(a => a.index == requestData.index);
            if (receive == null)
            {
                receive = new IndexReceived()
                {
                    index = requestData.index,
                    received_times = 0
                };
                log.index_receiveds.Add(receive);
            }

            if (receive.received_times > pointReward.max_buy_times_in_day)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxReceived);

            receive.received_times++;
            log.current_point -= pointReward.point_require;
            log.index_receiveds.Add(receive);

            MongoController.LogSubDB.SkDoiDo.Update(log);

            List<RewardItem> listResult = MongoController.UserDb.UpdateReward(player.cacheData, pointReward.rewards, ReasonActionGold.RewardPointSkDoiDo);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listResult,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.exp,
                user_ruby = player.cacheData.ruby
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardTopDoiDoOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

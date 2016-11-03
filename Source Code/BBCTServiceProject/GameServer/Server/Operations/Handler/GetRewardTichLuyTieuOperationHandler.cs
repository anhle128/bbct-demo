using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardTichLuyTieuOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            //CommonLog.Instance.PrintLog("index: " + requestData.index);

            bool isCreate = false;

            MSKTichLuyTieuConfig sk = MongoController.ConfigDb.SkTichluyTieu.GetData();

            if (sk == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            MSKTichLuyTieuLog log = MongoController.LogSubDB.SkTichLuyTieu.GetData
            (
                player.cacheData.info._id,
                sk._id.ToString()
            );

            if (log == null)
            {
                isCreate = true;
                log = new MSKTichLuyTieuLog()
                {
                    user_id = player.cacheData.info._id,
                    su_kien_id = sk._id,
                    index_received = new List<int>()
                };
            }
            else
            {
                if (log.index_received == null)
                    log.index_received = new List<int>();
            }

            if (log.index_received.Any(a => a == requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDoneBefore);

            double totalUsedGold = MongoController.LogDb.ActionGold.GetTotalUsedGold(player.cacheData.info._id,
                sk.start, DateTime.Now);

            int totalGoldNeed = sk.gold_rewards[requestData.index].gold_require;
            if (totalUsedGold < totalGoldNeed)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            log.index_received.Add(requestData.index);
            List<SubRewardItem> rewards = sk.gold_rewards[requestData.index].rewards;

            if (isCreate)
                MongoController.LogSubDB.SkTichLuyTieu.Create(log);
            else
                MongoController.LogSubDB.SkTichLuyTieu.Update(log);

            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData, rewards, ReasonActionGold.RewardSkTichLuyTieu);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listReward,
                user_silver = player.cacheData.info.silver,
                user_gold = player.cacheData.info.gold,
                user_ruby = player.cacheData.info.ruby
            };

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

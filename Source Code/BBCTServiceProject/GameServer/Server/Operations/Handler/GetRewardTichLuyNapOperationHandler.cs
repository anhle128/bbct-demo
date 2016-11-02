using DynamicDBModel.Enum;
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
    public class GetRewardTichLuyNapOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);



            MSKTichLuyNapConfig sk = MongoController.ConfigDb.SkTichluyNap.GetData();

            if (sk == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            if (sk.type == TypeSuKienTichLuyNap.RangeTime)
                return ProcessNapinRangeTime(player, operationRequest, sk, requestData);
            else
                return ProcessNapinDay(player, operationRequest, sk, requestData);

        }

        private static OperationResponse ProcessNapinDay(GamePlayer player, OperationRequest operationRequest,
            MSKTichLuyNapConfig sk, IndexRequestData requestData)
        {
            bool isCreate = false;
            MSKTichLuyNapLog log = MongoController.LogSubDB.SkTichLuyNap.GetData
                (
                    player.cacheData.id,
                    sk._id.ToString(),
                    CommonFunc.GetHashCodeTime()
                );

            if (log == null)
            {
                isCreate = true;
                log = new MSKTichLuyNapLog()
                {
                    user_id = player.cacheData.id,
                    su_kien_id = sk._id.ToString(),
                    index_received = new List<int>(),
                    hash_code_time = CommonFunc.GetHashCodeTime()
                };
            }
            else
            {
                if (log.index_received == null)
                    log.index_received = new List<int>();
            }

            if (log.index_received.Any(a => a == requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDoneBefore);

            double totalTransGold = MongoController.LogDb.Trans.GetTotalRuby
                (
                    player.cacheData.id,
                    CommonFunc.GetStartTimeInDay(),
                    CommonFunc.GetEndTimeInDay()
                );

            int totalGoldNeed = sk.gold_rewards[requestData.index].gold_require;
            if (totalTransGold < totalGoldNeed)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            log.index_received.Add(requestData.index);
            List<SubRewardItem> rewards = sk.gold_rewards[requestData.index].rewards;

            if (isCreate)
                MongoController.LogSubDB.SkTichLuyNap.Create(log);
            else
                MongoController.LogSubDB.SkTichLuyNap.Update(log);

            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData, rewards, ReasonActionGold.RewardSkTichLuyNap);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listReward,
                user_silver = player.cacheData.silver,
                user_gold = player.cacheData.gold,
                user_ruby = player.cacheData.ruby
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "OperationResponse done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }

        private static OperationResponse ProcessNapinRangeTime(GamePlayer player, OperationRequest operationRequest,
            MSKTichLuyNapConfig sk, IndexRequestData requestData)
        {
            bool isCreate = false;

            MSKTichLuyNapLog log = MongoController.LogSubDB.SkTichLuyNap.GetData
                (
                    player.cacheData.id,
                    sk._id.ToString()
                );

            if (log == null)
            {
                isCreate = true;
                log = new MSKTichLuyNapLog()
                {
                    user_id = player.cacheData.id,
                    su_kien_id = sk._id.ToString(),
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

            double totalTransGold = MongoController.LogDb.Trans.GetTotalRuby
                (
                    player.cacheData.id,
                    sk.start,
                    DateTime.Now
                );

            int totalGoldNeed = sk.gold_rewards[requestData.index].gold_require;
            if (totalTransGold < totalGoldNeed)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            log.index_received.Add(requestData.index);
            List<SubRewardItem> rewards = sk.gold_rewards[requestData.index].rewards;

            if (isCreate)
                MongoController.LogSubDB.SkTichLuyNap.Create(log);
            else
                MongoController.LogSubDB.SkTichLuyNap.Update(log);

            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData, rewards, ReasonActionGold.RewardSkTichLuyNap);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listReward,
                user_silver = player.cacheData.silver,
                user_gold = player.cacheData.gold,
                user_ruby = player.cacheData.ruby
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

using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardHoatDongDiemDanhOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MonthReward monthReward =
               StaticDatabase.entities.configs.hoatDongDiemDanhConfig.monthRewards.FirstOrDefault(a => a.month == DateTime.Today.Month);
            if (monthReward == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            MUserDienDanhThang userDiemDanh =
                MongoController.UserDb.DiemDanhThang.GetData(player.cacheData.id, monthReward.month);

            if (userDiemDanh == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (userDiemDanh.index_day_rewards == null)
                userDiemDanh.index_day_rewards = new List<int>();

            if (userDiemDanh.index_day_rewards.Any(a => a == requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDoneBefore);

            int currentIndex = StaticDatabase.entities.configs.hoatDongDiemDanhConfig.GetCurrentIndex();

            if (currentIndex < requestData.index)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            int goldRequire = 0;

            if (currentIndex != requestData.index)
                goldRequire = StaticDatabase.entities.configs.hoatDongDiemDanhConfig.goldRequireBuyMissingReward;

            if (player.cacheData.gold < goldRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            if (goldRequire > 0)
            {
                player.cacheData.gold -= goldRequire;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.BuyMissingRewardDiemDanh, goldRequire);
            }

            userDiemDanh.index_day_rewards.Add(requestData.index);
            MongoController.UserDb.DiemDanhThang.Update(userDiemDanh);

            Reward reward = monthReward.rewards[requestData.index];
            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, new List<SubRewardItem>()
                {
                    new SubRewardItem()
                    {
                        static_id = reward.staticID,
                        quantity = reward.amountMax,
                        type_reward = reward.typeReward
                    }
                },
            ReasonActionGold.RewardDiemDanh);

            RewardResponseData responseData = new RewardResponseData();
            responseData.rewards = listRewardResult;
            responseData.user_gold = player.cacheData.gold;
            responseData.user_silver = player.cacheData.silver;
            responseData.user_exp = player.cacheData.exp;
            responseData.user_level = player.cacheData.level;


            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

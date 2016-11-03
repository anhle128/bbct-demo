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
using StaticDB.Enum;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardVanTieuOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            GetRewardVanTieuRequestData requestData = new GetRewardVanTieuRequestData();
            requestData.Deserialize(operationRequest.Parameters);
            MUserVanTieu userVanTieu =
                    MongoController.UserDb.VanTieu.GetPrevData(player.cacheData.info._id);
            if (userVanTieu == null)
                userVanTieu =
                    MongoController.UserDb.VanTieu.GetDataByUserId(player.cacheData.info._id);
            if (userVanTieu == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            int goldNeed = 0;

            VanTieuConfig vanTieuConfig = StaticDatabase.entities.configs.vanTieuConfig;

            if (requestData.type == GetRewardVanTieuType.Quick)
            {
                if (player.cacheData.info.vip < vanTieuConfig.vipRequireToEnd)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
                if (player.cacheData.info.gold < vanTieuConfig.goldRequireToEnd)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                goldNeed = vanTieuConfig.goldRequireToEnd;
            }
            else
            {
                double restTime = CommonFunc.GetRestTimeSecond(userVanTieu.current_vehicle.start,
                   vanTieuConfig.GetSecondDurationTime());
                if (restTime != 0)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            if (userVanTieu.users_cuop_tieu == null)
                userVanTieu.users_cuop_tieu = new List<string>();

            int silverReward = StaticDatabase.entities.configs.GetSilverVanTieuReward(userVanTieu.users_cuop_tieu.Count,
                userVanTieu.current_vehicle.type);
            //CommonLog.Instance.PrintLog("silver in vehicle : " + silverReward);


            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, userVanTieu.rewards, ReasonActionGold.RewardVanTieu);
            RewardItem rewardSilver = listRewardResult.FirstOrDefault(a => a.type_reward == (int)TypeReward.Silver);
            if (rewardSilver == null)
            {
                listRewardResult.Add(new RewardItem()
                {
                    static_id = 1,
                    type_reward = (int)TypeReward.Silver,
                    quantity = silverReward
                });
            }
            else
            {
                rewardSilver.quantity += silverReward;
            }


            userVanTieu.end = true;
            userVanTieu.current_vehicle.going_on = false;

            player.cacheData.info.silver += silverReward;

            if (goldNeed != 0)
            {
                player.cacheData.info.gold -= goldNeed;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.QuickEndVanTieu, goldNeed);
            }
            MongoController.UserDb.VanTieu.UpdateEnd(userVanTieu);
            MongoController.UserDb.Info.UpdateSilver(player.cacheData, TypeUseSilver.None, 0);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listRewardResult,
                user_gold = player.cacheData.info.gold,
                user_silver = player.cacheData.info.silver - silverReward,
                user_level = player.cacheData.info.level,
                user_exp = player.cacheData.info.exp,
                user_ruby = player.cacheData.info.ruby
            };

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

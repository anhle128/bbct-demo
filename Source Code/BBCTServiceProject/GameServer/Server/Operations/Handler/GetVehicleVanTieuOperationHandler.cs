using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
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

namespace GameServer.Server.Operations.Handler
{
    public class GetVehicleVanTieuOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
             OperationController controller)
        {

            if (player.cacheData.level < StaticDatabase.entities.configs.vanTieuConfig.levelRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            MUserVanTieu userVanTieu =
                MongoController.UserDb.VanTieu.GetDataByUserId(player.cacheData.info._id);
            if (userVanTieu == null)
            {
                userVanTieu = new MUserVanTieu()
                {
                    user_id = player.cacheData.info._id,
                    hash_code_time = CommonFunc.GetHashCodeTime(),
                    level = player.cacheData.level,
                    end = false,
                    nickname = player.cacheData.nickname,
                    vip = player.cacheData.vip
                };
                MongoController.UserDb.VanTieu.Create(userVanTieu);
            }

            if (userVanTieu.current_vehicle != null)
            {
                if (player.cacheData.gold < StaticDatabase.entities.configs.vanTieuConfig.goldRefeshVehicle)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                if (userVanTieu.current_vehicle.going_on)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

                player.cacheData.gold -= StaticDatabase.entities.configs.vanTieuConfig.goldRefeshVehicle;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.GetVehicleVanTieu, StaticDatabase.entities.configs.vanTieuConfig.goldRefeshVehicle);
            }
            else
            {
                userVanTieu.current_vehicle = new MVehicle();
            }

            int randomProc = CommonFunc.RandomNumber(0, 100);
            VanTieuConfig config = StaticDatabase.entities.configs.vanTieuConfig;
            double totalProc = 0;
            int silverReward = 0;
            for (int i = 0; i < config.vehicles.Count; i++)
            {
                totalProc = totalProc + config.vehicles[i].proc;

                if (randomProc <= totalProc)
                {
                    userVanTieu.current_vehicle.type = (TypeVehicle)i;
                    userVanTieu.current_vehicle.going_on = false;
                    silverReward = config.vehicles[i].silverReward;
                    userVanTieu.rewards = config.vehicles[i].protectRewards != null ? CommonFunc.RandomSubRewardItem(config.vehicles[i].protectRewards) : null;
                    break;
                }
            }

            MongoController.UserDb.VanTieu.UpdateCurrentVehidle_Reward(userVanTieu);

            if (userVanTieu.rewards == null)
                userVanTieu.rewards = new List<SubRewardItem>();

            userVanTieu.rewards.Add(new SubRewardItem()
            {
                static_id = 0,
                type_reward = (int)TypeReward.Silver,
                quantity = silverReward
            });

            GetVehicleVanTieuResponseData responseData = new GetVehicleVanTieuResponseData()
            {
                user_gold = player.cacheData.gold,
                type = userVanTieu.current_vehicle.type,
                rewards = userVanTieu.rewards
            };

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

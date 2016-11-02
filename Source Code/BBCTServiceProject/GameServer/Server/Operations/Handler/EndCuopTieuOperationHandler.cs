using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDB.Bson;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class EndCuopTieuOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            MUserCuopTieu userCuopTieu =
                MongoController.UserDb.CuopTieu.GetData(player.cacheData.id);

            if (userCuopTieu == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MCuopTieuData cuopTieuData = userCuopTieu.cuop_tieu_datas.FirstOrDefault(b => b.van_tieu_id.Equals(player.cacheData.vanTieuId) && b.end == false);

            if (cuopTieuData == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MUserVanTieu userVanTieu =
                MongoController.UserDb.VanTieu.GetDataById(cuopTieuData.van_tieu_id);

            if (userVanTieu.end)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.EndVanTieu);
            if (userVanTieu.users_cuop_tieu == null)
                userVanTieu.users_cuop_tieu = new List<string>();
            if (userVanTieu.users_cuop_tieu.Count >=
                StaticDatabase.entities.configs.cuopTieuConfig.maxTimesVehicleBiCuop)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxCuopTieuTimes);

            if (userVanTieu.users_cuop_tieu == null)
                userVanTieu.users_cuop_tieu = new List<string>();

            cuopTieuData.end = true;

            // process
            int silverReward =
                StaticDatabase.entities.configs.GetSilverCuopTieuReward(userVanTieu.current_vehicle.type);
            player.cacheData.silver += (int)silverReward;
            userVanTieu.users_cuop_tieu.Add(player.cacheData.id);

            // update
            MongoController.UserDb.VanTieu.UpdateCurrentVehidle_UsersCuopTieu(userVanTieu);
            MongoController.UserDb.CuopTieu.UpdateCuopTieuData(userCuopTieu);
            MongoController.UserDb.Info.UpdateSilver(player.cacheData, TypeUseSilver.None, 0);

            VehicleConfig vehicleConfig =
               StaticDatabase.entities.configs.vanTieuConfig.GetVehicle(userVanTieu.current_vehicle.type);

            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, CommonFunc.RandomSubRewardItem(vehicleConfig.robRewards), ReasonActionGold.RewardCuopTieu);
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
            // response

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listRewardResult,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver - silverReward,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.exp,
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

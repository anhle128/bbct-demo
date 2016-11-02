using DynamicDBModel.Models;
using GameServer.Battle;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
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
    public class CuopTieuOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            StartCuopTieuRequestData requestData = new StartCuopTieuRequestData();
            if (operationRequest.Parameters != null)
                requestData.Deserialize(operationRequest.Parameters);

            MUserCuopTieu userCuopTieu =
                 MongoController.UserDb.CuopTieu.GetData(player.cacheData.id);

            VipConfig vip = StaticDatabase.entities.configs.vipConfigs[player.cacheData.vip];

            if (userCuopTieu.cuop_tieu_datas == null)
                userCuopTieu.cuop_tieu_datas = new List<MCuopTieuData>();
            if (userCuopTieu.cuop_tieu_datas.Count >= vip.cuopTieuTimes)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxCuopTieuTimes);

            MUserVanTieu userVanTieu =
                MongoController.UserDb.VanTieu.GetDataByUserId((requestData.id));

            if (userVanTieu.users_cuop_tieu == null)
                userVanTieu.users_cuop_tieu = new List<string>();

            if (userVanTieu.users_cuop_tieu.Count >= StaticDatabase.entities.configs.cuopTieuConfig.maxTimesVehicleBiCuop)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxCuopTieuTimes);

            if (userVanTieu.end)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.EndVanTieu);



            player.cacheData.vanTieuId = (requestData.id);

            // process
            userCuopTieu.cuop_tieu_datas.Add(new MCuopTieuData()
            {
                end = false,
                van_tieu_id = userVanTieu._id
            });
            BattleProcessor processor = new BattleProcessor();
            BattleSimulator.Battle battleSim = processor.BattlePvp
            (
                player.cacheData,
                userVanTieu.user_id
            );

            RewardResponseData responseData = new RewardResponseData();
            responseData.replay = battleSim.replay;

            //battleSim.replay

            if (battleSim.result == 2) // Player thang
            {
                MCuopTieuData cuopTieuData = userCuopTieu.cuop_tieu_datas.FirstOrDefault(b => b.van_tieu_id == player.cacheData.vanTieuId && b.end == false);
                cuopTieuData.end = true;

                // process
                int silverReward =
                    StaticDatabase.entities.configs.GetSilverCuopTieuReward(userVanTieu.current_vehicle.type);
                player.cacheData.silver += (int)silverReward;
                userVanTieu.users_cuop_tieu.Add(player.cacheData.id);

                // update
                MongoController.UserDb.VanTieu.UpdateCurrentVehidle_UsersCuopTieu(userVanTieu);
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

                responseData.rewards = listRewardResult;
                responseData.user_gold = player.cacheData.gold;
                responseData.user_silver = player.cacheData.silver;
                responseData.user_level = player.cacheData.level;
                responseData.user_exp = player.cacheData.exp;
                responseData.user_ruby = player.cacheData.ruby;
            }

            MongoController.UserDb.CuopTieu.UpdateCuopTieuData(userCuopTieu);

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

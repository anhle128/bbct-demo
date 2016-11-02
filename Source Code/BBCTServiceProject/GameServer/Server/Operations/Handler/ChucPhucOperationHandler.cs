
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
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class ChucPhucOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            MUserInfo userInfo =
                    MongoController.UserDb.Info.GetData(player.cacheData.id);

            int hashTime = CommonFunc.GetHashCodeTime();
            if (userInfo.hash_code_time_chuc_phuc == hashTime)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDoneBefore);
            userInfo.hash_code_time_chuc_phuc = hashTime;
            if (userInfo.count_chuc_phuc == StaticDatabase.entities.configs.chucPhucConfig.maxChucPhuc)
            {
                userInfo.count_chuc_phuc = 1;

                MongoController.UserDb.Info.UpdateChucPhuc(userInfo);
                MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.id, TypeNhiemVuHangNgay.ChucPhuc);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

            }
            else
            {
                userInfo.count_chuc_phuc++;
                MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.id, TypeNhiemVuHangNgay.ChucPhuc);
                if (userInfo.count_chuc_phuc == StaticDatabase.entities.configs.chucPhucConfig.maxChucPhuc)
                {
                    MChucPhucConfig config = MongoController.ConfigDb.ChucPhuc.GetData();

                    List<SubRewardItem> listReward = new List<SubRewardItem>() { CommonFunc.RandomOneSubRewardItem(config.rewards) };
                    List<RewardItem> listRewardItem = MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.RewardChucPhuc);
                    RewardResponseData responseData = new RewardResponseData()
                    {
                        rewards = listRewardItem,
                        user_gold = player.cacheData.gold,
                        user_silver = player.cacheData.silver,
                        user_level = player.cacheData.level,
                        user_exp = player.cacheData.exp,
                        user_ruby = player.cacheData.ruby
                    };

                    MongoController.UserDb.Info.UpdateChucPhuc(userInfo);
                    return new OperationResponse()
                    {
                        OperationCode = operationRequest.OperationCode,
                        DebugMessage = "ChucPhucOperationHandler done!",
                        Parameters = responseData.Serialize(),
                        ReturnCode = (short)ReturnCode.OK
                    };
                }

                MongoController.UserDb.Info.UpdateChucPhuc(userInfo);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
            }
        }
    }
}

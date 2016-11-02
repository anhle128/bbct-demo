
using DynamicDBModel.Models;
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
using System;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardCharTutorialOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            QuayTuongRequestData requestData = new QuayTuongRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            MUserInfo userinfo = MongoController.UserDb.Info.GetData(player.cacheData.id);

            int idChar = 0;

            if (requestData.type == QuayTuongType.Normal)
            {
                idChar = StaticDatabase.entities.configs.tutorialConfig.normalCharReward;
                userinfo.last_time_free_quay_tuong_normal = DateTime.Now;

                MongoController.UserDb.Info.UpdateGold_FreeTimeQuayTuongNormal(userinfo, 0);
            }
            else
            {
                idChar = StaticDatabase.entities.configs.tutorialConfig.specialCharReward;
                userinfo.last_time_free_quay_tuong_special = DateTime.Now;

                MongoController.UserDb.Info.UpdateGold_FreeTimeQuayTuongSpecial(userinfo, 0);
            }

            SubRewardItem subReward = new SubRewardItem()
            {
                quantity = 1,
                static_id = idChar,
                type_reward = (int)TypeReward.Character
            };


            List<RewardItem> listReward = MongoController.UserDb.UpdateReward
            (
                player.cacheData,
                new List<SubRewardItem>() { subReward },
                ReasonActionGold.RewardTutorial
            );

            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.id, TypeNhiemVuHangNgay.ChieuMo);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listReward,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.exp
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

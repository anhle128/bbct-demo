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
    public class GetRewardNhiemVuHangNgayOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            GetRewardNhiemVuHangNgayRequestData requestData = new GetRewardNhiemVuHangNgayRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            MNhiemVuHangNgayLog log = MongoController.LogSubDB.NhiemVuHangNgay.GetData(player.cacheData.info._id);
            if (log == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (log.nhiemVuHangNgay.Single(a => a.type == requestData.type).received)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyReceived);

            Reward[] arrRewards = null;
            int goldRequire = 0;

            if (requestData.type != TypeNhiemVuHangNgay.Complete)
            {
                NhiemVuHangNgay nhiemVu =
                 StaticDatabase.entities.configs.nhiemVuHangNgayConfig.nhiemVus.Single(
                     a => a.type == (int)requestData.type);
                int count = log.nhiemVuHangNgay.Single(a => a.type == requestData.type).count;
                if (count < nhiemVu.quantity)
                {
                    //return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);
                    goldRequire = StaticDatabase.entities.configs.nhiemVuHangNgayConfig.goldRequireCompolete;
                    if (player.cacheData.gold < goldRequire)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

                }

                arrRewards = StaticDatabase.entities.configs.nhiemVuHangNgayConfig.GetReward
                (
                    requestData.type,
                    player.cacheData.level
                );
            }
            else
            {
                int count = log.nhiemVuHangNgay.Count(a => a.received == false);
                if (count != 1)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

                arrRewards = StaticDatabase.entities.configs.nhiemVuHangNgayConfig.GetReward
                (
                    requestData.type,
                    player.cacheData.level
                );
            }

            log.nhiemVuHangNgay.Single(a => a.type == requestData.type).received = true;

            // process
            MongoController.LogSubDB.NhiemVuHangNgay.Update(log);
            if (goldRequire != 0)
            {
                player.cacheData.gold -= goldRequire;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.QuickFinishNhiemVuHangNgay, goldRequire);
            }

            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData,
                CommonFunc.ConvertToSubReward(arrRewards), ReasonActionGold.RewardNhiemVuHangNgay);

            RewardResponseData responseData = new RewardResponseData();
            responseData.rewards = listReward;
            responseData.user_gold = player.cacheData.gold;
            responseData.user_silver = player.cacheData.silver;
            responseData.user_exp = player.cacheData.exp;
            responseData.user_level = player.cacheData.level;
            responseData.user_ruby = player.cacheData.ruby;

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardNhiemVuHangNgayOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.NapThe;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardMailOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            GetRewardMailRequestData requestData = new GetRewardMailRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserMail userMail =
                MongoController.UserDb.Mail.GetData(requestData.mail_id);
            if (userMail == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (userMail.readed)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDoneBefore);

            // process
            MongoController.UserDb.Mail.UpdateReaded(userMail);


            List<RewardItem> listRewardItems = MongoController.UserDb.UpdateReward
            (
                userInfo: player.cacheData,
                listReward: userMail.rewards,
                 resource: ReasonActionGold.RewardMail
            );

            if (userMail.type == UserMailType.DenBuNapThe)
            {
                double totalRubyReward =
                    userMail.rewards.Where(a => a.type_reward == (int)TypeReward.Ruby).Sum(a => a.quantity);
                player.cacheData.info.total_ruby_trans += totalRubyReward;
                NapTheHandler.UpVip(player, player.cacheData.info.total_ruby_trans);


                double totalDayCreateAccount = (DateTime.Now - player.cacheData.info.created_at).TotalDays;

                // su kien phuc loi thang
                NapTheHandler.CheckSuKienPhucLoiThang(player, player.cacheData.info.total_ruby_trans);
                // su kien phuc loi truong thanh
                NapTheHandler.CheckSuKienPhucLoiTruongThanh(player, player.cacheData.info.total_ruby_trans, totalDayCreateAccount);
                // su kien cuu cuu tri ton
                NapTheHandler.CheckSuKienCuuCuuTriTon(player, player.cacheData.info.total_ruby_trans, totalDayCreateAccount);

                MongoController.UserDb.Info.UpdateTotalRubyTrans(player.cacheData);
            }

            RewardMailResponseData responseData = new RewardMailResponseData()
            {
                rewards = listRewardItems,
                user_gold = player.cacheData.info.gold,
                user_silver = player.cacheData.info.silver,
                user_vip = player.cacheData.info.vip,
                user_ruby = player.cacheData.info.ruby,
                user_total_ruby_trans = player.cacheData.info.total_ruby_trans
            };


            // response
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardMailOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }


    }
}

using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
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
    public class GetReward7NgayNhanThuongOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSK7NgayNhanThuongConfig sk = MongoController.ConfigDb.Sk7NgayNhanThuong.GetData();

            if (sk == null)
                CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            int day = DateTime.Now.Day;
            DayReward dayReward = sk.day_rewards.FirstOrDefault(a => a.day == day);
            if (dayReward == null)
                CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);

            MSK7NgayNhanThuongLog log =
                MongoController.LogSubDB.Sk7NgayNhanThuong.GetData(player.cacheData.info._id, sk._id);

            if (log == null)
            {
                log = new MSK7NgayNhanThuongLog()
                {
                    user_id = player.cacheData.info._id,
                    su_kien_id = sk._id,
                    day_received = new List<int>() { day }
                };
                MongoController.LogSubDB.Sk7NgayNhanThuong.Create(log);
            }
            else
            {
                if (log.day_received.Any(a => a == day))
                    CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyReceived);
                log.day_received.Add(day);
                MongoController.LogSubDB.Sk7NgayNhanThuong.Update(log);
            }

            List<RewardItem> rewardResult = MongoController.UserDb.UpdateReward
            (
                player.cacheData,
                dayReward.rewards,
                ReasonActionGold.RewardSk7NgayNhanThuong
            );

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = rewardResult,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetReward7NgayNhanThuongOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

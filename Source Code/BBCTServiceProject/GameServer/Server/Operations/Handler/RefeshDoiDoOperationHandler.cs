using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class RefeshDoiDoOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            if (!SuKienDoiDoInfo.Duration)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            MSKDoiDoConfig config = MongoController.ConfigDb.SkDoiDo.GetData();

            MSKDoiDoLog log = MongoController.LogSubDB.SkDoiDo.GetData(player.cacheData.id,
                config._id);
            if (log == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            double restTime = CommonFunc.GetCoolTimeSecond(log.last_time_get_item, config.refesh.hour_auto_refesh * 60 * 60);

            if (restTime == 0) // free
            {
                log.last_time_get_item = DateTime.Now;
                log.exchange_items = config.exchange_items.OrderBy(a => Guid.NewGuid()).Skip(0).Take(3).ToList();
            }
            else
            {
                if (player.cacheData.gold < config.refesh.gold_require)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                log.exchange_items = config.exchange_items.OrderBy(a => Guid.NewGuid()).Skip(0).Take(3).ToList();
                log.total_point += config.refesh.point_reward;
                log.current_point += config.refesh.point_reward;

                player.cacheData.gold -= config.refesh.gold_require;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.RefeshDoiDo, config.refesh.gold_require);

                SuKienDoiDoInfo.RefeshCurrentTopUsers(log);
            }
            log.index_exchanged = new List<int>();
            MongoController.LogSubDB.SkDoiDo.Update(log);

            RefeshDoiDoResponseData responseData = new RefeshDoiDoResponseData()
            {
                user_gold = player.cacheData.gold,
                current_point = log.current_point,
                total_point = log.total_point,
                exchange_items = log.exchange_items,
                rest_time_refesh = CommonFunc.GetCoolTimeSecond(log.last_time_get_item, config.refesh.hour_auto_refesh * 60 * 60)
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "RefeshDoiDoOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

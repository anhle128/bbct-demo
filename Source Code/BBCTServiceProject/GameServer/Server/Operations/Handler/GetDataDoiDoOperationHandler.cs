using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataDoiDoOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSKDoiDoConfig config = MongoController.ConfigDb.SkDoiDo.GetData();
            if (config == null)
            {
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.DoiDo);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            MSKDoiDoLog log = MongoController.LogSubDB.SkDoiDo.GetData(player.cacheData.id, config._id);

            double restTime = 0;
            if (log == null)
            {
                log = new MSKDoiDoLog()
                {
                    user_id = player.cacheData.id,
                    nickname = player.cacheData.nickname,
                    su_kien_id = config._id,
                    last_time_get_item = DateTime.Now,
                    exchange_items = config.exchange_items.OrderBy(a => Guid.NewGuid()).Skip(0).Take(3).ToList(),
                    avatar = player.cacheData.avatar,
                    hash_code_time = CommonFunc.GetHashCodeTime(),
                    index_receiveds = new List<IndexReceived>()
                };
                MongoController.LogSubDB.SkDoiDo.Create(log);

                restTime = CommonFunc.GetCoolTimeSecond(log.last_time_get_item, config.refesh.hour_auto_refesh * 60 * 60);
            }
            else
            {
                if (log.hash_code_time != CommonFunc.GetHashCodeTime())
                {
                    log.index_receiveds = new List<IndexReceived>();
                    log.hash_code_time = CommonFunc.GetHashCodeTime();
                    MongoController.LogSubDB.SkDoiDo.Update(log);
                }

                if (log.index_receiveds == null)
                    log.index_receiveds = new List<IndexReceived>();

                restTime = CommonFunc.GetCoolTimeSecond(log.last_time_get_item, config.refesh.hour_auto_refesh * 60 * 60);

                if (restTime == 0) // free
                {
                    log.last_time_get_item = DateTime.Now;
                    log.exchange_items = config.exchange_items.OrderBy(a => Guid.NewGuid()).Skip(0).Take(3).ToList();
                    if (log.index_exchanged != null)
                        log.index_exchanged.Clear();
                    MongoController.LogSubDB.SkDoiDo.Update(log);

                    restTime = CommonFunc.GetCoolTimeSecond(log.last_time_get_item, config.refesh.hour_auto_refesh * 60 * 60);
                }
            }

            SkDoiDoResponseData responseData = new SkDoiDoResponseData()
            {
                current_point = log.current_point,
                exchange_items = log.exchange_items,
                gold_require_refesh = config.refesh.gold_require,
                top_rewards = config.top_rewards,
                point_rewards = config.point_rewards,
                index_exchanged = log.index_exchanged,
                total_point = log.total_point,
                end_time = config.end,
                rest_time_refesh = restTime,
                index_recieveds = log.index_receiveds
            };


            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataDoiDoOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

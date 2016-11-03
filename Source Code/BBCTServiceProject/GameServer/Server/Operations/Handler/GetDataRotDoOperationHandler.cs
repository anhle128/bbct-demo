
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
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataRotDoOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            MSKRotDoConfig config = MongoController.ConfigDb.SkRotDo.GetData();
            if (config == null)
            {
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.RotDo);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            MSKRotDoLog log = MongoController.LogSubDB.SkRotDo.GetData(player.cacheData.info._id,
                config._id);
            if (log == null)
            {
                log = new MSKRotDoLog()
                {
                    user_id = player.cacheData.info._id,
                    hash_code_time = CommonFunc.GetHashCodeTime(),
                    su_kien_id = config._id,
                    index_receiveds = new List<IndexReceived>()
                };
                MongoController.LogSubDB.SkRotDo.Create(log);
            }
            else
            {
                if (log.hash_code_time != CommonFunc.GetHashCodeTime())
                {
                    log.index_receiveds = new List<IndexReceived>();
                    log.hash_code_time = CommonFunc.GetHashCodeTime();
                    MongoController.LogSubDB.SkRotDo.Update(log);
                }
                if (log.index_receiveds == null)
                    log.index_receiveds = new List<IndexReceived>();
            }

            SkRotDoResponseData responseData = new SkRotDoResponseData()
            {
                rewards = config.rewards,
                index_receiveds = log.index_receiveds,
                end_time = config.end
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataRotDoOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

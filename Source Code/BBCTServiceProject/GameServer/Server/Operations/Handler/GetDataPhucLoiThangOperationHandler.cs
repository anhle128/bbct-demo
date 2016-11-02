using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataPhucLoiThangOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            MUserPhucLoiThang userPhucLoiThang =
                MongoController.UserDb.PhucLoiThang.GetData(player.cacheData.id);

            DataPhucLoiThangResponseData responseData = null;

            if (userPhucLoiThang == null)
            {
                double gold = MongoController.LogDb.Trans.GetTotalRuby(player.cacheData.id);
                responseData = new DataPhucLoiThangResponseData()
                {
                    gold = gold,
                    day = 0
                };
            }
            else
            {

                if (userPhucLoiThang.day_end < DateTime.Now)
                {
                    double gold = MongoController.LogDb.Trans.GetTotalRuby(player.cacheData.id, userPhucLoiThang.day_end, DateTime.Now);
                    responseData = new DataPhucLoiThangResponseData()
                    {
                        gold = gold,
                        day = 0
                    };
                }
                else
                {
                    responseData = new DataPhucLoiThangResponseData()
                    {
                        gold = StaticDatabase.entities.configs.phucLoiThangConfig.rubyRequire,
                        day = (int)(userPhucLoiThang.day_end - DateTime.Now).TotalDays
                    };
                }
            }

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataPhucLoiThangOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

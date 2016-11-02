using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataSkDuaTopServerOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSKDuaTopServerConfig config = MongoController.ConfigDb.SkDuaTopServer.GetData();
            if (config == null)
            {
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.DuaTopServer);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            if(!config.is_send_reward)
            {
                List<TopUser>[] arrTopUsers = BangXepHangInfo.GetTopUsers(false);
                config.top_level_player = arrTopUsers[0];
                config.top_power_player = arrTopUsers[1];
            }

            SkDuaTopServerResponseData responseData = new SkDuaTopServerResponseData();
            responseData.top_level_rewards = config.top_level_rewards;
            responseData.top_power_rewards = config.top_power_rewards;
            responseData.top_level_player = config.top_level_player;
            responseData.top_power_player = config.top_power_player;
            responseData.end_time = config.end;

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataSkDuaTopServerOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

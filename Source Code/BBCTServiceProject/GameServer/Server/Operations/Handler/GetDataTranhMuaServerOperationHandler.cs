
using DynamicDBModel.Enum;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataTranhMuaServerOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSKTranhMuaServerConfig config = MongoController.ConfigDb.SkTranhMuaServer.GetData();
            if (config == null)
            {
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.TranhMuaServer);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            int day = (int)(DateTime.Now - config.start).TotalDays;

            SkTranhMuaServerResponseData responseData = new SkTranhMuaServerResponseData();
            responseData.items = config.days.Single(a => a.day == day).items;
            responseData.end_time = config.end;

            MSkTranhMuaServerLog log =
                MongoController.LogSubDB.SkTranhMuaServer.GetData(player.cacheData.id, config._id.ToString(), day);

            responseData.index_recieveds = log != null ? log.index_recieveds : null;

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataTranhMuaServerOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

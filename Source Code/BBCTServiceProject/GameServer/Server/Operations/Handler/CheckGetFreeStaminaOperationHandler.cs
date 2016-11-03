using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class CheckGetFreeStaminaOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            DateTime timeNow = DateTime.Now;

            FreeStaminaConfig freeStaminaTimeConfig =
                StaticDatabase.entities.configs.freeStaminaTimeConfig.FirstOrDefault(
                    a => a.from <= timeNow.Hour && a.to >= timeNow.Hour);
            //kiểm tra thời gian
            if (freeStaminaTimeConfig == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            // kiểm tra log
            List<MFreeStaminaLog> freeStaminaLog =
                MongoController.LogSubDB.FreeStamina.GetDatas(player.cacheData.info._id);
            if (freeStaminaLog.Any(a => freeStaminaTimeConfig.from <= a.created_at.Hour && freeStaminaTimeConfig.to >= a.created_at.Hour))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDoneBefore);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

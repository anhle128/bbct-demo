using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetFreeStamineOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            PlayerCacheData userInfo = player.cacheData;


            DateTime timeNow = DateTime.Now;
            FreeStaminaConfig freeStaminaTimeConfig =
                StaticDatabase.entities.configs.freeStaminaTimeConfig.FirstOrDefault(
                    a => a.from <= timeNow.Hour && timeNow.Hour <= a.to);
            // kiểm tra thời gian
            if (freeStaminaTimeConfig == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            // kiểm tra log
            List<MFreeStaminaLog> freeStaminaLog =
                MongoController.LogSubDB.FreeStamina.GetDatas(player.cacheData.info._id);

            if (freeStaminaLog.Any(a => a.created_at.Hour >= freeStaminaTimeConfig.from && a.created_at.Hour <= freeStaminaTimeConfig.to))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

            // process
            MFreeStaminaLog newLog = new MFreeStaminaLog()
            {
                user_id = player.cacheData.info._id,
                hash_code_time = CommonFunc.GetHashCodeTime()
            };
            userInfo.info.stamina += freeStaminaTimeConfig.stamina;

            // update
            MongoController.LogSubDB.FreeStamina.Create(newLog);
            MongoController.UserDb.Info.UpdateStamina(userInfo);
            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.info._id, TypeNhiemVuHangNgay.GetFreeStamina);
            // resoinse
            FreeStaminaResponse responseData = new FreeStaminaResponse()
            {
                stamina_reward = freeStaminaTimeConfig.stamina
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

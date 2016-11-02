using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class StartVanTieuOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            int countVanTieuDone =
                MongoController.UserDb.VanTieu.CountStartVanTieu(player.cacheData.info._id);

            if (countVanTieuDone >= StaticDatabase.entities.configs.vipConfigs[player.cacheData.vip].vanTieuTimes)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxVanTieuTimes);


            MUserVanTieu userVantieu =
                MongoController.UserDb.VanTieu.GetDataByUserId(player.cacheData.info._id);



            if (userVantieu == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (userVantieu.current_vehicle == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (userVantieu.current_vehicle.going_on)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDoneBefore);


            userVantieu.current_vehicle.going_on = true;
            userVantieu.current_vehicle.start = DateTime.Now;
            userVantieu.start = true;

            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.info._id, TypeNhiemVuHangNgay.VanTieu);
            MongoController.UserDb.VanTieu.UpdateCurrentVehidle(userVantieu);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

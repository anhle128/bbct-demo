using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataCuopTieuOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {

            if (player.cacheData.info.level < StaticDatabase.entities.configs.vanTieuConfig.levelRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            MUserCuopTieu userCuopTieu =
                MongoController.UserDb.CuopTieu.GetData(player.cacheData.info._id);


            if (userCuopTieu == null)
            {
                userCuopTieu = new MUserCuopTieu()
                {
                    user_id = player.cacheData.info._id,
                    hash_code_time = CommonFunc.GetHashCodeTime()
                };
                MongoController.UserDb.CuopTieu.Create(userCuopTieu);
            }

            Configs config = StaticDatabase.entities.configs;

            if (userCuopTieu.cuop_tieu_datas == null)
                userCuopTieu.cuop_tieu_datas = new List<MCuopTieuData>();
            if (userCuopTieu.cuop_tieu_datas.Count >= config.vipConfigs[player.cacheData.info.vip].cuopTieuTimes)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxCuopTieuTimes);
            int maxLevel = player.cacheData.info.level + 100;
            int minLevel = player.cacheData.info.level - 100 <= 1 ? 1 : player.cacheData.info.level - 100;

            List<MUserVanTieu> userVanTieus =
                MongoController.UserDb.VanTieu.GetRandomDatas(player.cacheData.info._id, minLevel, maxLevel);

            //CommonLog.Instance.PrintLog("userVanTieus: " + userVanTieus.CoundLogInDay);

            foreach (var data in userVanTieus)
            {
                if (data.users_cuop_tieu == null)
                    data.users_cuop_tieu = new List<string>();
            }

            DataCuopTieuResponseData responseData = new DataCuopTieuResponseData()
            {
                user_van_tieus = userVanTieus.Select(a => new UserVanTieu()
                {
                    id = a._id.ToString(),
                    userid = a.user_id.ToString(),
                    level = a.level,
                    nickname = a.nickname,
                    vip = a.vip,
                    currentVehicle = new CurVehicle()
                    {
                        type = a.current_vehicle.type,
                        countTimesBiCuop = a.users_cuop_tieu.Count
                    }
                }).ToList(),
                count_times_cuop_tieu = userCuopTieu.cuop_tieu_datas.Count
            };
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataCuopTieuOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;

namespace GameServer.Server.Operations.Handler
{
    public class ThachDauOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionPlayerRequestData requestData = new ActionPlayerRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            VipConfig vipConfig = StaticDatabase.entities.configs.vipConfigs[player.cacheData.vip];
            int countThachDau = MongoController.LogSubDB.ThachDau.Count(player.cacheData.info._id);
            if (countThachDau >= vipConfig.challengeTimes)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxAttackTimes);

            MUserInfo userInfo = MongoController.UserDb.Info.GetData((requestData.userid));

            AttackPlayerResponseData responseData = new AttackPlayerResponseData()
            {
                subData = MongoController.UserDb.GetSubDataPlayer(userInfo)
            };

            MThachDauLog log = new MThachDauLog()
            {
                user_id = player.cacheData.info._id,
                hash_code_time = CommonFunc.GetHashCodeTime(),
                other_user_id = userInfo._id
            };
            MongoController.LogSubDB.ThachDau.Create(log);

            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.info._id, TypeNhiemVuHangNgay.ThachDau);

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

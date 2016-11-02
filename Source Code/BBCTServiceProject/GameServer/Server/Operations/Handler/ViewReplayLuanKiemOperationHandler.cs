using DynamicDBModel.Models.Battle;
using GameServer.Common;
using GameServer.Common.Core;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class ViewReplayLuanKiemOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            ReplayRequestData requestData = new ReplayRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MLuanKiemLog log =
                MongoController.LogSubDB.LuanKiem.GetData(requestData.id);
               
            if (log == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            //BattleReplay battle = ProtoBufSerializerHelper.Handler().Deserialize<BattleReplay>(log.battle_replay);

            ReplayResponseData responseData = new ReplayResponseData(log.battle_replay);


            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "OperationResponse done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}

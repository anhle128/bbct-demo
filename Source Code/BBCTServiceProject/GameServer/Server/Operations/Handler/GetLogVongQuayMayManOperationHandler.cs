using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class GetLogVongQuayMayManOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSKVongQuayMayManConfig config = MongoController.ConfigDb.SkVongQuayMayMan.GetData();
            if (config == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            MSKVongQuayMayManLog log = MongoController.LogSubDB.SkVongQuayMayMan.GetData(player.cacheData.id, config._id);
            VongQuayMayManLogResponseData responseData = new VongQuayMayManLogResponseData();
            if (log != null)
            {
                responseData.rewards = log.rewards;
            }

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetVongQuayMayManLogOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

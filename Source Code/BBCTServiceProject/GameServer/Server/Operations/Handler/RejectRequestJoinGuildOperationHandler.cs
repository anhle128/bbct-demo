using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class RejectRequestJoinGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionPlayerRequestData requestData = new ActionPlayerRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData.userid))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var guild = MongoController.GuildDb.Guild.GetDataByUserId(player.cacheData.info._id);

            if (guild == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotHavePermission);
            }

            var requestJoin = MongoController.GuildDb.RequestJoin.GetData(guild._id, (requestData.userid));

            if (requestJoin == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            MongoController.GuildDb.RequestJoin.Delete(requestJoin._id);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

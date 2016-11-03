using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class EditNoticeGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            EditGuildNoticeRequestData requestData = new EditGuildNoticeRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData.notice))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var guild = MongoController.GuildDb.Guild.GetDataByUserId(player.cacheData.info._id);

            if (guild == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotHavePermission);
            }

            MongoController.GuildDb.Guild.UpdateNotice(guild._id, requestData.notice);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

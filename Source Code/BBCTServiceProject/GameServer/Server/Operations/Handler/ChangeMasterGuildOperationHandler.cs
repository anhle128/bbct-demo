using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class ChangeMasterGuildOperationHandler : IOperationHandler
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

            var member = MongoController.GuildDb.GuildMember.GetData(requestData.userid);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var bangChienDuring = MongoController.GuildDb.BangChien.GetData(BangChien.State.DangDienRa);

            if (bangChienDuring != null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            MongoController.GuildDb.Guild.UpdateMaster(guild._id, member.user_id);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

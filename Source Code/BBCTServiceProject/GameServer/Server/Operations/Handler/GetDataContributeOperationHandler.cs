using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataContributeOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);


            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var log = MongoController.LogSubDB.ContributeLog.GetData(player.cacheData.info._id);


            bool isCan = true;
            if (log != null)
            {
                isCan = CommonFunc.IsPassDay(log.created_at);
            }

            GetDataContributeResponseData responseData = new GetDataContributeResponseData()
            {
                isCan = isCan,
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

using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using StaticDB.Models;

namespace GameServer.Server.Operations.Handler
{
    public class SendGMMailOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            SendGMMailRequestData requestData = new SendGMMailRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            GMMailConfig config = StaticDatabase.entities.configs.mailGMConfig;
            int count = MongoController.MailDb.Gm.CountMailSent(player.cacheData.info._id);

            if (count >= config.maxMailCanSentPerDay)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxMailCanSend);

            if (requestData.mail.title.Length > config.titleLength || requestData.mail.content.Length > config.contentLength)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MongoController.MailDb.Gm.Create(player.cacheData.info._id, requestData.mail);
            //CommonLog.Instance.PrintLog("Done SendGMMailOperationHandler");
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

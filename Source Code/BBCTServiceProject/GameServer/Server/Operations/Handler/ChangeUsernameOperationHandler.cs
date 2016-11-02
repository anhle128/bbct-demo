using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using Photon.SocketServer;
using System;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class ChangeUsernameOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            //ChangeUsernameRequestData requestdata = new ChangeUsernameRequestData();
            //requestdata.Deserialize(operationRequest.Parameters);

            //CommonLog.Instance.PrintLog(string.Format("change userid {0} to {1}", requestdata.userid, requestdata.userid));

            //ChangeUsername(requestdata.userid, requestdata.userid);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }

        
    }
}

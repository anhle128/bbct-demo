using System.Collections.Generic;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using Photon.SocketServer;
using StaticDB.Models;
using System.Linq;
using LitJson;

namespace GameServer.Server.Operations.Handler
{
    class ChangeFormationOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ChangeFormationRequestData requestData = new ChangeFormationRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            LevelNumCharInFormation levelNumCharInFormation =
                StaticDatabase.entities.configs.playerLevelNumberCharInFormations.LastOrDefault(a => a.level <= player.cacheData.level);
            if (levelNumCharInFormation == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);
            }
           

            MongoController.UserDb.Info.UpdateAvatar_Formation(player.cacheData);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

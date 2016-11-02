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
           
            int totalNumCharInFormation = requestData.formationRows.Sum(stringArray => stringArray.columns.Count(a => a != "-1"));
            if (totalNumCharInFormation > levelNumCharInFormation.numberCharInFormation)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NumberCharInFormationIsWrong);

            foreach (var duBi in requestData.doi_hinh_du_bi.Where(a => a.id_char != "-1"))
            {
                foreach (var formation in requestData.formationRows)
                {
                    if (formation.columns.Any(a => a.Equals(duBi.id_char)))
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.CharInFormation);
                }
            }

            if (player.cacheData.doi_hinh_du_bi != null && player.cacheData.doi_hinh_du_bi.Count != requestData.doi_hinh_du_bi.Count)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            foreach (var duBi in requestData.doi_hinh_du_bi)
            {

                if (player.cacheData.doi_hinh_du_bi.All(a => a.index != duBi.index))
                {
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
                }
            }

            player.cacheData.formation = requestData.formationRows;
            player.cacheData.doi_hinh_du_bi = requestData.doi_hinh_du_bi;

            MongoController.UserDb.Info.UpdateAvatar_Formation(player.cacheData);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

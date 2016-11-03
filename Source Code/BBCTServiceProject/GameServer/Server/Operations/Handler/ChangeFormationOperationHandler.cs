using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using StaticDB.Models;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    class ChangeFormationOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ChangeFormationRequestData requestData = new ChangeFormationRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            FormationConfig formationConfig = StaticDatabase.entities.configs.formationConfig;

            if (requestData.index_formation == formationConfig.totalNumberFormation - 1)
            {
                if (player.cacheData.info.vip < formationConfig.vipRequireOpendLastMainFormation)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }


            // kiểm tra số lượng char trong đội hình chính
            int countTotalCharInMainFormation = CountTotalCharInMainFormation(requestData);
            if (countTotalCharInMainFormation > formationConfig.GetNumberCharInMainFormation(player.cacheData.info.level))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidNumCharInMainFormation);

            // kiểm tra level mở đội hình phụ
            int countTotalCharInSubFormation = requestData.data_formation.sub.Count(a => a != "-1");
            if (countTotalCharInSubFormation != 0 &&
                player.cacheData.info.level < formationConfig.levelRequireOpendSubFormation)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);


            // kiểm tra xem có char nào vừa có ở đội hình trính lẫn đội hình phụ không
            foreach (var row in requestData.data_formation.main)
            {
                foreach (var column in row.columns)
                {
                    if (requestData.data_formation.sub.Any(a => a == column))
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidChar);
                }
            }

            player.cacheData.info.formations[requestData.index_formation] = requestData.data_formation;

            MongoController.UserDb.Info.UpdateAvatar_Formation(player.cacheData);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }

        private int CountTotalCharInMainFormation(ChangeFormationRequestData requestData)
        {
            int countTotalCharInMainFormation = 0;
            foreach (var row in requestData.data_formation.main)
            {
                foreach (var column in row.columns)
                {
                    if (column != "-1")
                        continue;

                    countTotalCharInMainFormation++;
                }
            }
            return countTotalCharInMainFormation;
        }
    }
}

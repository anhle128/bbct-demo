using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;

namespace GameServer.Server.Operations.Handler
{
    public class StartCauCaOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            StartCauCaRequestData requestData = new StartCauCaRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            var uCauCas = MongoController.UserDb.CauCa.GetCurrentCauCa(player.cacheData.info._id);

            if (uCauCas != null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            int countTimes = MongoController.UserDb.CauCa.Count(player.cacheData.info._id);

            int maxTimes = StaticDatabase.entities.configs.GetVipConfig(player.cacheData.vip).cauCaTimes;

            if (countTimes >= maxTimes)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxCauCaTimes);
            }
            if (requestData.indexCanCau >= StaticDatabase.entities.configs.cauCaConfig.canCauConfigs.Length)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            CanCauConfig canCauConfig = StaticDatabase.entities.configs.cauCaConfig.canCauConfigs[requestData.indexCanCau];

            if (player.cacheData.silver < canCauConfig.silver ||
                player.cacheData.gold < canCauConfig.gold ||
                player.cacheData.vip < canCauConfig.vipRequire)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);
            }
            if (canCauConfig.gold > 0)
            {
                player.cacheData.gold -= canCauConfig.gold;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.StartCauCa, canCauConfig.gold);
            }
            else if (canCauConfig.silver > 0)
            {
                player.cacheData.silver -= canCauConfig.silver;
                MongoController.UserDb.Info.UpdateSilver(player.cacheData, TypeUseSilver.StartCauCa, canCauConfig.silver);
            }

            MCauCa mCauCa = new MCauCa()
            {
                user_id = player.cacheData.info._id,
                is_open = true,
                indexCanCau = requestData.indexCanCau,
                hash_code_time = CommonFunc.GetHashCodeTime(),
            };
            MongoController.UserDb.CauCa.Create(mCauCa);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

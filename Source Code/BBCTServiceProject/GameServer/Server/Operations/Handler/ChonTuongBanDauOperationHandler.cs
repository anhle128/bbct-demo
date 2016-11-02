using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    class ChonTuongBanDauOperationHandler : IOperationHandler
    {
        public Photon.SocketServer.OperationResponse Handler(GamePlayer player, Photon.SocketServer.OperationRequest operationRequest, Photon.SocketServer.SendParameters sendParameters, OperationController controller)
        {
            ActionCharRequestData requestData = new ActionCharRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            int totalCharacter = player.cacheData.listUserChar.Count;

            if (totalCharacter > 0)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.Error);

            if (
                StaticDatabase.entities.configs.characterConfig.defaultCharSelections.All(
                    a => a.id != int.Parse(requestData.char_id)))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // process
            MUserCharacter userCharacter = new MUserCharacter()
            {
                static_id = int.Parse(requestData.char_id),
                user_id = player.cacheData.info._id
            };

            player.cacheData.CreateUserChar(userCharacter);

            player.cacheData.info.avatar = userCharacter.static_id;
            player.cacheData.info.formations[0].main[1].columns[1] = userCharacter._id.ToString();

            MongoController.UserDb.Info.UpdateAvatar_Formation(player.cacheData);

            RewardItem reward = new RewardItem()
            {
                quantity = 1,
                _id = userCharacter._id.ToString(),
                static_id = userCharacter.static_id,
                type_reward = (int)TypeReward.Character
            };

            ChonTuongBanDauResponseData response = new ChonTuongBanDauResponseData()
            {
                char_reward = reward,
                formation = player.cacheData.info.formations[0]
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "ChonTuongBanDauOperationHandler done!",
                Parameters = response.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}

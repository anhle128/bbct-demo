using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    class UpStarLevelCharOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
           OperationController controller)
        {
            UpStarLevelCharRequestData requestData = new UpStarLevelCharRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            MUserCharacter userCharacter =
                player.cacheData.listUserChar.FirstOrDefault
                (
                    a =>
                        a._id.ToString() == requestData.char_id
                );
            if (userCharacter == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MUserCharacter userCharacterStock =
                player.cacheData.listUserChar.FirstOrDefault
                (
                    a =>
                        a._id.ToString() == requestData.char_id
                );
            if (userCharacterStock == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidChar);

            if (userCharacter.level != userCharacterStock.level ||
                userCharacter.powerup_level != userCharacterStock.powerup_level ||
                userCharacter.star_level != userCharacterStock.star_level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidChar);

            Character character = StaticDatabase.entities.characters.FirstOrDefault(a => a.id == userCharacter.static_id);
            if (character == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidChar);

            Character characterStock =
                StaticDatabase.entities.characters.FirstOrDefault(a => a.id == userCharacterStock.static_id);
            if (characterStock == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidChar);

            // kiểm tra xem char nguyên liệu có phải là nguyên liệu hay không
            if (characterStock.type != TypeCharacter.Element)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidChar);

            // kiểm tra xem có cùng ngũ hành hay không
            if (characterStock.element != character.element)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidChar);

            //kiểm tra xem đã max star chưa
            if (userCharacter.star_level >= character.highestStarLevel)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxStar);


            if (userCharacter.level < StaticDatabase.entities.configs.characterConfig.maxLevel)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            if (userCharacter.powerup_level < StaticDatabase.entities.configs.characterConfig.maxPowerup)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            int silverRequire =
                StaticDatabase.entities.configs.characterConfig.GetSilverNeedToStarUp(userCharacter.star_level);
            if (player.cacheData.info.silver < silverRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughSliver);

            userCharacter.star_level++;
            userCharacter.level = StaticDatabase.entities.configs.characterConfig.defaultConfig.levelChar;
            userCharacter.powerup_level = StaticDatabase.entities.configs.characterConfig.defaultConfig.powerupLevelChar;

            player.cacheData.info.silver -= silverRequire;

            player.cacheData.DeleteUserChar(userCharacterStock);

            MongoController.UserDb.Info.UpdateSilver(player.cacheData, TypeUseSilver.UpStarLevelChar, silverRequire);
            MongoController.UserDb.Char.UpdateStarLevel(userCharacter);
            player.cacheData.DeleteUserChar(userCharacterStock);

            RewardResponseData response = new RewardResponseData()
            {
                user_silver = player.cacheData.info.silver
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = response.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };


        }
    }
}

using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    class UpStarLevelCharOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
           OperationController controller)
        {
            ActionCharRequestData requestData = new ActionCharRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            MUserCharacter userCharacter =
                player.cacheData.listUserChar.FirstOrDefault
                (
                    a =>
                        a._id.ToString() == requestData.char_id
                );
            if (userCharacter == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            //MUserCharacterSoul userCharSoul =
            //    player.cacheData.listUserCharSoul.FirstOrDefault
            //    (
            //        a =>
            //            a.static_id == userCharacter.static_id
            //    );

            Character character = StaticDatabase.entities.characters.Single(a => a.id == userCharacter.static_id);
            //int numberSoulRequire = character.GetPieceNeedToUpStar(userCharacter.star_level);
            //if (userCharSoul.quantity < numberSoulRequire)
            //    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            //if (userCharacter.star_level >= StaticDatabase.entities.configs.characterConfig.maxStarCanUp)
            //    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.StarLevelIsMax);

            //// process
            //userCharSoul.quantity -= numberSoulRequire;
            //userCharacter.star_level++;

            //if (player.cacheData.avatar == userCharacter.static_id)
            //{
            //    player.cacheData.avatar_star = userCharacter.star_level;
            //    MongoController.UserDb.Info.UpdateAvatar(player.cacheData);
            //}

            //// update
            //MongoController.UserDb.CharSoul.UpdateQuantity(userCharSoul);
            //MongoController.UserDb.Char.UpdateStarLevel(userCharacter);

            // response
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);


        }
    }
}

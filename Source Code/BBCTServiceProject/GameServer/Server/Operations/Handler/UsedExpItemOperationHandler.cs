using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    class UsedExpItemOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            UsedItemWithCharRequestData requestData = new UsedItemWithCharRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            // kiểm tra character
            MUserCharacter userCharacter =
                player.cacheData.listUserChar.FirstOrDefault(a => a._id.ToString() == requestData.char_id);
            if (userCharacter == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);


            MUserItem userItem = player.cacheData.listUserItem.FirstOrDefault(a =>
                a.static_id == requestData.item_id);


            // Kiểm tra level
            if (StaticDatabase.entities.configs.characterLevelExps.All(a => a.level != userCharacter.level))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxLevel);

            Item itemExp =
                StaticDatabase.entities.items.FirstOrDefault(
                    a => a.id == userItem.static_id && a.type == (int)TypeItem.KinhNhiemDan);
            if (itemExp == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidItem);

            // Kiểm tra số lượng item
            if (userItem == null || userItem.quantity == 0 || userItem.quantity < requestData.quantity)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoesNotEnoughItem);

            // Lấy level max của character
            int levelMax = CommonFunc.GetMaxLevelCharacter(player.cacheData.info.level);
            CharacterLevelExp levelExp =
                StaticDatabase.entities.configs.characterLevelExps.FirstOrDefault(a => a.level == levelMax);
            int expNeedTopUpLevel = levelExp.exp;

            // Kiểm tra max level
            if (userCharacter.level >= levelMax && userCharacter.exp >= expNeedTopUpLevel - 1)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxLevel);

            float expPlush = itemExp.attribute[0] * requestData.quantity;
            userItem.quantity -= requestData.quantity;

            // update 
            bool isUpLevel = CommonFunc.UpLevelCharacter(userCharacter, expPlush, levelMax, false);

            MongoController.UserDb.Item.UpdateQuantity(userItem);
            MongoController.UserDb.Char.Update_Level_Exp_Skill(userCharacter);

            // response
            UsedExpItemReponseData response = new UsedExpItemReponseData()
            {
                char_id = userCharacter._id.ToString(),
                level = userCharacter.level,
                exp = userCharacter.exp
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "UsedExpItemOperationHandler done!",
                Parameters = response.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

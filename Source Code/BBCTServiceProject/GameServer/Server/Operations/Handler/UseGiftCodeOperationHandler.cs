using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class UseGiftCodeOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            if (operationRequest.Parameters.Count == 0)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            UseGiftCodeRequestData requestData = new UseGiftCodeRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            // kiểm tra gift code
            MGiftCode giftCode =
                MongoController.GiftCodeDb.Code.GetData(requestData.gift_code);
            if (giftCode == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.WrongGiftCode);

            MGiftCodeCategory giftCodeCategory =
                MongoController.GiftCodeDb.Category.GetData(giftCode.category);


            // kiểm tra server có được dùng gift code hay o
            if (!String.IsNullOrEmpty(giftCodeCategory.server_id.ToString()) &&
                !Settings.Instance.server_id.Equals(giftCodeCategory.server_id))
                return Common.CommonFunc.SimpleResponse(operationRequest, ReturnCode.GiftCodeNotForThisServer);



            // process
            if (giftCodeCategory.type == GiftCodeType.OnyOne)
            {
                // kiểm tra gift code đã được sử dụng hay chưa
                if (!string.IsNullOrEmpty(giftCode.user_id))
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.GiftCodeBeUsed);

                // kiểm tra đã dùng gift code nào cùng category chưa
                if (!CheckCategory(player, operationRequest, giftCodeCategory))
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.CategoryGiftCodeBeUsed);

                giftCode.user_id = player.cacheData.info._id;
                MongoController.GiftCodeDb.Code.Update(giftCode);
            }
            else if (giftCodeCategory.type == GiftCodeType.Unlimmit)
            {
                // kiểm tra gift code đã được sử dụng hay chưa
                if (!string.IsNullOrEmpty(giftCode.user_id))
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.GiftCodeBeUsed);

                giftCode.user_id = player.cacheData.info._id;
                MongoController.GiftCodeDb.Code.Update(giftCode);
            }
            else if (giftCodeCategory.type == GiftCodeType.AnyoneCanUse)
            {
                // kiểm tra đã dùng gift code nào cùng category chưa
                if (!CheckCategory(player, operationRequest, giftCodeCategory))
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.CategoryGiftCodeBeUsed);
            }


            MGiftCodeLog logUsedGiftCode = new MGiftCodeLog()
            {
                type = giftCodeCategory.type,
                user_id = player.cacheData.info._id,
                gift_code = giftCode._id.ToString(),
                rewards = giftCodeCategory.rewards,
                category = giftCodeCategory._id
            };
            MongoController.LogDb.GiftCode.Create(logUsedGiftCode);

            List<RewardItem> listRewardItem = MongoController.UserDb.UpdateReward(player.cacheData, giftCodeCategory.rewards.ToList(), ReasonActionGold.RewardGiftCode);
            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listRewardItem,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.exp,
                user_ruby = player.cacheData.ruby
            };

            // response
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "UseGiftCodeOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }

        private static bool CheckCategory(GamePlayer player, OperationRequest operationRequest,
            MGiftCodeCategory giftCodeCategory)
        {
            int countGiftCodeUsedInCategory = MongoController.LogDb.GiftCode.Count(player.cacheData.info._id, giftCodeCategory._id);

            if (countGiftCodeUsedInCategory != 0)
            {
                return false;
            }
            return true;
        }
    }
}

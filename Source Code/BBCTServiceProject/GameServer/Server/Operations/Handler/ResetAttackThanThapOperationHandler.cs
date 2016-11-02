using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;

namespace GameServer.Server.Operations.Handler
{
    public class ResetAttackThanThapOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            if (player.cacheData.thanThapAttacked == null)
            {
                player.cacheData.thanThapAttacked =
               MongoController.UserDb.ThanThap.GetData(player.cacheData.id, ThanThapInfo.GetHashTimeEnd());
            }

            if (player.cacheData.thanThapAttacked == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            MoneyResetThanThap money =
                StaticDatabase.entities.configs.thanThapConfig.GetMoneyResestThanThap(
                    player.cacheData.thanThapAttacked.reset_times);

            if (money.type == (int)TypeReward.Ruby)
            {
                if (player.cacheData.gold < money.quantity)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);
                player.cacheData.gold -= money.quantity;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.ResetThanThap, money.quantity);
            }
            else
            {
                if (player.cacheData.silver < money.quantity)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughSliver);
                player.cacheData.silver -= money.quantity;
                MongoController.UserDb.Info.UpdateSilver(player.cacheData, TypeUseSilver.ResetAttackThanThap, money.quantity);
            }

            player.cacheData.thanThapAttacked.reset_times++;
            player.cacheData.thanThapAttacked.dead = false;
            MongoController.UserDb.ThanThap.UpdateResetTime_Dead(player.cacheData.thanThapAttacked);

            // response
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

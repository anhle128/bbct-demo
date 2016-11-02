using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class ResetLuanKiemAttackTimeOperationHander : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

                double coolTime = CommonFunc.GetCoolTimeSecond(player.cacheData.lastTimeAttackLuanKiem,
                    StaticDatabase.entities.configs.luanKiemConfig.GetSecondCoolDownAttack());
                if (coolTime == 0)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

                if (player.cacheData.gold < StaticDatabase.entities.configs.luanKiemConfig.goldRequireQuickAttack)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                player.cacheData.gold -= StaticDatabase.entities.configs.luanKiemConfig.goldRequireQuickAttack;

                player.cacheData.lastTimeAttackLuanKiem =
                    DateTime.Now.AddSeconds(-StaticDatabase.entities.configs.luanKiemConfig.GetSecondCoolDownAttack());

                MongoController.UserDb.Info.UpdateGold_LastTimeAttackLuanKiem(player.cacheData, StaticDatabase.entities.configs.luanKiemConfig.goldRequireQuickAttack);

                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

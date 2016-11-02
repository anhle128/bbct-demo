using DynamicDBModel.Enum;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.GlobalInfo;
using GameServer.NapThe;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using MongoDBModel.MainDatabaseModels;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class CheckTransactionOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            // check payment
            List<MTransaction> listNewTrans = MongoController.LogDb.Trans.GetCheckTrans(player.cacheData.id);

            MSKx2NapConfig x2Config = MongoController.ConfigDb.Skx2Nap.GetData();
            if (x2Config == null)
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.x2Nap);


            if (listNewTrans.Count > 0)
            {
                return NapTheHandler.CheckTrans(player, operationRequest, listNewTrans, x2Config);
            }
            else
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoNotHaveTrans);
            }
        }
    }
}

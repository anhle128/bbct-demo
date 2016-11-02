using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
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
    public class UsedStaminaItemOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            UsedItemRequestData requestData = new UsedItemRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserItem userItem =
                player.cacheData.listUserItem.FirstOrDefault(a => a._id.ToString() == requestData.item_id);

            if (userItem == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            Item item = StaticDatabase.entities.items.Single(a => a.id == userItem.static_id);
            if (item == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);
            }
            if (item.type != (short)TypeItem.BanhBao)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (item.attribute.Length == 0)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);

            int staminaReceive = (int)item.attribute[0];
            player.cacheData.stamina += staminaReceive;
            userItem.quantity--;

            MongoController.UserDb.Item.UpdateQuantity(userItem);
            MongoController.UserDb.Info.UpdateStamina(player.cacheData);
            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.id, TypeNhiemVuHangNgay.GetFreeStamina);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

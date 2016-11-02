using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    class UnequipEquipmentOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            ActionEquipRequestData requestData = new ActionEquipRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            // kiểm tra user char
            MUserCharacter userChar = player.cacheData.listUserChar.FirstOrDefault
            (
                a =>
                    a._id.ToString() == requestData.char_id
            );
            if (userChar == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // Kiểm tra user equipment
            MUserEquip userEquip = player.cacheData.listUserEquip.FirstOrDefault
            (
                a =>
                    a._id.ToString() == requestData.equip_item_id
            );

            if (userEquip == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            Equipment equip = StaticDatabase.entities.equipments.Single(a => a.id == userEquip.static_id);

            // process
            userChar.equipments[(int)equip.category - 1] = "-1";
            userEquip.char_equip = "-1";

            // update
            MongoController.UserDb.Char.UpdateEquipments(userChar);
            MongoController.UserDb.Equip.UpdateCharEquip(userEquip);

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "UnequipEquipmentOperationHandler done!",
                Parameters = new Dictionary<byte, object>(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

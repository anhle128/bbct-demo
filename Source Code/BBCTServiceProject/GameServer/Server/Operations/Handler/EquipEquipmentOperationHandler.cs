using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    class EquipEquipmentOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionEquipRequestData requestData = new ActionEquipRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            //CommonLog.Instance.PrintLog("--------------- all listUserEquip");
            //foreach (var equipment in player.cacheData.listUserEquip)
            //{
            //    CommonLog.Instance.PrintLog(equipment._id.ToString());
            //}
            //CommonLog.Instance.PrintLog("------------------------------");
            //CommonLog.Instance.PrintLog("requestData.equip_item_id: " + requestData.equip_item_id);

            // kiểm tra user equip
            MUserEquip userEquip = player.cacheData.listUserEquip.FirstOrDefault
            (
                a =>
                    a._id.ToString() == requestData.equip_item_id
            );
            if (userEquip == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // kiểm tra user char
            MUserCharacter userChar = player.cacheData.listUserChar.FirstOrDefault
            (
                a =>
                    a._id.ToString() == requestData.char_id
            );
            if (userChar == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // kiểm tra equip
            Equipment equip = StaticDatabase.entities.equipments.FirstOrDefault(a => a.id == userEquip.static_id);
            if (equip == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // lấy char đang đeo equip
            if (userEquip.char_equip != "-1")
            {
                MUserCharacter userCharEquipBefore = player.cacheData.listUserChar.FirstOrDefault
               (
                   a =>
                       a._id.ToString() == userEquip.char_equip
               );
                for (int i = 0; i < userCharEquipBefore.equipments.Count; i++)
                {
                    if (userCharEquipBefore.equipments[i] == userEquip._id.ToString())
                    {
                        userCharEquipBefore.equipments[i] = "-1";
                        break;
                    }
                }
                MongoController.UserDb.Char.UpdateEquipments(userCharEquipBefore);
            }

            // xoa equip cu~
            string oldEquip = userChar.equipments[(int)equip.category - 1];
            if (oldEquip != "-1")
                MongoController.UserDb.Equip.RemoveCharEquip((oldEquip));

            // process
            userChar.equipments[(int)equip.category - 1] = requestData.equip_item_id;
            userEquip.char_equip = userChar._id.ToString();

            // updateUserChar
            MongoController.UserDb.Char.UpdateEquipments(userChar);
            MongoController.UserDb.Equip.UpdateCharEquip(userEquip);

            // response
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

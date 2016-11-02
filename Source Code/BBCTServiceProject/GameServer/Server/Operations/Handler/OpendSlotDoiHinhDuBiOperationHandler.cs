using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDBModel.Models;
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

namespace GameServer.Server.Operations.Handler
{
    public class OpendSlotDoiHinhDuBiOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (requestData.index > StaticDatabase.entities.configs.doiHinhDuBiConfig.datas.Length - 1)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            DoiHinhDuBiRequire require = StaticDatabase.entities.configs.doiHinhDuBiConfig.datas[requestData.index];
            if (player.cacheData.level < require.level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            Item item = StaticDatabase.entities.items.FirstOrDefault(a => a.type  == (short)TypeItem.ChiTonLenh);
            if (item == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);

            MUserItem userItem = player.cacheData.listUserItem.FirstOrDefault(a => a.static_id == item.id);
            if (userItem == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            if (userItem.quantity < require.numberItem)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoesNotEnoughItem);

            if(player.cacheData.doi_hinh_du_bi == null)
                player.cacheData.doi_hinh_du_bi = new List<DuBi>();

            if (player.cacheData.doi_hinh_du_bi.Any(a => a.index == requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

            player.cacheData.doi_hinh_du_bi.Add(new DuBi()
            {
                index = requestData.index,
                id_char = "-1"
            });

            userItem.quantity -= require.numberItem;
            MongoController.UserDb.Item.UpdateQuantity(userItem);

            MongoController.UserDb.Info.UpdateDoiHinhDiBi(player.cacheData);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

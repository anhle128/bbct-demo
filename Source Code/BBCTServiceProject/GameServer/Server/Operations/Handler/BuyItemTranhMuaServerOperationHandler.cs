
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class BuyItemTranhMuaServerOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MSKTranhMuaServerConfig config = MongoController.ConfigDb.SkTranhMuaServer.GetData();
            if (config == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            int day = (int)(DateTime.Now - config.start).TotalDays;

            DayTranhMua dayTranhMua = config.days.Single(a => a.day == day);
            ItemTranhMua item = dayTranhMua.items[requestData.index];
            if (item.quantity <= item.quantity_sold)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OutOfStock);

            if (player.cacheData.gold < item.price)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            item.quantity_sold++;
            player.cacheData.gold -= item.price;

            MSkTranhMuaServerLog log = MongoController.LogSubDB.SkTranhMuaServer.GetData(player.cacheData.id,
                config._id.ToString(), day);

            bool isCreate = false;
            if (log == null)
            {
                isCreate = true;
                log = new MSkTranhMuaServerLog()
                {
                    user_id = player.cacheData.id,
                    day = day,
                    index_recieveds = new List<IndexReceived>(),
                    su_kien_id = config._id.ToString()
                };
            }

            IndexReceived indexReceved = log.index_recieveds.FirstOrDefault(a => a.index == requestData.index);
            if (indexReceved == null)
            {
                indexReceved = new IndexReceived()
                {
                    index = requestData.index,
                    received_times = 1
                };
                log.index_recieveds.Add(indexReceved);
            }
            else
            {
                if (indexReceved.received_times >= item.quantity_each_user_can_buy)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxTimesCanBuy);
                indexReceved.received_times++;
            }

            // update
            MongoController.ConfigDb.SkTranhMuaServer.Update(config);
            List<RewardItem> listReward = MongoController.UserDb.UpdateReward
            (
                player.cacheData,
                new List<SubRewardItem>() { item.item },
                ReasonActionGold.None
            );
            MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.BuyItemTranhMuaServer, item.price);
            if (isCreate)
                MongoController.LogSubDB.SkTranhMuaServer.Create(log);
            else
                MongoController.LogSubDB.SkTranhMuaServer.Update(log);


            // response
            BuyItemTranhMuaResponseData responseData = new BuyItemTranhMuaResponseData()
            {
                rewards = listReward,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                items = dayTranhMua.items
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardMailOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}

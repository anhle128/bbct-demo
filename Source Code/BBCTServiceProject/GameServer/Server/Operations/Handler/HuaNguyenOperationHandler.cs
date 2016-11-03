using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class HuaNguyenOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionCharRequestData requestData = new ActionCharRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            HuaNguyenConfig config = StaticDatabase.entities.configs.huaNguyenConfig;
            if (config == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);

            if (player.cacheData.info.level < config.levelRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            MUserCharacter userChar =
                player.cacheData.listUserChar.FirstOrDefault(a => a._id.ToString().Equals(requestData.char_id));
            if (userChar == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            Character character = StaticDatabase.entities.characters.FirstOrDefault(a => a.id == userChar.static_id);

            MHuaNguyenLog huaNguyen = MongoController.LogSubDB.HuaNguyen.GetData(player.cacheData.info._id,
                CommonFunc.GetHashCodeTime());

            bool isCreate = false;
            if (huaNguyen == null)
            {
                huaNguyen = new MHuaNguyenLog()
                {
                    user_id = player.cacheData.info._id,
                    count_times = 0,
                    hash_code_time = CommonFunc.GetHashCodeTime()
                };
                isCreate = true;
            }

            int numberItemNeed = 0;

            // free time
            if (huaNguyen.count_times > config.freeTimes)
            {
                numberItemNeed = 1;
            }
            huaNguyen.count_times++;

            VipConfig vipConfig = StaticDatabase.entities.configs.vipConfigs[player.cacheData.info.vip];
            if (huaNguyen.count_times > vipConfig.huaNguyenTimes)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxHuaNguyenTimes);

            Item itemHuaNguyen =
                StaticDatabase.entities.items.FirstOrDefault(a => a.type == (short)TypeItem.HuaNguyenPhu);
            if (itemHuaNguyen == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);

            if (numberItemNeed != 0)
            {
                MUserItem userItem = player.cacheData.listUserItem.FirstOrDefault(a => a.static_id == itemHuaNguyen.id);

                if (userItem == null || userItem.quantity < numberItemNeed)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoesNotEnoughItem);

                userItem.quantity -= numberItemNeed;
                MongoController.UserDb.Item.UpdateQuantity(userItem);
            }

            double numberRandom = CommonFunc.RandomNumberDouble(0, 100);
            int idCharSoulReward = userChar.static_id;
            if (numberRandom < config.procGetCharHuaNguyen) // get char hua nguyen
            {
                idCharSoulReward = character.idCharHuaNguyen;
            }

            List<SubRewardItem> listReward = new List<SubRewardItem>(1)
            {
                new SubRewardItem()
                {
                    static_id = idCharSoulReward,
                    type_reward = (int)TypeReward.Character,
                    quantity = config.numberSoulReward
                }
            };

            // create or update log
            if (isCreate)
                MongoController.LogSubDB.HuaNguyen.Create(huaNguyen);
            else
                MongoController.LogSubDB.HuaNguyen.UpdateCountTimes(huaNguyen);

            // update reward
            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.None);

            // response
            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listRewardResult
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}

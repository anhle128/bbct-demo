using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Server.Operations.Handler
{
    public class UpMaxLevelCharOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            ActionCharRequestData requestData = new ActionCharRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            // kiểm tra character
            MUserCharacter character =
                player.cacheData.listUserChar.FirstOrDefault(a => a._id.ToString() == requestData.char_id);

            if (character == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.Error);

            // Kiểm tra level
            if (StaticDatabase.entities.configs.characterLevelExps.All(a => a.level != character.level))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxLevel);

            // Lấy level max của character
            int levelMax = CommonFunc.GetMaxLevelCharacter(player.cacheData.info.level);

            int expNeedUpLevel = StaticDatabase.entities.configs.characterLevelExps.Single(a => a.level == levelMax).exp;
            // Kiểm tra max level
            if (character.level >= levelMax && character.exp >= expNeedUpLevel - 1)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxLevel);

            // Lấy toàn bộ item tăng exp của user
            var listItemExp = StaticDatabase.entities.items.Where(a => a.type == (short)TypeItem.KinhNhiemDan).OrderBy(a => a.type);
            List<MUserItem> listAllUserExpItem = new List<MUserItem>();
            foreach (var item in listItemExp)
            {
                IEnumerable<MUserItem> ieExpIem =
                    player.cacheData.listUserItem.Where(a => a.static_id == item.id && a.quantity > 0);
                if (ieExpIem.Any())
                    listAllUserExpItem.AddRange(ieExpIem.ToList());
            }

            // Kiểm tra số lượng item tăng exp
            if (listAllUserExpItem.Count == 0)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoesNotEnoughItem);

            // Lấy số lượng exp cần thiết để up maxLevel
            double totalExpNeedToMaxLevel = StaticDatabase.entities.configs.characterLevelExps.Where(a => a.level >= character.level && a.level <= levelMax).Sum(a => a.exp);
            totalExpNeedToMaxLevel = totalExpNeedToMaxLevel - character.exp;

            // Dùng item và up exp
            UserItemAndUpExp(character, listAllUserExpItem, levelMax, totalExpNeedToMaxLevel);

            // Update
            UpdateAllUserItem(listAllUserExpItem);
            MongoController.UserDb.Char.Update_Level_Exp(character);

            // Response
            UpMaxLevelCharacterResponseData response = new UpMaxLevelCharacterResponseData()
            {
                char_id = character._id.ToString(),
                level = character.level,
                exp = character.exp,
                user_items =
                (
                    from a in listAllUserExpItem
                    select new UserItem
                    {
                        static_id = a.static_id,
                        quantity = a.quantity
                    }
                ).ToList()
            };


            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "UpMaxLevelCharOperationHandler done!",
                Parameters = response.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }

        private void UserItemAndUpExp(MUserCharacter character, List<MUserItem> listAllUserExpItem, int levelMax, double totalExpNeedToMaxLevel)
        {
            foreach (var userIem in listAllUserExpItem)
            {
                Item item = StaticDatabase.entities.items.FirstOrDefault(a => a.id == userIem.static_id);

                double totalExpInItems = userIem.quantity * item.attribute[0];

                if (totalExpNeedToMaxLevel <= item.attribute[0])
                {
                    totalExpNeedToMaxLevel = 0;
                    userIem.quantity--;
                    CommonFunc.UpLevelCharacter(character, totalExpInItems, levelMax, false);
                    break;
                }

                if (totalExpNeedToMaxLevel >= totalExpInItems)
                {
                    CommonFunc.UpLevelCharacter(character, totalExpInItems, levelMax, false);
                    totalExpNeedToMaxLevel = totalExpNeedToMaxLevel - totalExpInItems;
                    userIem.quantity = 0;
                }
                else
                {
                    int numberItemNeed = (int)(totalExpNeedToMaxLevel / item.attribute[0]);
                    double a = totalExpNeedToMaxLevel % (double)item.attribute[0];
                    if (totalExpNeedToMaxLevel % (double)item.attribute[0] != 0)
                    {
                        numberItemNeed++;
                    }
                    totalExpNeedToMaxLevel = 0;
                    userIem.quantity -= numberItemNeed;
                    CommonFunc.UpLevelCharacter(character, numberItemNeed * item.attribute[0], levelMax, false);
                }

                if (totalExpNeedToMaxLevel == 0)
                    break;
            }
        }

        private void UpdateAllUserItem(List<MUserItem> listAllUserExpItem)
        {
            Parallel.ForEach(listAllUserExpItem, item => MongoController.UserDb.Item.UpdateQuantity(item));
        }
    }
}

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
    public class CanQuetOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            CanQuetRequestData requestData = new CanQuetRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            if (requestData.map_index < 0 || requestData.map_index >= StaticDatabase.entities.maps.Length)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (requestData.stage_index < 0 || requestData.stage_index >= StaticDatabase.entities.maps[requestData.map_index].stages.Length)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            Stage stage = StaticDatabase.entities.maps[requestData.map_index].stages[requestData.stage_index];

            // Kiểm tra xem map này đã 3 sao chưa
            MUserStage userStage = MongoController.UserDb.Stage.GetData(player.cacheData.id, new StageMode()
            {
                level = requestData.level,
                map_index = requestData.map_index,
                stage_index = requestData.stage_index
            });

            if (userStage == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (userStage.stage_info.star < 3)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            if (userStage.stage_info.attack_times + requestData.attack_times > stage.maxAttack)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxAttackTimes);

            if (player.cacheData.stamina < stage.stamina * requestData.attack_times)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoesNotEnoughStamina);


            // Kiểm tra xem có đủ lệnh bài càn quét hay không
            var itemStatic = StaticDatabase.entities.items.FirstOrDefault(x => x.type == (int)TypeItem.LenhBaiCanQuet);
            var item = player.cacheData.listUserItem.FirstOrDefault(a => a.static_id == itemStatic.id);
            if (item == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);
            }
            if (item.quantity < requestData.attack_times)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);
            }

            CommonFunc.CheckStaminaAndCooldownTime(player);

            PlayerCacheData userInfo = player.cacheData;

            item.quantity -= requestData.attack_times;
            userInfo.stamina -= stage.stamina * requestData.attack_times;
            userStage.stage_info.attack_times += requestData.attack_times;

            MongoController.UserDb.Item.UpdateQuantity(item);
            MongoController.UserDb.Info.Update_Stamina_StageAttacked(userInfo);
            MongoController.UserDb.Stage.UpdateStageInfo(userStage);

            int silverReceived = CommonFunc.RandomNumber(stage.silverRewardMin * requestData.attack_times, stage.silverRewardMax * requestData.attack_times);
            int expCharReceived = CommonFunc.RandomNumber(stage.expRewardMin * requestData.attack_times, stage.expRewardMax * requestData.attack_times);

            List<Reward> bunusReward = MongoController.GetBunusItemSkRotDo();
            List<Reward> rewards = new List<Reward>();
            List<SubRewardItem> listReward = new List<SubRewardItem>();

            if (requestData.level == 1)
                rewards.AddRange(stage.rewards);
            else
                rewards.AddRange(stage.rewardsSupper);

            if (bunusReward != null)
                rewards.AddRange(bunusReward);

            for (int i = 0; i < requestData.attack_times; i++)
            {
                listReward.AddRange(CommonFunc.RandomSubRewardItem(rewards.ToArray()));
            }


            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.RewardAttackStage);

            int maxLevelChar = CommonFunc.GetMaxLevelCharacter(player.cacheData.level);
            List<CharBattleResult> listCharResult = CommonFunc.UpCharAfterBattle
            (
                userInfo,
                expCharReceived,
                maxLevelChar
            );
            MongoController.UserDb.Char.UpdateCharBattleResult(listCharResult);

            // update user info
            player.cacheData.silver += silverReceived;

            int oldLevel = player.cacheData.level;
            int expPlayerReceive = StaticDatabase.entities.GetExpReceiveInStage(userStage.stage_info.stage.map_index, userStage.stage_info.stage.stage_index) * requestData.attack_times;
            CommonFunc.UpLevelPlayer(player.cacheData, expPlayerReceive);

            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.id, TypeNhiemVuHangNgay.CanQuet, requestData.attack_times);
            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.id, TypeNhiemVuHangNgay.AttackStage, requestData.attack_times);

            if (oldLevel != player.cacheData.level)
            {
                MongoController.LogDb.UserLevelUp.Create(player.cacheData.id, player.cacheData.level);
                if (player.cacheData.stamina < StaticDatabase.entities.configs.maxStamina)
                {
                    player.cacheData.stamina = StaticDatabase.entities.configs.maxStamina;
                }
            }

            MongoController.UserDb.Info.Update_Silver_Level_EXP_Stamina_HighestStageAttacked(userInfo);

            AttackStageResponseData responseData = new AttackStageResponseData()
            {
                reward_silver = silverReceived,
                rewards = listRewardResult,
                reward_exp_player = expPlayerReceive,
                reward_exp_character = expCharReceived,
                level_player = player.cacheData.level,
                exp_player = player.cacheData.exp,
                chars = listCharResult
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "EndAttackStageOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}

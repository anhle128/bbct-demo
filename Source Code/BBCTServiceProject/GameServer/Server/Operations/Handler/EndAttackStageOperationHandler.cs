using DynamicDBModel.Models;
using GameServer.Battle;
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
using StaticDB.Models;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class EndAttackStageOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {

            if (player.cacheData.stageAttacked == null)
            {
                player.cacheData.stageAttacked = MongoController.UserDb.Stage.GetLastStageAttacked(player.cacheData.info._id);
                if (player.cacheData.stageAttacked == null)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            EndAttackStageRequestData requestData = new EndAttackStageRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            //Kiểm tra user
            PlayerCacheData userInfo = player.cacheData;
            if (userInfo == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AccountDoNotExist);



            // kiểm tra user stage_info
            MUserStage userStage = player.cacheData.stageAttacked;

            // lấy dữ liệu stage_info
            Map map = StaticDatabase.entities.maps[userStage.stage_info.stage.map_index];
            Stage stage = map.stages[userStage.stage_info.stage.stage_index];

            AttackStageResponseData responseData = new AttackStageResponseData();

            if (map.isAuto)
            {
                BattleProcessor processor = new BattleProcessor();
                BattleSimulator.Battle battle = processor.BattleGhk(player.cacheData, stage, userStage.stage_info.stage.level);

                responseData.replay = battle.replay;

                // player thua
                if (battle.result != 2)
                {
                    // response
                    return new OperationResponse()
                    {
                        OperationCode = operationRequest.OperationCode,
                        DebugMessage = "EndAttackStageOperationHandler done!",
                        Parameters = responseData.Serialize(),
                        ReturnCode = (short)ReturnCode.OK
                    };
                }
                requestData.star = battle.star;
            }
            else
            {
                // kiểm tra star
                if (requestData.star <= 0)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            int silverReceived = CommonFunc.RandomNumber(stage.silverRewardMin, stage.silverRewardMax);
            int expCharReceived = CommonFunc.RandomNumber(stage.expRewardMin, stage.expRewardMax);

            //process and update
            //update user stage_info
            if (userStage.stage_info.stage.level == 1 && userStage.stage_info.star == 0)
            {
                userInfo.info.highest_stages_attacked = userStage.stage_info.stage;
            }

            if (userStage.stage_info.star < requestData.star)
            {
                userStage.stage_info.star = requestData.star;
                MongoController.UserDb.Stage.UpdateStageInfo(userStage);
            }

            List<RewardItem> listRewardResult = null;

            Reward[] rewards = null;
            rewards = userStage.stage_info.stage.level == 1 ? stage.rewards : stage.rewardsSupper;

            List<SubRewardItem> listReward = CommonFunc.RandomSubRewardItem(rewards);

            // bonus thêm item sự kiện rớt đồ
            List<Reward> bunusReward = MongoController.GetBunusItemSkRotDo();
            if (bunusReward != null)
            {
                var bonusItem = CommonFunc.RandomSubRewardItem(bunusReward.ToArray());
                listReward.AddRange(bonusItem);
            }

            listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.RewardAttackStage);

            // update level Player
            int oldLevel = player.cacheData.info.level;
            int expPlayerReceive = StaticDatabase.entities.GetExpReceiveInStage(userStage.stage_info.stage.map_index,
                userStage.stage_info.stage.stage_index);
            CommonFunc.UpLevelPlayer(player.cacheData, expPlayerReceive);

            if (oldLevel != player.cacheData.info.level)
            {
                MongoController.LogDb.UserLevelUp.Create(player.cacheData.info._id, player.cacheData.info.level);
                if (player.cacheData.info.stamina < StaticDatabase.entities.configs.maxStamina)
                {
                    player.cacheData.info.stamina = StaticDatabase.entities.configs.maxStamina;
                }
            }

            int maxLevelChar = CommonFunc.GetMaxLevelCharacter(player.cacheData.info.level);
            // update characger result
            List<CharBattleResult> listCharResult = CommonFunc.UpCharAfterBattle
            (
                userInfo,
                expCharReceived,
                maxLevelChar
            );

            // update user info
            player.cacheData.info.silver += silverReceived;

            MongoController.UserDb.Info.Update_Silver_Level_EXP_Stamina_HighestStageAttacked(userInfo);
            MongoController.UserDb.Char.UpdateCharBattleResult(listCharResult);

            // xóa cache data
            player.cacheData.stageAttacked = null;

            // response
            responseData.reward_silver = silverReceived;
            responseData.rewards = listRewardResult;
            responseData.reward_exp_player = expPlayerReceive;
            responseData.reward_exp_character = expCharReceived;
            responseData.level_player = player.cacheData.info.level;
            responseData.exp_player = player.cacheData.info.exp;
            responseData.chars = listCharResult;

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

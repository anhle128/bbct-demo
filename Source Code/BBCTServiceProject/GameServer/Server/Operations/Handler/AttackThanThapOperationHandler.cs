using DynamicDBModel.Models;
using DynamicDBModel.Models.Battle;
using GameServer.Battle;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
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
    public class AttackThanThapOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            StartAttackThanThapRequestData requestData = new StartAttackThanThapRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            ThanThapConfig thanThapConfig = StaticDatabase.entities.configs.thanThapConfig;
            if (player.cacheData.info.level < thanThapConfig.levelRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            MUserThanThap userThanThap = player.cacheData.thanThapAttacked;
            if (userThanThap == null)
                userThanThap =
                MongoController.UserDb.ThanThap.GetData(player.cacheData.info._id, ThanThapInfo.GetHashTimeEnd());
            if (userThanThap == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.ReloadThanThap);
            if (userThanThap.dead)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (requestData.index_difficult > StaticDatabase.entities.configs.thanThapConfig.starRewards.Length - 1)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            int starReceive = StaticDatabase.entities.configs.thanThapConfig.starRewards[requestData.index_difficult];
            userThanThap.new_star = userThanThap.star + starReceive;
            userThanThap.dead = true;


            BattleReplay battleReplay = null;
            BattleProcessor processor = new BattleProcessor();
            BattleSimulator.Battle battle = processor.BattleThanThap
            (
                cacheData: player.cacheData,
                indexMonster: userThanThap.monsters[requestData.index_difficult],
                floor: userThanThap.floor,
                difficult: requestData.index_difficult
            );

            EndAttackThanThapResponseData responseData = new EndAttackThanThapResponseData();
            responseData.replay = battle.replay;

            // player win
            if (battle.result == 2)
            {
                userThanThap.monsters = CommonFunc.GetRandomMoster();
                userThanThap.star = userThanThap.new_star;
                userThanThap.dead = false;
                userThanThap.new_star = 0;

                ThanThapConfig config = StaticDatabase.entities.configs.thanThapConfig;

                // kiểm tra đến tầng bonus attributes
                if (CheckSteepFloor(config.stepFloorGetBonusAttribute,
                    userThanThap.floor))
                {
                    userThanThap.bonus_attributes_selection =
                        CommonFunc.GetBonusAttributeSelectionThanThap();
                }
                // kiểm tra đến tầng bonus item
                List<RewardItem> rewardItems = new List<RewardItem>();
                if (CheckSteepFloor(config.stepFloorGetBonusReward,
                    userThanThap.floor))
                {
                    //int indexReward = CommonFunc.RandomNumber(0, config.floorRewards.Length - 1);
                    SubRewardItem reward = CommonFunc.RandomOneSubRewardItem(config.floorRewards.ToList());
                    List<SubRewardItem> listReceive = new List<SubRewardItem>(1)
                {
                    reward
                };
                    rewardItems = MongoController.UserDb.UpdateReward(player.cacheData, listReceive, ReasonActionGold.RewardAttackStage);
                }
                userThanThap.floor++;

                ThanThapInfo.AddUserToTop(userThanThap);

                responseData.rewards = rewardItems;
                responseData.bonus_attributes_selection = userThanThap.bonus_attributes_selection;
                responseData.monsters = userThanThap.monsters;
            }

            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.info._id, TypeNhiemVuHangNgay.AttackPhuBanThanThap);
            MongoController.UserDb.ThanThap.Update(userThanThap);

            // responseData
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "EndAttackThanThapOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }

        public bool CheckSteepFloor(int step, int currentFloor)
        {
            if ((currentFloor) % step == 0)
                return true;
            return false;
        }
    }
}

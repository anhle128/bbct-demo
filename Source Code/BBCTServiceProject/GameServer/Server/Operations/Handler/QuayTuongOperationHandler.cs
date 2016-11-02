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
using StaticDB.Enum;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Server.Operations.Handler
{
    public class QuayTuongOperationHandler : IOperationHandler
    {
        private int numberMaxChangeProc = 20;

        private QuayTuongRequestData requestData;

        private PlayerCacheData cacheData;

        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            requestData = new QuayTuongRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            cacheData = player.cacheData;

            MUserInfo userInfo =
                MongoController.UserDb.Info.GetData(cacheData.id);

            if (userInfo.gold != player.cacheData.gold)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);

            cacheData.username = userInfo.username;

            MChieuMoConfig chieuMoConfig =
                MongoController.ConfigDb.ChieuMo.GetData();

            MQuayTuongGroup quayTuongConfig = chieuMoConfig.quay_tuong;

            OperationResponse response = null;
            if (requestData.times == 1) // quay 1 lan
            {
                response = QuayTuongx1(operationRequest, requestData, userInfo, quayTuongConfig);
            }
            else
            {
                response = QuayTuongx10(operationRequest, userInfo, quayTuongConfig);
            }

            return response;

        }

        private OperationResponse QuayTuongx1(OperationRequest operationRequest, QuayTuongRequestData requestData, MUserInfo userInfo, MQuayTuongGroup config)
        {
            if (requestData.type == QuayTuongType.Special)
            {
                double timeSpan = CommonFunc.CalculateSecondTimeSpand(config.special_config.wait_time_free,
                userInfo.last_time_free_quay_tuong_special);
                int goldRequire = 0;
                if (timeSpan > 0) // dung ruby
                {
                    if (userInfo.gold < config.special_config.price)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                    goldRequire = config.special_config.price;
                }
                else
                {
                    userInfo.last_time_free_quay_tuong_special = DateTime.Now;
                }
                userInfo.gold -= goldRequire;
                MongoController.UserDb.Info.UpdateGold_FreeTimeQuayTuongSpecial(userInfo, goldRequire);
                return RandomAndResponse(operationRequest, userInfo, config);
            }
            else if (requestData.type == QuayTuongType.Normal)
            {
                double timeSpan = CommonFunc.CalculateSecondTimeSpand(config.normal_config.wait_time_free,
                userInfo.last_time_free_quay_tuong_normal);
                int goldRequipre = 0;
                if (timeSpan > 0 ||
                    userInfo.count_times_free_quay_tuong_normal >= config.normal_config.max_free_in_day) // dung ruby
                {
                    if (userInfo.gold < config.normal_config.price)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                    goldRequipre = config.normal_config.price;
                    userInfo.gold -= goldRequipre;
                }
                else
                {
                    userInfo.last_time_free_quay_tuong_normal = DateTime.Now;
                    userInfo.count_times_free_quay_tuong_normal++;
                }
                MongoController.UserDb.Info.UpdateGold_FreeTimeQuayTuongNormal(userInfo, goldRequipre);
                return RandomAndResponse(operationRequest, userInfo, config);
            }
            else
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }
        }

        private OperationResponse QuayTuongx10(OperationRequest operationRequest, MUserInfo userInfo, MQuayTuongGroup config)
        {
            int price = config.special_config.x10_price;

            if (userInfo.gold < price)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            userInfo.count_time_x10_quoay_tuong_special++;

            userInfo.gold -= price;

            MongoController.UserDb.Info.UpdateGold_CountTimex10QuayTuong(userInfo, userInfo.count_time_x10_quoay_tuong_special, price);
            return Randomx10AndResponse(operationRequest, userInfo, cacheData, config);
        }

        private OperationResponse Randomx10AndResponse(OperationRequest operationRequest, MUserInfo userInfo, PlayerCacheData cacheData, MQuayTuongGroup config)
        {
            List<RewardItem> listReward = new List<RewardItem>();
            int numberCharRandom = 10;
            List<SubRewardItem> listSubReward = new List<SubRewardItem>();
            if (userInfo.count_time_x10_quoay_tuong_special == 1)
            {
                //List<Character> listChar =
                //    StaticDatabase.entities.characters.Where
                //    (
                //        a =>
                //            a.promotion == PromotionCharacter.Orange
                //    ).ToList();

                //numberCharRandom--;

                //List<Reward> listRandomChar =
                //    config.bonus_config.chars.FindAll(
                //        a => a.typeReward == (int)TypeReward.Character && listChar.Any(b => b.id == a.staticID));

                //SubRewardItem rewardBonus = CommonFunc.RandomOneSubRewardItem(listRandomChar);
                //listSubReward.Add(rewardBonus);
            }
            else if (userInfo.count_time_x10_quoay_tuong_special % config.bonus_config.times_quay_tuong_x10_special == 0)
            {
                numberCharRandom--;
                SubRewardItem rewardBonus = CommonFunc.RandomOneSubRewardItem(config.bonus_config.chars);
                listSubReward.Add(rewardBonus);
            }

            for (int i = 0; i < numberCharRandom; i++)
            {
                SubRewardItem reward = RandomCharacter(userInfo, config);
                //CommonLog.Instance.PrintLog(JsonMapper.ToJson(reward));
                listSubReward.Add(reward);
            }

            listReward = MongoController.UserDb.UpdateReward(cacheData, listSubReward, ReasonActionGold.None);
            return ResponseData(operationRequest, userInfo, listReward);
        }

        private void ChangeChieuMoConfigProc(MGroupChar[] arrGroup, int timesQuayTuong)
        {
            MGroupChar groupCharLowestProc = arrGroup.OrderBy(a => a.proc).First();
            groupCharLowestProc.proc = 5 * timesQuayTuong;
            if (groupCharLowestProc.proc == 100)
            {
                Parallel.ForEach(arrGroup, current =>
                {
                    if (current != groupCharLowestProc)
                        current.proc = 0;
                });
            }
        }

        private OperationResponse RandomAndResponse(OperationRequest operationRequest, MUserInfo userInfo, MQuayTuongGroup config)
        {
            SubRewardItem subReward = RandomCharacter(userInfo, config);

            List<RewardItem> listReward =
                MongoController.UserDb.UpdateReward(cacheData,
                new List<SubRewardItem>(1) { subReward }, ReasonActionGold.None);

            return ResponseData(operationRequest, userInfo, listReward);
        }

        private SubRewardItem RandomCharacter(MUserInfo userInfo, MQuayTuongGroup config)
        {
            bool isBonusTime = false;

            // nếu 20 là lần đầu quoay special
            if (requestData.type == QuayTuongType.Special
                && userInfo.count_time_quoay_tuong_special < numberMaxChangeProc)
            {
                userInfo.count_time_quoay_tuong_special++;
                if (userInfo.count_time_quoay_tuong_special == numberMaxChangeProc)
                {
                    ChangeChieuMoConfigProc(config.special_config.group_chars, userInfo.count_time_quoay_tuong_special);
                    isBonusTime = true;
                }
            }
            MGroupChar[] groupChars = null;
            if (requestData.type == QuayTuongType.Special)
            {
                groupChars = config.special_config.group_chars;
            }
            else
            {
                groupChars = config.normal_config.group_chars;
            }
            SubRewardItem idCharReceive = Random(groupChars, userInfo);

            if (isBonusTime)
            {
                config = MongoController.ConfigDb.ChieuMo.GetData().quay_tuong;
            }
            return idCharReceive;
        }

        private OperationResponse ResponseData(OperationRequest operationRequest, MUserInfo userInfo, List<RewardItem> listReward)
        {
            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(userInfo._id, TypeNhiemVuHangNgay.ChieuMo);

            MongoController.LogDb.ChieuMo.CreateLogQuayTuong(userInfo._id, listReward.Count == 1 ? 1 : 10, listReward);

            cacheData.gold = userInfo.gold;

            // response
            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listReward,
                user_gold = cacheData.gold,
                user_silver = cacheData.silver
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "Quay tuong done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }

        private SubRewardItem Random(MGroupChar[] groupCharRandom, MUserInfo userInfo)
        {
            double procRandom = CommonFunc.RandomNumberDouble(0, 100);
            double plushProc = 0;
            foreach (var group in groupCharRandom.OrderBy(a => a.proc))
            {
                plushProc = plushProc + group.proc;
                if (plushProc >= procRandom)
                {
                    return RamdomCharacterInGroup(group, userInfo);
                }
            }
            return null;
        }

        private SubRewardItem RamdomCharacterInGroup(MGroupChar groupChar, MUserInfo userInfo)
        {
            List<Reward> listChar = new List<Reward>();
            for (int i = 0; i <= userInfo.vip; i++)
            {
                if (i > groupChar.chars.Count - 1 || groupChar.chars[i] == null)
                    continue;
                listChar.AddRange(groupChar.chars[i]);
            }

            SubRewardItem reward = CommonFunc.RandomOneSubRewardItem(listChar);
            return reward;
        }
    }
}


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
    public class MoRuongOperationHandler : IOperationHandler
    {
        private int _firstTimesGetDoNguyen = 10;
        private int minTimesGetDoNguyen = 60;
        private int maxTimesGetDoNguyen = 80;

        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            UsedItemRequestData requestData = new UsedItemRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserItem userRuong =
                player.cacheData.listUserItem.FirstOrDefault(a => a._id.ToString() == requestData.item_id);

            if (userRuong == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (userRuong.quantity < requestData.quantity)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoesNotEnoughItem);

            userRuong.quantity -= requestData.quantity;

            MMoRuongLog moRuongLog = MongoController.LogSubDB.MoRuong.GetData(player.cacheData.info._id,
                userRuong.static_id);

            bool isCreate = false;
            if (moRuongLog == null)
            {
                moRuongLog = new MMoRuongLog()
                {
                    user_id = player.cacheData.info._id,
                    static_id = userRuong.static_id,
                    bonus_proc = 0,
                    total_times_opends = 0,
                    max_times_get_do_nguyen = _firstTimesGetDoNguyen
                };
                isCreate = true;
            }

            Item ruong = StaticDatabase.entities.items.Single(a => a.id == userRuong.static_id);

            RuongRewardConfig ruongRewardConfig =
                StaticDatabase.entities.configs.ruongRewardConfigs.FirstOrDefault(a => a.idRuong == ruong.id);
            if (ruongRewardConfig == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoNotHaveConfig);

            List<Reward> listDataRewardRandom = ruongRewardConfig.rewards.ToList();
            RewardResponseData responseData = new RewardResponseData();

            if (ruong.type == (int)TypeItem.RuongItem)
            {
                responseData.rewards = OpendRuongVatPham(player, listDataRewardRandom, requestData.quantity);
            }
            else
            {
                responseData.rewards = OpendRuongTrangBi(player, listDataRewardRandom, moRuongLog, requestData.quantity);
            }


            if (isCreate)
            {
                MongoController.LogSubDB.MoRuong.Create(moRuongLog);
            }
            else
            {
                MongoController.LogSubDB.MoRuong.Update(moRuongLog);
            }

            MongoController.UserDb.Item.Update(userRuong);

            responseData.user_gold = player.cacheData.gold;
            responseData.user_silver = player.cacheData.silver;
            responseData.user_level = player.cacheData.level;
            responseData.user_exp = player.cacheData.exp;
            responseData.user_ruby = player.cacheData.ruby;

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "MoRuongOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }

        private List<RewardItem> OpendRuongVatPham(GamePlayer player, List<Reward> listDataRewardRandom, int quantity)
        {
            List<SubRewardItem> listReward = new List<SubRewardItem>();
            for (int i = 0; i < quantity; i++)
            {
                listReward.Add(CommonFunc.RandomOneSubRewardItem(listDataRewardRandom));
            }
            //CommonLog.Instance.PrintLog("mo ruong listReward.CoundLogInDay: " + listReward.CoundLogInDay);
            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, listReward,
                ReasonActionGold.RewardMoRuong);
            return listRewardResult;
        }

        private List<RewardItem> OpendRuongTrangBi(GamePlayer player, List<Reward> listDataRewardRandom, MMoRuongLog moRuongLog, int quantity)
        {
            List<SubRewardItem> listReward = new List<SubRewardItem>();

            for (int i = 0; i < quantity; i++)
            {

                SubRewardItem reward = null;
                if (moRuongLog.bonus_proc == 0)
                {
                    reward = CommonFunc.RandomOneSubRewardItem(listDataRewardRandom);
                    listReward.Add(reward);

                    if (CheckVatPhamNguyen(reward))
                    {
                        // reset nếu nhận được 1 đồ nguyên
                        ResetLog(moRuongLog);
                    }
                    else
                    {
                        moRuongLog.bonus_proc += GetStepBonusProc(moRuongLog.max_times_get_do_nguyen);
                    }
                }
                else
                {
                    // random co ra do nguyen hay khong
                    double ramdom = CommonFunc.RandomNumberDouble(0, 100);
                    if (ramdom < moRuongLog.bonus_proc || moRuongLog.bonus_proc > 100) // ra 1 do nguyen
                    {
                        List<Reward> listRewardDoNguyen =
                            listDataRewardRandom.Where(a => a.typeReward == (int)TypeReward.Equipment).ToList();
                        if (listRewardDoNguyen.Count == 0)
                        {
                            reward = CommonFunc.RandomOneSubRewardItem(listDataRewardRandom);
                        }
                        else
                        {
                            reward = CommonFunc.RandomOneSubRewardItem(listRewardDoNguyen);
                        }

                        listReward.Add(reward);

                        ResetLog(moRuongLog);
                    }
                    else // random binh thuong
                    {
                        reward = CommonFunc.RandomOneSubRewardItem(listDataRewardRandom);
                        listReward.Add(reward);

                        if (CheckVatPhamNguyen(reward))
                        {
                            // reset nếu nhận được 1 đồ nguyên
                            ResetLog(moRuongLog);
                        }
                        else
                        {
                            moRuongLog.bonus_proc += GetStepBonusProc(moRuongLog.max_times_get_do_nguyen);
                        }
                    }
                }
            }
            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.RewardMoRuong);
            return listRewardResult;
        }

        private void ResetLog(MMoRuongLog moRuongLog)
        {
            moRuongLog.bonus_proc = 0;
            moRuongLog.max_times_get_do_nguyen = CommonFunc.RandomNumber(minTimesGetDoNguyen,
                maxTimesGetDoNguyen);
        }

        private double GetStepBonusProc(int maxTime)
        {
            return (100f / maxTime);
        }

        private bool CheckVatPhamNguyen(SubRewardItem reward)
        {
            return reward.type_reward == (int)TypeReward.Equipment;
        }
    }
}

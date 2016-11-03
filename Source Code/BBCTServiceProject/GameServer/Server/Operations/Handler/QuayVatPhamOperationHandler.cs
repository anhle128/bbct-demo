
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
using System;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class QuayVatPhamOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            QuayVatPhamRequestData requestData = new QuayVatPhamRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserInfo userInfo =
                MongoController.UserDb.Info.GetData(player.cacheData.info._id);

            if (userInfo.gold != player.cacheData.info.gold)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DBError);

            MQuayVatPhamGroup config = MongoController.ConfigDb.ChieuMo.GetData().quay_vat_pham;

            if (requestData.times == 1)
            {
                return QuayVatPhamx1(player, operationRequest, userInfo, config);
            }
            else
            {
                return QuayVatPhamx10(player, operationRequest, userInfo, config);
            }
        }

        private OperationResponse QuayVatPhamx10(GamePlayer player, OperationRequest operationRequest, MUserInfo userInfo,
            MQuayVatPhamGroup config)
        {
            if (userInfo.gold < config.normal_config.x10_price)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            int numberItemRandom = 10;
            userInfo.count_time_x10_quoay_vat_pham++;
            List<SubRewardItem> listItemRandom = new List<SubRewardItem>();
            listItemRandom = new List<SubRewardItem>()
            {
                CommonFunc.RandomOneSubRewardItem(config.special_vat_pham)
            };
            numberItemRandom = 9;
            listItemRandom.AddRange(RandomManyItemRewrd(numberItemRandom, config.normal_config.vat_phams));

            player.cacheData.info.gold -= config.normal_config.x10_price;
            MongoController.UserDb.Info.UpdateGold_CountTimex10VatPham(player.cacheData, userInfo.count_time_x10_quoay_vat_pham, config.normal_config.x10_price);

            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData, listItemRandom, ReasonActionGold.None);

            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(userInfo._id, TypeNhiemVuHangNgay.ChieuMo);

            MongoController.LogDb.ChieuMo.CreateLogQuayVatPham(userInfo._id, 10, listReward);
            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listReward,
                user_gold = player.cacheData.info.gold,
                user_silver = player.cacheData.info.silver,
                user_level = player.cacheData.info.level,
                user_exp = player.cacheData.info.exp,
                user_ruby = player.cacheData.info.ruby
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "QuayVatPhamOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }

        private OperationResponse QuayVatPhamx1(GamePlayer player, OperationRequest operationRequest, MUserInfo userInfo,
            MQuayVatPhamGroup config)
        {
            double timeSpan = CommonFunc.GetRestTimeSecond(userInfo.last_time_free_quay_vat_pham,
                config.normal_config.wait_time_free * 60);
            if (timeSpan > 0) // dung ruby
            {
                if (userInfo.gold < config.normal_config.price)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                player.cacheData.info.gold -= config.normal_config.price;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.QuayVatPhamx1, config.normal_config.price);
            }
            else
            {
                MongoController.UserDb.Info.UpdateLastTimeFreeQuayVatPham(player.cacheData, DateTime.Now);
            }

            List<SubRewardItem> rewards = new List<SubRewardItem>()
            {
                CommonFunc.RandomOneSubRewardItem(config.normal_config.vat_phams)
            };

            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData, rewards, ReasonActionGold.None);

            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(userInfo._id, TypeNhiemVuHangNgay.ChieuMo);

            MongoController.LogDb.ChieuMo.CreateLogQuayVatPham(userInfo._id, 1, listReward);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listReward,
                user_gold = player.cacheData.info.gold,
                user_silver = player.cacheData.info.silver,
                user_level = player.cacheData.info.level,
                user_exp = player.cacheData.info.exp
            };
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "QuayVatPhamOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }



        private List<SubRewardItem> RandomManyItemRewrd(int number, MVatPham[] rewards)
        {
            List<SubRewardItem> listResult = new List<SubRewardItem>();
            for (int i = 0; i < number; i++)
            {
                listResult.Add(CommonFunc.RandomOneSubRewardItem(rewards));
            }
            return listResult;
        }
    }
}

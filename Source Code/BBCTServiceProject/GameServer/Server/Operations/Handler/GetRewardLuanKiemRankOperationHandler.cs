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
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardLuanKiemRankOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            RewardRankLuanKiemRequestData requestData = new RewardRankLuanKiemRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserInfo userInfo =
                MongoController.UserDb.Info.GetData(player.cacheData.info._id);

            player.cacheData.info.rank_luan_kiem = userInfo.rank_luan_kiem;

            if (userInfo.index_rank_luan_kiem_rewarded == null)
                userInfo.index_rank_luan_kiem_rewarded = new List<int>();

            if (userInfo.index_rank_luan_kiem_rewarded.Any(a => a == requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDoneBefore);

            LuanKiemConfig config = StaticDatabase.entities.configs.luanKiemConfig;
            RankLuanKiemReward rankReward = config.rankRewards[requestData.index];
            if (userInfo.rank_luan_kiem > rankReward.rangeRank.start && userInfo.rank_luan_kiem > rankReward.rangeRank.end)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            List<SubRewardItem> listSubReward = CommonFunc.ConvertToSubReward(rankReward.rewards);
            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData, listSubReward, ReasonActionGold.RewardLuanKiemRank);

            userInfo.index_rank_luan_kiem_rewarded.Add(requestData.index);
            MongoController.UserDb.Info.UpdateRankLuanKieSubRewardItemed(player.cacheData.info._id, userInfo.index_rank_luan_kiem_rewarded);

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
                DebugMessage = "OperationResponse done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

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
    public class GetRewardNhiemVuChinhTuyenOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            GetRewardNhiemVuChinhTuyenRequestData requestData = new GetRewardNhiemVuChinhTuyenRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            //CommonLog.Instance.PrintLog("requestData.id: " + requestData.id);

            MUserNhiemVuChinhTuyen userNhiemVu =
                MongoController.UserDb.NhiemVuChinhTuyen.GetData(player.cacheData.info._id);

            NhiemVuChinhTuyenData nhiemVudata = userNhiemVu.datas.FirstOrDefault(a => a.id == requestData.id);
            if (nhiemVudata == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            }
            bool checkDone = MongoController.UserDb.CheckDoneNhiemVu(player.cacheData, nhiemVudata);
            //CommonLog.Instance.PrintLog("checkDone: " + checkDone);
            if (!checkDone)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            Reward[] rewards = StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig.GetRewards(nhiemVudata.id,
                nhiemVudata.level);

            nhiemVudata.level++;

            MongoController.UserDb.NhiemVuChinhTuyen.Update(userNhiemVu);
            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData, CommonFunc.ConvertToSubReward(rewards), ReasonActionGold.RewardNhiemVuChinhTuyen);

            RewardResponseData responseData = new RewardResponseData();
            responseData.rewards = listReward;
            responseData.user_gold = player.cacheData.gold;
            responseData.user_silver = player.cacheData.silver;
            responseData.user_level = player.cacheData.level;
            responseData.user_exp = player.cacheData.exp;
            responseData.user_ruby = player.cacheData.ruby;

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardNhiemVuChinhTuyenOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

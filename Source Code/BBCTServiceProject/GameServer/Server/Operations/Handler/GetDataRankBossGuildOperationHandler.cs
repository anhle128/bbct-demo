using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataRankBossGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var bossLogs = MongoController.LogSubDB.BossGuildLog.GetDatas(member.guild_id);

            GetDataRankBossGuildResponseData responseData = new GetDataRankBossGuildResponseData();
            responseData.ranks = new List<TopUserPrivateBoss>();

            int count = 0;

            for (int i = 0; i < bossLogs.Count(); i++)
            {
                var userInfo = MongoController.UserDb.Info.GetData(bossLogs[i].user_id);

                TopUserPrivateBoss rank = new TopUserPrivateBoss()
                {
                    userid = bossLogs[i].user_id.ToString(),
                    nickname = userInfo.nickname,
                    totalDamage = bossLogs[i].dmg,
                };
                responseData.ranks.Add(rank);

                count++;

                if (count == 10)
                {
                    break;
                }
            }

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

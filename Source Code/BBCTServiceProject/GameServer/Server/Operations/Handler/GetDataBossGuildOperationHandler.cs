using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataBossGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var bossLogs = MongoController.LogSubDB.BossGuildLog.GetDatas(member.guild_id);

            double totalDmg = bossLogs.Sum(x => x.dmg);
            var bossLogMember = bossLogs.FirstOrDefault(x => x.user_id.Equals(player.cacheData.id));

            double dmg = 0;
            int attackTimes = 0;
            if (bossLogMember != null)
            {
                dmg = bossLogMember.dmg;
                attackTimes = bossLogMember.attack_times;
            }

            GetDataBossGuildResponseData responseData = new GetDataBossGuildResponseData()
            {
                countAttackTimes = attackTimes,
                dmg = dmg,
                totalDmg = totalDmg,
            };

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

using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class EndAttackBossGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            EndAttackBossGuildRequestData requestData = new EndAttackBossGuildRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (requestData.dmg < 0)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var bossLog = MongoController.LogSubDB.BossGuildLog.GetData(member.guild_id, player.cacheData.username);

            if (bossLog != null)
            {
                MongoController.LogSubDB.BossGuildLog.UpdateDamageAndAttackTime(bossLog._id, bossLog.dmg + requestData.dmg, bossLog.attack_times);
            }
            else
            {
                MBossGuildLog log = new MBossGuildLog()
                {
                    user_id = player.cacheData.id,
                    guild_id = member.guild_id,
                    dmg = requestData.dmg,
                    attack_times = 1,
                    hash_code_time = CommonFunc.GetHashCodeTime(),
                };

                MongoController.LogSubDB.BossGuildLog.Create(log);
            }

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class StartAttackBossGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var bossLog = MongoController.LogSubDB.BossGuildLog.GetData(member.guild_id, player.cacheData.info._id);


            if (bossLog != null)
            {
                if (bossLog.attack_times >= StaticDatabase.entities.configs.guildConfig.maxTimeAttackBossGuild)
                {
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxAttackTimes);
                }
                MongoController.LogSubDB.BossGuildLog.UpdateDamageAndAttackTime(bossLog._id, bossLog.dmg, bossLog.attack_times + 1);
            }
            else
            {
                MBossGuildLog log = new MBossGuildLog()
                {
                    user_id = player.cacheData.info._id,
                    guild_id = member.guild_id,
                    dmg = 0,
                    attack_times = 1,
                    hash_code_time = CommonFunc.GetHashCodeTime(),
                };

                MongoController.LogSubDB.BossGuildLog.Create(log);
            }

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

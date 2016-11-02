using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class DisbandGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var guild = MongoController.GuildDb.Guild.GetDataByUserId(player.cacheData.info._id);

            if (guild == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotHavePermission);
            }

            int countMember = MongoController.GuildDb.GuildMember.CountMemberInGuild(guild._id);

            if (countMember > 1)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.ExistMember);
            }

            MongoController.GuildDb.GuildMember.DeleteAll(x => x.guild_id.Equals(guild._id));
            MongoController.GuildDb.RequestJoin.DeleteAll(x => x.guild_id.Equals(guild._id));
            MongoController.GuildDb.Guild.Delete(guild._id);

            MGuildLockLog lockLog = new MGuildLockLog()
            {
                user_id = player.cacheData.info._id,
            };

            MongoController.GuildDb.LockLog.Create(lockLog);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

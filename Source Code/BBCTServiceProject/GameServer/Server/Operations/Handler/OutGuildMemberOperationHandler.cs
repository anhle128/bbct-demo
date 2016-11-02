using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class OutGuildMemberOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var guild = MongoController.GuildDb.Guild.GetDataByUserId(member.guild_id);

            if (member.user_id.Equals(guild.user_id))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var bangChienDuring = MongoController.GuildDb.BangChien.GetData(BangChien.State.DangDienRa);

            if (bangChienDuring != null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            MUserMail mail = new MUserMail()
            {
                title = "Rời bang",
                content = player.cacheData.nickname + " đã rời khỏi bang " + guild.name + " đi phiêu bạt giang hồ",
                readed = false,
                user_id = guild.user_id,
                type = MongoDBModel.Enum.UserMailType.Normal,
            };

            MongoController.UserDb.Mail.Create(mail);

            MGuildLockLog lockLog = new MGuildLockLog()
            {
                user_id = member.user_id
            };

            MongoController.GuildDb.LockLog.Create(lockLog);

            MongoController.GuildDb.GuildMember.Delete(member._id);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

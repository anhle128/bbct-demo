using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class SackGuildMemberOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionPlayerRequestData requestData = new ActionPlayerRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData.userid))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            if (requestData.userid.Equals(player.cacheData.info._id))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var guild = MongoController.GuildDb.Guild.GetDataByUserId(player.cacheData.info._id);

            if (guild == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotHavePermission);
            }

            var member = MongoController.GuildDb.GuildMember.GetMemberInGuild((requestData.userid), guild._id);



            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var bangChienDuring = MongoController.GuildDb.BangChien.GetData(BangChien.State.DangDienRa);

            if (bangChienDuring != null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            MUserMail mail = new MUserMail()
            {
                title = "Sa thải",
                content = "Bạn đã bị bang chủ đuổi khỏi bang " + guild.name,
                readed = false,
                user_id = member.user_id,
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

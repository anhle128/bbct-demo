using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class AcceptRequestJoinGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionPlayerRequestData requestData = new ActionPlayerRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData.userid))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            var lockLog = MongoController.GuildDb.LockLog.GetData((requestData.userid));


            if (lockLog != null)
            {
                if ((DateTime.Now - lockLog.created_at).TotalHours < StaticDatabase.entities.configs.guildConfig.hourLockMember)
                {
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MemberLockGuild);
                }
                else
                {
                    MongoController.GuildDb.LockLog.Delete(lockLog._id);
                }
            }

            bool checkIsMemberInGuild = MongoController.GuildDb.GuildMember.CheckMemberInGuild((requestData.userid));

            if (checkIsMemberInGuild)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsMemberInGuild);

            var guild = MongoController.GuildDb.Guild.GetDataByUserId(player.cacheData.id);

            if (guild == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotHavePermission);

            int maxMember = guild.level + StaticDatabase.entities.configs.guildConfig.defaultAmountMember;

            int countMemberInGuild = MongoController.GuildDb.GuildMember.CountMemberInGuild(guild._id);
            if (countMemberInGuild >= maxMember)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxMember);

            var requestJoin = MongoController.GuildDb.RequestJoin.GetData(guild._id, (requestData.userid));

            if (requestJoin == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MGuildMember newMem = new MGuildMember()
            {
                contribution = StaticDatabase.entities.configs.guildConfig.defaultContributionMember,
                guild_id = guild._id,
                user_id = (requestData.userid)
            };

            player.cacheData.guildId = guild._id.ToString();

            MongoController.GuildDb.GuildMember.Create(newMem);
            MongoController.GuildDb.RequestJoin.DeleteAll
            (
                a =>
                    a.server_id.Equals(Settings.Instance.server_id) &&
                    a.user_id.Equals((requestData.userid))
            );

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

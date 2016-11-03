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
    public class JoinGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            JoinGuildRequestData requestData = new JoinGuildRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData.guild_id))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            if (player.cacheData.info.level < StaticDatabase.entities.configs.guildConfig.levelRequireCreateGuild)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);
            }

            var lockLog = MongoController.GuildDb.LockLog.GetData(player.cacheData.info._id);

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

            bool checkMemberInGuild = MongoController.GuildDb.GuildMember.CheckMemberInGuild(player.cacheData.info._id);

            if (checkMemberInGuild)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsMemberInGuild);
            }

            //Fix cứng sau Update phien bản mới sẽ dùng config
            int maxRequestJoinGuil = 20;
            int countRequest = MongoController.GuildDb.RequestJoin.CountRequestInGuild((requestData.guild_id));
            if (countRequest >= maxRequestJoinGuil)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsMaxRequestJoin);

            bool checkExistRequest =
                MongoController.GuildDb.RequestJoin.CheckExistRequest((requestData.guild_id),
                    player.cacheData.info._id);

            if (checkExistRequest)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.RequestedJoinThisGuild);

            MGuildRequestJoin mRqJoin = new MGuildRequestJoin()
            {
                guild_id = (requestData.guild_id),
                user_id = player.cacheData.info._id,
            };

            MongoController.GuildDb.RequestJoin.Create(mRqJoin);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

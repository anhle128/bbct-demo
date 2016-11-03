using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDB.Bson;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class CreateGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            CreateGuildRequestData requestData = new CreateGuildRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData.nameGuild))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            if (player.cacheData.info.level < StaticDatabase.entities.configs.guildConfig.levelRequireCreateGuild)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);
            }

            if (player.cacheData.info.gold < StaticDatabase.entities.configs.guildConfig.priceCreateGuild)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);
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

            bool checkIsMemberInGuild = MongoController.GuildDb.GuildMember.CheckMemberInGuild(player.cacheData.info._id);

            if (checkIsMemberInGuild)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsMemberInGuild);
            }

            bool checkExistGuildName = MongoController.GuildDb.Guild.CheckExistGuildName(requestData.nameGuild);

            if (checkExistGuildName)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NameGuildExist);
            }

            player.cacheData.info.gold -= StaticDatabase.entities.configs.guildConfig.priceCreateGuild;
            MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.CreateGuild, StaticDatabase.entities.configs.guildConfig.priceCreateGuild);

            MGuild newGuild = CreateNewGuild(requestData.nameGuild, player.cacheData.info._id);

            MongoController.GuildDb.Guild.Create(newGuild);

            MGuildMember firstMember = new MGuildMember()
            {
                guild_id = newGuild._id,
                contribution = StaticDatabase.entities.configs.guildConfig.defaultContributionMember,
                user_id = player.cacheData.info._id,
            };

            MongoController.GuildDb.GuildMember.Create(firstMember);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }

        private MGuild CreateNewGuild(string nameGuild, string userid)
        {
            MGuild newGuild = new MGuild()
            {
                name = nameGuild,
                level = 1,
                notice = StaticDatabase.entities.configs.guildConfig.defaultNotice,
                contribution = StaticDatabase.entities.configs.guildConfig.defaultContribution,
                user_id = userid,
                tmp_contribution = 0,
            };
            return newGuild;
        }
    }
}

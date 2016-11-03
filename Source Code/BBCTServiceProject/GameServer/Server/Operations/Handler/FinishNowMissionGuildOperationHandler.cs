using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class FinishNowMissionGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            MissionGuildRequestData requestData = new MissionGuildRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (requestData.indexMission < 0 && requestData.indexMission > StaticDatabase.entities.configs.guildConfig.missions.Length - 1)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var guild = MongoController.GuildDb.Guild.GetDataByUserId(member.guild_id);

            if (guild == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            TimeSpan timeSpan = new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.missions[requestData.indexMission].durationMinutes, 0);

            var missionLog = MongoController.LogSubDB.MissionGuildLog.GetAvailableMission(member.guild_id, player.cacheData.info._id, requestData.indexMission);


            if (missionLog == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            if (player.cacheData.info.gold < StaticDatabase.entities.configs.guildConfig.goldToFinishNowMission)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);
            }
            player.cacheData.info.gold -= StaticDatabase.entities.configs.guildConfig.goldToFinishNowMission;

            MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.QuickFinishMissionGuild, StaticDatabase.entities.configs.guildConfig.goldToFinishNowMission);

            MongoController.LogSubDB.MissionGuildLog.UpdateState(missionLog._id, true);

            guild.contribution = guild.contribution + StaticDatabase.entities.configs.guildConfig.missions[requestData.indexMission].contribute;
            guild.tmp_contribution = guild.tmp_contribution + StaticDatabase.entities.configs.guildConfig.missions[requestData.indexMission].contribute;
            bool isUpLevel = MongoController.GuildDb.Guild.CheckUpLevelGuild(guild);

            member.contribution += StaticDatabase.entities.configs.guildConfig.missions[requestData.indexMission].contributeMember;
            MongoController.GuildDb.GuildMember.Update(member);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

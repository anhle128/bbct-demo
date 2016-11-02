using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class FinishMissionGuildOperationHandler : IOperationHandler
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

            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var guild = MongoController.GuildDb.Guild.GetDataByUserId(member.guild_id);

            if (guild == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var missionLog = MongoController.LogSubDB.MissionGuildLog.GetAvailableMission(member.guild_id, player.cacheData.id, requestData.indexMission);

            if (missionLog == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

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

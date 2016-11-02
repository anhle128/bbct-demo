using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class StartMissionGuildOperationHandler : IOperationHandler
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

            int countMissionLog = MongoController.LogSubDB.MissionGuildLog.Count(member.guild_id, player.cacheData.id,
                requestData.indexMission);


            if (countMissionLog > 0)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            MMissionGuildLog missionLog = new MMissionGuildLog()
            {
                guild_id = member.guild_id,
                index_mission = requestData.indexMission,
                is_finish = false,
                user_id = player.cacheData.id,
                hash_code_time = CommonFunc.GetHashCodeTime(),
            };
            MongoController.LogSubDB.MissionGuildLog.Create(missionLog);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

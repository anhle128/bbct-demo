using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataMissionGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var missionLogs = MongoController.LogSubDB.MissionGuildLog.GetDatas(member.guild_id, player.cacheData.info._id);

            GetDataMissionGuildResponseData responseData = new GetDataMissionGuildResponseData();
            responseData.missions = new int[StaticDatabase.entities.configs.guildConfig.missions.Length];

            for (int i = 0; i < StaticDatabase.entities.configs.guildConfig.missions.Length; i++)
            {
                var fMissions = missionLogs.Where(x => x.index_mission == i);
                if (!fMissions.Any())
                {
                    responseData.missions[i] = -1;
                }
                else
                {
                    var mission = fMissions.FirstOrDefault();
                    if (mission.is_finish)
                    {
                        responseData.missions[i] = -2;
                    }
                    else
                    {
                        TimeSpan timeSpan = new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.missions[i].durationMinutes, 0);
                        if (DateTime.Now >= mission.created_at + timeSpan)
                        {
                            responseData.missions[i] = -3;
                        }
                        else
                        {
                            responseData.missions[i] = StaticDatabase.entities.configs.guildConfig.missions[i].durationMinutes * 60 - (int)(DateTime.Now - mission.created_at).TotalSeconds;
                        }
                    }

                }
            }

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };


        }
    }
}

using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataLuaTraiOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            int countLuaTraiLog = MongoController.LogSubDB.LuaTraiLog.CoundLogInDay(member.guild_id);


            int state = 1;
            double time = 0;

            if (countLuaTraiLog <= 0)
            {
                state = 1;
            }
            else
            {
                TimeSpan timeSpan = new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.durationLuaTraiMinutes, 0);
                var luaTraiLog2 = MongoController.LogSubDB.LuaTraiLog.GetData(member.guild_id, timeSpan);


                if (luaTraiLog2 != null)
                {
                    int countRewardLog = MongoController.LogSubDB.LuaTraiRewardLog.Count(member.guild_id, member.user_id);

                    if (countRewardLog > 0)
                    {
                        state = 4;
                    }
                    else
                    {
                        state = 2;
                    }

                    time = (luaTraiLog2.created_at + timeSpan - DateTime.Now).TotalSeconds;
                }
                else
                {
                    state = 3;
                }
            }

            GetDataLuaTraiResponseData responseData = new GetDataLuaTraiResponseData()
            {
                state = state,
                time = time,
            };

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

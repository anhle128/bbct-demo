using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class FindGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            FindWithKeyWorkRequestData requestData = new FindWithKeyWorkRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData.keyword))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }
            var guilds = MongoController.GuildDb.Guild.FindGuilds(requestData.keyword);

            FindGuildResponseData responseData = new FindGuildResponseData()
            {
                guilds = new List<Guild>(),
            };
            foreach (var guild in guilds)
            {
                MUserInfo masterGuild = MongoController.UserDb.Info.GetData(guild.user_id);

                int amountMember = MongoController.GuildDb.GuildMember.CountMemberInGuild(guild._id);
                Guild g = new Guild()
                {
                    _id = guild._id.ToString(),
                    contribution = guild.contribution,
                    level = guild.level,
                    name = guild.name,
                    nicknameMaster = masterGuild.nickname,
                    amountMember = amountMember,
                };
                responseData.guilds.Add(g);
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

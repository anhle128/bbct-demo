using DynamicDBModel.Models;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetTopLevelGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var guilds = MongoController.GuildDb.Guild.GetTopLevelGuils();

            FindGuildResponseData responseData = new FindGuildResponseData()
            {
                guilds = new List<Guild>(),
            };

            for (int i = 0; i < 10; i++)
            {
                if (i < guilds.Count)
                {
                    MUserInfo masterGuild = MongoController.UserDb.Info.GetData(guilds[i].user_id);
                    int amountMember = MongoController.GuildDb.GuildMember.CountMemberInGuild(guilds[i]._id);
                    Guild g = new Guild();
                    g._id = guilds[i]._id.ToString();
                    g.contribution = guilds[i].contribution;
                    g.level = guilds[i].level;
                    g.name = guilds[i].name;
                    g.nicknameMaster = masterGuild.nickname;
                    g.amountMember = amountMember;
                    g.tmpContribute = guilds[i].tmp_contribution;
                    responseData.guilds.Add(g);
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

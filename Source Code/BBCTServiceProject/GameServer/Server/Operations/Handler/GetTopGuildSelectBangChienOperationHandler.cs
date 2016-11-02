using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using GameServer.Common.SerializeData.ResponseData;
using System.Collections.Generic;
using DynamicDBModel.Models;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetTopGuildSelectBangChienOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            List<MGuild> guilds = MongoController.GuildDb.Guild.GetTopContributionGuils();
                
            FindGuildResponseData responseData = new FindGuildResponseData()
            {
                guilds = new List<Guild>(),
            };

            for (int i = 0; i < 8; i++)
            {
                if(i < guilds.Count)
                {
                    MUserInfo masterGuild = MongoController.UserDb.Info.GetData(guilds[i].user_id);
                    int amountMember = MongoController.GuildDb.GuildMember.CountMemberInGuild(guilds[i]._id);
                    Guild g = new Guild()
                    {
                        _id = guilds[i]._id.ToString(),
                        contribution = guilds[i].contribution,
                        level = guilds[i].level,
                        name = guilds[i].name,
                        nicknameMaster = masterGuild.nickname,
                        amountMember = amountMember,
                        tmpContribute = guilds[i].tmp_contribution,
                    };
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

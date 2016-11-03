using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.MainDatabaseModels;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetGuildMemberOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var guildMem = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);
            if (guildMem == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            var guild = MongoController.GuildDb.Guild.GetDataByUserId(guildMem.guild_id);

            if (guild == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var members = MongoController.GuildDb.GuildMember.GetDatas(guildMem.guild_id);

            GetGuildMemberResponseData responseData = new GetGuildMemberResponseData()
            {
                members = new List<GuildMember>(),
            };

            foreach (var item in members)
            {
                MUserInfo userInfo = MongoController.UserDb.Info.GetData(item.user_id);
                MLoginLog logLogin = MongoController.LogDb.LoginLog.GetLastLogin(item.user_id);

                try
                {
                    GuildMember mem = new GuildMember();
                    mem.username = userInfo.username;
                    mem.nickname = userInfo.nickname;
                    mem.level = userInfo.level;
                    mem.avatar = userInfo.avatar;
                    mem.vip = userInfo.vip;
                    mem.isMaster = (userInfo._id.Equals(guild.user_id)) ? true : false;
                    mem.contribution = item.contribution;
                    mem.lastUpdate = logLogin != null ? logLogin.login_time : userInfo.updated_at;
                    responseData.members.Add(mem);
                }
                catch (Exception ex)
                {
                    CommonLog.Instance.PrintLog("------------------------------------");
                    CommonLog.Instance.PrintLog("GetGuildMemberOperationHandler error");
                    CommonLog.Instance.PrintLog("userid: " + userInfo.username);
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

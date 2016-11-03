using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardLuaTraiOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);

            if (member == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
            }

            TimeSpan timeSpan = new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.durationLuaTraiMinutes, 0);

            int countLuaTraiLog = MongoController.LogSubDB.LuaTraiLog.CoundLogInTimeSpan(member.guild_id, timeSpan);

            if (countLuaTraiLog <= 0)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            int countRewardLog = MongoController.LogSubDB.LuaTraiRewardLog.Count(member.guild_id, member.user_id);

            if (countRewardLog > 0)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxLuaTraiTimes);
            }

            List<RewardItem> listRewardResult = null;
            List<SubRewardItem> listReward = CommonFunc.RandomSubRewardItem(StaticDatabase.entities.configs.guildConfig.rewardsLuaTrai);
            listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, listReward,
            ReasonActionGold.RewardLuaTrai);

            MLuaTraiRewardLog log = new MLuaTraiRewardLog()
            {
                guild_id = member.guild_id,
                user_id = player.cacheData.info._id,
                hash_code_time = CommonFunc.GetHashCodeTime(),
            };
            MongoController.LogSubDB.LuaTraiRewardLog.Create(log);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listRewardResult,
                user_gold = player.cacheData.info.gold,
                user_silver = player.cacheData.info.silver,
                user_level = player.cacheData.info.level,
                user_exp = player.cacheData.info.exp,
                user_ruby = player.cacheData.info.ruby
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

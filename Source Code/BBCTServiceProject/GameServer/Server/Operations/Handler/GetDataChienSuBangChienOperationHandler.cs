using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataChienSuBangChienOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            BattleBangChienRequestData requestData = new BattleBangChienRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData._id))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var battle = MongoController.GuildDb.BattleBangChien.GetData(requestData._id);
                //.GetSingleData(x => x._id.Equals((requestData._id)));

            if (battle == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            if (battle.result != (int)BattleBangChien.Result.DangDienRa)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.StateInvalid);
            }

            if (!player.cacheData.guildId.Equals(battle.guild_a.ToString()) && !player.cacheData.guildId.Equals(battle.guild_b.ToString()))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotHavePermission);
            }

            var guildAInfo = MongoController.GuildDb.Guild.GetDataByUserId(battle.guild_a);
            var guildBInfo = MongoController.GuildDb.Guild.GetDataByUserId(battle.guild_b);

            DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                StaticDatabase.entities.configs.guildConfig.hourStartBangChien.hour,
                StaticDatabase.entities.configs.guildConfig.hourStartBangChien.minute, 0);
            CommonLog.Instance.PrintLog("end time: " + endTime);
            if (battle.round == 1)
            {
                endTime += new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.minuteDurationBattleBangChien, 0);
            }
            if (battle.round == 2)
            {
                endTime += new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.minuteDurationBattleBangChien * 2 + StaticDatabase.entities.configs.guildConfig.waitTimeBangChien, 0);
            }
            if (battle.round == 3)
            {
                endTime += new TimeSpan(0, StaticDatabase.entities.configs.guildConfig.minuteDurationBattleBangChien * 3 + StaticDatabase.entities.configs.guildConfig.waitTimeBangChien * 2, 0);
            }

            GetDataChienSuBangChienResponseData responseData = new GetDataChienSuBangChienResponseData()
            {
                battle = new BattleBangChien()
                {
                    _id = battle._id.ToString(),
                    guildA = guildAInfo._id.ToString(),
                    guildB = guildBInfo._id.ToString(),
                    result = battle.result,
                    round = battle.round,
                    dmgBotA = battle.dmg_bot_a,
                    dmgTopA = battle.dmg_top_a,
                    dmgMidA = battle.dmg_mid_a,
                    dmgBotB = battle.dmg_bot_b,
                    dmgMidB = battle.dmg_mid_b,
                    dmgTopB = battle.dmg_top_b,
                },
                guildA = new Guild()
                {
                    _id = guildAInfo._id.ToString(),
                    contribution = guildAInfo.contribution,
                    level = guildAInfo.level,
                    name = guildAInfo.name,
                },
                guildB = new Guild()
                {
                    _id = guildBInfo._id.ToString(),
                    contribution = guildBInfo.contribution,
                    level = guildBInfo.level,
                    name = guildBInfo.name,
                },
                timeEnd = (endTime - DateTime.Now).TotalSeconds,
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

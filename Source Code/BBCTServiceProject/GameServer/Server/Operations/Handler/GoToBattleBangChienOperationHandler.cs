using BattleSimulator;
using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Battle;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using MongoDB.Bson;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GoToBattleBangChienOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            GoToBattleBangChienRequestData requestData = new GoToBattleBangChienRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData._id))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            if (requestData.lane < 1 && requestData.lane > 3)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var battle = MongoController.GuildDb.BattleBangChien.GetData(requestData._id);
               

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

            string guildEnemy = battle.guild_b;
            if (player.cacheData.guildId.Equals(battle.guild_b.ToString()))
            {
                guildEnemy = battle.guild_a;
            }

            var members = MongoController.GuildDb.GuildMember.GetDatas(guildEnemy);

            string userIdEnemy = members[CommonFunc.RandomNumber(0, members.Count)].user_id;

            BattleProcessor processor = new BattleProcessor();
            BattleSimulator.Battle battleSim = processor.BattlePvp(player.cacheData, userIdEnemy);
            GoToBattleBangChienResponseData responseData = new GoToBattleBangChienResponseData()
            {
                replay = battleSim.replay,
            };

            double totalDmg = 0f;
            foreach (var ch in battleSim.charactersA)
            {
                totalDmg += ch.totalDmg;
            }

            if (player.cacheData.guildId.Equals(battle.guild_a.ToString()))
            {
                MongoController.GuildDb.BattleBangChien.UpdateDamage(battle, requestData.lane, "a", totalDmg);
            }
            else
            {
                MongoController.GuildDb.BattleBangChien.UpdateDamage(battle, requestData.lane, "b", totalDmg);
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

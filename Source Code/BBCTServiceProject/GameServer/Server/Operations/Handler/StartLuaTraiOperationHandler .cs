using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class StartLuaTraiOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var guild = MongoController.GuildDb.Guild.GetDataByUserId(player.cacheData.info._id);

            if (guild == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotHavePermission);
            }

            int countLuaTraiLog = MongoController.LogSubDB.LuaTraiLog.CoundLogInDay(guild._id);

            if (countLuaTraiLog > 0)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxLuaTraiTimes);
            }

            MLuaTraiLog luaTraiLog = new MLuaTraiLog()
            {
                guild_id = guild._id,
                hash_code_time = CommonFunc.GetHashCodeTime(),
            };
            MongoController.LogSubDB.LuaTraiLog.Create(luaTraiLog);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

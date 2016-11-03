using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRequestJoinGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var guild = MongoController.GuildDb.Guild.GetDataByUserId(player.cacheData.info._id);

            if (guild == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotHavePermission);

            GetRequestJoinGuildResponseData responseData = new GetRequestJoinGuildResponseData()
            {
                requests = new List<RequestJoinGuild>(),
            };

            //Phai Lay trong config
            var requestList = MongoController.GuildDb.RequestJoin.GetDatas(guild._id);

            if (requestList != null && requestList.Count > 0)
            {
                var listUserId = requestList.Select(a => a._id).ToList();
                var uInfos = MongoController.UserDb.Info.GetDatasByUserID(listUserId);

                if (uInfos != null && uInfos.Count > 0)
                {
                    foreach (var item in requestList)
                    {
                        MUserInfo userInfo = uInfos.FirstOrDefault(a => a._id.Equals(item.user_id));
                        RequestJoinGuild rq = new RequestJoinGuild()
                        {
                            userid = userInfo.username,
                            nickname = userInfo.nickname,
                            level = userInfo.level,
                            avatar = userInfo.avatar,
                            vip = userInfo.vip
                        };
                        responseData.requests.Add(rq);
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

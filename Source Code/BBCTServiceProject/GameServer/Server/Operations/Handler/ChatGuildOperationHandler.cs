using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class ChatGuildOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            ChatServerRequestData requestData = new ChatServerRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            Dictionary<byte, object> subParam = new Dictionary<byte, object>();
            subParam.Add(1, requestData.message);

            if (player.peer != null)
            {
                if (player.cacheData.guildId == null)
                {
                    var member = MongoController.GuildDb.GuildMember.GetData(player.cacheData.info._id);

                    if (member == null)
                    {
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
                    }
                    else
                    {
                        var guild = MongoController.GuildDb.Guild.GetDataByUserId(member.guild_id);

                        if (guild != null)
                        {
                            player.cacheData.guildId = guild._id.ToString();
                            player.cacheData.guildName = guild.name;
                        }
                        else
                        {
                            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.IsNotMemberInGuild);
                        }
                    }
                }

                GameController.Instance.FireEvent(player.peer, new SendParameters(),
                    (byte)EventCode.ChatGuild, new Dictionary<byte, object>(), subParam);
            }
            return null;
        }
    }
}

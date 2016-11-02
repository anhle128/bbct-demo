using System;
using System.Linq;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.MMO.Concepts.Messages;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Server.Operations.Handler
{
    public class ChangeAvatarOperationHandler : IOperationHandler
    {
        public Photon.SocketServer.OperationResponse Handler(GamePlayer player,
            Photon.SocketServer.OperationRequest operationRequest, Photon.SocketServer.SendParameters sendParameters,
            OperationController controller)
        {
            ActionCharRequestData requestData = new ActionCharRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserCharacter userChar =
                player.cacheData.listUserChar.FirstOrDefault(a => a._id.ToString() == requestData.char_id);
                    
            if (userChar == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            PlayerCacheData info = player.cacheData;
            info.avatar = userChar.static_id;
            info.avatar_star = userChar.star_level;

            MongoController.UserDb.Info.UpdateAvatar(info);

            try
            {
                ChangeAvatarRegionMessage msg = new ChangeAvatarRegionMessage(player.cacheData.avatar);
                msg.SetSource(player.item);
                if (player.item.currentRegion != null)
                    player.item.currentRegion.Publish(msg);
            }
            catch (Exception ex)
            {
                CommonLog.Instance.PrintLog(ex.ToString());
            }
           

            // response
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}

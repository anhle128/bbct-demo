
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.EventData;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;

namespace GameServer.Server.Operations.Handler
{
    public class MoiRuouOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            ActionPlayerRequestData requestData = new ActionPlayerRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            GamePlayer otherPlayer;
            GameController.Instance.userOnline.TryGetItem(requestData.userid, out otherPlayer);
            if (otherPlayer == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            PlayerCacheData userInfo = player.cacheData;

            MUserInfo otherUserInfo =
                MongoController.UserDb.Info.GetData((requestData.userid));

            if (otherUserInfo == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            VipConfig vipConfig = StaticDatabase.entities.configs.vipConfigs[userInfo.info.vip];
            int countMoiRuouInDay =
                MongoController.LogSubDB.MoiRuou.Count(userInfo.info._id);

            if (countMoiRuouInDay >= vipConfig.moiRuouTimes)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxMoiRuouTmies);


            string otherUserId = requestData.userid;

            MMoiRuouLog log =
                MongoController.LogSubDB.MoiRuou.GetData(userInfo.info._id, otherUserId);

            if (log == null)
            {
                log = new MMoiRuouLog()
                {
                    user_id = userInfo.info._id,
                    other_user_id = otherUserId,
                    hash_code_time = CommonFunc.GetHashCodeTime()
                };
                MongoController.LogSubDB.MoiRuou.Create(log);
            }
            else
            {
                if (log.hash_code_time == CommonFunc.GetHashCodeTime())
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

                log.hash_code_time = CommonFunc.GetHashCodeTime();
                MongoController.LogSubDB.MoiRuou.UpdateHashCodeTime(log);
            }

            int staminaReceive = StaticDatabase.entities.configs.moiRuouConfig.stamina;

            // process
            userInfo.info.stamina += staminaReceive;
            otherUserInfo.stamina += staminaReceive;

            // update
            MongoController.UserDb.Info.UpdatePlusStamina(userInfo);
            MongoController.UserDb.Info.UpdatePlusStamina(otherUserInfo);

            MoiRuouEventData eventData = new MoiRuouEventData()
            {
                nickname = player.cacheData.info.nickname,
                stamina = staminaReceive
            };

            otherPlayer.peer.SendEvent((byte)EventCode.MoiRuou, eventData.Serialize());
            otherPlayer.peer.Player.cacheData.info.stamina = otherUserInfo.stamina;
            otherPlayer.peer.Player.cacheData.info.last_time_update_stamina = otherUserInfo.last_time_update_stamina;

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}

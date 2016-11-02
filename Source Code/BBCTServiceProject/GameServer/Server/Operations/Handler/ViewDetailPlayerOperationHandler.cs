using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class ViewDetailPlayerOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionPlayerRequestData requestData = new ActionPlayerRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            string requestUserId = (requestData.userid);

            MUserInfo userInfo = MongoController.UserDb.Info.GetData(requestUserId);
            if (userInfo == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // process
            // lấy nhân vật
            List<MUserCharacter> listChar =
                MongoController.UserDb.Char.GetDatas(requestUserId);


            // lấy trang bị
            List<MUserEquip> listEquip =
                MongoController.UserDb.Equip.GetDatas(requestUserId);

            // response
            ViewDetailPlayerResponseData responseData = new ViewDetailPlayerResponseData()
            {
                formations = userInfo.formations,
                chars = CommonFunc.GetUserChars(listChar),
                equips = CommonFunc.GetUserEquips(listEquip),
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "ViewDetailPlayerOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}

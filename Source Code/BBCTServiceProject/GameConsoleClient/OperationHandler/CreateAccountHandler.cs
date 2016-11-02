using ExitGames.Client.Photon;
using GameConsoleClient.Components;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using System;
using System.Collections.Generic;

namespace GameConsoleClient.OperationHandler
{
    public class CreateAccountHandler : AbsOperationHandler
    {
        public CreateAccountHandler(Player player, OperationCode code)
            : base(player, code)
        {
        }

        public override void OnResponse(OperationResponse operationResponse)
        {
            Console.WriteLine("operationResponse.ReturnCode: " + ((ReturnCode)operationResponse.ReturnCode).ToString());

            if (operationResponse.ReturnCode == (byte)ReturnCode.OK)
            {
                SignInResponseData responseData = new SignInResponseData();
                responseData.Deserialize(operationResponse.Parameters);
                Player.DynamicData = responseData.entities;

                Player.DoOperationRequest(OperationCode.EnterWorld, null);
            }
        }

        public override void OnRequest(Dictionary<byte, object> dataRequest)
        {
            CreateAccountRequestData requestData = new CreateAccountRequestData()
            {
                nickname = Player.GetUsername(),
                char_id = CommonFunc.RandomNumber(1, 50)
            };
            Player.Peer.OpCustom((byte)Code, requestData.Serialize(), true);
        }
    }
}

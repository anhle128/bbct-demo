using ExitGames.Client.Photon;
using GameConsoleClient.Components;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using System;
using System.Collections.Generic;

namespace GameConsoleClient.OperationHandler
{
    public class SignInHandler : AbsOperationHandler
    {
        public SignInHandler(Player player, OperationCode code)
            : base(player, code)
        {
        }

        public override void OnRequest(Dictionary<byte, object> dataRequest)
        {

            Player.state = Player.State.Loging;

            SignInRequestData signinRequest = new SignInRequestData()
            {
                token = Player.Account.Token
            };


            Player.Peer.OpCustom((byte)Code, signinRequest.Serialize(), true);
        }

        public override void OnResponse(OperationResponse operationResponse)
        {
            ReturnCode returnCode = (ReturnCode)operationResponse.ReturnCode;
            Console.WriteLine("SignInPhotonHandler " + returnCode.ToString());

            if (returnCode == ReturnCode.OK)
            {
                Player.state = Player.State.Logined;
                SignInResponseData data = new SignInResponseData();
                data.Deserialize(operationResponse.Parameters);
                Player.DynamicData = data.entities;
                Console.WriteLine("signin done !");
                if ((ReturnCode)operationResponse.ReturnCode == ReturnCode.OK)
                {
                    Player.DoOperationRequest(OperationCode.EnterWorld, null);
                }
            }
            else if (returnCode == ReturnCode.FirstSignin)
            {
                Player.DoOperationRequest(OperationCode.CreateAccount, null);
            }
        }
    }
}

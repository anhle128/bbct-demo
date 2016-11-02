using ExitGames.Client.Photon;
using GameConsoleClient.Components;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using System.Collections.Generic;

namespace GameConsoleClient.OperationHandler
{
    public class MoveHandler : AbsOperationHandler
    {
        public MoveHandler(Player player, OperationCode code)
            : base(player, code)
        {
        }

        public override void OnResponse(OperationResponse operationResponse)
        {
            base.OnResponse(operationResponse);
            if (operationResponse.ReturnCode == (short)ReturnCode.OK)
            {

            }
        }

        public override void OnRequest(Dictionary<byte, object> dataRequest)
        {
            int randomStepX = CommonFunc.RandomNumber(100, 600);
            int randomStepY = CommonFunc.RandomNumber(10, 50);
            MoveToRequestData data = new MoveToRequestData()
            {
                x = (float)RandomPosition(Player.X, -1200, 1200, randomStepX),
                y = (float)RandomPosition(Player.Y, -250, -25, randomStepY)
            };
            Player.X = (int)data.x;
            Player.Y = (int)data.y;
            Player.Peer.OpCustom((byte)Code, data.Serialize(), true);

        }

        private double RandomPosition(double currentPosition, double min, double max, double randomStep)
        {
            double randomUpDown = CommonFunc.RandomNumber(1, 100);
            if (randomUpDown >= 50) // up
            {
                if (currentPosition + randomStep > max)
                {
                    currentPosition -= randomStep;

                }
                else
                {
                    currentPosition += randomStep;
                }
            }
            else // down
            {
                if (currentPosition - randomStep < min)
                {
                    currentPosition += randomStep;
                }
                else
                {
                    currentPosition -= randomStep;
                }
            }
            if (currentPosition > max)
            {
                currentPosition = max;
            }
            else if (currentPosition < min)
            {
                currentPosition = min;
            }
            return currentPosition;
        }
    }
}


using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetTopDoiDoOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

                if (!SuKienDoiDoInfo.Duration)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

                if (SuKienDoiDoInfo.TopUser.Length > 0)
                {
                    TopUserDoiDoResponseData responseData = new TopUserDoiDoResponseData()
                    {
                        top_users = SuKienDoiDoInfo.TopUser
                    };

                    //CommonLog.Instance.PrintLog(LitJson.JsonMapper.ToJson(responseData));

                    return new OperationResponse()
                    {
                        OperationCode = operationRequest.OperationCode,
                        DebugMessage = "GetTopDoiDoOperationHandler Done!",
                        Parameters = responseData.Serialize(),
                        ReturnCode = (short)ReturnCode.OK
                    };
                }
                else
                {

                    TopUserDoiDoResponseData responseData = new TopUserDoiDoResponseData()
                    {
                        top_users = new TopUserDoiDo[3]
                    };

                    return new OperationResponse()
                    {
                        OperationCode = operationRequest.OperationCode,
                        DebugMessage = "GetTopDoiDoOperationHandler Done!",
                        Parameters = responseData.Serialize(),
                        ReturnCode = (short)ReturnCode.OK
                    };
                }

        }
    }
}

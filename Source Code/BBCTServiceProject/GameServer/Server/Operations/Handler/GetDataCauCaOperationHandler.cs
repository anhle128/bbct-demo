using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataCauCaOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            bool isDoing = false;
            int indexCanCau = 0;
            int time = 0;

            var uCauCas = MongoController.UserDb.CauCa.GetCurrentCauCa(player.cacheData.info._id);
            if (uCauCas != null )
            {
                isDoing = true;
                indexCanCau = uCauCas.indexCanCau;
                time = StaticDatabase.entities.configs.cauCaConfig.canCauConfigs[uCauCas.indexCanCau].duration - (int)(DateTime.Now - uCauCas.created_at).TotalSeconds;
                if (time < 0)
                {
                    time = 0;
                }
            }

            int countTimes = MongoController.UserDb.CauCa.Count(player.cacheData.info._id);
          


            DataCauCaResponseData responseData = new DataCauCaResponseData()
            {
                countTimes = countTimes,
                isDoing = isDoing,
                indexCanCau = indexCanCau,
                time = time,
            };
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

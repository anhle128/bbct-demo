
using ExitGames.Client.Photon;
using System.Collections.Generic;

namespace GameConsoleClient.Cores
{
    public interface IOperationHandleable
    {
        void OnRequest(Dictionary<byte, object> dataRequest);

        void OnResponse(OperationResponse operationResponse);
    }
}

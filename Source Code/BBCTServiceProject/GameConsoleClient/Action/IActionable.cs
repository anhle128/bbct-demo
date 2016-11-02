using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleClient.Action
{
   public  interface IActionable
    {
        void Prepare();
        void DoAction();
        void OnResponse(OperationResponse operationResponse);
    }
}

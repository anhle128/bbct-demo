using BattleSimulator;
using GameServer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Battle
{
    public class BattleLogger : IDebugLogger
    {
        public void Print(string message)
        {
            CommonLog.Instance.PrintLog(message);
        }
    }
}

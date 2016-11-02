using GameServer.ServerTimer.Core;
using System;

namespace GameServer.ServerTimer.Handler
{
    public class StartBangChienHandler : AbsTimeCounterHandler
    {
        public StartBangChienHandler(DateTime endTime)
            : base(endTime)
        {
        }
    }
}

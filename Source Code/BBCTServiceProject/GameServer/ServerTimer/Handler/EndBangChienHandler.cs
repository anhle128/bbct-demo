using GameServer.ServerTimer.Core;
using System;

namespace GameServer.ServerTimer.Handler
{
    public class EndBangChienHandler : AbsTimeCounterHandler
    {
        public EndBangChienHandler(DateTime endTime)
            : base(endTime)
        {
        }
    }
}

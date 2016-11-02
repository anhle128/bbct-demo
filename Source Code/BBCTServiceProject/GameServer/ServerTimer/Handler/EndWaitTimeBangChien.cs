
using GameServer.ServerTimer.Core;
using System;

namespace GameServer.ServerTimer.Handler
{
    public class EndWaitTimeBangChien : AbsTimeCounterHandler
    {
        public EndWaitTimeBangChien(DateTime endTime)
            : base(endTime)
        {
        }
    }
}

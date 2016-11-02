using GameServer.Common;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Core
{
    public class AbsTimeCounterHandler : IElapsedHandler
    {
        private DateTime endTime;
        private Timer myTimer;
        public AbsTimeCounterHandler(DateTime endTime)
        {
            this.endTime = endTime;
        }

        public void Start()
        {
            myTimer = new Timer();
            myTimer.Elapsed += Handler;
            myTimer.AutoReset = false;
            myTimer.Interval = CommonFunc.GetInterval(endTime);
            myTimer.Start();
        }

        public void Start(ElapsedEventHandler EndTimeEventListener)
        {
            myTimer = new Timer();
            myTimer.Elapsed += EndTimeEventListener;
            myTimer.AutoReset = false;
            myTimer.Interval = CommonFunc.GetInterval(endTime);
            myTimer.Start();
        }

        public void Restart(DateTime endTime)
        {
            this.endTime = endTime;
            Start();
        }

        public virtual void Handler(object sender, System.Timers.ElapsedEventArgs e)
        {

        }
    }
}

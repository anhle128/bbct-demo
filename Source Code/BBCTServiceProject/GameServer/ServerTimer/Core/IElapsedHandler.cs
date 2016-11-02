using System;
using System.Timers;

namespace GameServer.ServerTimer.Core
{
    public interface IElapsedHandler
    {
        void Start();
        void Restart(DateTime endTime);
        void Handler(object sender, ElapsedEventArgs e);

    }
}

using ExitGames.Logging;

namespace GameServer.Common
{
    public class CommonLog
    {
        private readonly ILogger _log = LogManager.GetCurrentClassLogger();

        private static readonly CommonLog _instance = new CommonLog();
        public static CommonLog Instance
        {
            get
            {
                return _instance;
            }
        }

        public void PrintLog(string msg)
        {
            _log.Debug(msg);
        }
    }
}

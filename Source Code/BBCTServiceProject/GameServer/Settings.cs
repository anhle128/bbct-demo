using GameServer.Common;
using LitJson;
using MongoDBModel.MainDatabaseModels;
using System.IO;

namespace GameServer
{
    public class Settings
    {
        #region Fields
        public int MaxLockWaitTimeMilliseconds { get; set; }
        public string WorldName { get; set; }
        public int InterestDistance { get; set; }
        public int maxSubscription { get; set; }
        public int maxConnection { get; set; }
        public int avatar { get; set; }
        public string urlDataVersion { get; set; }
        public string server_id { get; set; }

        private string objServerId;
        public string group_id { get; set; }
        public MMongoConnection mainDatabase { get; set; }
        public int maxLengthCacheChat { get; set; }
        public bool isMainServer { get; set; }

        public string LiveAPIKey { get; set; }
        public string game_verion { get; set; }
        #endregion

        #region Singleton
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                    LoadSetting();
                return _instance;

            }
            set { _instance = value; }
        }

        private static Settings _instance;
        #endregion

        public static void LoadSetting()
        {
            string dirSettings = Directory.GetCurrentDirectory() + "\\Settings.json";
            //string dirSettings = Path.Combine(MMOApplication.CurrentBinaryPath, "Settings.json");
            CommonLog.Instance.PrintLog("path: " + dirSettings);
            string text = File.ReadAllText(dirSettings);
            //Console.WriteLine(text);
            _instance = JsonMapper.ToObject<Settings>(text);
            CommonLog.Instance.PrintLog(("server_id: " + _instance.server_id));
        }

        public void ChangeServerId(string newServerId)
        {
            _instance.server_id = newServerId.ToString();
            _instance.objServerId = newServerId;
        }

    }
}

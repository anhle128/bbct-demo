using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MTopGlobalBossLog : IServerTimeDataModel
    {
        public List<TopUserPrivateBoss> top_users;
        public TopUserPrivateBoss user_kill_boss;
    }
}

using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MLuanKiemLog : IServerDataModel
    {
        public int hash_code_time;
        public UserLuanKiem user;
        public UserLuanKiem user_opponent;
        public OutcomeResult outcome;
        public byte[] battle_replay;
    }
}

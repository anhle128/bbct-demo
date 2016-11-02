using MongoDB.Bson;
using MongoDBModel.Implement;
using System;
using DynamicDBModel.Models;

namespace MongoDBModel.SubDatabaseModels
{
    public class MBangChien : IServerDataModel
    {
        public DateTime start_time;
        public BangChien.State state;
        public string[] guilds;
    }
}

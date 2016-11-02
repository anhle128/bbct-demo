

using MongoDBModel.MainDatabaseModels;
using KDQHNPHTool.Model;
using System.Collections.Generic;
namespace KDQHNPHTool.Database.Model
{
    public class DatabaseManager
    {
        public MMongoConnection main_database;
        public List<ServerInMain> sub_database;
    }
}

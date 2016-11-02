using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBModel.MainDatabaseModels
{
    public class MUserLevelUpLog : IUserDataModel
    {
        public int level;
    }
}

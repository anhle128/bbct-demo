using MongoDB.Bson;
using MongoDBModel.Implement;
using System;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserPhucLoiThang : IUserDataModel
    {
        public DateTime day_start;
        public DateTime day_end;
        public string server_id;
    }
}

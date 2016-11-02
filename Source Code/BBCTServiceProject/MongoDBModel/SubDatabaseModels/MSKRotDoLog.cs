
using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKRotDoLog : IUserTimeDataModel
    {
        public string su_kien_id { get; set; }
        public List<IndexReceived> index_receiveds { get; set; }
    }
}

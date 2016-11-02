using MongoDB.Bson;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSK7NgayNhanThuongLog : IUserDataModel
    {
        public string su_kien_id;
        public List<int> day_received;
    }
}

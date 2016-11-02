
using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSkTranhMuaServerLog : IUserDataModel
    {
        public string su_kien_id { get; set; }
        public int day { get; set; }
        public List<IndexReceived> index_recieveds { get; set; }
    }
}

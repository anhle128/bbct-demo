using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKTichLuyNapLog : IUserTimeDataModel
    {
        public string su_kien_id { get; set; }
        public List<int> index_received { get; set; }
    }
}

using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKTichLuyTieuLog : IUserDataModel
    {
        public string su_kien_id;
        public List<int> index_received;
    }
}

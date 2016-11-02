
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MPhucLoiTruongThanhLog : IUserDataModel
    {
        public Status status { get; set; }
        public List<int> index_received { get; set; }
    }
}

using MongoDB.Bson;
using MongoDBModel.Enum;
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MTransaction : IUserDataModel
    {
        public double trans_id { get; set; }
        public string time { get; set; }
        public TransactionType type { get; set; }
        public double money { get; set; }
        public double ruby { get; set; }
        public string sign { get; set; }
        public TransactionStatus status { get; set; }
        public double account_id { get; set; }
        public string partnerinfo { get; set; }
        public string server_id { get; set; }
    }
}

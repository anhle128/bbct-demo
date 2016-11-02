
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MSystemMail : IMongoModel
    {
        public string title { get; set; }
        public string content { get; set; }
    }
}

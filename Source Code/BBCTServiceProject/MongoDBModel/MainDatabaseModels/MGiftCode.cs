using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MGiftCode : IMongoModel
    {
        public string category { get; set; }
        public string code { get; set; }
        public string username { get; set; }
    }
}

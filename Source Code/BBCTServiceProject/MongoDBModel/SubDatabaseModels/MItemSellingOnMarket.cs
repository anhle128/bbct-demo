using MongoDB.Bson;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MItemSellingOnMarket : IUserDataModel
    {
        public string id_equipment;
        public int price;
        public string keyword_search;
        public string server_id;
    }
}

using MongoDB.Bson;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserThanThap : IUserDataModel
    {
        public string server_id { get; set; }
        public string nickname { get; set; }
        public int hash_code_time { get; set; }
        public int new_star { get; set; }
        public int star { get; set; }
        public int floor { get; set; }
        public int reset_times { get; set; }
        public bool dead { get; set; }
        public int[] bonus_attributes { get; set; }
        public int[] bonus_attributes_selection { get; set; }
        public int[] monsters { get; set; }
        public int avatar { get; set; }
    }
}

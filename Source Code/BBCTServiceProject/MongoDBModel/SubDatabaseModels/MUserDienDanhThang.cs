using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserDienDanhThang : IUserDataModel
    {
        public int month { get; set; }
        public int year { get; set; }
        public List<int> index_day_rewards { get; set; }
    }
}

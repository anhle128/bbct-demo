
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserStarReward : IUserDataModel
    {
        public int map_index;
        public int level;
        public List<int> index_reveived;
    }
}

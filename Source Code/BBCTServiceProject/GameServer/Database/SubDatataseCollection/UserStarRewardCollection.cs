
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserStarRewardCollection : AbsCollectionController<MUserStarReward>
    {
        public UserStarRewardCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        public MUserStarReward GetData(string userid, int mapIndex, int level)
        {
            return
                GetSingleData(
                    a => a.user_id == userid && a.map_index == mapIndex && a.level == level);
        }

        public List<MUserStarReward> GetDatas(string userid)
        {
            return GetListData(a => a.user_id == userid);
        }

        public void UpdateReveived(MUserStarReward data)
        {
            Dictionary<string, List<int>> dictData = new Dictionary<string, List<int>>()
            {
                {"index_reveived",data.index_reveived}
            };
            UpdateFields(data._id, dictData);
        }
    }
}

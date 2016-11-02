using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserFriendCollection : AbsCollectionController<MUserFriend>
    {
        public UserFriendCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }
        public int Count(string userid)
        {
            return CountData(a => a.user_id.Equals(userid));
        }

        public void UpdateHashCodeStaminaTime(MUserFriend userFriend)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"hash_code_time",userFriend.hash_code_time}
            };
            UpdateFields(userFriend._id, dictData);
        }

        public List<MUserFriend> GetDatas(string userid)
        {
            return GetListData(a => a.user_id == userid);
        }

        public MUserFriend GetData(string userid, string useridFriend)
        {
            return GetSingleData(a => a.user_id.Equals(userid) && a.user_id_friend.Equals(useridFriend));
        }


        public bool CheckExistFriend(string userid, string otherUserId)
        {
            return
                 CountData(
                     a => a.user_id.Equals(userid) && a.user_id_friend.Equals(otherUserId)) > 0;
        }
    }
}

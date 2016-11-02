
using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserCuuCuuTriTonCollection : AbsCollectionController<MUserCuuCuuTriTon>
    {
        public UserCuuCuuTriTonCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        //protected override void SetDefaultValue(MUserCuuCuuTriTon data)
        //{
        //    data.ser = Settings.Instance.server_id;
        //}

        public MUserCuuCuuTriTon GetData(string userid)
        {
            return GetSingleData(a => a.user_id.Equals(userid));
        }


        public bool CheckRewardInDay(string userid)
        {
            double number = CountData
            (
                a =>
                    a.user_id.Equals(userid) &&
                    a.hash_code_time == CommonFunc.GetHashCodeTime()
            );
            return number != 0;
        }

        public bool CheckExist(string userid)
        {
            return CountData(a => a.user_id.Equals(userid)) != 0;
        }
    }
}

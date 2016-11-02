using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserPhucLoiThangCollection : AbsCollectionController<MUserPhucLoiThang>
    {
        public UserPhucLoiThangCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }


        protected override void SetDefaultValue(MUserPhucLoiThang data)
        {
            data.server_id = Settings.Instance.server_id;
        }

        public MUserPhucLoiThang GetData(string userid)
        {
            return
                GetListDataDescending
                (
                    a => a.user_id.Equals(userid),
                    a => a.day_end,
                    0,
                    5
                ).FirstOrDefault();
        }

        public string[] GetUserActivate()
        {
            return
                GetListData
                (
                    a =>
                        a.server_id == Settings.Instance.server_id &&
                        a.day_start <= DateTime.Now &&
                        a.day_end >= DateTime.Now
                ).Select
                (
                    a => a._id
                ).ToArray();
        }
    }
}

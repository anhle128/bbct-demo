using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserDiemDanhThangCollection : AbsCollectionController<MUserDienDanhThang>
    {
        public UserDiemDanhThangCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public MUserDienDanhThang GetData(string userid, int month)
        {
            return GetSingleData(a =>
                a.user_id.Equals(userid) &&
                a.month == month &&
                a.year == DateTime.Now.Year);
        }
    }
}

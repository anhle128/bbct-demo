using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;
using System;

namespace GameServer.Database.MainDatabaseCollection
{
    public class UsedSilverLogCollection : AbsCollectionController<MUsedSilverLog>
    {
        public UsedSilverLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public void Create(string userId, int silver, TypeUseSilver type)
        {
            if (silver == 0)
                return;
            MUsedSilverLog log = new MUsedSilverLog()
            {
                user_id = userId,
                silver = silver,
                type = type,
            };
            Create(log);
        }

        public double GetTotalUsedSilver(string useridId, DateTime start, DateTime end)
        {
            return
                GetSumData
                (
                    a =>
                        a.user_id.Equals(useridId) &&
                        a.created_at >= start &&
                        a.created_at <= end, a => a.silver
                );
        }
    }
}

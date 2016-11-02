using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;
using System;

namespace GameServer.Database.MainDatabaseCollection
{
    public class UsedGoldLogCollection : AbsCollectionController<MUsedGoldLog>
    {
        public UsedGoldLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        //public void Create(string userid, int gold, TypeUseGold type)
        //{
        //    if (gold == 0)
        //        return;
        //    MUsedGoldLog log = new MUsedGoldLog()
        //    {
        //        userid = userid,
        //        gold = gold,
        //        type = type,
        //    };
        //    Create(log);
        //}

        //public double GetTotalUsedGold(string userid, DateTime start, DateTime end)
        //{
        //    return
        //        GetSumData
        //        (
        //            a =>
        //                a.userid == userid &&
        //                a.server_id == Settings.Instance.server_id &&
        //                a.created_at >= start &&
        //                a.created_at <= end, a => a.gold
        //        );
        //}
    }
}

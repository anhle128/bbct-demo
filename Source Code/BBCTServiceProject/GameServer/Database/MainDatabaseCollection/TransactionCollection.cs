
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;

namespace GameServer.Database.MainDatabaseCollection
{
    public class TransactionCollection : AbsCollectionController<MTransaction>
    {
        public TransactionCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection, new Dictionary<string, object>()
            {
                {"status",1}
            });
        }

        public double GetTotalRuby(string userid)
        {
            return GetSumData(a => a.user_id.Equals(userid), a => a.ruby);
        }

        public double GetTotalRuby(string userId, DateTime start, DateTime end)
        {
            return GetSumData
            (
                a =>
                   a.user_id.Equals(userId) &&
                    a.created_at >= start &&
                    a.created_at <= end,
                a => a.ruby
            );
        }

        public int CountTotalTrans(string userId)
        {
            return CountData(a => a.user_id.Equals(userId));
        }

        public List<MTransaction> GetCheckTrans(string userId)
        {
            return
                GetListData
                (
                    a =>
                        a.user_id.Equals(userId) &&
                        a.status == TransactionStatus.Check
                );
        }



        public void UpdateDoneTrans(List<MTransaction> trans)
        {
            string[] filters = new string[trans.Count];
            Dictionary<string, object>[] listUpdates = new Dictionary<string, object>[trans.Count];

            for (int i = 0; i < trans.Count; i++)
            {

                var data = trans[i];
                data.status = TransactionStatus.Done;
                Dictionary<string, object> dictUpdate = new Dictionary<string, object>()
                {
                    { "status", data.status}
                };

                filters[i] = data._id;
                listUpdates[i] = dictUpdate;
            }
            UpdateManyFields(filters, listUpdates);
        }
    }
}

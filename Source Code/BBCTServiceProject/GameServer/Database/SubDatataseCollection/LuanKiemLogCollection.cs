using DynamicDBModel.Enum;
using GameServer.Common;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class LuanKiemLogCollection : AbsCollectionController<MLuanKiemLog>
    {
        public LuanKiemLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        protected override void SetDefaultValue(MLuanKiemLog data)
        {
            data.server_id = Settings.Instance.server_id;
        }

        public int CountAttackTimes(string userid)
        {
            return CountData
            (
                a =>
                    a.user.userid.Equals(userid.ToString()) &&
                    a.hash_code_time == CommonFunc.GetHashCodeTime()
            );
        }

        public List<MLuanKiemLog> GetChienBaoLogs(string userid)
        {
            return GetListDataDescending
            (
                filter:
                    a =>
                        a.user.userid == userid.ToString()
                        ||
                        a.user_opponent.userid == userid.ToString(),
                orderBy: a => a.created_at,
                skip: 0,
                take: 5
            );
        }

        public List<MLuanKiemLog> GetChangeRankLogs(string userid, DateTime startTime)
        {
            return GetListDataDescending
            (
                filter:
                    a =>
                        a.user.userid == userid.ToString() &&
                        a.outcome == OutcomeResult.Win &&
                        a.created_at >= startTime
                        ||
                        a.user_opponent.userid == userid.ToString() &&
                        a.outcome == OutcomeResult.Lose &&
                        a.created_at >= startTime,
                orderBy: a => a.created_at,
                skip: 0,
                take: 50
            );
        }

        public List<MLuanKiemLog> GetChienBaoTop10()
        {
            return GetListDataDescending
             (
                 filter:
                     a =>
                         a.user.new_rank <= 10 &&
                        a.server_id == Settings.Instance.server_id
                         ||
                         a.user_opponent.new_rank <= 10 &&
                        a.server_id == Settings.Instance.server_id,
                 orderBy: a => a.created_at,
                 skip: 0,
                 take: 10
             );
        }

        public MLuanKiemLog GetData(string id)
        {
            return GetSingleData(a => a._id.Equals((id)));
        }
    }
}

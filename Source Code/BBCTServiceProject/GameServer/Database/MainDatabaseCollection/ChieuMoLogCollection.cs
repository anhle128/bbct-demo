using DynamicDBModel.Models;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class ChieuMoLogCollection : AbsCollectionController<MChieuMoLog>
    {
        private List<MChieuMoLog> listLog = new List<MChieuMoLog>();

        private readonly object objectLock = new object();
        public ChieuMoLogCollection(string nameCollection, IMongoDatabase database) : base(nameCollection, database)
        {
        }

        public void CreateLogQuayTuong(string userid, int times, List<RewardItem> rewards)
        {
            MChieuMoLog log = new MChieuMoLog()
            {
                user_id = userid,
                times = times,
                rewards = rewards,
                type = TypeChieuMo.Tuong,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            lock (objectLock)
            {
                listLog.Add(log);
            }
        }

        public void CreateLogQuayVatPham(string userid, int times, List<RewardItem> rewards)
        {
            MChieuMoLog log = new MChieuMoLog()
            {
                user_id = userid,
                times = times,
                rewards = rewards,
                type = TypeChieuMo.TrangBi,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            lock (objectLock)
            {
                listLog.Add(log);
            }
        }

        public void SaveLogs()
        {
            if (listLog.Count == 0)
                return;

            lock (objectLock)
            {
                CreateAllImmediately(listLog.OrderBy(a => a.created_at).ToList());
                listLog.Clear();
            }
        }
    }
}

using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.MainDatabaseCollection
{
    public class ActionGoldLogCollection : AbsCollectionController<MActionGoldLog>
    {
        private List<MActionGoldLog> _listLogs = new List<MActionGoldLog>();

        private readonly object _objectLock = new object();

        public ActionGoldLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        public MActionGoldLog GetLastTimeActionGold(string userid)
        {
            lock (_objectLock)
            {
                MActionGoldLog log = null;

                log = _listLogs.LastOrDefault(a => a.user_id.Equals(userid));

                if (log == null)
                {
                    log = GetLastSingleData(a => a.user_id.Equals(userid),
                        a => a.created_at);
                }
                return log;
            }
        }

        public void CreateGetGoldLog(string userid, int oldGlod, int rewardGlod, int newGold, ReasonActionGold reason)
        {
            MActionGoldLog log = new MActionGoldLog()
            {
                user_id = userid,
                old_glod = oldGlod,
                reward_glod = rewardGlod,
                new_gold = newGold,
                reason = reason,
                type = TypeActionGold.Get,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            lock (_objectLock)
            {
                _listLogs.Add(log);
            }
        }

        public void CreateSpentGoldLog(string userid, int oldGlod, int spentGold, int newGold, ReasonActionGold reason)
        {
            MActionGoldLog log = new MActionGoldLog()
            {
                user_id = userid,
                old_glod = oldGlod,
                reward_glod = spentGold,
                new_gold = newGold,
                reason = reason,
                type = TypeActionGold.Spent,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };
            lock (_objectLock)
            {
                _listLogs.Add(log);
            }
        }

        public double GetTotalUsedGold(string userid, DateTime start, DateTime end)
        {
            lock (_objectLock)
            {
                double totalGoldSpent = 0;

                totalGoldSpent = GetSumData
                (
                    a =>
                        a.user_id == userid &&
                        a.created_at >= start &&
                        a.created_at <= end &&
                        a.type == TypeActionGold.Spent,
                    a => a.reward_glod
                );

                double totalGoldSpentInTime = _listLogs.Where
                (
                    a =>
                        a.user_id == userid &&
                        a.created_at >= start &&
                        a.created_at <= end &&
                        a.type == TypeActionGold.Spent
                ).Sum(a => a.reward_glod);

                totalGoldSpent += totalGoldSpentInTime;

                return totalGoldSpent;
            }
        }

        public void SaveLogs()
        {
            if (_listLogs.Count == 0)
                return;

            lock (_objectLock)
            {
                CreateAllImmediately(_listLogs.OrderBy(a => a.created_at).ToList());
                _listLogs.Clear();
            }
        }
    }
}

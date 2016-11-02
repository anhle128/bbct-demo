using GameServer.Common.Enum;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.MainDatabaseCollection
{
    public class RequestLogCollection : AbsCollectionController<MRequestLog>
    {

        private List<MRequestLog> _listLogs = new List<MRequestLog>();

        private readonly object _objectLock = new object();

        public RequestLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        public void Create(string userid, OperationCode code)
        {
            MRequestLog log = new MRequestLog()
            {
                user_id = userid,
                request = code.ToString(),
                updated_at = DateTime.Now,
                created_at = DateTime.Now
            };

            lock (_objectLock)
            {
                _listLogs.Add(log);
            }
        }

        public void SaveLogs()
        {
            lock (_objectLock)
            {
                if (_listLogs.Count == 0)
                    return;

                CreateAllImmediately(_listLogs.OrderBy(a => a.created_at).ToList());
                _listLogs.Clear();
            }
        }
    }
}

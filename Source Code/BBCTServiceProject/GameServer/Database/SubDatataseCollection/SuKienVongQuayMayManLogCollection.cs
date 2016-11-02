using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienVongQuayMayManLogCollection : AbsCollectionController<MSKVongQuayMayManLog>
    {
        public SuKienVongQuayMayManLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        protected override void SetDefaultValue(MSKVongQuayMayManLog data)
        {
            data.server_id = Settings.Instance.server_id;
        }

        public MSKVongQuayMayManLog GetData(string userid, string suKienId)
        {
            return
                GetSingleData
                (
                    a =>
                        a.user_id == userid &&
                        a.su_kien_id == suKienId
                );
        }

        public List<TopUserVongQuayMayMan> GetTopUsers(string suKienId)
        {
            List<MSKVongQuayMayManLog> listDataLog =
                GetListDataDescending(a => a.server_id == Settings.Instance.server_id && a.su_kien_id == suKienId && a.total_point != 0,
                    a => a.total_point, 0, 10);
            if (listDataLog.Count <= 0)
                return null;
            return listDataLog.Select(a => new TopUserVongQuayMayMan()
            {
                userid = a.user_id.ToString(),
                total_point = a.total_point,
                level = a.level,
                nickname = a.nickname,
                avatar = a.avatar,
                vip = a.vip
            }).ToList();
        }
    }
}

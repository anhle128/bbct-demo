using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using GameServer.GlobalInfo;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class TopThanThapLogCollection : AbsCollectionController<MTopThanPhapLog>
    {

        public TopThanThapLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerTimeData(Collection, new Dictionary<string, object>()
            {
                {"user.userid",1}
            });
        }

        protected override void SetDefaultValue(MTopThanPhapLog data)
        {
            data.hash_code_time = ThanThapInfo.GetHashTimeEnd();
            data.server_id = Settings.Instance.server_id;
            data.user.group_id = Settings.Instance.group_id;
        }

        public List<TopUserThanThap> GetTopUsersInServer(int hashTimeCode, int number)
        {
            List<MTopThanPhapLog> listData =
                GetListDataDescending
                (
                    a =>
                    a.hash_code_time == hashTimeCode &&
                    a.server_id == Settings.Instance.server_id, a => a.user.floor,
                    0,
                    number
                );
            if (listData == null || listData.Count == 0)
                return new List<TopUserThanThap>();
            return listData.Select(a => a.user).ToList();

        }

        public List<TopUserThanThap> GetPrevTopUsersInGroupServer(int hashTimeCode)
        {
            List<MTopThanPhapLog> listData =
                GetListDataAscending(a => a.hash_code_time == hashTimeCode && a.user.group_id == Settings.Instance.group_id, a => a.user.floor, 0, 10);
            if (listData == null)
                return null;
            return listData.Select(a => a.user).ToList();

        }


    }
}

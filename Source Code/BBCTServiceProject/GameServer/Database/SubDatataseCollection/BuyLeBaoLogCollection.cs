using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class BuyLeBaoLogCollection : AbsCollectionController<MBuyLeBaoLog>
    {
        public BuyLeBaoLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        //protected override void SetDefaultValue(MBuyLeBaoLog data)
        //{
        //    data.server_id = Settings.Instance.server_id;
        //}

        public List<MBuyLeBaoLog> GetDatas(string userid)
        {
            return
                GetListData(
                    a =>
                        a.user_id.Equals(userid) &&
                        a.hash_code_time == CommonFunc.GetHashCodeTime());
        }

        public int Count(string userid, string lebaoId)
        {
            return  CountData
                 (
                     a =>
                         a.user_id.Equals(userid)&&
                         a.hash_code_time == CommonFunc.GetHashCodeTime() &&
                         a.le_bao_id.Equals(lebaoId)
                 );
        }
    }
}

using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienPhucLoiTruongThanhLogCollection : AbsCollectionController<MPhucLoiTruongThanhLog>
    {
        public SuKienPhucLoiTruongThanhLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public MPhucLoiTruongThanhLog GetData(string userid)
        {
            return GetSingleData
            (
                a =>
                    a.user_id == userid &&
                    a.status == Status.Activate
            );
        }

        public void UpdateIndexsReceived(MPhucLoiTruongThanhLog data)
        {
            Dictionary<string, List<int>> dictData = new Dictionary<string, List<int>>()
            {
                {"index_received",data.index_received}
            };
            UpdateFields(data._id, dictData);
        }

        public bool CheckActivate(string userid)
        {
            int count = CountData
            (
                a =>
                    a.status == Status.Activate &&
                    a.user_id.Equals(userid)
            );
            return count == 1;
        }
    }
}

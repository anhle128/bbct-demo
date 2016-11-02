using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserCuopTieuCollection : AbsCollectionController<MUserCuopTieu>
    {
        public UserCuopTieuCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public void UpdateCuopTieuData(MUserCuopTieu data)
        {
            Dictionary<string, List<MCuopTieuData>> dictData = new Dictionary<string, List<MCuopTieuData>>()
            {
                {"cuop_tieu_datas",data.cuop_tieu_datas}
            };
            UpdateFields(data._id, dictData);
        }

        public MUserCuopTieu GetData(string userid)
        {
            return
                GetSingleData
                (
                    a =>
                        a.user_id.Equals(userid) &&
                        a.hash_code_time == CommonFunc.GetHashCodeTime()
                );
        }
    }
}

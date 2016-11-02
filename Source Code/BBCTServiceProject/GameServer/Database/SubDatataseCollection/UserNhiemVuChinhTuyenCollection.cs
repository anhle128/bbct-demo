using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Enum;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserNhiemVuChinhTuyenCollection : AbsCollectionController<MUserNhiemVuChinhTuyen>
    {
        public UserNhiemVuChinhTuyenCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public MUserNhiemVuChinhTuyen GetData(string userid)
        {

            NhiemVuChinhTuyenConfig config = StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig;
            MUserNhiemVuChinhTuyen nhiemVu = GetSingleData(a => a.user_id.Equals(userid));
            if (nhiemVu == null)
            {
                nhiemVu = new MUserNhiemVuChinhTuyen();
                nhiemVu.datas = new List<NhiemVuChinhTuyenData>();
                nhiemVu.user_id = userid;
                for (int i = 0; i < config.nhiemVus.Length; i++)
                {
                    nhiemVu.datas.Add(new NhiemVuChinhTuyenData()
                    {
                        process = 0,
                        level = 0,
                        id = config.nhiemVus[i].id
                    });
                }
                Create(nhiemVu);
            }
            else
            {
                if (nhiemVu.datas.Count < config.nhiemVus.Length)
                {
                    int count = config.nhiemVus.Length - nhiemVu.datas.Count;
                    int number = nhiemVu.datas.Count;
                    for (int i = 0; i < count; i++)
                    {
                        nhiemVu.datas.Add(new NhiemVuChinhTuyenData()
                        {
                            process = 0,
                            level = 0,
                            id = config.nhiemVus[i + number].id
                        });
                    }
                    Update(nhiemVu);
                }
            }
            return nhiemVu;
        }

        /// <summary>
        /// dùng cho TypeNhiemVuChinhTuyen.UpLevelSkill
        /// </summary>
        public void SaveNhiemVu(string userid)
        {
            MUserNhiemVuChinhTuyen nhiemVu = GetData(userid);

            List<NhiemVuChinhTuyen> listDataNhiemVu =
               StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig.GetNhiemVuByType(TypeNhiemVuChinhTuyen.UpLevelSkill);

            foreach (var data in listDataNhiemVu)
            {
                nhiemVu.datas.Single(a => a.id == data.id).process++;
                Update(nhiemVu);
            }
        }
    }
}

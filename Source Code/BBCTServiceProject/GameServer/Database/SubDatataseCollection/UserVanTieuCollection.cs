using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserVanTieuCollection : AbsCollectionController<MUserVanTieu>
    {
        public UserVanTieuCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        protected override void SetDefaultValue(MUserVanTieu data)
        {
            data.server_id = Settings.Instance.server_id;
        }

        public MUserVanTieu GetPrevData(string userId)
        {
            return GetSingleData
            (
                a =>
                    a.user_id == userId &&
                    a.hash_code_time != CommonFunc.GetHashCodeTime() &&
                    !a.end &&
                    a.current_vehicle != null &&
                    a.current_vehicle.going_on
            );
        }

        public MUserVanTieu GetDataByUserId(string userId)
        {
            return GetSingleData
            (
                a =>
                    a.user_id == userId &&
                    a.hash_code_time == CommonFunc.GetHashCodeTime() &&
                    a.end == false
            );
        }



        public int CountStartVanTieu(string userId)
        {
            return CountData
            (
                a =>
                    a.user_id == userId &&
                    a.hash_code_time == CommonFunc.GetHashCodeTime() &&
                    a.start
            );
        }

        public void UpdateCurrentVehidle(MUserVanTieu data)
        {
            Dictionary<string, object> dictdata = new Dictionary<string, object>()
            {
                 {"current_vehicle", data.current_vehicle},
                 {"start", data.start},
            };
            UpdateFields(data._id, dictdata);
        }

        public void UpdateCurrentVehidle_Reward(MUserVanTieu data)
        {
            Dictionary<string, object> dictdata = new Dictionary<string, object>()
            {
                 {"current_vehicle", data.current_vehicle},
                 {"rewards", data.rewards},
            };
            UpdateFields(data._id, dictdata);
        }

        public void UpdateEnd(MUserVanTieu data)
        {
            Dictionary<string, object> dictdata = new Dictionary<string, object>()
            {
                 {"end", data.end}
            };
            UpdateFields(data._id, dictdata);
        }

        public void UpdateCurrentVehidle_UsersCuopTieu(MUserVanTieu data)
        {
            Dictionary<string, object> dictdata = new Dictionary<string, object>()
            {
                {"current_vehicle", data.current_vehicle},
                {"users_cuop_tieu", data.users_cuop_tieu}
            };
            UpdateFields(data._id, dictdata);
        }

        public void UpdateLevel(string username, int level)
        {
            Dictionary<string, object> dictFilter = new Dictionary<string, object>(1)
            {
                {"userid",username}
            };
            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                {"level",level}
            };
            UpdateAllAsync(dictFilter, dictData);
        }


        public List<MUserVanTieu> GetRandomDatas(string userId, int minLevel, int maxLevel)
        {
            return
                GetRandomListData(
                    filter: a =>
                        a.level >= minLevel &&
                        a.level <= maxLevel &&
                        a.current_vehicle.going_on &&
                        a.server_id == Settings.Instance.server_id &&
                        a.end == false &&
                        a.users_cuop_tieu.Count < StaticDatabase.entities.configs.cuopTieuConfig.maxTimesVehicleBiCuop - 1 &&
                        a.user_id != userId
                        ||
                        a.level >= minLevel &&
                        a.level <= maxLevel &&
                        a.current_vehicle.going_on &&
                        a.server_id == Settings.Instance.server_id &&
                        a.end == false &&
                        a.users_cuop_tieu == null &&
                        a.user_id != userId,
                    skip: 0,
                    take: 3
                );
        }
    }
}

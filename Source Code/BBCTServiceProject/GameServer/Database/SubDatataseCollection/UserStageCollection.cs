using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserStageCollection : AbsCollectionController<MUserStage>
    {
        public UserStageCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public List<MUserStage> GetDatas(string userid)
        {
            return GetListData
            (
                a => a.user_id.Equals(userid)
            );
        }

        public MUserStage GetLastStageAttacked(string userid)
        {
            return GetLastSingleData(a => a.user_id.Equals(userid), a => a.updated_at);
        }

        public void ClearAllAttackTimes(MUserInfo data)
        {
            Dictionary<string, object> dictFilter = new Dictionary<string, object>(1)
            {
                {"user_id",data._id}
            };

            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                { "stage_info.attack_times", 0 }
            };

            UpdateAllAsync(dictFilter, dictData);
        }

        public void UpdateStageInfo(MUserStage userStage)
        {
            var data = new Dictionary<string, object> { { "stage_info", userStage.stage_info } };
            UpdateFields(userStage._id, data);
        }

        public bool CheckDoneStage(string userid, int indexMap, int indexStage)
        {
            int count = CountData
            (
                a =>
                    a.user_id.Equals(userid) &&
                    a.stage_info.stage.map_index == indexMap &&
                    a.stage_info.stage.stage_index == indexStage &&
                    a.stage_info.star >= 1 &&
                    a.stage_info.stage.level == 1
            );
            return count > 0 ? true : false;
        }

        public double SumStar(string userid, int mapIndex, int level)
        {
            return
                GetSumData
                (
                    a =>
                        a.user_id.Equals(userid) &&
                        a.stage_info.stage.map_index == mapIndex &&
                        a.stage_info.stage.level == level,
                    a =>
                        a.stage_info.star
                );
        }

        public MUserStage GetData(string userid, StageMode prevStage)
        {
            return
                    GetSingleData
            (
                a =>
                    a.user_id.Equals(userid) &&
                    a.stage_info.stage.stage_index == prevStage.stage_index &&
                    a.stage_info.stage.map_index == prevStage.map_index &&
                    a.stage_info.stage.level == prevStage.level
            );
        }
    }
}

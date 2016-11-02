
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
    public class SuKienDoiDoLogCollection : AbsCollectionController<MSKDoiDoLog>
    {
        public SuKienDoiDoLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public MSKDoiDoLog GetData(string userid, string suKienId)
        {
            return GetSingleData(a => a.user_id.Equals(userid) && a.su_kien_id.Equals(suKienId));
        }

        public TopUserDoiDo[] GetTopUser(string suKienId, List<TopRewardDoiDo> topRewardDoiDo)
        {
            MSKDoiDoLog[] arrData = new MSKDoiDoLog[topRewardDoiDo.Count];
            int minPointRequire = topRewardDoiDo.Min(b => b.point_require);
            List<MSKDoiDoLog> listLog = GetListDataDescending
            (
                filter: a => a.su_kien_id.Equals(suKienId) && a.total_point >= minPointRequire,
                orderBy: a => a.total_point,
                skip: 0,
                take: topRewardDoiDo.Count
            );
            if (listLog.Count > 0)
            {
                foreach (var log in listLog)
                {
                    for (int i = 0; i < topRewardDoiDo.Count; i++)
                    {
                        TopRewardDoiDo topReward = topRewardDoiDo[i];

                        if (log.total_point >= topReward.point_require)
                        {
                            if (arrData[i] == null)
                            {
                                arrData[i] = log;
                                break;
                            }
                            else
                            {
                                if (arrData[i].total_point < log.total_point)
                                {
                                    arrData[i] = log;
                                    break;
                                }
                            }
                        }
                    }
                }

                TopUserDoiDo[] arrResult = new TopUserDoiDo[topRewardDoiDo.Count];
                for (int i = 0; i < topRewardDoiDo.Count; i++)
                {
                    if (arrData[i] == null)
                        continue;
                    TopUserDoiDo top = new TopUserDoiDo()
                    {
                        userid = arrData[i].user_id.ToString(),
                        total_point = arrData[i].total_point,
                        nickname = arrData[i].nickname,
                        avatar = arrData[i].avatar
                    };
                    arrResult[i] = top;
                }
                return arrResult;
            }
            return null;
        }
    }
}

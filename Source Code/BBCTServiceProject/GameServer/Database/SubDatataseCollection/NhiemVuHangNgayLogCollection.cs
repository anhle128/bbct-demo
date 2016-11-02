using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Enum;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class NhiemVuHangNgayLogCollection : AbsCollectionController<MNhiemVuHangNgayLog>
    {
        public NhiemVuHangNgayLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public MNhiemVuHangNgayLog GetData(string userid)
        {
            MNhiemVuHangNgayLog nhiemVuLog = GetSingleData
            (
                a =>
                    a.user_id.Equals(userid) &&
                    a.hash_code_time == CommonFunc.GetHashCodeTime()
            );
            if (nhiemVuLog == null)
            {
                nhiemVuLog = new MNhiemVuHangNgayLog();
                nhiemVuLog.hash_code_time = CommonFunc.GetHashCodeTime();
                nhiemVuLog.user_id = userid;
                nhiemVuLog.nhiemVuHangNgay = new List<MNhiemVuHangNgay>();
                foreach (var nhiemVu in StaticDatabase.entities.configs.nhiemVuHangNgayConfig.nhiemVus)
                {
                    nhiemVuLog.nhiemVuHangNgay.Add(new MNhiemVuHangNgay()
                    {
                        type = (TypeNhiemVuHangNgay)nhiemVu.type,
                        count = 0,
                        received = false
                    });
                }
                Create(nhiemVuLog);
            }
            else
            {
                if (nhiemVuLog.nhiemVuHangNgay.Count <
                    StaticDatabase.entities.configs.nhiemVuHangNgayConfig.nhiemVus.Length)
                {
                    foreach (var nhiemVu in StaticDatabase.entities.configs.nhiemVuHangNgayConfig.nhiemVus)
                    {
                        if (nhiemVuLog.nhiemVuHangNgay.Any(a => a.type == (TypeNhiemVuHangNgay)nhiemVu.type))
                            continue;
                        nhiemVuLog.nhiemVuHangNgay.Add(new MNhiemVuHangNgay()
                        {
                            type = (TypeNhiemVuHangNgay)nhiemVu.type,
                            count = 0,
                            received = false
                        });
                    }
                }
                Update(nhiemVuLog);
            }
            return nhiemVuLog;
        }

        public List<NhiemVuHangNgayData> GetDataNhiemVuHangNgay(string userid)
        {
            MNhiemVuHangNgayLog nhiemVuLog = GetData(userid);
            List<NhiemVuHangNgayData> listResult = new List<NhiemVuHangNgayData>();
            foreach (var data in nhiemVuLog.nhiemVuHangNgay)
            {
                NhiemVuHangNgayData nhiemVu = new NhiemVuHangNgayData();
                nhiemVu.type = data.type;
                nhiemVu.count = data.count;
                nhiemVu.received = data.received;
                listResult.Add(nhiemVu);
            }
            return listResult;
        }

        public void SaveLogNhiemVu(string userId, TypeNhiemVuHangNgay type)
        {
            MNhiemVuHangNgayLog log = GetData(userId);
            if (log.hash_code_time != CommonFunc.GetHashCodeTime())
            {
                log = new MNhiemVuHangNgayLog()
                {
                    user_id = userId,
                    nhiemVuHangNgay = new List<MNhiemVuHangNgay>(),
                    hash_code_time = CommonFunc.GetHashCodeTime()
                };
                foreach (var nhiemVu in StaticDatabase.entities.configs.nhiemVuHangNgayConfig.nhiemVus)
                {
                    log.nhiemVuHangNgay.Add(new MNhiemVuHangNgay()
                    {
                        type = (TypeNhiemVuHangNgay)nhiemVu.type,
                        count = 0,
                        received = false
                    });
                }
                log.nhiemVuHangNgay.Single(a => a.type == type).count++;
                Create(log);
            }
            else
            {
                int maxQuantity = StaticDatabase.entities.configs.nhiemVuHangNgayConfig.nhiemVus.Single(a => a.type == (int)type).quantity;
                if (log.nhiemVuHangNgay.Single(a => a.type == type).count < maxQuantity)
                {
                    log.nhiemVuHangNgay.Single(a => a.type == type).count++;
                    Update(log);
                }
            }
        }

        public void SaveLogNhiemVu(string userid, TypeNhiemVuHangNgay type, int times)
        {
            MNhiemVuHangNgayLog log = GetData(userid);
            if (log.hash_code_time != CommonFunc.GetHashCodeTime())
            {
                log = new MNhiemVuHangNgayLog()
                {
                    user_id = userid,
                    nhiemVuHangNgay = new List<MNhiemVuHangNgay>(),
                    hash_code_time = CommonFunc.GetHashCodeTime()
                };
                foreach (var nhiemVu in StaticDatabase.entities.configs.nhiemVuHangNgayConfig.nhiemVus)
                {
                    log.nhiemVuHangNgay.Add(new MNhiemVuHangNgay()
                    {
                        type = (TypeNhiemVuHangNgay)nhiemVu.type,
                        count = 0,
                        received = false
                    });
                }
                log.nhiemVuHangNgay.Single(a => a.type == type).count += times;
                Create(log);
            }
            else
            {
                int maxQuantity = StaticDatabase.entities.configs.nhiemVuHangNgayConfig.nhiemVus.Single(a => a.type == (int)type).quantity;
                if (log.nhiemVuHangNgay.Single(a => a.type == type).count < maxQuantity)
                {
                    log.nhiemVuHangNgay.Single(a => a.type == type).count += times;
                    Update(log);
                }
            }

        }
    }
}

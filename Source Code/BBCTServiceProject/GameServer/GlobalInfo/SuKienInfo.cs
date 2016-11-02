using DynamicDBModel.Enum;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using GameServer.Common;
using GameServer.Quartz;

namespace GameServer.GlobalInfo
{
    public class SuKienInfo
    {
        private static MSuKienActivate dataSuKienActivate;

        private static readonly object ObjectLock = new object();

        public static MSKVongQuayMayManConfig vongQuayMayManEnd;
        public static MSKDuaTopServerConfig duaTopEndd;

        public static List<TypeSuKien> GetListSuKienActivate()
        {
            if (dataSuKienActivate != null)
                return dataSuKienActivate.su_kien_activate;
            else
                return new List<TypeSuKien>();
        }

        public static void StartCheckSuKien()
        {
            dataSuKienActivate = MongoController.ConfigDb.SuKienActivate.GetData();
            if (dataSuKienActivate == null)
            {
                dataSuKienActivate = new MSuKienActivate()
                {
                    su_kien_activate = new List<TypeSuKien>()
                };
                MongoController.ConfigDb.SuKienActivate.Create(dataSuKienActivate);
            }
            //CheckSuKien();
        }

        public static async void CheckSuKien()
        {
            dataSuKienActivate.su_kien_activate.Clear();

            if (await MongoController.ConfigDb.Sk7NgayNhanThuong.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.BayNgayNhanThuong);
            }

            if (await MongoController.ConfigDb.SkTichluyTieu.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.TichLuyTieu);
            }

            if (await MongoController.ConfigDb.SkTichluyNap.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.TichLuyNap);
            }

            if (await MongoController.ConfigDb.SkRotDo.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.RotDo);
            }

            if (await MongoController.ConfigDb.SkDoiDo.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.DoiDo);

                MSKDoiDoConfig config = MongoController.ConfigDb.SkDoiDo.GetData();
                SuKienDoiDoInfo.CheckStartSuKienDoiDo(config);
                if (config.end > DateTime.Now && config.end.Day == DateTime.Now.Day && config.end.Month == DateTime.Now.Month)
                {
                    QuartzManager.Instance.ScheduleEndDoiDo(config);
                }
            }

            if (await MongoController.ConfigDb.SkThanTai.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.ThanTai);
            }

            if (await MongoController.ConfigDb.SkTranhMuaServer.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.TranhMuaServer);
            }

            if (await MongoController.ConfigDb.SkVongQuayMayMan.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.VongQuayMayMan);
                MSKVongQuayMayManConfig config = MongoController.ConfigDb.SkVongQuayMayMan.GetData();
                if (config.end.Day == DateTime.Now.Day 
                    && config.end.Month == DateTime.Now.Month 
                    && config.end > DateTime.Now)
                {
                    vongQuayMayManEnd = config;
                    QuartzManager.Instance.ScheduleEndTimeVongQuayMayMan(config);
                }
            }

            if (await MongoController.ConfigDb.Skx2Nap.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.x2Nap);
            }

            if (await MongoController.ConfigDb.SkDuaTopServer.CheckActivate())
            {
                dataSuKienActivate.su_kien_activate.Add(TypeSuKien.DuaTopServer);
                MSKDuaTopServerConfig mSkDuaTopConfig = MongoController.ConfigDb.SkDuaTopServer.GetData();
                if (!mSkDuaTopConfig.is_send_reward && mSkDuaTopConfig.end > DateTime.Now)
                {
                    if (mSkDuaTopConfig.end.Day == DateTime.Now.Day && mSkDuaTopConfig.end.Month == DateTime.Now.Month)
                    {
                        duaTopEndd = mSkDuaTopConfig;
                        QuartzManager.Instance.ScheduleEndTimeDuaTopServer(mSkDuaTopConfig);
                    }
                }
            }
            CommonLog.Instance.PrintLog("------- Su Kien Active -------");
            foreach (var sk in dataSuKienActivate.su_kien_activate)
            {
                CommonLog.Instance.PrintLog(sk.ToString());
            }
            CommonLog.Instance.PrintLog("-------------------------------");
            MongoController.ConfigDb.SuKienActivate.Update(dataSuKienActivate);
        }

        public static void SetDeactiveSuKien(TypeSuKien type)
        {
            lock (ObjectLock)
            {
                if (dataSuKienActivate.su_kien_activate.Any(a => a == type))
                {
                    //CommonLog.Instance.PrintLog("SetDeactiveSuKien " + type.ToString());
                    dataSuKienActivate.su_kien_activate.Remove(type);
                }
            }
        }
    }
}

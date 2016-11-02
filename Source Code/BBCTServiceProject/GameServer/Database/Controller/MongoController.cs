
using DynamicDBModel;
using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Database.Core;
using GameServer.GlobalInfo;
using GameServer.MainServer.Database.Controller;
using GameServer.Server;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.Controller
{
    public class MongoController : AbsDatabaseController
    {
        private static IMongoDatabase _mainDatabase;
        private static IMongoDatabase _subDatabase;

        #region DB controller

        private static UserDbController _userDb;
        private static ConfigDbController _configDb;
        private static GiftCodeDbController _giftCodeDb;
        private static MailDbController _mailDb;
        private static LogDbController _logDb;
        private static ServerDbController _serverDb;
        private static ShopDbController _shopDb;
        private static LogSubDbController _logSubDb;
        private static GuildDbController _guildDb;
        private static MarketDbController _marketDb;

        public static LogSubDbController LogSubDB
        {
            get { return MongoController._logSubDb; }
        }
        public static UserDbController UserDb
        {
            get { return _userDb; }
        }

        public static ConfigDbController ConfigDb
        {
            get { return _configDb; }
        }

        public static GiftCodeDbController GiftCodeDb
        {
            get { return _giftCodeDb; }
        }

        public static MailDbController MailDb
        {
            get { return _mailDb; }
        }

        public static LogDbController LogDb
        {
            get { return _logDb; }
        }

        public static ServerDbController ServerDb
        {
            get { return _serverDb; }
        }

        public static ShopDbController ShopDb
        {
            get { return _shopDb; }
        }

        public static GuildDbController GuildDb
        {
            get { return _guildDb; }
        }

        public static MarketDbController MarketDb
        {
            get { return _marketDb; }
        }

        #endregion

        #region Connection
        public static void Connected()
        {
            // set up main data base
            _mainDatabase = GetDatabase(Settings.Instance.mainDatabase);

            //var list = _mainDatabase.ListCollections().ToList();

            _giftCodeDb = new GiftCodeDbController(_mainDatabase);
            _mailDb = new MailDbController(_mainDatabase);
            _logDb = new LogDbController(_mainDatabase);
            _serverDb = new ServerDbController(_mainDatabase);

            // set up sub database
            string serverId = Settings.Instance.server_id;
            MServer server = _serverDb.Server.GetServer(Settings.Instance.server_id);

            CommonLog.Instance.PrintLog(string.Format("-------------- server name: {0} --------------", server.name));

            _subDatabase = GetDatabase(server.mongo_connection);

            _userDb = new UserDbController(_subDatabase);
            _configDb = new ConfigDbController(_subDatabase);
            _shopDb = new ShopDbController(_subDatabase);

            _logSubDb = new LogSubDbController(_subDatabase);
            _guildDb = new GuildDbController(_subDatabase);

            _marketDb = new MarketDbController(_subDatabase);

        }

        public static void Connected(MServer server)
        {
            // set up main data base
            _mainDatabase = GetDatabase(Settings.Instance.mainDatabase);

            //var list = _mainDatabase.ListCollections().ToList();

            _giftCodeDb = new GiftCodeDbController(_mainDatabase);
            _mailDb = new MailDbController(_mainDatabase);
            _logDb = new LogDbController(_mainDatabase);
            _serverDb = new ServerDbController(_mainDatabase);

            CommonLog.Instance.PrintLog(string.Format("-------------- server name: {0} --------------", server.name));

            _subDatabase = GetDatabase(server.mongo_connection);

            _userDb = new UserDbController(_subDatabase);
            _configDb = new ConfigDbController(_subDatabase);
            _shopDb = new ShopDbController(_subDatabase);

            _logSubDb = new LogSubDbController(_subDatabase);
            _guildDb = new GuildDbController(_subDatabase);

            _marketDb = new MarketDbController(_subDatabase);
        }
        #endregion

        public static Entity GetEntity(PlayerCacheData cacheData, MUserInfo userInfo)
        {
            Entity entity = _userDb.GetEntityResult(cacheData, userInfo);
            entity.system_mails = _mailDb.GetSystemMails();
            entity.nhiem_vu_hang_ngay = _logSubDb.NhiemVuHangNgay.GetDataNhiemVuHangNgay(userInfo._id);
            entity.nhiem_vu_chinh_tuyen = _userDb.NhiemVuChinhTuyen.GetData(userInfo._id).datas;
            entity.vipRewards = _configDb.VipReward.GetVipRewards();
            entity.server_time = DateTime.Now;
            entity.suKienActivate = new List<TypeSuKien>(SuKienInfo.GetListSuKienActivate());
            CheckSuKienPhucLoiTruongThanh(userInfo, entity);
            CheckSuKienCuuCuuTriTon(userInfo, entity);
            return entity;
        }

        public static void CheckSuKienCuuCuuTriTon(MUserInfo userInfo, Entity entity)
        {
            double totalCreateDay = (DateTime.Now - userInfo.created_at).TotalDays;
            if (totalCreateDay > StaticDatabase.entities.configs.cuuCuuTriTonConfig.duration)
            {
                if (!_userDb.CuuCuuTriTon.CheckExist(userInfo._id))
                    return;

                if (_userDb.CuuCuuTriTon.CheckRewardInDay(userInfo._id))
                    return;

                entity.suKienActivate.Add(TypeSuKien.CuuCuuTriTon);
            }
            else
            {
                if (_userDb.CuuCuuTriTon.CheckExist(userInfo._id))
                {
                    if (_userDb.CuuCuuTriTon.CheckRewardInDay(userInfo._id))
                        return;

                    entity.suKienActivate.Add(TypeSuKien.CuuCuuTriTon);
                }
                else
                {
                    entity.suKienActivate.Add(TypeSuKien.CuuCuuTriTon);
                }
            }
        }

        private static void CheckSuKienPhucLoiTruongThanh(MUserInfo userInfo, Entity entity)
        {
            if (_logSubDb.SkPhucLoiTruongThanh.CheckActivate(userInfo._id))
            {
                entity.suKienActivate.Add(TypeSuKien.PhucLoiTruongThanh);
            }
        }

        public static UserFriend GetUserFriendFromUserInfo(MUserInfo friendInfo)
        {
            if (friendInfo == null)
                return null;

            UserFriend friend = new UserFriend()
            {
                username = friendInfo.username,
                avatar = friendInfo.avatar,
                level = friendInfo.level,
                vip = friendInfo.vip,
                nickname = friendInfo.nickname
            };
            return friend;
        }

        public static List<ShopItem> GetShopItems(string userId, int vip)
        {
            List<MShopItem> listDataShopItem =
                _shopDb.Item.GetDatas();

            List<MBuyShopItemLog> listLog =
                _logSubDb.BuyShopItem.GetDatas(userId);


            List<ShopItem> listResult = new List<ShopItem>();

            foreach (var dataShopItem in listDataShopItem)
            {
                ShopItem item = new ShopItem();
                item._id = dataShopItem._id.ToString();
                item.gold = dataShopItem.gold;
                item.totalNumberCanBuy = dataShopItem.vip_buy_times[vip];
                item.totalNumberBought = listLog.Count == 0 ?
                    0 : listLog.Where(a => a.item_id == dataShopItem._id.ToString()).Sum(a => a.quantity);
                item.reward = new RewardItem()
                {
                    quantity = dataShopItem.reward.quantity,
                    type_reward = dataShopItem.reward.type_reward,
                    static_id = dataShopItem.reward.static_id,
                    _id = ""
                };
                listResult.Add(item);
            }

            return listResult;
        }

        public static List<LeBao> GetLeBaos(string userid, int vip)
        {
            List<MLebao> listDataLeBaos =
                _shopDb.LeBao.GetDatas();

            List<MBuyLeBaoLog> listLog =
                _logSubDb.BuyLeBao.GetDatas(userid);

            return listDataLeBaos.Select
            (
                dataLeBao => GetLeBaoFromData
                (
                    vip,
                    dataLeBao,
                    listLog
                )
            ).Where
            (
                lebao => lebao != null
            ).ToList();
        }

        private static LeBao GetLeBaoFromData(int vip, MLebao lebao, List<MBuyLeBaoLog> listLog)
        {
            LeBao resultLeBao = null;
            if (CheckValidTimeToGetLeBao(lebao.activation, lebao.start, lebao.end))
            {
                resultLeBao = new LeBao()
                {
                    _id = lebao._id.ToString(),
                    name = lebao.name,
                    start = lebao.start,
                    end = lebao.end,
                    gold = lebao.gold,
                    rewards = lebao.rewards,
                    activation = lebao.activation,
                    totalBuyTimes = listLog.Count(a => a.le_bao_id.Equals(lebao._id)),
                    max_buy_times = CommonFunc.GetTimesCanBuyLeBao(lebao, vip),
                    realGold = lebao.real_gold,
                    vip_required = lebao.vip_required,
                    buy_times = lebao.buy_times
                };
            }
            return resultLeBao;
        }

        private static bool CheckValidTimeToGetLeBao(TypeLeBaoActivationTime activationType, string start, string end)
        {
            //CommonLog.Instance.PrintLog(DateTime.Now.ToString());
            switch (activationType)
            {
                case TypeLeBaoActivationTime.None:
                    return true;
                case TypeLeBaoActivationTime.ActivateDateInWeek:
                    return true;
                case TypeLeBaoActivationTime.ActivateDaysInMonth:
                    return true;
                case TypeLeBaoActivationTime.ActivateHoursInDay:
                    return true;
                case TypeLeBaoActivationTime.ActivateInTimeRange:
                    if (DateTime.Now >= DateTime.Parse(start) && DateTime.Now <= DateTime.Parse(end))
                        return true;
                    return false;
                default:
                    return false;
            }
        }

        public static List<LuanKiemShopItem> GetLuanKiemShopItems(string userid)
        {
            List<MLuanKiemShopItem> listDataShopItem =
                _shopDb.LuanKiem.GetActiveItems();

            List<MBuyShopLuanKiemItemLog> listLog =
                _logSubDb.BuyLuanKiemShopItem.GetDatas(userid);

            return listDataShopItem.Select(dataShopItem => new LuanKiemShopItem()
            {
                _id = dataShopItem._id.ToString(),
                pointLuanKiem = dataShopItem.point_luan_kiem,
                totalNumberCanBuy = dataShopItem.maxBuyTimes,
                totalNumberBought = listLog.Count == 0 ? 0 : listLog.Where(a => a.item_id == dataShopItem._id.ToString()).Sum(a => a.quantity),
                reward = new RewardItem()
                {
                    quantity = dataShopItem.reward.quantity,
                    type_reward = dataShopItem.reward.type_reward,
                    static_id = dataShopItem.reward.static_id,
                    _id = ""
                },
                rankRequire = dataShopItem.rank_require
            }).ToList();
        }

        public static List<Reward> GetBunusItemSkRotDo()
        {
            List<TypeSuKien> listTypeSuKien = SuKienInfo.GetListSuKienActivate();
            if (listTypeSuKien.Any(a => a == TypeSuKien.RotDo))
            {
                MSKRotDoConfig config = _configDb.SkRotDo.GetData();
                if (config != null)
                {
                    return config.drop_items;
                }
                else
                {
                    SuKienInfo.SetDeactiveSuKien(TypeSuKien.RotDo);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}

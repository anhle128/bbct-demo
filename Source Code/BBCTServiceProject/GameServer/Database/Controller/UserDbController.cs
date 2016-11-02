using DynamicDBModel;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Database.SubDatataseCollection;
using GameServer.Server;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Enum;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.Controller
{
    public class UserDbController
    {
        #region Property

        private readonly UserInfoCollection _info;
        private readonly UserEquipCollection _equip;
        private readonly UserCharCollection _char;
        private readonly UserItemCollection _item;
        private readonly UserMailCollection _mail;
        private readonly UserFriendCollection _friend;
        private readonly UserStageCollection _stage;
        private readonly UserThanThapCollection _thanThap;
        private readonly UserVanTieuCollection _vanTieu;
        private readonly UserCuopTieuCollection _cuopTieu;
        private readonly UserGlobalBossCollection _globalBoss;
        private readonly UserCauCaCollection _cauCa;
        private readonly UserNhiemVuChinhTuyenCollection _nhiemVuChinhTuyen;
        private readonly UserDiemDanhThangCollection _diemDanhThang;
        private readonly UserPhucLoiThangCollection _phucLoiThang;
        private readonly UserCuuCuuTriTonCollection _cuuCuuTriTon;
        private readonly UserStarRewardCollection _starReward;
        private readonly TestCollection _test;

        public UserInfoCollection Info
        {
            get { return _info; }
        }

        public UserEquipCollection Equip
        {
            get { return _equip; }
        }

        public UserCharCollection Char
        {
            get { return _char; }
        }

        public UserItemCollection Item
        {
            get { return _item; }
        }

        public UserMailCollection Mail
        {
            get { return _mail; }
        }

        public UserFriendCollection Friend
        {
            get { return _friend; }
        }

        public UserStageCollection Stage
        {
            get { return _stage; }
        }

        public UserVanTieuCollection VanTieu
        {
            get { return _vanTieu; }
        }

        public UserCuopTieuCollection CuopTieu
        {
            get { return _cuopTieu; }
        }

        public UserThanThapCollection ThanThap
        {
            get { return _thanThap; }
        }

        public UserGlobalBossCollection GlobalBoss
        {
            get { return _globalBoss; }
        }

        public UserCauCaCollection CauCa
        {
            get { return _cauCa; }
        }

        public UserNhiemVuChinhTuyenCollection NhiemVuChinhTuyen
        {
            get { return _nhiemVuChinhTuyen; }
        }

        public UserDiemDanhThangCollection DiemDanhThang
        {
            get { return _diemDanhThang; }
        }

        public UserPhucLoiThangCollection PhucLoiThang
        {
            get { return _phucLoiThang; }
        }

        public UserCuuCuuTriTonCollection CuuCuuTriTon
        {
            get { return _cuuCuuTriTon; }
        }

        public UserStarRewardCollection StarReward
        {
            get { return _starReward; }
        }

        public TestCollection Test
        {
            get { return _test; }
        }

        #endregion

        #region Constructor
        public UserDbController(IMongoDatabase database)
        {
            _info = new UserInfoCollection("user_infos", database);
            _equip = new UserEquipCollection("user_equips", database);
            _char = new UserCharCollection("user_chars", database);
            _item = new UserItemCollection("user_items", database);
            _mail = new UserMailCollection("user_mails", database);
            _friend = new UserFriendCollection("user_friends", database);
            _stage = new UserStageCollection("user_stages", database);
            _vanTieu = new UserVanTieuCollection("user_van_tieu", database);
            _cuopTieu = new UserCuopTieuCollection("user_cuop_tieu", database);
            _thanThap = new UserThanThapCollection("user_than_thap", database);
            _globalBoss = new UserGlobalBossCollection("user_global_boss", database);
            _cauCa = new UserCauCaCollection("user_cau_ca", database);
            _nhiemVuChinhTuyen = new UserNhiemVuChinhTuyenCollection("user_nhiem_vu_chinh_tuyen", database);
            _diemDanhThang = new UserDiemDanhThangCollection("user_diem_danh_thang", database);
            _phucLoiThang = new UserPhucLoiThangCollection("user_phuc_loi_thang", database);
            _cuuCuuTriTon = new UserCuuCuuTriTonCollection("user_cuu_cuu_tri_ton", database);
            _starReward = new UserStarRewardCollection("user_star_rewards", database);
            _test = new TestCollection("test_collection", database);
        }


        #endregion

        #region Get Entity Result
        public Entity GetEntityResult(PlayerCacheData cacheData, MUserInfo userInfo)
        {
            Entity entities = new Entity()
            {
                info = new UserInfo()
            };
            string guildName = null;
            var guild = GetGuild(userInfo);
            if (guild != null)
            {
                guildName = guild.name;
            }

            int hashCodeTime = CommonFunc.GetHashCodeTime();

            entities.info.username = userInfo.username;
            entities.info.nickname = userInfo.nickname;
            entities.info.avatar = userInfo.avatar;
            entities.info.posX = (float)userInfo.posX;
            entities.info.posY = (float)userInfo.posY;
            entities.info.exp = userInfo.exp;
            entities.info.gold = userInfo.gold;
            entities.info.ruby = userInfo.ruby;
            entities.info.silver = userInfo.silver;
            entities.info.stamina = userInfo.stamina;
            entities.info.vip = userInfo.vip;
            entities.info.level = userInfo.level;
            entities.info.point_skill = userInfo.point_skill;
            entities.info.guildName = guildName;
            entities.formation_rows = userInfo.formation;
            entities.info.count_chuc_phuc = userInfo.count_chuc_phuc;
            entities.info.vipRewarded = userInfo.vip_rewarded;
            entities.info.isSendFacebook = userInfo.hash_code_time_send_facebook == hashCodeTime;
            entities.info.isChucPhuc = userInfo.hash_code_time_chuc_phuc == hashCodeTime;
            entities.info.tutorial = userInfo.tutorial;
            entities.info.total_ruby_trans = userInfo.total_ruby_trans;

            entities.info.create_at = userInfo.created_at;
            entities.info.inviteFriend = userInfo.invite_friend;

            entities.indexRankLuanKiemRewarded = userInfo.index_rank_luan_kiem_rewarded;

            entities.stages = GetListStages(userInfo._id);
            entities.lastest_stage_attacked = userInfo.lastest_stage_attacked;
            entities.highest_stage_attacked = userInfo.highest_stages_attacked;

            entities.characters = GetListUserChar(cacheData);

            entities.equips = GetListEquip(cacheData);

            entities.items = GetListUserItem(cacheData);

            entities.index_level_rewarded = userInfo.index_level_rewarded;
            entities.index_invite_rewarded = userInfo.index_invite_rewarded;

            entities.mails = GetListUserEmail(userInfo._id);

            entities.star_rewards = GetListStarReward(userInfo._id);

            MHuaNguyenLog huaNguyenLog = MongoController.LogSubDB.HuaNguyen.GetData(userInfo._id,
                CommonFunc.GetHashCodeTime());
            entities.countTimesHuaNguyen = huaNguyenLog != null ? huaNguyenLog.count_times : 0;

            MBuyPointSkillLog buyPointSkill = MongoController.LogSubDB.BuyPointSkill.GetData(userInfo._id,
                CommonFunc.GetHashCodeTime());
            entities.countTimeBuyPointSkill = buyPointSkill != null ? buyPointSkill.count_times : 0;

            entities.doi_hinh_du_bi = userInfo.doi_hinh_du_bi;

            return entities;
        }


        //private List<UserRuongBau> GetListRuongBau(string userid)
        //{
        //    List<MUserRuongBau> dataUserRuongBaus =
        //        _ruongBau.GetDatas(userid);
        //    return dataUserRuongBaus.Select(a => new UserRuongBau()
        //    {
        //        name = a.name,
        //        desc = a.desc,
        //        _id = a._id.ToString()
        //    }).ToList();
        //}

        private List<UserStage> GetListStages(string userid)
        {
            List<MUserStage> userStages = _stage.GetDatas(userid);
            return userStages.Select(a => a.stage_info).ToList();
        }

        public List<UserMail> GetListUserEmail(string userid)
        {
            List<MUserMail> listUserMails = _mail.GetDatas(userid);

            return (from a in listUserMails
                    select new UserMail()
                    {
                        _id = a._id.ToString(),
                        content = a.content,
                        readed = a.readed,
                        rewards = a.rewards != null ? (from b in a.rewards select new RewardItem() { static_id = b.static_id, quantity = b.quantity, type_reward = b.type_reward }).ToList() : null,
                        title = a.title,
                        time = a.created_at
                    }).ToList();
        }

        public List<UserStarReward> GetListStarReward(string userid)
        {
            List<MUserStarReward> listData = _starReward.GetDatas(userid);
            return listData.Select(a => new UserStarReward()
            {
                map_index = a.map_index,
                index_reveived = a.index_reveived,
                level = a.level

            }).ToList();
        }

        public List<UserEquip> GetListEquip(PlayerCacheData cacheData)
        {
            cacheData.listUserEquip = _equip.GetDatas(cacheData.id);
            if (cacheData.listUserEquip == null)
            {
                cacheData.listUserEquip = new List<MUserEquip>();
                return null;
            }
            return CommonFunc.GetUserEquips(cacheData.listUserEquip);
        }

        public List<UserCharacter> GetListUserChar(PlayerCacheData cacheData)
        {
            cacheData.listUserChar = _char.GetDatas(cacheData.id);
            if (cacheData.listUserChar == null)
            {
                cacheData.listUserChar = new List<MUserCharacter>();
                return null;
            }
            return CommonFunc.GetUserChars(cacheData.listUserChar);
        }

        private List<UserItem> GetListUserItem(PlayerCacheData cacheData)
        {
            cacheData.listUserItem = _item.GetDatas(cacheData.id);
            if (cacheData.listUserItem == null)
            {
                cacheData.listUserItem = new List<MUserItem>();
                return null;
            }
            return CommonFunc.GetUserItem(cacheData.listUserItem);
        }
        #endregion


        #region Reward Item
        public List<RewardItem> UpdateReward(PlayerCacheData userInfo, List<SubRewardItem> listReward, ReasonActionGold resource)
        {
            var listRewardResult = new List<RewardItem>();

            if (listReward == null || listReward.Count == 0)
                return listRewardResult;

            // reward item
            RewardItem(userInfo, listReward.Where(a => a.type_reward == (int)TypeReward.Item).ToList(), listRewardResult);
            // reward char
            RewardChar(userInfo, listReward.Where(a => a.type_reward == (int)TypeReward.Character).ToList(), listRewardResult);
            // reward equip
            RewardEquip(userInfo, listReward.Where(a => a.type_reward == (int)TypeReward.Equipment).ToList(), listRewardResult);
            // reward userinfo (exp - silver - ruby - gold - point luan kien)
            RewardUserInfo(userInfo, listReward, listRewardResult, resource);

            return listRewardResult;
        }

        private void RewardUserInfo(PlayerCacheData userInfo, List<SubRewardItem> listReward, List<RewardItem> listRewardResult, ReasonActionGold reason)
        {
            int totalSilver = listReward.Where(a => a.type_reward == (int)TypeReward.Silver).Sum(a => a.quantity);
            int totalRuby = listReward.Where(a => a.type_reward == (int)TypeReward.Ruby).Sum(a => a.quantity);
            int totalExp = listReward.Where(a => a.type_reward == (int)TypeReward.ExpPlayer).Sum(a => a.quantity);
            int totalLuanKiemPoint = listReward.Where(a => a.type_reward == (int)TypeReward.LuanKiemPoint).Sum(a => a.quantity);
            int totalGold = listReward.Where(a => a.type_reward == (int)TypeReward.Gold).Sum(a => a.quantity);

            if (totalSilver == 0 && totalRuby == 0 && totalExp == 0 && totalLuanKiemPoint == 0 && totalGold == 0)
                return;

            int oldGlod = userInfo.gold;

            userInfo.silver += totalSilver;
            userInfo.ruby += totalRuby;
            userInfo.gold += totalGold;
            userInfo.pointLuanKiem += totalLuanKiemPoint;

            if (totalExp != 0)
            {
                int oldLevel = userInfo.level;
                CommonFunc.UpLevelPlayer(userInfo, totalExp);
                if (oldLevel != userInfo.level
                    && userInfo.stamina < StaticDatabase.entities.configs.maxStamina) // up level
                {
                    userInfo.stamina = StaticDatabase.entities.configs.maxStamina;
                    userInfo.last_time_update_stamina = new DateTime();
                }
            }


            if (totalSilver != 0)
            {
                listRewardResult.Add(new RewardItem()
                {
                    quantity = totalSilver,
                    type_reward = (int)TypeReward.Silver
                });
            }
            if (totalRuby != 0)
            {
                listRewardResult.Add(new RewardItem()
                {
                    quantity = totalRuby,
                    type_reward = (int)TypeReward.Ruby
                });
            }
            if (totalExp != 0)
            {
                listRewardResult.Add(new RewardItem()
                {
                    quantity = totalExp,
                    type_reward = (int)TypeReward.ExpPlayer
                });
            }
            if (totalLuanKiemPoint != 0)
            {
                listRewardResult.Add(new RewardItem()
                {
                    quantity = totalLuanKiemPoint,
                    type_reward = (int)TypeReward.LuanKiemPoint
                });
            }
            if (totalGold != 0)
            {
                listRewardResult.Add(new RewardItem()
                {
                    quantity = totalGold,
                    type_reward = (int)TypeReward.Gold
                });

                MongoController.LogDb.ActionGold.CreateGetGoldLog(userInfo.id, oldGlod, totalGold, userInfo.gold, reason);
            }

            _info.UpdateUserInfoReward(userInfo);
        }

        private void AddSubRewardToList(List<SubRewardItem> listRewardResult, SubRewardItem rewardResult)
        {
            if (rewardResult.type_reward == (int)TypeReward.Equipment ||
                rewardResult.type_reward == (int)TypeReward.Character)
            {
                listRewardResult.Add(rewardResult);
                return;
            }

            if (listRewardResult.Any(a => a.type_reward == rewardResult.type_reward && a.static_id == rewardResult.static_id))
            {
                listRewardResult.Single(a => a.type_reward == rewardResult.type_reward && a.static_id == rewardResult.static_id).
                    quantity += rewardResult.quantity;
            }
            else
            {
                listRewardResult.Add(rewardResult);
            }
        }

        private void RewardItem(PlayerCacheData userInfo, List<SubRewardItem> listRewardItems, List<RewardItem> listRewardResult)
        {
            List<MUserItem> listItemCreate = new List<MUserItem>();
            List<MUserItem> listItemUpdate = new List<MUserItem>();
            List<MUserItem> listAllItem = userInfo.listUserItem;
            foreach (SubRewardItem reward in listRewardItems)
            {
                Item item = StaticDatabase.entities.items.FirstOrDefault(a => a.id == reward.static_id);
                if (item == null)
                {
                    CommonLog.Instance.PrintLog("error item_id: " + reward.static_id);
                    break;
                }
                if (item.type == (short)TypeItem.RuongBau)
                {
                    #region RewardRuongBau
                    MRuongBauConfig ruongBau = MongoController.ConfigDb.RuongBau.GetData(reward.ruong_bau_id);

                    var userItem = new MUserItem
                    {
                        user_id = userInfo.id,
                        quantity = 1,
                        static_id = reward.static_id,
                        ruong_bau_id = ruongBau._id.ToString(),
                        rewards = ruongBau.rewards
                    };

                    AddObjectToList(listItemCreate, userItem, 0);
                    #endregion
                }
                else
                {
                    var userItem = listAllItem.FirstOrDefault(a => a.static_id == reward.static_id);
                    if (userItem == null)
                    {
                        userItem = new MUserItem
                        {
                            user_id = userInfo.id,
                            quantity = 0,
                            static_id = reward.static_id
                        };
                        AddObjectToList(listItemCreate, userItem, reward.quantity);
                    }
                    else
                    {
                        AddObjectToList(listItemUpdate, userItem, reward.quantity);
                    }
                }
            }

            if (listItemCreate.Count > 0)
            {
                MongoController.UserDb.Item.CreateAll(listItemCreate);
                listAllItem.AddRange(listItemCreate);
                listRewardResult.AddRange(ConvertUserItemToReward(listItemCreate, TypeReward.Item, listRewardItems));
            }
            if (listItemUpdate.Count > 0)
            {
                MongoController.UserDb.Item.UpdatesQuantity(listItemUpdate);
                listRewardResult.AddRange(ConvertUserItemToReward(listItemUpdate, TypeReward.Item, listRewardItems));
            }
        }

        private void AddObjectToList<T>(List<T> listItem, T item, int plusQuantity) where T : IStaticObjCountable
        {
            IStaticObjCountable sameObject = listItem.FirstOrDefault(a => a.static_id == item.static_id);
            if (sameObject == null)
            {
                item.quantity += plusQuantity;
                listItem.Add(item);
            }
            else
            {
                sameObject.quantity += plusQuantity;
            }
        }

        private List<RewardItem> ConvertStaticObjectCountableToReward<T>(List<T> datas, TypeReward typeReward, List<SubRewardItem> listSubReward) where T : IStaticObjCountable
        {
            return datas.Select(data => new RewardItem
            {
                _id = data._id.ToString(),
                static_id = data.static_id,
                type_reward = (int)typeReward,
                quantity = listSubReward.Where(a => a.static_id == data.static_id && a.type_reward == (int)typeReward).Sum(a => a.quantity)
            }).ToList();
        }

        private List<RewardItem> ConvertUserItemToReward<T>(List<T> datas, TypeReward typeReward, List<SubRewardItem> listSubReward) where T : MUserItem
        {
            return datas.Select(data => new RewardItem
            {
                _id = data._id.ToString(),
                static_id = data.static_id,
                type_reward = (int)typeReward,
                rewards = data.rewards,
                quantity = listSubReward.Where(a => a.static_id == data.static_id && a.type_reward == (int)typeReward).Sum(a => a.quantity)
            }).ToList();
        }

        private List<RewardItem> ConvertStaticObjectToReward<T>(List<T> datas, TypeReward typeReward) where T : IStaticObj
        {
            return datas.Select(data => new RewardItem
            {
                _id = data._id.ToString(),
                static_id = data.static_id,
                type_reward = (int)typeReward,
                quantity = 1
            }).ToList();
        }

        public void RewardChar(PlayerCacheData userInfo, List<SubRewardItem> listRewards, List<RewardItem> listRewardResult)
        {

            List<MUserCharacter> listCreate = new List<MUserCharacter>();

            foreach (var reward in listRewards)
            {
                for (int i = 0; i < reward.quantity; i++)
                {
                    var userChar = new MUserCharacter()
                    {
                        user_id = userInfo.id,
                        static_id = reward.static_id
                    };
                    listCreate.Add(userChar);
                }
            }

            if (listCreate.Count > 0)
            {
                MongoController.UserDb.Char.CreateAll(listCreate);
                userInfo.listUserChar.AddRange(listCreate);
                listRewardResult.AddRange(ConvertStaticObjectToReward(listCreate, TypeReward.Character));

            }
        }

        private void RewardEquip(PlayerCacheData userInfo, List<SubRewardItem> listReward, List<RewardItem> listRewardResult)
        {
            List<MUserEquip> listCreate = new List<MUserEquip>();
            foreach (var reward in listReward)
            {
                for (int i = 0; i < reward.quantity; i++)
                {
                    var userEquip = RandomEquipsElementAndBonusAttribute(reward.static_id);
                    userEquip.user_id = userInfo.id;
                    listCreate.Add(userEquip);
                }
            }

            if (listCreate.Count == 0)
                return;

            userInfo.listUserEquip.AddRange(listCreate);
            MongoController.UserDb.Equip.CreateAll(listCreate);

            listRewardResult.AddRange(ConvertStaticObjectToReward(listCreate, TypeReward.Equipment));
        }

        private MUserEquip RandomEquipsElementAndBonusAttribute(int staticId)
        {
            var userEquip = new MUserEquip();

            userEquip.static_id = staticId;
            userEquip.element = RandomEquipElement();

            Equipment equipment = StaticDatabase.entities.equipments.Single(a => a.id == userEquip.static_id);
            ElementBonusAttribute elementBonusAttribute =
                equipment.bonusAttributes.FirstOrDefault(a => a.element == userEquip.element);

            if (elementBonusAttribute == null)
                return userEquip;

            BonusAttribute bonusAttribute = RandomEquipBonusAttribute(elementBonusAttribute.bonusAttributes);
            if (bonusAttribute == null)
                return userEquip;

            userEquip.bonus_attribute = bonusAttribute.attribute;

            userEquip.bonus_attribute_grow_mod = CommonFunc.RandomNumber
            (
                bonusAttribute.minGrowMod,
                bonusAttribute.maxGrowMod
            );

            userEquip.bonus_attribute_mod = CommonFunc.RandomNumber
            (
                bonusAttribute.minMod,
                bonusAttribute.maxMod
            );

            return userEquip;
        }

        private TypeElement RandomEquipElement()
        {
            float[] procElements = StaticDatabase.entities.configs.equipmentConfig.procElements;
            float totalProc = procElements.Sum();

            float randomProc = CommonFunc.RandomNumber(0, Convert.ToInt16(totalProc));

            float currentProc = 0;
            for (int i = 0; i < procElements.Length; i++)
            {
                currentProc += procElements[i];
                if (currentProc >= randomProc)
                    return (TypeElement)i;
            }
            return (TypeElement)(procElements.Length - 1);
        }

        private BonusAttribute RandomEquipBonusAttribute(BonusAttribute[] arrBonusAttribute)
        {
            return null;
        }

        #endregion

        public bool CheckDoneNhiemVu(PlayerCacheData playerCacheData, NhiemVuChinhTuyenData nhiemVu)
        {
            NhiemVuChinhTuyen nhiemVuConfig =
                StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig.nhiemVus.Single(a => a.id == nhiemVu.id);

            switch ((TypeNhiemVuChinhTuyen)nhiemVuConfig.type)
            {
                case TypeNhiemVuChinhTuyen.AttachStage:
                    return CheckDoneAttackStage(playerCacheData.id, nhiemVu);
                case TypeNhiemVuChinhTuyen.GetEquip:
                    return CheckDoneGetEquip(playerCacheData, nhiemVu, nhiemVuConfig.numberRequire);
                case TypeNhiemVuChinhTuyen.UpLevelPlayer:
                    return CheckDoneUpLevelPlayer(playerCacheData.level, nhiemVu);
                case TypeNhiemVuChinhTuyen.UpLevelEquip:
                    return CheckDoneUpLevelEquip(playerCacheData, nhiemVu, nhiemVuConfig.numberRequire);
                case TypeNhiemVuChinhTuyen.UpLevelSkill:
                    return CheckDoneUpLevelSkill(nhiemVu);
                default:
                    return false;
            }
        }

        private bool CheckDoneUpLevelSkill(NhiemVuChinhTuyenData nhiemVu)
        {
            int numberRequire = StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig.GetNumberRequire(nhiemVu.id,
                nhiemVu.level);
            return nhiemVu.process >= numberRequire ? true : false;
        }

        private bool CheckDoneUpLevelEquip(PlayerCacheData cacheData, NhiemVuChinhTuyenData nhiemVuData, int numberRequire)
        {
            //int number = StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig.GetNumberRequire(nhiemVuData.id,
            //    nhiemVuData.level);
            //int levelRequire =
            //    StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig.GetLevelEquipRequire(nhiemVuData.level);
            //int count = cacheData.listUserEquip.Count(a => a.level >= levelRequire);
            //return count >= number ? true : false;
            return true;
        }

        private bool CheckDoneAttackStage(string userid, NhiemVuChinhTuyenData nhiemVuData)
        {
            int indexMap = StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig.GetNumberRequire(nhiemVuData.id,
                nhiemVuData.level);
            int indexStage = StaticDatabase.entities.maps[indexMap].stages.Length - 1;
            return _stage.CheckDoneStage(userid, indexMap, indexStage);
        }

        private bool CheckDoneGetEquip(PlayerCacheData cacheData, NhiemVuChinhTuyenData nhiemVuData, int promotion)
        {
            int numberRequire = StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig.GetNumberRequire(
                nhiemVuData.id, nhiemVuData.level);

            //List<int> listIdEquipment =
            //    StaticDatabase.entities.equipments.Where(a => a.promotion == promotion).Select(a => a.id).ToList();

            int count = 0;
            //foreach (var userEquipment in cacheData.listUserEquip)
            //{
            //    if (listIdEquipment.All(a => a != userEquipment.static_id))
            //        continue;

            //    count++;
            //}

            //int count = cacheData.listUserEquip.CoundLogInDay(a => a.promotion == promotion);
            CommonLog.Instance.PrintLog("count: " + count);
            //CommonLog.Instance.PrintLog("=====================");
            //foreach (var a in cacheData.listUserEquip)
            //{
            //    CommonLog.Instance.PrintLog("" + a.promotion);
            //}
            return count >= numberRequire ? true : false;
        }

        private bool CheckDoneUpLevelPlayer(int level, NhiemVuChinhTuyenData nhiemVuData)
        {
            int levelRequire = StaticDatabase.entities.configs.nhiemVuChinhTuyenConfig.GetNumberRequire(
               nhiemVuData.id, nhiemVuData.level);
            return level >= levelRequire ? true : false;
        }

        public SubDataPlayer GetSubDataPlayer(MUserInfo userInfo)
        {
            SubDataPlayer subData = new SubDataPlayer();
            subData.formation_rows = userInfo.formation;

            List<MUserCharacter> listAllChar =
                MongoController.UserDb.Char.GetDatas(userInfo._id);

            subData.idAllChars = listAllChar.Select(a => a.static_id).ToList();

            // get list char in formation
            List<string> listIdCharInFormation = new List<string>();
            foreach (StringArray t in subData.formation_rows)
            {
                listIdCharInFormation.AddRange(t.columns.Where(t1 => t1 != "-1"));
            }
            List<MUserCharacter> listCharInFormation = new List<MUserCharacter>();

            foreach (var idChar in listIdCharInFormation)
            {
                MUserCharacter userChar = new MUserCharacter();
                userChar = listAllChar.FirstOrDefault(a => a._id == idChar);
                if (userChar != null)
                    listCharInFormation.Add(userChar);
            }
            subData.chars = CommonFunc.GetUserChars(listCharInFormation);


            // get list equipment
            List<MUserEquip> listAllEquip = MongoController.UserDb.Equip.GetEquipUsed(userInfo._id);

            List<MUserEquip> listEquipmentResult = new List<MUserEquip>();

            foreach (var character in listCharInFormation)
            {
                List<string> listIdEquipInChar = character.equipments.Where(a => a != "-1").ToList();
                listEquipmentResult.AddRange(listIdEquipInChar.Select(idEquip => listAllEquip.FirstOrDefault(a => a._id.Equals(idEquip))).Where(userEquip => userEquip != null));
            }

            subData.equips = CommonFunc.GetUserEquips(listEquipmentResult);

            return subData;
        }

        public MGuild GetGuild(MUserInfo userInfo)
        {
            var member = MongoController.GuildDb.GuildMember.GetData(userInfo._id);

            if (member == null)
            {
                return null;
            }
            else
            {
                var guild = MongoController.GuildDb.Guild.GetDataByUserId(member.guild_id);

                return guild;
            }
        }
    }
}
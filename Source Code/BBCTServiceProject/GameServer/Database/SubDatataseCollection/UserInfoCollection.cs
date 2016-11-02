using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using GameServer.Server;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserInfoCollection : AbsCollectionController<MUserInfo>
    {
        public UserInfoCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        //public MUserInfo GetData(string username)
        //{
        //    return GetSingleData
        //    (
        //        a => a.username.Equals(username) && a.server_id.Equals(Settings.Instance.server_id)
        //    );
        //}

        public MUserInfo GetDataByUsername(string username)
        {
            return GetSingleData
            (
                a => a.username.Equals(username) && a.server_id.Equals(Settings.Instance.server_id)
            );
        }

        public List<MUserInfo> GetDatasByUserID(List<string> userid)
        {
            return GetListData("userid", userid);
        }

        public MUserInfo GetData(int rankRandom)
        {
            return GetSingleData(a => a.rank_luan_kiem == rankRandom && a.server_id == Settings.Instance.server_id);
        }

        /// <summary>
        /// Kiểm tra userid đã có nick trong server hay chưa
        /// 1. gửi lên trùng userid
        /// 2. userid đã có nick trong server nhưng vẫn gọi lên create account
        /// </summary>
        /// <returns></returns>
        public bool CheckExistAccount(string nickname, string username)
        {
            int countData =
                CountData
                (
                    a =>
                        a.nickname == nickname &&
                        a.server_id == Settings.Instance.server_id
                    ||
                        a.username == username &&
                        a.server_id == Settings.Instance.server_id
                );
            return countData == 1;
        }

        public MUserInfo GetData(string _id)
        {
            return GetSingleData(a => a._id.Equals(_id));
        }

        public List<MUserInfo> GetRandomData(string username, int number)
        {
            return
                GetListData
                (
                    a =>
                    a.server_id == Settings.Instance.server_id &&
                    a.isBot == false &&
                    a.isLocked == false &&
                    a.username != username
                ).OrderBy
                (
                    a => Guid.NewGuid()
                ).Take(number).ToList();
        }

        public List<MUserInfo> GetRandomWithRank(int highestRank)
        {
            return GetListData
                (
                    a =>
                        a.server_id == Settings.Instance.server_id &&
                        a.rank_luan_kiem <= highestRank
                ).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
        }

        public MUserInfo GetDataWithToken(string token)
        {
            return GetSingleData(a => a.access_token == token && a.server_id == Settings.Instance.server_id);
        }

        public List<MUserInfo> GetListDataWithRank(int start, int end)
        {
            return
                GetListData
                (
                    a =>
                        a.rank_luan_kiem >= start &&
                        a.rank_luan_kiem <= end &&
                        a.server_id == Settings.Instance.server_id &&
                        a.isBot == false
                );
        }

        public List<MUserInfo> GetTopUsers(int number)
        {

            List<MUserInfo> listUser = GetListDataDescending
            (
                a =>
                    a.server_id == Settings.Instance.server_id &&
                    a.isBot == false,
                a => a.level,
                0,
                number
            );

            for (int i = 0; i < listUser.Count - 1; i++)
            {
                for (int j = 1; j < listUser.Count; j++)
                {
                    if (listUser[i].level == listUser[j].level)
                    {
                        MUserInfo userSave = listUser[i];
                        listUser[i] = listUser[j];
                        listUser[j] = userSave;
                    }
                }
            }

            return listUser;
        }

        public bool CheckUserExist(string username)
        {
            int countUserInfo = CountData(a => a.username == username && a.server_id == Settings.Instance.server_id);
            if (countUserInfo != 1)
                return false;
            return true;
        }

        protected override void SetDefaultValue(MUserInfo data)
        {
            data.gold = StaticDatabase.entities.configs.playerDefaultConfig.gold;
            data.silver = StaticDatabase.entities.configs.playerDefaultConfig.silver;
            data.stamina = StaticDatabase.entities.configs.playerDefaultConfig.stamina;
            data.point_skill = 0;
            data.isBot = false;
            data.isLocked = false;
            data.level = StaticDatabase.entities.configs.playerDefaultConfig.level;
            data.rank_luan_kiem = 10000;
            data.lastest_stage_attacked = new StageMode()
            {
                map_index = 0,
                stage_index = 0
            };
            data.highest_stages_attacked = new StageMode()
            {
                level = 1,
                stage_index = 0,
                map_index = 0
            };
            //data.avatar_star = StaticDatabase.entities.configs.characterConfig.defaultConfig.st;
            data.posX = CommonFunc.RandomNumber(-1500, 1500);
            data.posY = CommonFunc.RandomNumber(-250, -25);
        }

        public void UpdateUserInfoReward(PlayerCacheData userInfo)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"silver",userInfo.silver},
                {"gold",userInfo.gold},
                {"ruby",userInfo.ruby},
                {"exp",userInfo.exp},
                {"level",userInfo.level},
                {"point_luan_kiem",userInfo.pointLuanKiem},
                {"last_time_update_stamina",userInfo.last_time_update_stamina},
                {"stamina",userInfo.stamina},
            };
            UpdateFields(userInfo.id, dictData);
        }


        public void UpdateGold(PlayerCacheData cacheData, ReasonActionGold reason, int goldUsed)
        {
            var data = new Dictionary<string, object>
            {
                { "gold", cacheData.gold }
            };

            UpdateFields(cacheData.id, data);

            MongoController.LogDb.ActionGold.CreateSpentGoldLog
            (
                userid: cacheData.id,
                oldGlod: cacheData.gold + goldUsed,
                spentGold: goldUsed,
                newGold: cacheData.gold,
                reason: reason
            );
        }



        public void UpdateGold_CountTimex10VatPham(PlayerCacheData userInfo, int timeQuayx10VatPham, int goldUsed)
        {
            var data = new Dictionary<string, object>(2)
            {
                { "gold", userInfo.gold },
                { "count_time_x10_quoay_vat_pham", timeQuayx10VatPham}
            };
            UpdateFields(userInfo.id, data);

            MongoController.LogDb.ActionGold.CreateSpentGoldLog
            (
                userid: userInfo.id,
                oldGlod: userInfo.gold + goldUsed,
                spentGold: goldUsed,
                newGold: userInfo.gold,
                reason: ReasonActionGold.QuayVatPhamx10
            );
        }
        public void UpdateLastTimeFreeQuayVatPham(PlayerCacheData userInfo, DateTime lastTimeFreeQuayVatPham)
        {
            var data = new Dictionary<string, object>(2)
            {
                {"last_time_free_quay_vat_pham",lastTimeFreeQuayVatPham}
            };
            UpdateFields(userInfo.id, data);
        }

        public void UpdateSilver(PlayerCacheData userInfo, TypeUseSilver type, int silverUsed)
        {
            var data = new Dictionary<string, object>(1)
            {
                { "silver", userInfo.silver }
            };
            UpdateFields(userInfo.id, data);
            if (type != TypeUseSilver.None && silverUsed != 0)
                MongoController.LogDb.UsedSilver.Create(userInfo.id, silverUsed, type);

        }

        public void Update_Silver_Level_EXP_Stamina_HighestStageAttacked(PlayerCacheData userInfo)
        {
            var data = new Dictionary<string, object>(4)
            {
                {"silver", userInfo.silver},
                {"level", userInfo.level},
                {"exp", userInfo.exp},
                {"stamina", userInfo.stamina},
                {"highest_stages_attacked", userInfo.highest_stages_attacked},
                {"lastest_stage_attacked", userInfo.lastest_stage_attacked}
            };
            if (userInfo.stamina < StaticDatabase.entities.configs.maxStamina)
            {
                userInfo.last_time_update_stamina = DateTime.Now;
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }
            else if (userInfo.stamina >= StaticDatabase.entities.configs.maxStamina
                && userInfo.last_time_update_stamina != new DateTime())
            {
                userInfo.last_time_update_stamina = new DateTime();
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }
            UpdateFields(userInfo.id, data);
        }

        public void UpdateStamina(PlayerCacheData userInfo)
        {
            var data = new Dictionary<string, object>(1)
            {
                { "stamina", userInfo.stamina }
            };
            //userInfo.last_time_update_stamina == new DateTime()
            //                && 
            if (userInfo.stamina < StaticDatabase.entities.configs.maxStamina)
            {
                userInfo.last_time_update_stamina = DateTime.Now;
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }
            else if (userInfo.stamina >= StaticDatabase.entities.configs.maxStamina &&
                     userInfo.last_time_update_stamina != new DateTime())
            {
                userInfo.last_time_update_stamina = new DateTime();
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }
            UpdateFields(userInfo.id, data);
        }

        //public void UpdateStamina(MUserInfo userInfo)
        //{
        //    var data = new Dictionary<string, object>(1)
        //    {
        //        { "stamina", userInfo.stamina }
        //    };

        //    if (userInfo.last_time_update_stamina == new DateTime()
        //       && userInfo.stamina < StaticDatabase.entities.configs.maxStamina)
        //    {
        //        userInfo.last_time_update_stamina = DateTime.Now;
        //        data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
        //    }
        //    UpdateFields(userInfo._id, data);
        //}

        public void Update_Level_Exp(PlayerCacheData data)
        {
            var dictData = new Dictionary<string, object>
            {
                { "exp", data.exp },
                { "level", data.level }
            };
            UpdateFields(data.id, dictData);
        }

        public void UpdateSilver_PointSkill(PlayerCacheData data, int silverUsed)
        {
            data.last_time_update_point_skill =
                data.point_skill == StaticDatabase.entities.configs.pointSkillConfig.maxPointSkillCanReach ?
                new DateTime() : DateTime.Now;
            var dictData = new Dictionary<string, object>
            {
                { "point_skill", data.point_skill },
                { "last_time_update_point_skill", data.last_time_update_point_skill },
                { "silver", data.silver },
            };
            UpdateFields(data.id, dictData);
            MongoController.LogDb.UsedSilver.Create(data.id, silverUsed, TypeUseSilver.UpSkillChar);
        }

        public void UpdateAvatar(PlayerCacheData data)
        {
            var dictData = new Dictionary<string, object>
            {
                { "avatar", data.avatar },
                { "avatar_star", data.avatar_star }
            };
            UpdateFields(data.id, dictData);
        }

        public void UpdateLastTimeAttackLuanKiem(PlayerCacheData data)
        {
            var dictData = new Dictionary<string, object>
            {
                { "last_time_attack_luan_kiem", data.lastTimeAttackLuanKiem }
            };
            UpdateFields(data.id, dictData);
        }

        public void UpdateGold_LastTimeAttackLuanKiem(PlayerCacheData data, int goldUsed)
        {
            var dictData = new Dictionary<string, object>
            {
                { "last_time_attack_luan_kiem", data.lastTimeAttackLuanKiem },
                { "gold", data.gold }
            };
            UpdateFields(data.id, dictData);
            MongoController.LogDb.ActionGold.CreateSpentGoldLog
            (
                userid: data.id,
                oldGlod: data.gold + goldUsed,
                spentGold: goldUsed,
                newGold: data.gold,
                reason: ReasonActionGold.ResetLuanKiem
            );
        }

        public void UpdateAvatar_Formation(PlayerCacheData data)
        {
            var dictData = new Dictionary<string, object>
            {
                { "avatar", data.avatar },
                {"formation",data.formation},
                {"doi_hinh_du_bi",data.doi_hinh_du_bi},
            };
            UpdateFields(data.id, dictData);
        }

        public void UpdateFormation(PlayerCacheData data)
        {
            var dictData = new Dictionary<string, object>
            {
                {"formation",data.formation}
            };
            UpdateFields(data.id, dictData);
        }

        public void UpdateDoiHinhDiBi(PlayerCacheData data)
        {
            var dictData = new Dictionary<string, List<DuBi>>
            {
                {"doi_hinh_du_bi",data.doi_hinh_du_bi}
            };
            UpdateFields(data.id, dictData);
        }

        public void UpdatePosition(string id, double posX, double posY)
        {
            var dictData = new Dictionary<string, double>
            {
                { "posY", posY },
                { "posX", posX }
            };
            UpdateFields(id, dictData);
        }

        public void ClearInfo(MUserInfo data)
        {
            var dictDataInfo = new Dictionary<string, object>
            {
                { "reset_stage_times", 0 },
                { "hash_code_login_time", data.hash_code_login_time },
                { "count_times_free_quay_tuong_normal", 0},
                { "invite_friend", 0},
                { "index_invite_rewarded", new List<int>()}
            };
            UpdateFields(data._id, dictDataInfo);
        }

        public void Update_Stamina_StageAttacked(PlayerCacheData userInfo)
        {
            var data = new Dictionary<string, object>
            {
                {"stamina", userInfo.stamina},
                {"lastest_stage_attacked", userInfo.lastest_stage_attacked},
                //{"highest_stages_attacked", userInfo.highest_stages_attacked},
            };
            if (userInfo.stamina >= StaticDatabase.entities.configs.maxStamina)
            {
                userInfo.last_time_update_stamina = new DateTime();
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }
            else if (userInfo.stamina < StaticDatabase.entities.configs.maxStamina)
            {
                userInfo.last_time_update_stamina = DateTime.Now;
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }
            UpdateFields(userInfo.id, data);
        }

        public void UpdateGold_FreeTimeQuayTuongSpecial(MUserInfo userInfo, int goldUsed)
        {
            var data = new Dictionary<string, object>
            {
                { "gold", userInfo.gold },
                { "last_time_free_quay_tuong_special",userInfo.last_time_free_quay_tuong_special},
                { "count_time_quoay_tuong_special",userInfo.count_time_quoay_tuong_special}

            };
            UpdateFields(userInfo._id, data);
            if (goldUsed != 0)
            {
                MongoController.LogDb.ActionGold.CreateSpentGoldLog
                (
                    userid: userInfo._id,
                    oldGlod: userInfo.gold + goldUsed,
                    spentGold: goldUsed,
                    newGold: userInfo.gold,
                    reason: ReasonActionGold.QuayTuongx1
                );
            }
        }

        public void UpdateGold_FreeTimeQuayTuongNormal(MUserInfo userInfo, int goldUsed)
        {
            var data = new Dictionary<string, object>
            {
                { "gold", userInfo.gold },
                { "last_time_free_quay_tuong_normal",userInfo.last_time_free_quay_tuong_normal},
                { "count_times_free_quay_tuong_normal",userInfo.count_times_free_quay_tuong_normal}
            };
            UpdateFields(userInfo._id, data);
            if (goldUsed != 0)
            {
                MongoController.LogDb.ActionGold.CreateSpentGoldLog
                (
                    userid: userInfo._id,
                    oldGlod: userInfo.gold + goldUsed,
                    spentGold: goldUsed,
                    newGold: userInfo.gold,
                    reason: ReasonActionGold.QuayTuongx1
                );
            }
            //MongoController.LogDb.UsedGold.Create(userInfo.userid, goldUsed, TypeUseGold.QuayTuongx1);
        }

        public void UpdateReset(MUserInfo userInfo)
        {
            var data = new Dictionary<string, object>
            {
                { "hash_code_login_time",userInfo.hash_code_login_time},
                { "count_times_free_quay_tuong_normal",userInfo.count_times_free_quay_tuong_normal}
            };
            UpdateFields(userInfo._id, data);
        }

        //public void UpdateSilver(PlayerCacheData cacheData, TypeUseSilver type, int usedSilver)
        //{
        //    Dictionary<string, object> dictData = new Dictionary<string, object>()
        //    {
        //        {"silver",cacheData.silver}
        //    };
        //    UpdateFields(cacheData.id, dictData);
        //    if (type != TypeUseSilver.None)
        //        MongoController.LogDb.UsedSilver.Create(cacheData.userid, usedSilver, type);
        //}

        public void UpdateGold_CountTimex10QuayTuong(MUserInfo userInfo, int timex10QuayTuong, int goldUsed)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"gold",userInfo.gold},
                {"count_time_x10_quoay_tuong_special",timex10QuayTuong},
            };

            UpdateFields(userInfo._id, dictData);

            MongoController.LogDb.ActionGold.CreateSpentGoldLog
            (
                userid: userInfo._id,
                oldGlod: userInfo.gold + goldUsed,
                spentGold: goldUsed,
                newGold: userInfo.gold,
                reason: ReasonActionGold.QuayTuongx10
            );
        }

        public void UpdateGold_Silver(PlayerCacheData data, int goldUsed)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"gold",data.gold},
                {"silver",data.silver},
            };
            UpdateFields(data.id, dictData);
            //MongoController.LogDb.UsedGold.Create(data.userid, goldUsed, TypeUseGold.ExchangeGoldToSilver);
            MongoController.LogDb.ActionGold.CreateSpentGoldLog
            (
                userid: data.id,
                oldGlod: data.gold + goldUsed,
                spentGold: goldUsed,
                newGold: data.gold,
                reason: ReasonActionGold.ExchangeGoldToSilver
            );
        }

        public void UpdatePlusStamina(PlayerCacheData userInfo)
        {
            var data = new Dictionary<string, object>
            {
                { "stamina", userInfo.stamina },
            };
            if (userInfo.stamina >= StaticDatabase.entities.configs.maxStamina)
            {
                userInfo.last_time_update_stamina = new DateTime();
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }
            else
            {
                userInfo.last_time_update_stamina = DateTime.Now;
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }

            UpdateFields(userInfo.id, data);
        }

        public void UpdatePlusStamina(MUserInfo userInfo)
        {
            var data = new Dictionary<string, object>
            {
                { "stamina", userInfo.stamina },
            };
            if (userInfo.stamina >= StaticDatabase.entities.configs.maxStamina)
            {
                userInfo.last_time_update_stamina = new DateTime();
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }
            else
            {
                userInfo.last_time_update_stamina = DateTime.Now;
                data.Add("last_time_update_stamina", userInfo.last_time_update_stamina);
            }

            UpdateFields(userInfo._id, data);
        }

        public void UpdatePlusPointSkill(PlayerCacheData userInfo)
        {
            userInfo.last_time_update_point_skill =
                userInfo.point_skill == StaticDatabase.entities.configs.pointSkillConfig.maxPointSkillCanReach ?
                new DateTime() : DateTime.Now;

            var data = new Dictionary<string, object>
            {
                { "point_skill", userInfo.point_skill },
                { "last_time_update_point_skill", userInfo.last_time_update_point_skill},

            };
            UpdateFields(userInfo.id, data);
        }

        public void UpdateBonusThanThap(string id, int all_bonus_than_thap_attributes)
        {
            var data = new Dictionary<string, object> { { "all_bonus_than_thap_attributes", all_bonus_than_thap_attributes } };
            UpdateFields(id, data);
        }

        public void UpdateRank(MUserInfo userInfo)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"rank_luan_kiem",userInfo.rank_luan_kiem}
            };
            UpdateFields(userInfo._id, dictData);
        }

        public void UpdatePointLuanKiem(PlayerCacheData userInfo)
        {
            var data = new Dictionary<string, object> { { "point_luan_kiem", userInfo.pointLuanKiem } };
            UpdateFields(userInfo.id, data);
        }

        public void UpdateVip(PlayerCacheData userInfo)
        {
            var data = new Dictionary<string, object>
            {
                {"vip",userInfo.vip},
            };
            UpdateFields(userInfo.id, data);
        }

        //public void UpdateRuby_Gold(PlayerCacheData userInfo)
        //{
        //    var data = new Dictionary<string, object>
        //    {
        //        {"ruby",userInfo.ruby}
        //    };
        //    UpdateFields(userInfo.id, data);
        //}

        public void UpdateRankLuanKieSubRewardItemed(string id, List<int> rankRewarded)
        {
            var dictData = new Dictionary<string, List<int>>
            {
                { "index_rank_luan_kiem_rewarded", rankRewarded }
            };
            UpdateFields(id, dictData);
        }

        public void UpdateChucPhuc(MUserInfo userInfo)
        {
            var data = new Dictionary<string, object>
            {
                {"count_chuc_phuc", userInfo.count_chuc_phuc},
                {"hash_code_time_chuc_phuc", userInfo.hash_code_time_chuc_phuc}
            };
            UpdateFields(userInfo._id, data);
        }

        public void UpdateVipRewarded(MUserInfo userInfo)
        {
            var data = new Dictionary<string, object>
            {
                {"vip_rewarded",userInfo.vip_rewarded}
            };
            UpdateFields(userInfo._id, data);
        }

        public void UpdateTutorial(string id, int tutorial)
        {
            var data = new Dictionary<string, object>
            {
                { "tutorial",tutorial}
            };
            UpdateFields(id, data);
        }

        public void UpdateRuby(PlayerCacheData userInfo)
        {
            var data = new Dictionary<string, object>
            {
                { "ruby",userInfo.ruby}
            };
            UpdateFields(userInfo.id, data);
        }

        public void UpdateRuby_TotalRubyTrans(PlayerCacheData userInfo)
        {
            var data = new Dictionary<string, object>
            {
                { "ruby",userInfo.ruby},
                { "total_ruby_trans",userInfo.total_ruby_trans},
            };
            UpdateFields(userInfo.id, data);
        }

        public void UpdateTotalRubyTrans(PlayerCacheData userInfo)
        {
            var data = new Dictionary<string, double>
            {
                { "total_ruby_trans",userInfo.total_ruby_trans}
            };
            UpdateFields(userInfo.id, data);
        }

        public void UpdatePosition(PlayerCacheData userInfo)
        {
            if (userInfo != null)
            {
                var data = new Dictionary<string, double>
                {
                    { "posX",userInfo.x},
                    { "posY",userInfo.y},
                };
                UpdateFields(userInfo.id, data);
            }
        }

        public void UpdateInviteFriend(string _id, int num)
        {
            UpdateOneInc(_id, "invite_friend", num);
        }

        public List<MUserInfo> GetTopPlayersLuanKiem(int top)
        {
            return
                GetListDataAscending
                    (
                        a => a.rank_luan_kiem <= top &&
                            a.rank_luan_kiem > 0 &&
                        a.server_id == Settings.Instance.server_id,
                        a => a.rank_luan_kiem,
                        0,
                        top
                    );
        }


    }
}

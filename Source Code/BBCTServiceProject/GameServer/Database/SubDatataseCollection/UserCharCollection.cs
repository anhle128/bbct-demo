using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserCharCollection : AbsCollectionController<MUserCharacter>
    {
        public UserCharCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexStaticData(Collection);
        }

        public MUserCharacter GetData(string userid, int staticId)
        {
            return
                GetSingleData(
                    a =>
                        a.user_id.Equals(userid) &&
                        a.static_id == staticId);
        }

        public List<MUserCharacter> GetDatas(string userId)
        {
            return GetListData(a => a.user_id.Equals(userId));
        }

        protected override void SetDefaultValue(MUserCharacter data)
        {
            Character character = StaticDatabase.entities.characters.Single(x => x.id == data.static_id);

            if (data.star_level == 0)
            {
                data.star_level = character.lowestStarLevel;
            }

            if (data.equipments == null)
            {
                data.equipments = new List<string>() { "-1", "-1", "-1", "-1", "-1", "-1" };
            }

            data.active_skills = new List<LevelSkill>();

            foreach (var skill in character.ultimateSkill)
            {
                data.active_skills.Add(new LevelSkill()
                {
                    star = StaticDatabase.entities.configs.characterConfig.defaultConfig.starSkill,
                    level = StaticDatabase.entities.configs.characterConfig.defaultConfig.levelSkill
                });
            }

            data.passive_skill = new LevelSkill()
            {
                star = StaticDatabase.entities.configs.characterConfig.defaultConfig.starSkill,
                level = StaticDatabase.entities.configs.characterConfig.defaultConfig.levelSkill
            };
        }

        private void Update_Exp_Level_LevelSkill(string id, int exp, int level, List<LevelSkill> level_skills, bool isOpendNewSkill)
        {
            if (isOpendNewSkill)
            {
                var data = new Dictionary<string, object>
                {
                    { "exp", exp },
                    { "level", level },
                    {"level_skills",level_skills}
                };
                UpdateFields(id, data);
            }
            else
            {
                var data = new Dictionary<string, object>
                {
                    { "exp", exp },
                    { "level", level },
                };
                UpdateFields(id, data);
            }

        }


        //public int CountCharWithPromotion(string userid, int promotion)
        //{
        //    List<int> listChar =
        //        StaticDatabase.entities.mainChars.Where(a => a.promotion == promotion).Select(a => a.id).ToList();
        //    List<MUserCharacter> listUserChar = MongoController.UserDb.Char.GetDatas(userid);
        //    return listChar.Sum(idChar => listUserChar.CoundLogInDay(a => a.static_id == idChar));
        //}


        public void UpdateEquipments(MUserCharacter data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1);
            dictData.Add("equipments", data.equipments);
            UpdateFields(data._id, dictData);
        }

        public void UpdateStarLevel(MUserCharacter data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1);
            dictData.Add("star_level", data.star_level);
            dictData.Add("level", data.level);
            dictData.Add("powerup_level", data.powerup_level);
            UpdateFields(data._id, dictData);
        }



        public void Update_Level_Exp_Skill(MUserCharacter data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(2);
            dictData.Add("level", data.level);
            dictData.Add("exp", data.exp);
            dictData.Add("active_skills", data.active_skills);
            dictData.Add("passive_skill", data.passive_skill);
            UpdateFields(data._id, dictData);
        }



        public void Update_PowerupLevel(MUserCharacter data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(2);
            dictData.Add("powerup_level", data.powerup_level);
            dictData.Add("exp", data.exp);
            UpdateFields(data._id, dictData);
        }

        public void UpdateLevelSkill(MUserCharacter data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1);
            dictData.Add("active_skills", data.active_skills);
            dictData.Add("passive_skill", data.passive_skill);
            UpdateFields(data._id, dictData);
        }

        public void UpdateCharBattleResult(List<CharBattleResult> listChar)
        {
            string[] filters = new string[listChar.Count];
            Dictionary<string, object>[] listUpdates = new Dictionary<string, object>[listChar.Count];

            for (int i = 0; i < listChar.Count; i++)
            {
                var data = listChar[i];

                Dictionary<string, object> dictUpdate = new Dictionary<string, object>()
                {
                    { "exp", data.exp },
                    { "level", data.level }
                };

                filters[i] = (data._id);
                listUpdates[i] = dictUpdate;
            }

            UpdateManyFields(filters, listUpdates);
        }

        public void Update_Level_Exp(MUserCharacter character)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>();
            dictData.Add("level", character.level);
            dictData.Add("exp", character.exp);
            UpdateFields(character._id, dictData);
        }
    }
}

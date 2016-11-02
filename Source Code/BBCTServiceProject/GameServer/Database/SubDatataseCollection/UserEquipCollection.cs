using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserEquipCollection : AbsCollectionController<MUserEquip>
    {
        public UserEquipCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexStaticData(Collection);
        }

        public List<MUserEquip> GetEquipUsed(string userId)
        {
            return GetListData(a => a.user_id == userId && a.char_equip != "-1");
        }

        public int CountEquipWithPowerupLevel(string userId, int level)
        {
            return CountData(a => a.user_id.Equals(userId) && a.powerup_level >= level);
        }

        public List<MUserEquip> GetDatas(string userId)
        {
            return GetListData(a => a.user_id.Equals(userId));
        }

        public MUserEquip GetData(string idEquipment)
        {
            return GetSingleData(
                     a => a._id.Equals(idEquipment));
        }

        protected override void SetDefaultValue(MUserEquip data)
        {
            Equipment equip = StaticDatabase.entities.equipments.Single(a => a.id == data.static_id);
            data.star_level = equip.lowestStarLevel;
            data.powerup_level = StaticDatabase.entities.configs.equipmentConfig.defaultConfig.powerup;
            data.char_equip = "-1";
        }

        public void UpdateOwner(string id, string userid)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("user_id", userid);
            UpdateFields(id, dict);
        }

        public void UpdateStarLevel(MUserEquip data)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("star_level", data.star_level);
            dict.Add("static_id", data.static_id);
            UpdateFields(data._id, dict);
        }

        public void UpdateCharEquip(MUserEquip data)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("char_equip", data.char_equip);
            dict.Add("static_id", data.static_id);
            UpdateFields(data._id, dict);
        }

        public void RemoveCharEquip(string id)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"char_equip","-1"}
            };

            UpdateFields(id, dictData);
        }
    }
}

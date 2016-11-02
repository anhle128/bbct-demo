using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server
{
    public class PlayerCacheData
    {
        public string loginId { get; set; }
        public MUserInfo info { get; set; }
        public MUserStage stageAttacked { get; set; }
        public int allBonusThanThapAttributes { get; set; }
        public MUserThanThap thanThapAttacked { get; set; }
        public MUserGlobalBoss userGlobalBoss { get; set; }
        public string guildName { get; set; }
        public string guildId { get; set; }

        //public string vanTieuId { get; set; }
        //public string id { get; set; }
        //public string username { get; set; }
        //public string nickname { get; set; }
        //public int avatar { get; set; }
        //public int level { get; set; }
        //public int exp { get; set; }
        //public int vip { get; set; }
        //public int title { get; set; }
        //public float x { get; set; }
        //public float y { get; set; }

        //public int silver { get; set; }
        //public int gold { get; set; }
        //public int ruby { get; set; }
        //public int avatar_star { get; set; }
        //public StageMode lastest_stage_attacked { get; set; }
        //public StageMode highest_stages_attacked { get; set; }
        //public int stamina { get; set; }
        //public int point_skill { get; set; }
        //public DateTime last_time_update_stamina { get; set; }
        //public DateTime list_time_update_point_skill { get; set; }


        //public int pointLuanKiem { get; set; }
        //public int rankLuanKiem { get; set; }
        //public DateTime lastTimeAttackLuanKiem { get; set; }

        //public int idMainChar { get; set; }
        //public double total_ruby_trans { get; set; }
        //public DateTime create_at { get; set; }
        //public DateTime last_time_update_point_skill { get; set; }
        //public DataFormation[] formations { get; set; }

        #region user item
        public List<MUserItem> listUserItem { get; set; }

        public void DeleteUserItem(MUserItem userItem)
        {
            listUserItem.Remove(userItem);
            MongoController.UserDb.Item.Delete(userItem._id);
        }
        #endregion

        #region user equipment
        public List<MUserEquip> listUserEquip { get; set; }

        public void CreateUserEquip(MUserEquip userEquip)
        {
            listUserEquip.Add(userEquip);
            MongoController.UserDb.Equip.Create(userEquip);
        }

        public void DeleteUserEquipment(string equipId)
        {
            MUserEquip muserEquip = listUserEquip.FirstOrDefault(a => a._id.ToString() == equipId);
            listUserEquip.Remove(muserEquip);
            MongoController.UserDb.Equip.Delete(muserEquip._id);
        }
        public void RemoveOwnEquipment(MUserEquip userEquip)
        {
            listUserEquip.Remove(userEquip);
            MongoController.UserDb.Equip.UpdateOwner(userEquip._id, null);
        }

        public void AddOwnOwnEquipment(MUserEquip userEquip)
        {
            listUserEquip.Add(userEquip);
            MongoController.UserDb.Equip.UpdateOwner(userEquip._id, userEquip.user_id);
        }
        #endregion

        #region user char
        public List<MUserCharacter> listUserChar { get; set; }

        public void CreateUserChar(MUserCharacter userChar)
        {
            listUserChar.Add(userChar);
            MongoController.UserDb.Char.Create(userChar);
        }
        #endregion
    }
}

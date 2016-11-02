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
    public class UserThanThapCollection : AbsCollectionController<MUserThanThap>
    {
        public UserThanThapCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);

        }


        public MUserThanThap GetData(string userid, int hashCodeTime)
        {
            return
                GetSingleData(
                    a => a.user_id.Equals(userid) && a.hash_code_time == hashCodeTime);
        }


        public List<MTopThanPhapLog> GetTopUsers(int number, int hashCodeTime)
        {
            List<MUserThanThap> listUserThanThap = GetListDataDescending
            (
                a =>
                    a.server_id.Equals(Settings.Instance.server_id) &&
                    a.hash_code_time == hashCodeTime &&
                    a.floor > 1,
                a => a.floor,
                0,
                number
            );
            return listUserThanThap.Select(a => new MTopThanPhapLog()
            {
                server_id = a.server_id,
                hash_code_time = a.hash_code_time,
                user = new TopUserThanThap()
                {
                    userid = a.user_id.ToString(),
                    avatar = a.avatar,
                    star = a.star,
                    nickname = a.nickname,
                    group_id = Settings.Instance.group_id,
                    floor = a.floor,
                    total_day_in_top = 1
                }
            }).ToList();
        }

        public void UpdateBonusAttribute_DonePlusAttribute(MUserThanThap data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"bonus_attributes",data.bonus_attributes},
                {"star",data.star},
                {"bonus_attributes_selection",data.bonus_attributes_selection}
            };
            UpdateFields(data._id, dictData);
        }

        public void UpdateFloor(MUserThanThap data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"floor",data.floor},
                {"star",data.star},
                {"dead",data.dead},
                {"new_star",data.new_star},
            };
            UpdateFields(data._id, dictData);
        }

        public void UpdateResetTime_Dead(MUserThanThap data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"reset_times",data.reset_times},
                {"dead",data.dead},
            };
            UpdateFields(data._id, dictData);
        }

        public void UpdateEndFloor(MUserThanThap data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"bonus_attributes_selection",data.bonus_attributes_selection},
                {"monsters",data.monsters},
                {"star",data.star},
                {"dead",data.dead},
                {"new_star",data.new_star},
                {"floor",data.floor},
            };
            UpdateFields(data._id, dictData);
        }


    }
}

using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserInfo : IMongoModel
    {
        public string server_id { get; set; }
        public string username { get; set; }
        public int avatar_power_up { get; set; }
        public int avatar_star { get; set; }
        public List<int> vip_rewarded { get; set; }
        public string access_token { get; set; }
        public bool isBot { get; set; }
        public int hash_code_time_chuc_phuc { get; set; }
        public int count_chuc_phuc { get; set; }
        public int avatar { get; set; }
        [BsonRepresentation(BsonType.Double)]
        public double posX { get; set; }
        [BsonRepresentation(BsonType.Double)]
        public double posY { get; set; }
        public string nickname { get; set; }
        public int exp { get; set; }
        public int gold { get; set; }
        public int ruby { get; set; }
        public int silver { get; set; }
        public int stamina { get; set; }
        public int vip { get; set; }
        public int level { get; set; }
        public string[] first { get; set; }
        public int hash_code_login_time { get; set; }
        public int count_time_quoay_tuong_special { get; set; }
        public int count_time_x10_quoay_tuong_special { get; set; }
        public int count_time_x10_quoay_vat_pham { get; set; }
        public int reset_stage_times { get; set; }
        public StageMode lastest_stage_attacked { get; set; }
        public StageMode highest_stages_attacked { get; set; }
        public DataFormation[] formations { get; set; }
        public int lastFormationUsed { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime last_time_update_point_skill { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime last_time_update_stamina { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime last_time_free_quay_tuong_normal { get; set; }

        public int count_times_free_quay_tuong_normal { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime last_time_free_quay_tuong_special { get; set; }


        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime last_time_free_quay_vat_pham { get; set; }
        public int all_bonus_than_thap_attributes { get; set; }
        public List<int> index_rank_luan_kiem_rewarded { get; set; }
        public int rank_luan_kiem { get; set; }
        public int point_luan_kiem { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime last_time_attack_luan_kiem { get; set; }

        public bool isLocked { get; set; }

        public List<int> index_level_rewarded { get; set; }
        public List<int> index_invite_rewarded { get; set; }
        public int tutorial { get; set; }
        public int hash_code_time_send_facebook { get; set; }
        public int invite_friend { get; set; }
        public double total_ruby_trans { get; set; }
        public MUserInfo()
        {

        }
    }
}

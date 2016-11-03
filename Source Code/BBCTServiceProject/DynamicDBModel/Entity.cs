using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace DynamicDBModel
{
    [ProtoContract]
    public class Entity
    {

        [ProtoMember(1)]
        public UserInfo info { get; set; }
        [ProtoMember(2)]
        public List<UserEquip> equips { get; set; }
        [ProtoMember(3)]
        public List<UserEquipPiece> equip_pieces { get; set; }
        [ProtoMember(4)]
        public List<UserCharacter> characters { get; set; }
        [ProtoMember(5)]
        public List<UserCharSoul> charSouls { get; set; }
        [ProtoMember(6)]
        public List<UserItem> items { get; set; }
        [ProtoMember(7)]
        public List<UserPowerUpItem> power_up_item { get; set; }
        [ProtoMember(8)]
        public List<UserMail> mails { get; set; }
        [ProtoMember(9)]
        public List<SystemMail> system_mails { get; set; }
        [ProtoMember(11)]
        public List<UserStage> stages { get; set; }
        [ProtoMember(12)]
        public StageMode lastest_stage_attacked { get; set; }
        [ProtoMember(13)]
        public StageMode highest_stage_attacked { get; set; }
        [ProtoMember(14)]
        public List<int> indexRankLuanKiemRewarded { get; set; }
        [ProtoMember(15)]
        public List<NhiemVuHangNgayData> nhiem_vu_hang_ngay { get; set; }
        [ProtoMember(16)]
        public List<NhiemVuChinhTuyenData> nhiem_vu_chinh_tuyen { get; set; }
        [ProtoMember(17)]
        public List<VipReward> vipRewards { get; set; }
        [ProtoMember(18)]
        public List<TypeSuKien> suKienActivate { get; set; }
        [ProtoMember(19)]
        public List<int> index_level_rewarded { get; set; }
        [ProtoMember(20)]
        public DateTime server_time { get; set; }
        [ProtoMember(21)]
        public List<UserStarReward> star_rewards { get; set; }
        [ProtoMember(22)]
        public List<int> index_invite_rewarded { get; set; }
        [ProtoMember(23)]
        public int countTimesHuaNguyen { get; set; }
        [ProtoMember(24)]
        public int countTimeBuyPointSkill { get; set; }
        [ProtoMember(25)]
        public DataFormation[] formations { get; set; }

        public Entity()
        {

        }
    }
}

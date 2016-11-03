using ProtoBuf;
using System;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserInfo
    {
        [ProtoMember(1)]
        public string username { get; set; }
        [ProtoMember(2)]
        public string nickname { get; set; }
        [ProtoMember(3)]
        public int avatar { get; set; }
        [ProtoMember(4)]
        public float posX { get; set; }
        [ProtoMember(5)]
        public float posY { get; set; }
        [ProtoMember(6)]
        public int exp { get; set; }
        [ProtoMember(7)]
        public int gold { get; set; }
        [ProtoMember(8)]
        public int silver { get; set; }
        [ProtoMember(9)]
        public int stamina { get; set; }
        [ProtoMember(10)]
        public int vip { get; set; }
        [ProtoMember(11)]
        public int level { get; set; }
        [ProtoMember(12)]
        public int title { get; set; }
        [ProtoMember(13)]
        public double total_ruby_trans { get; set; }
        [ProtoMember(14)]
        public int ruby { get; set; }
        [ProtoMember(16)]
        public string guildName { get; set; }
        [ProtoMember(18)]
        public List<int> vipRewarded { get; set; }
        [ProtoMember(19)]
        public int count_chuc_phuc { get; set; }
        [ProtoMember(20)]
        public bool isChucPhuc { get; set; }
        [ProtoMember(21)]
        public bool isSendFacebook { get; set; }
        [ProtoMember(22)]
        public bool isRatedStore { get; set; }
        [ProtoMember(23)]
        public int tutorial { get; set; }
        [ProtoMember(24)]
        public int idMainChar { get; set; }
        [ProtoMember(25)]
        public DateTime create_at { get; set; }
        [ProtoMember(26)]
        public int inviteFriend { get; set; }

        public UserInfo()
        {

        }
    }
}

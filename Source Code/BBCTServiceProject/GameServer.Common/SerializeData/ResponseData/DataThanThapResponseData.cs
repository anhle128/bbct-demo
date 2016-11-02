using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class DataThanThapResponseData : ISerializeData
    {
        public int reset_attack_times;
        public int floor;
        public List<TopReward> top_10_rewards;
        public List<TopUserThanThap> priv_top_users;
        public int[] bonus_attributes;
        public int[] bonus_attributes_selection;
        public int[] monster;
        public bool dead;
        public int star;
        public int all_bonus_tran_phap_attribute;


        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(4);
            data.Add(1, reset_attack_times);
            data.Add(2, floor);
            data.Add(5, ProtoBufSerializerHelper.Handler().Serialize<List<TopReward>>(top_10_rewards));
            data.Add(6, ProtoBufSerializerHelper.Handler().Serialize<List<TopUserThanThap>>(priv_top_users));
            data.Add(7, ProtoBufSerializerHelper.Handler().Serialize<int[]>(bonus_attributes));
            data.Add(8, ProtoBufSerializerHelper.Handler().Serialize<int[]>(bonus_attributes_selection));
            data.Add(9, ProtoBufSerializerHelper.Handler().Serialize<int[]>(monster));
            data.Add(10, dead);
            data.Add(11, star);
            data.Add(12, all_bonus_tran_phap_attribute);

            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            reset_attack_times = int.Parse(data[1].ToString());
            floor = int.Parse(data[2].ToString());
            top_10_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<TopReward>>(data[5] as byte[]);
            priv_top_users = ProtoBufSerializerHelper.Handler().Deserialize<List<TopUserThanThap>>(data[6] as byte[]);
            bonus_attributes = ProtoBufSerializerHelper.Handler().Deserialize<int[]>(data[7] as byte[]);
            bonus_attributes_selection = ProtoBufSerializerHelper.Handler().Deserialize<int[]>(data[8] as byte[]);
            monster = ProtoBufSerializerHelper.Handler().Deserialize<int[]>(data[9] as byte[]);
            dead = bool.Parse(data[10].ToString());
            star = int.Parse(data[11].ToString());

            if (priv_top_users == null)
                priv_top_users = new List<TopUserThanThap>();

            all_bonus_tran_phap_attribute = (int)data[12];
        }
    }
}

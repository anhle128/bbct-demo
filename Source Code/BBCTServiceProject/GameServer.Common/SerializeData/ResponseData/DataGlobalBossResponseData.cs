using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class DataGlobalBossResponseData : ISerializeData
    {
        public double time_boss;
        public double total_damage;
        public double time_attack;
        public TopUsersGlobalBoss current_top_users;
        public TopUsersGlobalBoss prev_top_users;
        public bool in_time_attack_boss;
        public List<TopReward> top_10_rewards;
        public double maxBossHp;
        public double currentBossHp;
        public int indexTimeAttackBoss;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, time_boss);
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize<double>(time_attack));
            data.Add(4, total_damage);
            data.Add(5, ProtoBufSerializerHelper.Handler().Serialize<TopUsersGlobalBoss>(current_top_users));
            data.Add(6, ProtoBufSerializerHelper.Handler().Serialize<TopUsersGlobalBoss>(prev_top_users));
            data.Add(8, in_time_attack_boss);
            data.Add(9, ProtoBufSerializerHelper.Handler().Serialize<List<TopReward>>(top_10_rewards));
            data.Add(10, maxBossHp);
            data.Add(11, currentBossHp);
            data.Add(12, indexTimeAttackBoss);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            time_boss = (double)data[1];
            time_attack = ProtoBufSerializerHelper.Handler().Deserialize<double>(data[2] as byte[]);
            total_damage = (double)data[4];
            current_top_users = ProtoBufSerializerHelper.Handler().Deserialize<TopUsersGlobalBoss>(data[5] as byte[]);
            prev_top_users = ProtoBufSerializerHelper.Handler().Deserialize<TopUsersGlobalBoss>(data[6] as byte[]);
            in_time_attack_boss = (bool)data[8];
            top_10_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<TopReward>>(data[9] as byte[]);
            maxBossHp = (double)data[10];
            currentBossHp = (double)data[11];
            indexTimeAttackBoss = (int)data[12];

        }
    }
}

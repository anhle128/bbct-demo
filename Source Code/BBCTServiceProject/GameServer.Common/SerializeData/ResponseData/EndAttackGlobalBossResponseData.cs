using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;
using DynamicDBModel.Models.Battle;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class EndAttackGlobalBossResponseData : ISerializeData
    {
        public double time_boss;
        public int user_silver;
        public TopUsersGlobalBoss current_top_users;
        public List<RewardItem> rewards;
        public BattleReplay replay;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, time_boss);
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize(current_top_users));
            data.Add(3, user_silver);
            data.Add(4, ProtoBufSerializerHelper.Handler().Serialize(rewards));
            data.Add(5, ProtoBufSerializerHelper.Handler().Serialize(replay));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            time_boss = (double)data[1];
            current_top_users = ProtoBufSerializerHelper.Handler().Deserialize<TopUsersGlobalBoss>(data[2] as byte[]);
            user_silver = (int)data[3];
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[4] as byte[]);
            replay = ProtoBufSerializerHelper.Handler().Deserialize<BattleReplay>(data[5] as byte[]);
        }
    }
}

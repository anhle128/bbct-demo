using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;
using DynamicDBModel.Models.Battle;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class AttackStageResponseData : ISerializeData
    {
        public int reward_silver;
        public int level_player;
        public int exp_player;
        public int reward_exp_player;
        public int reward_exp_character;
        public List<RewardItem> rewards;
        public List<CharBattleResult> chars;
        public BattleReplay replay;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize(rewards));
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize(chars));
            data.Add(3, reward_silver);
            data.Add(4, level_player);
            data.Add(5, exp_player);
            data.Add(6, reward_exp_player);
            data.Add(7, reward_exp_character);
            data.Add(8, ProtoBufSerializerHelper.Handler().Serialize(replay));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[1] as byte[]);
            chars = ProtoBufSerializerHelper.Handler().Deserialize<List<CharBattleResult>>(data[2] as byte[]);
            reward_silver = (int)data[3];
            level_player = (int)data[4];
            exp_player = (int)data[5];
            reward_exp_player = (int)data[6];
            reward_exp_character = (int)data[7];

            if (data.ContainsKey(8) && data[8] != null)
                replay = ProtoBufSerializerHelper.Handler().Deserialize<BattleReplay>(data[8] as byte[]);

        }
    }
}

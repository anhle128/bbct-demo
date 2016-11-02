using DynamicDBModel.Models;
using DynamicDBModel.Models.Battle;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class RewardResponseData : ISerializeData
    {
        public List<RewardItem> rewards;
        public int user_gold;
        public int user_silver;
        public int user_level;
        public int user_exp;
        public int user_ruby;
        public BattleReplay replay;

        public RewardResponseData()
        {

        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(6);
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize(rewards));
            data.Add(2, user_gold);
            data.Add(3, user_silver);
            data.Add(4, user_level);
            data.Add(5, user_exp);
            data.Add(6, user_ruby);
            data.Add(7, ProtoBufSerializerHelper.Handler().Serialize(replay));

            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[1] as byte[]);
            user_gold = (int)data[2];
            user_silver = (int)data[3];
            user_level = (int)data[4];
            user_exp = (int)data[5];
            user_ruby = (int)data[6];
            replay = ProtoBufSerializerHelper.Handler().Deserialize<BattleReplay>(data[7] as byte[]);
        }
    }
}

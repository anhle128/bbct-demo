using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetRewardVongQuayMayManResponseData : ISerializeData
    {
        public int user_gold;
        public int user_silver;
        public List<SubRewardItem> show_rewards;
        public List<RewardItem> rewards;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<List<RewardItem>>(rewards));
            data.Add(2, user_gold);
            data.Add(3, user_silver);
            data.Add(4, ProtoBufSerializerHelper.Handler().Serialize<List<SubRewardItem>>(show_rewards));

            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[1] as byte[]);
            user_gold = (int)data[2];
            user_silver = (int)data[3];
            show_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<SubRewardItem>>(data[4] as byte[]);

        }
    }
}

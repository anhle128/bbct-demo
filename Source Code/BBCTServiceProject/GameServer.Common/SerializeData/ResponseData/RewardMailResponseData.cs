
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class RewardMailResponseData : ISerializeData
    {
        public List<RewardItem> rewards;
        public int user_gold;
        public int user_silver;
        public int user_ruby;
        public int user_vip;
        public double user_total_ruby_trans;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(8);
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize(rewards));
            data.Add(2, user_gold);
            data.Add(3, user_silver);
            data.Add(4, user_ruby);
            data.Add(5, user_vip);
            data.Add(6, user_total_ruby_trans);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[1] as byte[]);
            user_gold = (int)data[2];
            user_silver = (int)data[3];
            user_ruby = (int)data[4];
            user_vip = (int)data[5];
            user_total_ruby_trans = (double)data[6];
        }
    }
}

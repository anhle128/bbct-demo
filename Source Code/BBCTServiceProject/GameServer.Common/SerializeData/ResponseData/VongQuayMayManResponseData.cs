using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class VongQuayMayManResponseData : ISerializeData
    {
        public int max_free_times;
        public int free_times;
        public double rest_time;
        public SubRewardItem[] rewards;
        public int price;
        public int x10_price;
        public int total_point;
        public List<int> index_point_receiveds;
        public List<PointVongQuayMayManReward> point_rewards;
        public List<TopReward> top_rewards;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(10)
            {
                {1,max_free_times},
                {2,free_times},
                {3,rest_time},
                {4,ProtoBufSerializerHelper.Handler().Serialize(rewards)},
                {5, price},
                {6, x10_price},
                {7, total_point},
                {8, ProtoBufSerializerHelper.Handler().Serialize(index_point_receiveds)},
                {9, ProtoBufSerializerHelper.Handler().Serialize(point_rewards)},
                {10, ProtoBufSerializerHelper.Handler().Serialize(top_rewards)},
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            max_free_times = (int)data[1];
            free_times = (int)data[2];
            rest_time = (double)data[3];
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<SubRewardItem[]>(data[4] as byte[]);
            price = (int)data[5];
            x10_price = (int)data[6];
            total_point = (int)data[7];
            index_point_receiveds = ProtoBufSerializerHelper.Handler().Deserialize<List<int>>(data[8] as byte[]);
            if (index_point_receiveds == null)
                index_point_receiveds = new List<int>();
            point_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<PointVongQuayMayManReward>>(data[9] as byte[]);
            top_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<TopReward>>(data[10] as byte[]);

        }
    }
}

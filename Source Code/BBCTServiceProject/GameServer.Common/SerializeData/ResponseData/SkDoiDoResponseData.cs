using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SkDoiDoResponseData : ISerializeData
    {

        public int total_point;
        public int current_point;
        public int gold_require_refesh;
        public double rest_time_refesh;
        public List<ItemDoiDo> exchange_items;
        public List<int> index_exchanged;
        public DateTime end_time;
        public List<TopRewardDoiDo> top_rewards;
        public List<PointDoiDoReward> point_rewards;
        public List<IndexReceived> index_recieveds;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(10)
           {
               {1,total_point},
               {2, current_point},
               {3, gold_require_refesh},
               {4, rest_time_refesh},
               {5, ProtoBufSerializerHelper.Handler().Serialize(exchange_items)},
               {6, ProtoBufSerializerHelper.Handler().Serialize(index_exchanged)},
               {7, ProtoBufSerializerHelper.Handler().Serialize(end_time)},
               {8, ProtoBufSerializerHelper.Handler().Serialize(top_rewards)},
               {9, ProtoBufSerializerHelper.Handler().Serialize(point_rewards)},
               {10, ProtoBufSerializerHelper.Handler().Serialize(index_recieveds)},
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            total_point = (int)data[1];
            current_point = (int)data[2];
            gold_require_refesh = (int)data[3];
            rest_time_refesh = (double)data[4];
            exchange_items = ProtoBufSerializerHelper.Handler().Deserialize<List<ItemDoiDo>>(data[5] as byte[]);
            index_exchanged = ProtoBufSerializerHelper.Handler().Deserialize<List<int>>(data[6] as byte[]);
            if (index_exchanged == null)
                index_exchanged = new List<int>();
            end_time = ProtoBufSerializerHelper.Handler().Deserialize<DateTime>(data[7] as byte[]);
            top_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<TopRewardDoiDo>>(data[8] as byte[]);
            point_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<PointDoiDoReward>>(data[9] as byte[]);
            index_recieveds = ProtoBufSerializerHelper.Handler().Deserialize<List<IndexReceived>>(data[10] as byte[]);

            if (index_recieveds == null)
                index_recieveds = new List<IndexReceived>();
        }
    }
}

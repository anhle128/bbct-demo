using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SkTichLuyTieuResponseData : ISerializeData
    {
        public double total_used_gold;
        public List<GoldReward> gold_rewards;
        public DateTime end_time;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(2)
           {
               {1,total_used_gold},
               {2, ProtoBufSerializerHelper.Handler().Serialize(gold_rewards)},
               {3, ProtoBufSerializerHelper.Handler().Serialize(end_time)},
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            total_used_gold = (double)data[1];
            gold_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<GoldReward>>(data[2] as byte[]);
            end_time = ProtoBufSerializerHelper.Handler().Deserialize<DateTime>(data[3] as byte[]);
        }
    }
}

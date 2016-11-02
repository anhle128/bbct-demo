using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SkTichLuyNapResponseData : ISerializeData
    {
        public double total_trans_gold;
        public TypeSuKienTichLuyNap type;
        public List<GoldReward> gold_rewards;
        public DateTime end_time;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(4)
           {
               {1,total_trans_gold},
               {2, ProtoBufSerializerHelper.Handler().Serialize(gold_rewards)},
               {3,type},
               {4, ProtoBufSerializerHelper.Handler().Serialize(end_time)},

           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            total_trans_gold = (double)data[1];
            gold_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<GoldReward>>(data[2] as byte[]);
            type = (TypeSuKienTichLuyNap)data[3];
            end_time = ProtoBufSerializerHelper.Handler().Deserialize<DateTime>(data[4] as byte[]);

        }
    }
}

using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SkDuaTopServerResponseData : ISerializeData
    {
        public List<TopReward> top_level_rewards;
        public List<TopReward> top_power_rewards;
        public List<TopUser> top_level_player;
        public List<TopUser> top_power_player;
        public DateTime end_time;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(3)
           {
               {1, ProtoBufSerializerHelper.Handler().Serialize(top_level_rewards)},
               {2, ProtoBufSerializerHelper.Handler().Serialize(top_power_rewards)},
               {3, ProtoBufSerializerHelper.Handler().Serialize(top_level_player)},
               {4, ProtoBufSerializerHelper.Handler().Serialize(top_power_player)},
               {5, ProtoBufSerializerHelper.Handler().Serialize(end_time)}
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            top_level_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<TopReward>>(data[1] as byte[]);
            top_power_rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<TopReward>>(data[2] as byte[]);
            top_level_player = ProtoBufSerializerHelper.Handler().Deserialize<List<TopUser>>(data[3] as byte[]);
            top_power_player = ProtoBufSerializerHelper.Handler().Deserialize<List<TopUser>>(data[4] as byte[]);
            end_time = ProtoBufSerializerHelper.Handler().Deserialize<DateTime>(data[5] as byte[]);
        }
    }
}

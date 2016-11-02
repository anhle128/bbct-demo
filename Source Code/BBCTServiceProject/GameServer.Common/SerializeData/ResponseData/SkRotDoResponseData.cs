using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SkRotDoResponseData : ISerializeData
    {
        public DateTime end_time;
        public List<IndexReceived> index_receiveds;
        public List<RotDoReward> rewards;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(3)
           {
               {1, ProtoBufSerializerHelper.Handler().Serialize(end_time)},
               {2, ProtoBufSerializerHelper.Handler().Serialize(index_receiveds)},
               {3, ProtoBufSerializerHelper.Handler().Serialize(rewards)},
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {

            end_time = ProtoBufSerializerHelper.Handler().Deserialize<DateTime>(data[1] as byte[]);

            index_receiveds = ProtoBufSerializerHelper.Handler().Deserialize<List<IndexReceived>>(data[2] as byte[]);
            if (index_receiveds == null)
                index_receiveds = new List<IndexReceived>();

            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RotDoReward>>(data[3] as byte[]);
        }
    }
}

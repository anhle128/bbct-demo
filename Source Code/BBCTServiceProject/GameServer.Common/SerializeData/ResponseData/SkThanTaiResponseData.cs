using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SkThanTaiResponseData : ISerializeData
    {
        public int current_index_reward;
        public List<int> gold_requires;
        public DateTime end_time;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(3)
           {
               {1, current_index_reward},
               {2, ProtoBufSerializerHelper.Handler().Serialize(gold_requires)},
               {3, ProtoBufSerializerHelper.Handler().Serialize(end_time)}
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            current_index_reward = (int)data[1];
            gold_requires = ProtoBufSerializerHelper.Handler().Deserialize<List<int>>(data[2] as byte[]);
            end_time = ProtoBufSerializerHelper.Handler().Deserialize<DateTime>(data[3] as byte[]);
        }
    }
}

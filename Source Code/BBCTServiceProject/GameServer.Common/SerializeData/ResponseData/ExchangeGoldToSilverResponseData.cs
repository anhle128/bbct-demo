
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class ExchangeGoldToSilverResponseData : ISerializeData
    {
        public int total_time_exchange { get; set; }
        public int user_silver { get; set; }
        public int user_glod { get; set; }
        public List<RewardItem> rewards { get; set; }
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>()
           {
               {1, total_time_exchange},
               {3, user_silver},
               {4, user_glod},
               {5, ProtoBufSerializerHelper.Handler().Serialize(rewards)},
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            total_time_exchange = (int)data[1];
            user_silver = (int)data[3];
            user_glod = (int)data[4];
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[5] as byte[]);
        }
    }
}

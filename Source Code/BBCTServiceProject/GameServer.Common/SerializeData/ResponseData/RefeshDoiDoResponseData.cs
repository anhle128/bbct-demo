using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class RefeshDoiDoResponseData : ISerializeData
    {
        public int total_point;
        public int current_point;
        public int user_gold;
        public double rest_time_refesh;
        public List<ItemDoiDo> exchange_items;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(5)
           {
               {1, total_point},
               {2, current_point},
               {3, rest_time_refesh},
               {4, ProtoBufSerializerHelper.Handler().Serialize(exchange_items)},
               {5, user_gold},
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            total_point = (int)data[1];
            current_point = (int)data[2];
            rest_time_refesh = (double)data[3];
            exchange_items = ProtoBufSerializerHelper.Handler().Deserialize<List<ItemDoiDo>>(data[4] as byte[]);
            user_gold = (int)data[5];
        }
    }
}

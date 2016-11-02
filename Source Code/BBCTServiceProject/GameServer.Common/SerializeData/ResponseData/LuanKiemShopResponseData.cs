using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class LuanKiemShopResponseData : ISerializeData
    {
        public int rank;
        public double point;
        public List<LuanKiemShopItem> items;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
           {
               {1,ProtoBufSerializerHelper.Handler().Serialize(items)},
               {2, rank},
               {3,point}
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            items = ProtoBufSerializerHelper.Handler().Deserialize<List<LuanKiemShopItem>>(data[1] as byte[]);
            rank = (int)data[2];
            point = (double)data[3];
        }
    }
}

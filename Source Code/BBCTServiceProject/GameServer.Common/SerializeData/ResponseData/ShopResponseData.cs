using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class ShopResponseData : ISerializeData
    {
        public List<ShopItem> items;
        public List<LeBao> lebaos;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<List<ShopItem>>(items));
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize<List<LeBao>>(lebaos));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            items = ProtoBufSerializerHelper.Handler().Deserialize<List<ShopItem>>(data[1] as byte[]);
            lebaos = ProtoBufSerializerHelper.Handler().Deserialize<List<LeBao>>(data[2] as byte[]);
        }
    }
}

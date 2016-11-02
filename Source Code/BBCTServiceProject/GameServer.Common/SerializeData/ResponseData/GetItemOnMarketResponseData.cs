using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetItemOnMarketResponseData : ISerializeData
    {
        public List<ItemOnMarket> items;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<List<ItemOnMarket>>(items));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            items = ProtoBufSerializerHelper.Handler().Deserialize<List<ItemOnMarket>>(data[1] as byte[]);
        }
    }
}

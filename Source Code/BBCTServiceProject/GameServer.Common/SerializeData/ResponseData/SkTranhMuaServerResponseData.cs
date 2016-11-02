
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SkTranhMuaServerResponseData : ISerializeData
    {
        public DateTime end_time;
        public List<ItemTranhMua> items;
        public List<IndexReceived> index_recieveds;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(3)
            {
                {1,ProtoBufSerializerHelper.Handler().Serialize(end_time)},
                {2,ProtoBufSerializerHelper.Handler().Serialize(items)},
                {3,ProtoBufSerializerHelper.Handler().Serialize(index_recieveds)},
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            end_time = ProtoBufSerializerHelper.Handler().Deserialize<DateTime>(data[1] as byte[]);
            items = ProtoBufSerializerHelper.Handler().Deserialize<List<ItemTranhMua>>(data[2] as byte[]);
            index_recieveds = ProtoBufSerializerHelper.Handler().Deserialize<List<IndexReceived>>(data[3] as byte[]);
            if (index_recieveds == null)
                index_recieveds = new List<IndexReceived>();
        }
    }
}

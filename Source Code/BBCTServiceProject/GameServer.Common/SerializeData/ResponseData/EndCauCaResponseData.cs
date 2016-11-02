using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class EndCauCaResponseData : ISerializeData
    {
        public List<RewardItem> rewards;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<List<RewardItem>>(rewards));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[1] as byte[]);
        }
    }
}

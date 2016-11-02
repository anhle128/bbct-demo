using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class VongQuayMayManLogResponseData : ISerializeData
    {
        public List<SubRewardItem> rewards;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1, ProtoBufSerializerHelper.Handler().Serialize(rewards)}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<SubRewardItem>>(data[1] as byte[]);
            if (rewards == null)
                rewards = new List<SubRewardItem>();
        }
    }
}

using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class QuayTuongResponseData : ISerializeData
    {
        public int user_gold;
        public List<RewardItem> rewards;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, user_gold);
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize<List<RewardItem>>(rewards));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            user_gold = (int)data[1];
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[2] as byte[]);
        }
    }
}

using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class ChonTuongBanDauResponseData : ISerializeData
    {
        public RewardItem char_reward;
        public DataFormation formation;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize(char_reward));
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize(formation));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            char_reward = ProtoBufSerializerHelper.Handler().Deserialize<RewardItem>(data[1] as byte[]);
            formation = ProtoBufSerializerHelper.Handler().Deserialize<DataFormation>(data[2] as byte[]);
        }
    }
}

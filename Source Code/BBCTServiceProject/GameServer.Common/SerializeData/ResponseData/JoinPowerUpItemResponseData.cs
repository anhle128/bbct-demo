using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class JoinPowerUpItemResponseData : ISerializeData
    {
        public UserPowerUpItem new_item;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1);
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<UserPowerUpItem>(new_item));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            byte[] bData = (byte[])data[1];
            new_item = ProtoBufSerializerHelper.Handler().Deserialize<UserPowerUpItem>(bData);
        }
    }
}

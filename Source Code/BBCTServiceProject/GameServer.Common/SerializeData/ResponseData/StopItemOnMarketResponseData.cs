using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class StopItemOnMarketResponseData : ISerializeData
    {
        public UserEquip equip;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<UserEquip>(equip));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            equip = ProtoBufSerializerHelper.Handler().Deserialize<UserEquip>(data[1] as byte[]);
        }
    }
}

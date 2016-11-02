using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class BuyItemOnMarketResponseData : ISerializeData
    {
        public UserEquip equip;
        public int userRuby;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<UserEquip>(equip));
            data.Add(2, userRuby);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            equip = ProtoBufSerializerHelper.Handler().Deserialize<UserEquip>(data[1] as byte[]);
            userRuby = int.Parse(data[2].ToString());
        }
    }
}

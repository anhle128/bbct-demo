using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class JoinCharSoulResponseData : ISerializeData
    {
        public UserCharSoul char_soul;
        public UserCharacter new_char;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<UserCharSoul>(char_soul));
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize<UserCharacter>(new_char));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            char_soul = ProtoBufSerializerHelper.Handler().Deserialize<UserCharSoul>(data[1] as byte[]);
            new_char = ProtoBufSerializerHelper.Handler().Deserialize<UserCharacter>(data[2] as byte[]);
        }
    }
}

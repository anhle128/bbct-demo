using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class PowerupCharRequestData : ISerializeData
    {
        public string char_powerup;
        public List<string> char_stocks;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(2)
            {
                {1, char_powerup },
                {2, ProtoBufSerializerHelper.Handler().Serialize(char_stocks) }
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            char_powerup = data[1].ToString();
            char_stocks = ProtoBufSerializerHelper.Handler().Deserialize<List<string>>(data[2] as byte[]);
        }
    }
}

using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class UseGiftCodeRequestData : ISerializeData
    {
        public string gift_code;
        public void Deserialize(Dictionary<byte, object> data)
        {
            gift_code = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, gift_code}
            };
            return data;
        }
    }
}

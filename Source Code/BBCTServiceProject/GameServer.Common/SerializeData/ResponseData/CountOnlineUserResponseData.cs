using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class CountOnlineUserResponseData : ISerializeData
    {
        public int number;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1, number}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            number = (int)data[1];
        }
    }
}

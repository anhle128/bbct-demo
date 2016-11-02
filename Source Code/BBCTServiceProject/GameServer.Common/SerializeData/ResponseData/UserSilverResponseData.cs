using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class UserSilverResponseData : ISerializeData
    {
        public int user_silver;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1,user_silver}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            user_silver = (int)data[1];
        }
    }
}

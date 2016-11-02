
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class GetRewardVongQuayMayManRequestData : ISerializeData
    {
        public int times;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1, times}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            times = (int)data[1];
        }
    }
}

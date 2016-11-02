
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class JoinPowerUpItemRequestData : ISerializeData
    {
        public int item_id;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(2)
            {
                {1, item_id}
            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            item_id = (int)data[1];
        }
    }
}

using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class MoveToRequestData : ISerializeData
    {
        public float x;
        public float y;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(2)
            {
                {1, x}, {2, y}
            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            x = float.Parse(data[1].ToString());
            y = float.Parse(data[2].ToString());
        }
    }
}

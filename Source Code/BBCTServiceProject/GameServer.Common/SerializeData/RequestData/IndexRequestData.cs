using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class IndexRequestData : ISerializeData
    {
        public int index;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(2, index);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            index = (int)data[2];
        }
    }
}

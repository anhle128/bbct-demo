using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class FindWithKeyWorkRequestData : ISerializeData
    {
        public string keyword;
        public void Deserialize(Dictionary<byte, object> data)
        {
            keyword = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, keyword}
            };
            return data;
        }
    }
}

using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ActionCharRequestData : ISerializeData
    {
        public string char_id;
        public void Deserialize(Dictionary<byte, object> data)
        {
            char_id = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, char_id}
            };
            return data;
        }
    }
}

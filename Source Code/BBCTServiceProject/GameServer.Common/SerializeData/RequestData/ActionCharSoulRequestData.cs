using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ActionCharSoulRequestData : ISerializeData
    {
        public string soul_id;
        public void Deserialize(Dictionary<byte, object> data)
        {
            soul_id = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, soul_id}
            };
            return data;
        }
    }
}

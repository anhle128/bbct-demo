using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class BattleBangChienRequestData : ISerializeData
    {
        public string _id;

        public void Deserialize(Dictionary<byte, object> data)
        {
            if(data.ContainsKey(0))
                _id = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, _id}
            };
            return data;
        }
    }
}

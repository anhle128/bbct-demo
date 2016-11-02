using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ContributeGuildRequestData : ISerializeData
    {
        public int type;

        public void Deserialize(Dictionary<byte, object> data)
        {
            type = int.Parse(data[0].ToString());
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, type}
            };
            return data;
        }
    }
}

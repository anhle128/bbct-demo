using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ActionPlayerRequestData : ISerializeData
    {
        public string userid;
        public void Deserialize(Dictionary<byte, object> data)
        {
            userid = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, userid}
            };
            return data;
        }
    }
}

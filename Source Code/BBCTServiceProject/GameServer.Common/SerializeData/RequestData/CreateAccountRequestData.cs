using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class CreateAccountRequestData : ISerializeData
    {
        public string nickname;
        public int char_id;
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(2)
            {
                {1, nickname},
                {2, char_id}
            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            nickname = data[1].ToString();
            char_id = (int)data[2];
        }
    }
}

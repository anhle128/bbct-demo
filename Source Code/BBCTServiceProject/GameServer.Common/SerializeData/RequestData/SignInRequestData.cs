using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class SignInRequestData : ISerializeData
    {
        public string token;
        public string username;


        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(2)
            {
                {1, token},
                {2,username}

            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            token = data[1].ToString();
            if (data[2] != null)
                username = data[2].ToString();
        }
    }
}

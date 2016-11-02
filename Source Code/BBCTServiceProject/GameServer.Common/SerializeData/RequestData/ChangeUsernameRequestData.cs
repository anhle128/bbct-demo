
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ChangeUsernameRequestData : ISerializeData
    {

        public string username;
        public string userId;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(2)
            {
                {0, username},
                {1,userId}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            username = data[0].ToString();
            userId = data[1].ToString();
        }
    }
}

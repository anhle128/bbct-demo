using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.RequestData
{
    public class JoinGuildRequestData : ISerializeData
    {
        public string guild_id;

        public void Deserialize(Dictionary<byte, object> data)
        {
            guild_id = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, guild_id}
            };
            return data;
        }
    }
}

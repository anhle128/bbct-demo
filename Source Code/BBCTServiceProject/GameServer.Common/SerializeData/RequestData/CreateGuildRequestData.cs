using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.RequestData
{
    public class CreateGuildRequestData : ISerializeData
    {
        public string nameGuild;

        public void Deserialize(Dictionary<byte, object> data)
        {
            nameGuild = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, nameGuild}
            };
            return data;
        }
    }
}

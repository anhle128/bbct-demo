﻿using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ItemOnMarketRequestData : ISerializeData
    {
        public string id;

        public void Deserialize(Dictionary<byte, object> data)
        {
            id = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, id},
            };
            return data;
        }
    }
}

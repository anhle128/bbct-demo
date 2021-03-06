﻿using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class PaymentResponseData : ISerializeData
    {
        public string id;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1,id}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            id = data[1].ToString();
        }
    }
}

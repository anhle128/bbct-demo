using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.EventData
{
    public class NotifyMessageEventData : ISerializeData
    {
        public string message { get; set; }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(3)
            {
                {1, message},
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            message = data[1].ToString();
        }
    }
}

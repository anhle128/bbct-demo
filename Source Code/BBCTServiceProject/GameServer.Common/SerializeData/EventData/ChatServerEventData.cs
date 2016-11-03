using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.EventData
{
    public class ChatServerEventData : ISerializeData
    {
        public string message { get; set; }
        public string userid { get; set; }
        public string nickname { get; set; }
        public int avatar { get; set; }
        public int vip { get; set; }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(3)
            {
                {1, message},
                {2, userid},
                {3, nickname},
                {4, avatar},
                {5, vip}
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            message = data[1].ToString();
            userid = data[2].ToString();
            nickname = data[3].ToString();
            avatar = Convert.ToInt32(data[4].ToString());
            vip = Convert.ToInt32(data[5].ToString());
        }
    }
}

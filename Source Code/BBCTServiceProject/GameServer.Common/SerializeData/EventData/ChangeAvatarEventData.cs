using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.EventData
{
    public class ChangeAvatarEventData : ISerializeData
    {
        public string username { get; set; }
        public int avatar { get; set; }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(3)
            {
                {1, username},
                {2, avatar},
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            username = data[1].ToString();
            avatar = Convert.ToInt32(data[2].ToString());
        }
    }
}

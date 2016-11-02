using GameServer.Common.Core;
using System.Collections.Generic;
using DynamicDBModel.Models;
using GameServer.Common.SerializeData.EventData;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class EnterWorldResponseData : ISerializeData
    {
        public float x;
        public float y;
        public List<ChatData> chatData;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(3);
            data.Add(1, x);
            data.Add(2, y);
            data.Add(3, ProtoBufSerializerHelper.Handler().Serialize(chatData));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            x = float.Parse(data[1].ToString());
            y = float.Parse(data[2].ToString());
            chatData = ProtoBufSerializerHelper.Handler().Deserialize<List<ChatData>>(data[3] as byte[]);
            if(chatData == null)
                chatData = new List<ChatData>();
        }
    }
}

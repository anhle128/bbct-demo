using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.EventData
{
    public class ItemMoveEventData : ISerializeData
    {
        public string itemId;
        public byte itemType;
        public float posX;
        public float posY;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, itemId);
            data.Add(2, itemType);
            data.Add(3, posX);
            data.Add(4, posY);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            itemId = data[1].ToString();
            itemType = (byte)data[2];
            posX = float.Parse(data[3].ToString());
            posY = float.Parse(data[4].ToString());
        }
    }
}

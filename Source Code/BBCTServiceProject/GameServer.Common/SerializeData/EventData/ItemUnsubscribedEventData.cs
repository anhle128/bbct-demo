using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.EventData
{
    public class ItemUnsubscribedEventData : ISerializeData
    {
        public string itemId;
        public byte itemType;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, itemId);
            data.Add(2, itemType);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            itemId = data[1].ToString();
            itemType = (byte)data[2];
        }
    }
}

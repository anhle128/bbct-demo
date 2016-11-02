using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class UsedItemWithCharRequestData : ISerializeData
    {
        public int item_id;
        public string char_id;
        public int quantity;

        public void Deserialize(Dictionary<byte, object> data)
        {
            item_id = int.Parse(data[0].ToString());
            char_id = data[1].ToString();
            quantity = (int)data[2];
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(3)
            {
                {0, item_id}, 
                {1, char_id},
                {2,quantity == 0 ? 1 : quantity}
            };
            return data;
        }
    }
}

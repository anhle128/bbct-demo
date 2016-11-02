using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class UsedItemRequestData : ISerializeData
    {
        public string item_id;
        public int quantity = 1;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(2)
           {
               {1, item_id},
               {2, quantity},
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            item_id = data[1].ToString();
            if (data.ContainsKey(2))
                quantity = (int)data[2];
        }
    }
}

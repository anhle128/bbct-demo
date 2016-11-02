using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class BuyItemInShopRequestData : ISerializeData
    {
        public string id;
        public int quantity;
        public void Deserialize(Dictionary<byte, object> data)
        {
            id = data[0].ToString();
            quantity = (int)data[1];
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(2)
            {
                {0, id},
                {1,quantity }
            };
            return data;
        }
    }
}

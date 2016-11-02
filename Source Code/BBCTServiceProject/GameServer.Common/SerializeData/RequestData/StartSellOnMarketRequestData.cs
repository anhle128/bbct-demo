using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class StartSellOnMarketRequestData : ISerializeData
    {
        public string equip_id;
        public int price;
        public string keywordSearch;

        public void Deserialize(Dictionary<byte, object> data)
        {
            equip_id = data[0].ToString();
            price = int.Parse(data[1].ToString());
            keywordSearch = data[2].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, equip_id},
                {1, price},
                {2, keywordSearch},
            };
            return data;
        }
    }
}

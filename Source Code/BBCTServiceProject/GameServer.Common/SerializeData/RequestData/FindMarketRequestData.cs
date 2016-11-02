using GameServer.Common.Core;
using StaticDB.Enum;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class FindMarketRequestData : ISerializeData
    {
        public string keyword;
        public int minPrice;
        public int maxPrice;
        public CategoryEquipment category;

        public void Deserialize(Dictionary<byte, object> data)
        {
            keyword = data[0].ToString();
            minPrice = int.Parse(data[1].ToString());
            maxPrice = int.Parse(data[2].ToString());
            category = (CategoryEquipment)data[3];
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, keyword},
                {1, minPrice},
                {2, maxPrice},
                {3, category}
            };
            return data;
        }
    }
}

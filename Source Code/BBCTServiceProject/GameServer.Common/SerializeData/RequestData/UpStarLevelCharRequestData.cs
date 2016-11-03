using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class UpStarLevelCharRequestData : ISerializeData
    {
        public string char_id { get; set; }
        public string char_stock_id { get; set; }
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(2)
           {
               {1,char_id },
               {2, char_stock_id }
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            char_id = data[1].ToString();
            char_stock_id = data[2].ToString();
        }
    }
}

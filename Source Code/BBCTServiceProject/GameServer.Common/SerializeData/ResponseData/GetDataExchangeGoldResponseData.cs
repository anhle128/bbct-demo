
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataExchangeGoldResponseData : ISerializeData
    {
        public int total_times_exchange;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
           {
               {1, total_times_exchange}
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            total_times_exchange = (int)data[1];
        }
    }
}

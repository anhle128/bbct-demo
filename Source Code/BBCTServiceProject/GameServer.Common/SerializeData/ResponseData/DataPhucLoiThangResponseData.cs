using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class DataPhucLoiThangResponseData : ISerializeData
    {
        public double gold;
        public int day;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, gold);
            data.Add(2, day);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            gold = (double)data[1];
            day = (int)data[2];
        }
    }
}

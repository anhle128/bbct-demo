using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataDoPhuongResponseData : ISerializeData
    {
        public int countTimesPlay;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, countTimesPlay);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            countTimesPlay = int.Parse(data[1].ToString());
        }
    }
}

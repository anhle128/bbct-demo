using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataLuaTraiResponseData : ISerializeData
    {
        public int state;
        public double time;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, state);
            data.Add(2, time);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            state = int.Parse(data[1].ToString());
            time = double.Parse(data[2].ToString());
        }
    }
}

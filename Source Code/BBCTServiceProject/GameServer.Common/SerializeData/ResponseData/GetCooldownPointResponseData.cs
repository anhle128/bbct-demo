using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetCooldownPointResponseData : ISerializeData
    {
        public int point;
        public double cooldown_time;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(3);
            data.Add(1, point);
            data.Add(2, cooldown_time);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            point = (int)data[1];
            cooldown_time = (double)data[2];
        }
    }
}

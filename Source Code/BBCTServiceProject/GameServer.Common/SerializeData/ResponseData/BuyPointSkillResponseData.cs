using System;
using System.Collections.Generic;
using System.Text;
using GameServer.Common.Core;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class BuyPointSkillResponseData : ISerializeData
    {
        public int point;
        public int buy_times;
        public int user_gold;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(3);
            data.Add(1, point);
            data.Add(2, buy_times);
            data.Add(3, user_gold);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            point = (int)data[1];
            buy_times = (int)data[2];
            user_gold = (int) data[3];
        }
    }
}

using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class Sk7NgayNhanThuongResponseData : ISerializeData
    {
        public int currentDay;
        public DayReward[] rewards;
        public List<int> day_received;
        public DateTime end_time;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize(rewards));
            data.Add(2, currentDay);
            data.Add(3, ProtoBufSerializerHelper.Handler().Serialize(day_received));
            data.Add(4, ProtoBufSerializerHelper.Handler().Serialize(end_time));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<DayReward[]>(data[1] as byte[]);
            currentDay = (int)data[2];
            day_received = ProtoBufSerializerHelper.Handler().Deserialize<List<int>>(data[3] as byte[]);

            if (day_received == null)
                day_received = new List<int>();

            end_time = ProtoBufSerializerHelper.Handler().Deserialize<DateTime>(data[4] as byte[]);
        }
    }
}

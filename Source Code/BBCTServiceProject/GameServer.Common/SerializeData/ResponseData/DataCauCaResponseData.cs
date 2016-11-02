using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class DataCauCaResponseData : ISerializeData
    {
        public int countTimes;
        public bool isDoing;
        public int indexCanCau;
        public int time;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, countTimes);
            data.Add(2, isDoing);
            data.Add(3, indexCanCau);
            data.Add(4, time);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            countTimes = int.Parse(data[1].ToString());
            isDoing = bool.Parse(data[2].ToString());
            indexCanCau = int.Parse(data[3].ToString());
            time = int.Parse(data[4].ToString());
        }
    }
}

using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataBangChienResponseData : ISerializeData
    {
        public int state;
        public BangChien bangChien;
        public double timeEnd;
        public int stateBattle;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, state);
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize<BangChien>(bangChien));
            data.Add(3, timeEnd);
            data.Add(4, stateBattle);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            state = int.Parse(data[1].ToString());
            bangChien = ProtoBufSerializerHelper.Handler().Deserialize<BangChien>(data[2] as byte[]);
            timeEnd = double.Parse(data[3].ToString());
            stateBattle = int.Parse(data[4].ToString());
        }
    }
}

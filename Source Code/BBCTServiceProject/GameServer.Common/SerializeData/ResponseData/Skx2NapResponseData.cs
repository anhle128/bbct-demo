using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class Skx2NapResponseData : ISerializeData
    {
        public DateTime end_time;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>()
           {
               {1, ProtoBufSerializerHelper.Handler().Serialize(end_time)}
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            end_time = ProtoBufSerializerHelper.Handler().Deserialize<DateTime>(data[1] as byte[]);
        }
    }
}

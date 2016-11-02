using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class DataChieuMoResponseData : ISerializeData
    {
        public ChieuMo data;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<ChieuMo>(this.data));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            this.data = ProtoBufSerializerHelper.Handler().Deserialize<ChieuMo>(data[1] as byte[]);
        }
    }
}

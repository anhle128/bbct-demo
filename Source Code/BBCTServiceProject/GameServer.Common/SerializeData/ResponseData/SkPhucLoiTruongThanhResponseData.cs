using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SkPhucLoiTruongThanhResponseData : ISerializeData
    {
        public List<int> index_received;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(3, ProtoBufSerializerHelper.Handler().Serialize(index_received));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            index_received = ProtoBufSerializerHelper.Handler().Deserialize<List<int>>(data[3] as byte[]);

            if (index_received == null)
                index_received = new List<int>();

        }
    }
}

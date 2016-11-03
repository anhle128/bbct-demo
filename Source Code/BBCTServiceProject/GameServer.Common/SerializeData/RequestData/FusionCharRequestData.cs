using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class FusionCharRequestData : ISerializeData
    {
        public List<string> chars;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
           {
               {1, ProtoBufSerializerHelper.Handler().Serialize(chars) }
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            chars = ProtoBufSerializerHelper.Handler().Deserialize<List<string>>(data[1] as byte[]);
        }
    }
}

using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ExchangeRubyRequestData : ISerializeData
    {
        public int ruby;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1, ruby}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            ruby = (int)data[1];
        }
    }
}

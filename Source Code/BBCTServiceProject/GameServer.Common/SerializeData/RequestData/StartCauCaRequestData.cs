using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class StartCauCaRequestData : ISerializeData
    {
        public int indexCanCau;
        public void Deserialize(Dictionary<byte, object> data)
        {
            indexCanCau = int.Parse(data[1].ToString());
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {1, indexCanCau}
            };
            return data;
        }
    }
}

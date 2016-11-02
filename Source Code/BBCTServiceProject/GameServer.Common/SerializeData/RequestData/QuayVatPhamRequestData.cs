
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class QuayVatPhamRequestData : ISerializeData
    {
        public int times;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(2)
            {
                {2, times}
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            times = (int)data[2];
        }
    }
}

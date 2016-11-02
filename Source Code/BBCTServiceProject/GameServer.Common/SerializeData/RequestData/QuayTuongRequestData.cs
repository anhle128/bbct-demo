using GameServer.Common.Core;
using GameServer.Common.Enum;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class QuayTuongRequestData : ISerializeData
    {
        public QuayTuongType type;
        public int times;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(2)
            {
                {1, type}, 
                {2, times}
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            type = (QuayTuongType)data[1];
            times = (int)data[2];
        }
    }
}

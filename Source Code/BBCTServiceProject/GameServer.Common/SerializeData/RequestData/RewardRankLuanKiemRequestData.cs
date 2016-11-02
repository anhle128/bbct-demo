using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class RewardRankLuanKiemRequestData : ISerializeData
    {
        public int index;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1,index}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            index = (int)data[1];
        }
    }
}

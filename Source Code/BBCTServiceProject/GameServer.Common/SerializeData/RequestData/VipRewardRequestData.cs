using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class VipRewardRequestData : ISerializeData
    {
        public int vip;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(3)
            {
                {1, vip}
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            vip = (int)data[1];
        }
    }
}

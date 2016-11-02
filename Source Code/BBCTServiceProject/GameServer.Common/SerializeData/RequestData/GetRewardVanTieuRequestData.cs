using GameServer.Common.Core;
using GameServer.Common.Enum;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class GetRewardVanTieuRequestData : ISerializeData
    {
        public GetRewardVanTieuType type;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1, type}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            type = (GetRewardVanTieuType)data[1];
        }
    }
}

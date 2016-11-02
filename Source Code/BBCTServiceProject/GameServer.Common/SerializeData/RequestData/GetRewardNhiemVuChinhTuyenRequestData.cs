using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class GetRewardNhiemVuChinhTuyenRequestData : ISerializeData
    {
        public int id;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1,id}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            id = (int)data[1];
        }
    }
}

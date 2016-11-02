using GameServer.Common.Core;
using StaticDB.Enum;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class GetRewardNhiemVuHangNgayRequestData : ISerializeData
    {

        public TypeNhiemVuHangNgay type;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1,type }
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            type = (TypeNhiemVuHangNgay)data[1];
        }
    }
}

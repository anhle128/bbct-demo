using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class HoatDongDiemDanhThangResponseData : ISerializeData
    {
        public int month;
        public int currentIndex;
        public List<int> indexDayRewards;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(3)
           {
               {1,month},
               {2,ProtoBufSerializerHelper.Handler().Serialize(indexDayRewards)},
               {3,currentIndex}
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            month = (int)data[1];
            indexDayRewards = ProtoBufSerializerHelper.Handler().Deserialize<List<int>>(data[2] as byte[]);
            if (indexDayRewards == null)
                indexDayRewards = new List<int>();
            currentIndex = (int)data[3];
        }
    }
}

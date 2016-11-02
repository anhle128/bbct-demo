using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class DataCuopTieuResponseData : ISerializeData
    {
        public int count_times_cuop_tieu;
        public List<UserVanTieu> user_van_tieus;
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
           {
               {1,ProtoBufSerializerHelper.Handler().Serialize<List<UserVanTieu>>(user_van_tieus)},
                {2, count_times_cuop_tieu }
           };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            user_van_tieus = ProtoBufSerializerHelper.Handler().Deserialize<List<UserVanTieu>>(data[1] as byte[]);
            count_times_cuop_tieu = (int)data[2];

            if (user_van_tieus == null)
                user_van_tieus = new List<UserVanTieu>();
        }
    }
}

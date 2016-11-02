using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class BangXepHangResponseData : ISerializeData
    {
        public List<TopUser> top_level;
        public List<TopUser> top_power;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(2)
            {
                {1,ProtoBufSerializerHelper.Handler().Serialize(top_level)},
                {2,ProtoBufSerializerHelper.Handler().Serialize(top_power)},
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            top_level = ProtoBufSerializerHelper.Handler().Deserialize<List<TopUser>>(data[1] as byte[]);
            top_power = ProtoBufSerializerHelper.Handler().Deserialize<List<TopUser>>(data[2] as byte[]);
        }
    }
}

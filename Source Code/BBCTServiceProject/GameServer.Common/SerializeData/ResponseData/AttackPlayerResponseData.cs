
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class AttackPlayerResponseData : ISerializeData
    {
        public SubDataPlayer subData;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1, ProtoBufSerializerHelper.Handler().Serialize(subData)}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            subData = ProtoBufSerializerHelper.Handler().Deserialize<SubDataPlayer>(data[1] as byte[]);
        }
    }
}

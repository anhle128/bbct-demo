using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class TopUserVongQuayMayManResponseData : ISerializeData
    {
        public List<TopUserVongQuayMayMan> top_users;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
           {
               {1, ProtoBufSerializerHelper.Handler().Serialize(top_users)}
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            top_users = ProtoBufSerializerHelper.Handler().Deserialize<List<TopUserVongQuayMayMan>>(data[1] as byte[]);

            if (top_users == null)
                top_users = new List<TopUserVongQuayMayMan>();
        }
    }
}

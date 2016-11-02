using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class TopUserDoiDoResponseData : ISerializeData
    {
        public TopUserDoiDo[] top_users;
        public Dictionary<byte, object> Serialize()
        {
            for (int i = 0; i < top_users.Length; i++)
            {
                if (top_users[i] == null)
                    top_users[i] = new TopUserDoiDo();
            }
            object objectdata = ProtoBufSerializerHelper.Handler().Serialize(top_users);
            return new Dictionary<byte, object>(1)
            {
                {1,objectdata}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            top_users = ProtoBufSerializerHelper.Handler().Deserialize<TopUserDoiDo[]>(data[1] as byte[]);
        }
    }
}

using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class FriendResponseData : ISerializeData
    {
        public List<UserFriend> friends;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize(friends));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            friends = ProtoBufSerializerHelper.Handler().Deserialize<List<UserFriend>>(data[2] as byte[]);
            if(friends == null)
                friends = new List<UserFriend>();
        }
    }
}

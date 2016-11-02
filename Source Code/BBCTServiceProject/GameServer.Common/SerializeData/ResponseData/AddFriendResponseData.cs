using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class AddFriendResponseData : ISerializeData
    {
        public UserFriend new_friend;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<UserFriend>(new_friend));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            new_friend = ProtoBufSerializerHelper.Handler().Deserialize<UserFriend>(data[1] as byte[]);
        }
    }
}

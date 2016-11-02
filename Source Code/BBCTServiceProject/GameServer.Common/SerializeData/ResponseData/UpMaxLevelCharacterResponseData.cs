using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class UpMaxLevelCharacterResponseData : ISerializeData
    {
        public string char_id;
        public int level;
        public int exp;
        public List<UserItem> user_items;

        public void Deserialize(Dictionary<byte, object> data)
        {
            char_id = data[1].ToString();
            level = int.Parse(data[2].ToString());
            exp = int.Parse(data[3].ToString());
            user_items = ProtoBufSerializerHelper.Handler().Deserialize<List<UserItem>>(data[4] as byte[]);
            // check null
            if (user_items == null)
                user_items = new List<UserItem>();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(3);
            data.Add(1, char_id);
            data.Add(2, level);
            data.Add(3, exp);
            data.Add(4, ProtoBufSerializerHelper.Handler().Serialize(user_items));
            return data;
        }
    }
}

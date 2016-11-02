using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class UsedExpItemReponseData : ISerializeData
    {
        public string char_id;
        public int level;
        public int exp;

        public void Deserialize(Dictionary<byte, object> data)
        {
            char_id = data[1].ToString();
            level = int.Parse(data[2].ToString());
            exp = int.Parse(data[3].ToString());
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(3);
            data.Add(1, char_id);
            data.Add(2, level);
            data.Add(3, exp);
            return data;
        }
    }
}


using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ActionRuongBauRequestData : ISerializeData
    {
        public string id;
        public int index_reward;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1, id},
                {2, index_reward}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            id = data[1].ToString();
            index_reward = (int)data[2];
        }
    }
}

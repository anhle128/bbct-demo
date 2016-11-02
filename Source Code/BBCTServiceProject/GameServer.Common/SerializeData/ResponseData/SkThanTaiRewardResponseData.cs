using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class SkThanTaiRewardResponseData : ISerializeData
    {
        public int gold_reward;
        public int user_gold;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(2)
            {
                {1, gold_reward},
                {2, user_gold}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            gold_reward = (int)data[1];
            user_gold = (int)data[2];
        }
    }
}

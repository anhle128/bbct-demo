using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class GetRewardStarMapRequestData : ISerializeData
    {

        public int index_map;
        public int index_reward;
        public int level;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>()
            {
               {1,index_map},
               {2,index_reward},
               {3,level},
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            index_map = (int)data[1];
            index_reward = (int)data[2];
            level = (int)data[3];
        }
    }
}

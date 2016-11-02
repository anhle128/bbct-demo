using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class CanQuetRequestData : ISerializeData
    {
        public int map_index;
        public int stage_index;
        public int level;
        public int attack_times;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>()
            {
                {1, map_index},
                {2, stage_index},
                {3, level},
                {4, attack_times},
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            map_index = int.Parse(data[1].ToString());
            stage_index = int.Parse(data[2].ToString());
            level = int.Parse(data[3].ToString());
            if (data.ContainsKey(4))
            {
                attack_times = int.Parse(data[4].ToString());
            }
            else
            {
                attack_times = 1;
            }
        }
    }
}

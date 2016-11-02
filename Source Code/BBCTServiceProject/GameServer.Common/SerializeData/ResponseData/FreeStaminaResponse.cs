using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class FreeStaminaResponse : ISerializeData
    {
        /// <summary>
        /// //
        /// </summary>
        public int stamina_reward;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1);
            data.Add(1, stamina_reward);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            stamina_reward = int.Parse(data[1].ToString());
        }
    }
}

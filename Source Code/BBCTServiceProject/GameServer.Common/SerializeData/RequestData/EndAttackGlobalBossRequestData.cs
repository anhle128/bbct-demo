using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class EndAttackGlobalBossRequestData : ISerializeData
    {
        public double damage;
        public void Deserialize(Dictionary<byte, object> data)
        {
            damage = (double)data[0];
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, damage}
            };
            return data;
        }
    }
}

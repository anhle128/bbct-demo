using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class StartAttackGlobalBossRequestData : ISerializeData
    {
        public int typeAttackGlobalBoss;
        public void Deserialize(Dictionary<byte, object> data)
        {
            typeAttackGlobalBoss = (int)data[0];
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, typeAttackGlobalBoss}
            };
            return data;
        }
    }
}

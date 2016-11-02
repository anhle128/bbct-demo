using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class EndAttackBossGuildRequestData : ISerializeData
    {
        public double dmg;
        public void Deserialize(Dictionary<byte, object> data)
        {
            dmg = double.Parse(data[0].ToString());
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, dmg}
            };
            return data;
        }
    }
}

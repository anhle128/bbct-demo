using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class EndAttackStageRequestData : ISerializeData
    {
        public int star;
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(2)
            {
                {1, star},
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            star = (int)data[1];
        }
    }
}

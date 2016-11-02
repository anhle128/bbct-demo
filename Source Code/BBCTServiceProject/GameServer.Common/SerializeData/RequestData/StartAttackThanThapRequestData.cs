using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class StartAttackThanThapRequestData : ISerializeData
    {
        public int index_difficult;


        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(2)
            {
                {1, index_difficult}, 
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            index_difficult = (int)data[1];
        }
    }
}

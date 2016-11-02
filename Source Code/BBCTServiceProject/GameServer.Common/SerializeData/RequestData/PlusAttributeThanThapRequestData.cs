using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class PlusAttributeThanThapRequestData : ISerializeData
    {
        public int index_bonus_attribute_selection;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(2)
            {
                {2, index_bonus_attribute_selection},
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            index_bonus_attribute_selection = (int)data[2];
        }
    }
}

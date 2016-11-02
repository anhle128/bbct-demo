using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ActionEquipRequestData : ISerializeData
    {
        public string char_id;
        public string equip_item_id;
        public int index;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(3)
            {
                {1, char_id}, 
                {2, equip_item_id},
                {3, index}
            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            char_id = data[1].ToString();
            equip_item_id = data[2].ToString();
            index = (int)data[3];
        }
    }
}

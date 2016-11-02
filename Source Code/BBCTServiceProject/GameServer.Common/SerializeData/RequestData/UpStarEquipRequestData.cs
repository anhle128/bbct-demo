
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class UpStarEquipRequestData : ISerializeData
    {
        public string equip_id;
        public List<string> equip_stocks;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(2)
            {
                {1, equip_id},
                {2, ProtoBufSerializerHelper.Handler().Serialize<List<string>>(equip_stocks)}
            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            equip_id = data[1].ToString();
            equip_stocks = ProtoBufSerializerHelper.Handler().Deserialize<List<string>>(data[2] as byte[]);
        }
    }
}


using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.EventData
{
    public class MoiRuouEventData : ISerializeData
    {
        public string nickname;
        public int stamina;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, nickname);
            data.Add(2, stamina);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            nickname = data[1].ToString();
            stamina = (int)data[2];
        }
    }
}

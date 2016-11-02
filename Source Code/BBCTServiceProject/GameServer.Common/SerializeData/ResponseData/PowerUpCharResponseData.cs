using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class PowerUpCharResponseData : ISerializeData
    {

        public bool is_opend_new_skill;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(2, is_opend_new_skill);
            return data;
        }
        
        public void Deserialize(Dictionary<byte, object> data)
        {
            is_opend_new_skill = (bool)data[2];
        }
    }
}

using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class GetRewardMailRequestData : ISerializeData
    {
        public string mail_id;
        public void Deserialize(Dictionary<byte, object> data)
        {
            mail_id = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, mail_id}
            };
            return data;
        }
    }
}

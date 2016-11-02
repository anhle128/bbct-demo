using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class EditGuildNoticeRequestData : ISerializeData
    {
        public string notice;

        public void Deserialize(Dictionary<byte, object> data)
        {
            notice = data[0].ToString();
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, notice}
            };
            return data;
        }
    }
}

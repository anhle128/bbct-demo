using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class GoToBattleBangChienRequestData : ISerializeData
    {
        public string _id;
        public int lane;

        public void Deserialize(Dictionary<byte, object> data)
        {
            _id = data[0].ToString();
            lane = int.Parse(data[1].ToString());
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, _id},
                {1, lane},
            };
            return data;
        }
    }
}

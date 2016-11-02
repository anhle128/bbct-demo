using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class MissionGuildRequestData : ISerializeData
    {
        public int indexMission;
        public void Deserialize(Dictionary<byte, object> data)
        {
            indexMission = int.Parse(data[0].ToString());
        }

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1)
            {
                {0, indexMission}
            };
            return data;
        }
    }
}

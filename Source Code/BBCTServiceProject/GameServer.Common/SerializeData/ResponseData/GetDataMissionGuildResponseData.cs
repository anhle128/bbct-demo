using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataMissionGuildResponseData : ISerializeData
    {
        public int[] missions;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, missions);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            missions = (int[])data[1];
        }
    }
}

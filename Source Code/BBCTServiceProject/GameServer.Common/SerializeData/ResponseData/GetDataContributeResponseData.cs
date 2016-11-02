using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataContributeResponseData : ISerializeData
    {
        public bool isCan;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(0, isCan);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            isCan = bool.Parse(data[0].ToString());
        }
    }
}

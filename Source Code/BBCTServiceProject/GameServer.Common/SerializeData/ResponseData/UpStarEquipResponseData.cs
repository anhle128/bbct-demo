using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class UpStarEquipResponseData : ISerializeData
    {
        public bool success;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(1)
           {
               {1,success}
           };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            success = (bool)data[1];
        }
    }
}

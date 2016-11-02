using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class JoinPieceRequestData : ISerializeData
    {
        public string _id;
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(1)
            {
                {1, _id}
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            _id = data[1].ToString();
        }
    }
}

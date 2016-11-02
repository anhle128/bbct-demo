using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class TutorialRequestData : ISerializeData
    {
        public int tutorial;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
           {
               {1,tutorial}
           };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            tutorial = (int)data[1];
        }
    }
}

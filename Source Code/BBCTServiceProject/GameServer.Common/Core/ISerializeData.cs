using System.Collections.Generic;

namespace GameServer.Common.Core
{
    public interface ISerializeData
    {
        Dictionary<byte, object> Serialize();
        void Deserialize(Dictionary<byte, object> data);
    }
}

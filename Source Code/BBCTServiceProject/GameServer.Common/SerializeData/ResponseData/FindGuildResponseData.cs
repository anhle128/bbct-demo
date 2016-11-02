using GameServer.Common.Core;
using StaticDB.Enum;
using System.Collections.Generic;
using DynamicDBModel.Models;
using StaticDB.Models;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class FindGuildResponseData : ISerializeData
    {
        public List<Guild> guilds;
         
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(1)
            {
                {0,ProtoBufSerializerHelper.Handler().Serialize<List<Guild>>(guilds)} 
        };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            guilds = ProtoBufSerializerHelper.Handler().Deserialize<List<Guild>>(data[0] as byte[]);
        }
    }
}

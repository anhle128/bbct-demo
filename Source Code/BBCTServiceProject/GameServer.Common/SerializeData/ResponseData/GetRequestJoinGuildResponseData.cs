using GameServer.Common.Core;
using StaticDB.Enum;
using System.Collections.Generic;
using DynamicDBModel.Models;
using StaticDB.Models;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetRequestJoinGuildResponseData : ISerializeData
    {
        public List<RequestJoinGuild> requests;
         
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(1)
            {
                {0,ProtoBufSerializerHelper.Handler().Serialize<List<RequestJoinGuild>>(requests)} 
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            requests = ProtoBufSerializerHelper.Handler().Deserialize<List<RequestJoinGuild>>(data[0] as byte[]);
        }
    }
}

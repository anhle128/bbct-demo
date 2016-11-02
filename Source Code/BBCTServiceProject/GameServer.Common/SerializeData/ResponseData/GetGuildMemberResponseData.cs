using GameServer.Common.Core;
using StaticDB.Enum;
using System.Collections.Generic;
using DynamicDBModel.Models;
using StaticDB.Models;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetGuildMemberResponseData : ISerializeData
    {
        public List<GuildMember> members;
         
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(1)
            {
                {0,ProtoBufSerializerHelper.Handler().Serialize<List<GuildMember>>(members)} 
        };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            members = ProtoBufSerializerHelper.Handler().Deserialize<List<GuildMember>>(data[0] as byte[]);
        }
    }
}

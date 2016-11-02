using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class MailResponseData : ISerializeData
    {
        public List<UserMail> user_mails;
        public List<SystemMail> system_mails;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dictdata = new Dictionary<byte, object>(2)
            {
                {0,ProtoBufSerializerHelper.Handler().Serialize<List<UserMail>>(user_mails)},
                {1,ProtoBufSerializerHelper.Handler().Serialize<List<SystemMail>>(system_mails)}
            };
            return dictdata;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            user_mails = ProtoBufSerializerHelper.Handler().Deserialize<List<UserMail>>(data[0] as byte[]);
            system_mails = ProtoBufSerializerHelper.Handler().Deserialize<List<SystemMail>>(data[1] as byte[]);
        }
    }
}

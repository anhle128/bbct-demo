using System;
using System.Collections.Generic;
using System.Text;
using DynamicDBModel.Models;
using GameServer.Common.Core;

namespace GameServer.Common.SerializeData.RequestData
{
    public class SendGMMailRequestData :ISerializeData
    {
        public SystemMail mail;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1,ProtoBufSerializerHelper.Handler().Serialize(mail) }
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            mail = ProtoBufSerializerHelper.Handler().Deserialize<SystemMail>(data[1] as byte[]);
        }
    }
}

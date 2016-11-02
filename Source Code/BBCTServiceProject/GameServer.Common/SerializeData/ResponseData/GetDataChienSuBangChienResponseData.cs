using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataChienSuBangChienResponseData : ISerializeData
    {
        public BattleBangChien battle;
        public Guild guildA;
        public Guild guildB;
        public double timeEnd;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<BattleBangChien>(battle));
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize<Guild>(guildA));
            data.Add(3, ProtoBufSerializerHelper.Handler().Serialize<Guild>(guildB));
            data.Add(4, timeEnd);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            battle = ProtoBufSerializerHelper.Handler().Deserialize<BattleBangChien>(data[1] as byte[]);
            guildA = ProtoBufSerializerHelper.Handler().Deserialize<Guild>(data[2] as byte[]);
            guildB = ProtoBufSerializerHelper.Handler().Deserialize<Guild>(data[3] as byte[]);
            timeEnd = double.Parse(data[4].ToString());
        }
    }
}

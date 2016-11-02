using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataRankBossGuildResponseData : ISerializeData
    {
        public List<TopUserPrivateBoss> ranks;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<List<TopUserPrivateBoss>>(ranks));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            ranks = ProtoBufSerializerHelper.Handler().Deserialize<List<TopUserPrivateBoss>>(data[1] as byte[]);
        }
    }
}

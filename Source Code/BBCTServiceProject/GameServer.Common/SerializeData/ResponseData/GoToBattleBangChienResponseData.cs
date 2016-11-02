using DynamicDBModel.Models;
using DynamicDBModel.Models.Battle;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GoToBattleBangChienResponseData : ISerializeData
    {
        public BattleReplay replay;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<BattleReplay>(replay));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            replay = ProtoBufSerializerHelper.Handler().Deserialize<BattleReplay>(data[1] as byte[]);
        }
    }
}

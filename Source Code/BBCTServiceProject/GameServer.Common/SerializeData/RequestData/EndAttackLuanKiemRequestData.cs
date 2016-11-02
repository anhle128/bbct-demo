using DynamicDBModel.Models.Battle;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class EndAttackLuanKiemRequestData : ISerializeData
    {
        public BattleReplay battleReplay;
        public bool win;
        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>()
            {
                {1,ProtoBufSerializerHelper.Handler().Serialize(battleReplay)},
                {2,win}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            throw new NotImplementedException();
        }
    }
}

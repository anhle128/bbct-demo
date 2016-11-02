using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;
using DynamicDBModel.Models.Battle;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class EndAttackThanThapResponseData : ISerializeData
    {
        public List<RewardItem> rewards;
        public int[] bonus_attributes_selection;
        public int[] monsters;
        public BattleReplay replay;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize(rewards));
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize(bonus_attributes_selection));
            data.Add(3, ProtoBufSerializerHelper.Handler().Serialize(monsters));
            data.Add(4, ProtoBufSerializerHelper.Handler().Serialize(replay));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[1] as byte[]);
            bonus_attributes_selection = ProtoBufSerializerHelper.Handler().Deserialize<int[]>(data[2] as byte[]);
            monsters = ProtoBufSerializerHelper.Handler().Deserialize<int[]>(data[3] as byte[]);
            if (rewards == null)
                rewards = new List<RewardItem>();

            replay = ProtoBufSerializerHelper.Handler().Deserialize<BattleReplay>(data[4] as byte[]);
        }
    }
}

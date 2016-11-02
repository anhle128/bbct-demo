using DynamicDBModel.Models;
using DynamicDBModel.Models.Battle;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class AttackLuanKiemResponseData : ISerializeData
    {
        public BattleReplay battleReplay;
        public List<RewardItem> rewards;

        private byte[] _arrByte;
        

        public AttackLuanKiemResponseData(byte[] arrByte,List<RewardItem> rewards)
        {
            this._arrByte = arrByte;
            this.rewards = rewards;
        }

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1,_arrByte},
                {2, ProtoBufSerializerHelper.Handler().Serialize(rewards)}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            battleReplay = ProtoBufSerializerHelper.Handler().Deserialize<BattleReplay>(data[1] as byte[]);
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<RewardItem>>(data[2] as byte[]);
            if(rewards == null)
                rewards = new List<RewardItem>();
        }
    }
}

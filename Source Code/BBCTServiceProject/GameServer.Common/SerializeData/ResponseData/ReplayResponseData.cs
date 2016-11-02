using DynamicDBModel.Models.Battle;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class ReplayResponseData : ISerializeData
    {
        public BattleReplay battleReplay;

        private byte[] _arrByte;
        public ReplayResponseData(byte[] arrByte)
        {
            this._arrByte = arrByte;
        }

        public ReplayResponseData()
        {
        }

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>(1)
            {
                {1,_arrByte}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            battleReplay = ProtoBufSerializerHelper.Handler().Deserialize<BattleReplay>(data[1] as byte[]);
        }
    }
}

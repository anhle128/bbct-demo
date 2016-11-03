using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ActionStageRequestData : ISerializeData
    {
        public StageMode stage_info;
        public int formation;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(3)
            {
                {1, ProtoBufSerializerHelper.Handler().Serialize<StageMode>(stage_info)},
                {2, formation }
            };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            stage_info = ProtoBufSerializerHelper.Handler().Deserialize<StageMode>(data[1] as byte[]);
            formation = (int)data[2];
        }
    }
}

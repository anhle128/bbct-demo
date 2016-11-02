
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class ThachDauResponseData : ISerializeData
    {
        public StringArray[] formation { get; set; }
        public List<UserCharacter> chars { get; set; }
        public List<UserEquip> equips { get; set; }
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(5)
            {
                {1,ProtoBufSerializerHelper.Handler().Serialize<List<UserCharacter>>(chars)},
                {2,ProtoBufSerializerHelper.Handler().Serialize<List<UserEquip>>(equips)},
                {3,ProtoBufSerializerHelper.Handler().Serialize<StringArray[]>(formation)},
            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            chars = ProtoBufSerializerHelper.Handler().Deserialize<List<UserCharacter>>(data[1] as byte[]);
            equips = ProtoBufSerializerHelper.Handler().Deserialize<List<UserEquip>>(data[2] as byte[]);
            formation = ProtoBufSerializerHelper.Handler().Deserialize<StringArray[]>(data[3] as byte[]);
        }
    }
}

using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class ViewDetailPlayerResponseData : ISerializeData
    {
        public StringArray[] formation_rows;
        public List<UserCharacter> chars;
        public List<UserEquip> equips;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(5)
            {
                {1,ProtoBufSerializerHelper.Handler().Serialize<List<UserCharacter>>(chars)},
                {2,ProtoBufSerializerHelper.Handler().Serialize<List<UserEquip>>(equips)},
                {4,ProtoBufSerializerHelper.Handler().Serialize<StringArray[]>(formation_rows)},
            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            chars = ProtoBufSerializerHelper.Handler().Deserialize<List<UserCharacter>>(data[1] as byte[]);
            equips = ProtoBufSerializerHelper.Handler().Deserialize<List<UserEquip>>(data[2] as byte[]);
            formation_rows = ProtoBufSerializerHelper.Handler().Deserialize<StringArray[]>(data[4] as byte[]);
        }
    }
}

using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class ViewDetailPlayerResponseData : ISerializeData
    {
        public DataFormation[] formations;
        public List<UserCharacter> chars;
        public List<UserEquip> equips;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(5)
            {
                {1,ProtoBufSerializerHelper.Handler().Serialize(chars)},
                {2,ProtoBufSerializerHelper.Handler().Serialize(equips)},
                {3,ProtoBufSerializerHelper.Handler().Serialize(formations)},
            };
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            chars = ProtoBufSerializerHelper.Handler().Deserialize<List<UserCharacter>>(data[1] as byte[]);
            equips = ProtoBufSerializerHelper.Handler().Deserialize<List<UserEquip>>(data[2] as byte[]);
            formations = ProtoBufSerializerHelper.Handler().Deserialize<DataFormation[]>(data[3] as byte[]);
        }
    }
}

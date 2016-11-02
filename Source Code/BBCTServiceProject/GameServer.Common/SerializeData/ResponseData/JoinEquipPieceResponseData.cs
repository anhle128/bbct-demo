using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class JoinEquipPieceResponseData : ISerializeData
    {
        public UserEquipPiece equip_piece;
        public UserEquip new_equip;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<UserEquipPiece>(equip_piece));
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize<UserEquip>(new_equip));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            equip_piece = ProtoBufSerializerHelper.Handler().Deserialize<UserEquipPiece>(data[1] as byte[]);
            new_equip = ProtoBufSerializerHelper.Handler().Deserialize<UserEquip>(data[2] as byte[]);
        }
    }
}
